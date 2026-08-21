<div align="right">

English | [简体中文](./README.zh-CN.md)

</div>

<div align="center">

# CB2 CSharp Binding

A high-performance, modern C# plugin framework for the *SCP: Containment Breach 2* game server

![License](https://img.shields.io/badge/license-LGPLv2.1-blue.svg)
![Version](https://img.shields.io/badge/version-v0.1.0-brightgreen.svg)
![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-14.0-239120?logo=csharp&logoColor=white)
![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)

</div>

---

## 📖 Table of Contents

- [📖 Project Overview](#-project-overview)
    - [🌟 Key Features](#-key-features)
- [🚀 Getting Started](#-getting-started)
    - [Prerequisites](#prerequisites)
    - [Installing CCB](#installing-ccb)
    - [Plugin Development](#plugin-development)
        - [1. Entry Point & Metadata](#1-entry-point--metadata)
        - [2. Plugin Configuration](#2-plugin-configuration)
        - [3. Event Registration](#3-event-registration)
        - [4. Iterating Objects](#4-iterating-objects)
        - [5. Thread Safety](#5-thread-safety)
        - [6. Script Functions](#6-script-functions)
        - [7. Dependency Injection](#7-dependency-injection)
        - [8. Appendix](#8-appendix)
- [🔧 Technical Details](#-technical-details)

---

## 📖 Project Overview

This project creates a .NET virtual machine inside the game server and generates script-function bindings so that plugins can interact with the server.

Plugin loading is handled via dependency injection.

### 🌟 Key Features

- ⚡ **High Performance**: Built on native CoreCLR
- 🚀 **Multithreading / Async**: Uses `SynchronizationContext`, allowing script functions to be called from multiple threads or asynchronous code
- 🔥 **Hot Reload**: Supports hot reloading via `dotnet watch`, JetBrains Rider, and similar tools

---

## 🚀 Getting Started

### Prerequisites

Make sure the .NET SDK 10 (x86) is installed on your machine.

### Installing CCB

1. Download `ccb.zip` from the latest [Release](https://github.com/EasyT-T/ccb/releases) and extract it into `path/to/server`.
2. Edit `server.cfg` and add the following lines (**Note: the order must match the example exactly**):
```
plugin ccb/plugin.as
script ccb/script.as
```
3. Launch `server-launcher.exe` and verify that CCB has been installed correctly.

Plugins are installed in `path/to/server/ccb/plugins`

Dependencies are installed in `path/to/server/ccb/dependencies`

### Plugin Development

#### 1. Entry Point & Metadata

Create a new .NET 10 project and reference `CCB.dll`. For logging, you'll also need to reference the `Microsoft.Extensions.Logging.Abstractions` NuGet package.

Create a `PluginMetadata` class, as shown below:
```csharp
// Usings...
public class PluginMetadata : IPluginMetadata
{
    public string Name => "This is your plugin name";

    public string Description => "This is your plugin description";

    public string Author => "Who wrote this plugin";
}
```

Next, create an `EntryPoint` class, which will serve as your plugin's entry point:
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
> Any class marked with the `[Injectable]` attribute is added to the dependency injection pool. The plugin loader iterates over every class in that pool that implements `ILoad` and calls its `Load` method.
> More details are given in the examples that follow.

`ILoad::Load` is invoked when the plugin is loaded.

Besides `ILoad`, you can also implement `IPreload`, `IUnload`, and others.

`IPreload` is covered in the **Plugin Configuration** section below.

`IUnload::Unload` currently has no effect, but once hot plug/unplug support for plugins is added, it will be called when a plugin is unloaded.

#### 2. Plugin Configuration

CCB provides a built-in plugin configuration service. Plugin configuration is likewise injected into your plugin via dependency injection. By default, plugin configuration files live in `path/to/server/ccb/config`.

To load a plugin configuration, you need to consider its **load timing**, its **behavior when no file exists**, and its **storage strategy after loading**.

Here's a simple example:
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
Here we define a simple `record` type as the serializable object for the plugin configuration, where the serializable configuration content consists of the immutable properties `StringContent` and `FloatContent`.

- `Name` is a constant specifying the configuration file's name.
- `Type` specifies the configuration file's type (currently only `Json` is supported, using `System.Text.Json`).
- `Default` specifies the default configuration created when the configuration file doesn't exist.

Next, we need to call the plugin configuration service to load the configuration. This can be done in the entry point, as shown below:
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

`IConfigProvider<TConfig>::Cache` loads the specified plugin configuration and stores the deserialized object in a variable. To retrieve it again later, simply call `IConfigProvider<TConfig>::GetConfig`. However, if the configuration hasn't been loaded yet, this will throw an `InvalidOperationException`.

You'll notice that `_config` is annotated as `nullable` here, since the variable isn't assigned until `Load` is called.

A better approach is therefore to load the configuration ahead of time in `IPreload`, and then simply retrieve it directly in `ILoad`.

Here's the improved example:
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

#### 3. Event Registration

The game exposes a large number of event types that you can subscribe to in CCB.

Example:

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

Once registered, `OnPlayerConnect` will be called every time a player joins.

All event arguments are stored in `EventRegistry.{event_name}EventArg`.

If the event has a `bool` return value, you can modify the `EventResult` field on the EventArg; CCB will ultimately pass that value back to the server as the return value.

Note: modifications to `EventResult` also affect other plugins.

#### 4. Iterating Objects

Many objects in the game can be enumerated globally, such as `Player`, `Items`, etc.

To iterate them, simply call the object's static `::List` method:

```csharp
foreach (Player player in Player.List())
```

You can also use `LINQ`:

```csharp
IEnumerable<Player> admins = Player.List().Where(p => p.IsAdmin());
```

Note: object iteration is not thread-safe — see the **Thread Safety** section for details.

#### 5. Thread Safety

**Any interaction with the server is not thread-safe.**

For example:
- Calling object methods such as `Player::GetName`
- Calling `Player::List` and iterating over it
- Calling `script functions`

All of the above must be performed on the main thread.

CCB registers a `MainThreadContext` to support multithreading.

Under the default async behavior, an `await` on the main thread will automatically resume back on the main thread.

However, if you use `Task::Run`, `Task::Start`, or `Thread::Start`, any server interaction must be dispatched back to the main thread.

Example:

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

Be careful about deferred evaluation when using LINQ to iterate objects.

❌ Incorrect

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

✅ Correct
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

Because of LINQ's deferred evaluation, in the incorrect example the global iteration over `Player` actually happens on the other thread rather than on the main thread.

#### 6. Script Functions

All script functions live in the `ScriptFunctions` class and can be called directly.

Objects like `Player` are essentially wrapper calls around `ScriptFunctions`.

Thread-safety considerations apply when calling script functions, just as noted above.

#### 7. Dependency Injection

Any class marked with the `[Injectable]` attribute is added to a service collection.

You can reference other `[Injectable]` services in a class's constructor.

CCB also provides some default services:
- `IConfigLoader` -> `FileConfigLoader`
- `IConfigProvider` -> `ConfigProvider`
- `IObjectSerializer` -> `JsonObjectSerializer`
- `IPathProvider` -> `PathProvider`

#### 8. Appendix

- CB2 scripting documentation: https://scpcbmr.42web.io/

## 🔧 Technical Details

This project is composed of three parts: the AngelScript | C# binding generator, the plugin loader, and a Rust middle layer.

- AngelScript | C# binding generator — automatically generates C# mappings for AngelScript script functions
- Rust middle layer — creates the .NET virtual machine and starts the plugin loader
- Plugin loader — after the .NET virtual machine is created, loads event callback bindings, performs dependency injection, and invokes all plugins

See the Rust middle layer repository at https://github.com/EasyT-T/ccb-rust