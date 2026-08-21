<div align="right">

[English](./README.md) | 简体中文

</div>

<div align="center">

# CB2 CSharp Binding

一个为游戏《SCP收容失效2》服务端开发的高性能、现代化 C# 插件框架

![License](https://img.shields.io/badge/license-LGPLv2.1-blue.svg)
![Version](https://img.shields.io/badge/version-v0.1.0-brightgreen.svg)
![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-14.0-239120?logo=csharp&logoColor=white)
![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)

</div>

---

## 📖 目录

- [📖 项目简介](#-项目简介)
    - [🌟 核心特性](#-核心特性)
- [🚀 快速开始](#-快速开始)
    - [前置条件](#前置条件)
    - [安装 CCB](#安装-ccb)
    - [插件开发](#插件开发)
        - [1. 入口点与元数据](#1-入口点与元数据)
        - [2. 插件配置](#2-插件配置)
        - [3. 事件注册](#3-事件注册)
        - [4. 遍历对象](#4-遍历对象)
        - [5. 线程安全](#5-线程安全)
        - [6. 脚本函数](#6-脚本函数)
        - [7. 依赖注入](#7-依赖注入)
        - [8. 附录](#8-附录)
- [🔧 技术细节](#-技术细节)

---

## 📖 项目简介

本项目会在服务端中创建 .NET 虚拟机，并生成脚本函数绑定，以支持插件与服务端的交互

插件加载使用依赖注入

### 🌟 核心特性

- ⚡ **高性能**：使用原生 CoreCLR
- 🚀 **多线程/异步**：使用 SynchronizationContext，支持在多线程或异步中调用脚本函数
- 🔥 **热重载**：支持 dotnet watch / JetBrains Rider 等热重载

---

## 🚀 快速开始

### 前置条件

确保你的电脑已安装 .NET SDK 10 x86

### 安装 CCB

1. 从最新 [Release](https://github.com/EasyT-T/ccb/releases) 中下载 `ccb.zip`，解压至 `path/to/server`
2. 修改 server.cfg，加入以下内容（**注意：确保顺序与示例一致**）
```
plugin ccb/plugin.as
script ccb/script.as
```
3. 启动 `server-launcher.exe`，检查 CCB 是否正确安装

插件安装于 `path/to/server/ccb/plugins` 中

依赖安装于 `path/to/server/ccb/dependencies` 中

### 插件开发

#### 1. 入口点与元数据

新建一个 .NET10 项目，引用 `CCB.dll`；对于日志记录，则需要引用 `Microsoft.Extensions.Logging.Abstractions` nuget 包

创建 `PluginMetadata` 类，示例如下
```csharp
// Usings...
public class PluginMetadata : IPluginMetadata
{
    public string Name => "This is your plugin name";

    public string Description => "This is your plugin description";

    public string Author => "Who wrote this plugin";
}
```

随后，创建 `EntryPoint` 类，这将作为你的插件的入口点，示例如下
```csharp
//Usings...
[Injectable]
internal class EntryPoint(ILogger<EntryPoint> logger) : ILoad
{
    public void Load()
    {
        logger.LogInformation("Hello from my plugin!");
    }
}
```
> [!NOTE]
> 任何使用 `[Injectable]` 特性的类都会被依赖注入，插件加载器会遍历注入池中所有继承 ILoad 的类，并调用其 Load 方法。
> 详细说明请看后续示例

`ILoad::Load` 会在插件被加载时调用

除了 `ILoad`，你还可以继承 `IPreload` `IUnload` 等

`IPreload` 会在 **插件配置** 一节中提及

`IUnload::Unload` 目前尚无作用，但在未来加入插件热拔插时，会在插件被卸载时调用

#### 2. 插件配置

CCB 已经提供好了插件配置服务，插件配置同样会以依赖注入的形式注入到插件中；
默认情况下，插件配置位于 `path/to/server/ccb/config`

要加载一个插件配置，我们需要关注其**加载时机**、**无文件时的行为**、**加载后的存储策略**

以下是一个简单示例
```csharp
// Usings...
public record MyPluginConfig(
    string StringContent,
    float FloatContent)
{
    public const string Name = "my_config.json";

    public const ConfigFileType Type = ConfigFileType.Json;

    public static MyPluginConfig Default { get; } = new MyPluginConfig("A default content!", 3.14f);
}
```
我们创建了一个简单的 record 类型作为插件配置的可序列化对象，
其中可序列化的配置内容为 `StringContent` 和 `FloatContent` 不可变属性,

- `Name` 常量表示插件配置的文件名，
- `Type`表示配置的文件类型（目前仅有 Json 类型，使用 `System.Text.Json`）
- `Default` 表示当配置文件不存在时，创建的默认配置

随后，我们需要调用插件配置服务以加载配置，我们可以在入口点中进行调用加载，以下是示例
```csharp
//Usings...
[Injectable]
internal class EntryPoint(
    ILogger<EntryPoint> logger,
    IConfigProvider<MyPluginConfig> configProvider) : ILoad
{
    private readonly MyPluginConfig? _config = null;
    
    public void Load()
    {
        logger.LogInformation("Hello from my plugin!");

        this._config = configProvider.Cache(
            MyPluginConfig.Name,
            MyPluginConfig.Type,
            MyPluginConfig.Default);
            
        logger.LogInformation("String content: {str}", this._config.StringContent);
        logger.LogInformation("Float content: {float}", this._config.FloatContent);
    }
}
```

`IConfigProvider<TConfig>::Cache` 方法会加载指定插件配置，并将反序列化对象存储在变量中;
需要再次获取时，只需要调用 `IConfigProvider<TConfig>::GetConfig` 即可，
但如果配置尚未加载，则会抛出 `InvalidOperationException` 异常

你可以注意到，这里的 `_config` 拥有 `nullable` 注解，因为变量直到 `Load` 被调用时才会被赋值

因此更推荐的加载方式是在 `IPreload` 中提前加载，并在 `ILoad` 中直接获取

以下是改进后的示例代码
```csharp
//Usings...
[Injectable]
public class ConfigPreloader(IConfigProvider<MyPluginConfig> configProvider) : IPreload
{
    public void Preload()
    {
        configProvider.Cache(MyPluginConfig.Name, MyPluginConfig.Type, MyPluginConfig.Default);
    }
}

[Injectable]
internal class EntryPoint(
    ILogger<EntryPoint> logger,
    IConfigProvider<MyPluginConfig> configProvider) : ILoad
{
    private readonly MyPluginConfig _config = configProvider.GetConfig();
    
    public void Load()
    {
        logger.LogInformation("Hello from my plugin!");
            
        logger.LogInformation("String content: {str}", this._config.StringContent);
        logger.LogInformation("Float content: {float}", this._config.FloatContent);
    }
}
```

#### 3. 事件注册

游戏中有大量的事件类型，你可以在 CCB 中订阅事件

以下是示例代码

```csharp
// In ILoad
void Load()
{
    // ...
    EventRegistry.PlayerConnect += this.OnPlayerConnect;
}

// In IUnload
void Unload()
{
    // ...
    EventRegistry.PlayerConnect -= this.OnPlayerConnect;
}

private void OnPlayerConnect(EventRegistry.PlayerConnectEventArg ev)
{
    logger.LogInformation("Player {player} has joined the server.", ev.Player.GetName());
    
    Chat chat = GlobalProperties.Chat;
    
    chat.SendPlayer(ev.Player, "Hi! Welcome to my server!");
}
```

注册此事件后，每当有玩家加入，`OnPlayerConnect` 就会被调用

所有事件参数均存储在 `EventRegistry.{event_name}EventArg` 中

如果该事件有 `bool` 返回值，你可以修改 EventArg 中 `EventResult` 的值，最终 CCB 会将其的值作为返回值传递给服务端

注意：对 `EventResult` 的修改同样会影响其它插件

#### 4. 遍历对象

游戏中的许多对象都是可以全局遍历的，例如 `Player` `Items` 等

要遍历它们，你只需要调用该对象下的 `::List` 静态方法

```csharp
foreach (Player player in Player.List())
```

你也可以使用 `LINQ`

```csharp
IEnumerable<Player> admins = Player.List().Where(p => p.IsAdmin());
```

注意：对象遍历是线程不安全的，详情请见 **线程安全** 一节

#### 5. 线程安全

**任何与服务端的交互都是线程不安全的**

例如：
- 调用 `Player::GetName` 为例的对象方法
- 调用 `Player::List` 并进行遍历
- 调用 `脚本函数`

以上行为都需要在主线程中进行

CCB 注册了 `MainThreadContext` 用来支持多线程

默认异步行为下，主线程下调用 `await` 后会自动回到主线程上

但如果使用了 `Task::Run` `Task::Start` `Thread::Start` ，
若需要进行服务端交互，则需要将行为提交到主线程中

以下是示例

```csharp
Task.Run(OtherThreadActionAsync);

async Task OtherThreadActionAsync()
{
    await MainThreadContext.RunOnMainThreadAsync(() => 
    {
        Chat chat = GlobalProperties.Chat;
        
        chat.Send("Hello everyone!");
    });
    
    string name = await MainThreadContext.RunOnMainThreadAsync(() => 
    {
        Player player = ScriptFunctions.GetPlayer(1);
        
        return player.GetName();
    });
}

new Thread(OtherThreadAction).Start();

void OtherThreadAction()
{
    MainThreadContext.RunOnMainThread(() => 
    {
        Chat chat = GlobalProperties.Chat;
        
        chat.Send("Hello everyone!");
    });
    
    string name = MainThreadContext.RunOnMainThread(() => 
    {
        Player player = ScriptFunctions.GetPlayer(1);
        
        return player.GetName();
    });
}
```

需要注意的是使用 LINQ 遍历对象时的延迟求值问题

❌ 错误示范

```csharp
// Run on another thread
IEnumerable<Player> admins = MainThreadContext.RunOnMainThread(() => 
{
    return Player.List().Where(p => p.IsAdmin());
});

foreach (Player p in admins)
{
    p.SendMessage("Hello admin!", 10.0f);
}
```

✅ 正确示范
```csharp
// Run on another thread
List<Player> admins = MainThreadContext.RunOnMainThread(() => 
{
    return Player.List().Where(p => p.IsAdmin()).ToList();
});

foreach (Player p in admins)
{
    p.SendMessage("Hello admin!", 10.0f);
}
```

由于 LINQ 的延迟求值，错误示范中 `Player` 的全局遍历实质在其它线程而非主线程中完成

#### 6. 脚本函数

所有脚本函数均在 `ScriptFunctions` 类中，你可以直接调用

以 `Player` 为例的对象本质是对 ScriptFunctions 的调用包装

调用脚本函数时需注意线程安全问题

#### 7. 依赖注入

任何标注了 `[Injectable]` 特性的类都会被添加至一个服务集合中

你可以在类的构造函数中引用其它 `[Injectable]` 服务

CCB 也提供了一些默认服务：
- `IConfigLoader` -> `FileConfigLoader`
- `IConfigProvider` -> `ConfigProvider`
- `IObjectSerializer` -> `JsonObjectSerializer`
- `IPathProvider` -> `PathProvider`

#### 8. 附录

- CB2 脚本开发文档：https://scpcbmr.42web.io/

## 🔧 技术细节

本项目分为三部分—— AngelScript | C# 绑定生成器，插件加载器与Rust中间层

- AngelScript | C# 绑定生成器 - 负责自动生成 AngelScript 脚本函数的 C# 映射
- Rust中间层 - 负责创建 .NET 虚拟机并启动插件加载器
- 插件加载器 - 负责在 .NET 虚拟机创建完后，加载事件回调绑定，并依赖注入、调用所有插件

Rust 中间层仓库见 https://github.com/EasyT-T/ccb-rust