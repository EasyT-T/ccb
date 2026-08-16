namespace CCB.Internal;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static class EventRegistry
{

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnServerUpdateInternal()
    {
        try
        {
            var args = new ServerUpdateEventArg();
            ServerUpdate?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnServerConsoleInternal(IntPtr command)
    {
        try
        {
            var args = new ServerConsoleEventArg(Marshal.PtrToStringUTF8(command)!);
            ServerConsole?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnServerRestartInternal()
    {
        try
        {
            var args = new ServerRestartEventArg();
            ServerRestart?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnWorldLoadedInternal()
    {
        try
        {
            var args = new WorldLoadedEventArg();
            WorldLoaded?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnWorldUpdateInternal()
    {
        try
        {
            var args = new WorldUpdateEventArg();
            WorldUpdate?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerUpdateInternal(ObjectHandle player)
    {
        try
        {
            var args = new PlayerUpdateEventArg(new Player(player));
            PlayerUpdate?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerConnectInternal(ObjectHandle player)
    {
        try
        {
            var args = new PlayerConnectEventArg(new Player(player));
            PlayerConnect?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerDisconnectInternal(ObjectHandle player)
    {
        try
        {
            var args = new PlayerDisconnectEventArg(new Player(player));
            PlayerDisconnect?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerChatInternal(ObjectHandle player, IntPtr text)
    {
        try
        {
            var args = new PlayerChatEventArg(new Player(player), Marshal.PtrToStringUTF8(text)!);
            PlayerChat?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerAttachesUpdateInternal(ObjectHandle player)
    {
        try
        {
            var args = new PlayerAttachesUpdateEventArg(new Player(player));
            PlayerAttachesUpdate?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerTakeItemInternal(ObjectHandle player, ObjectHandle item)
    {
        try
        {
            var args = new PlayerTakeItemEventArg(new Player(player), new Items(item));
            PlayerTakeItem?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerDropItemInternal(ObjectHandle player, ObjectHandle item)
    {
        try
        {
            var args = new PlayerDropItemEventArg(new Player(player), new Items(item));
            PlayerDropItem?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerDialogActionInternal(ObjectHandle player, int index, int response, IntPtr input, int selecteditem)
    {
        try
        {
            var args = new PlayerDialogActionEventArg(new Player(player), index, response != 0, Marshal.PtrToStringUTF8(input)!, selecteditem);
            PlayerDialogAction?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerShootPlayerInternal(ObjectHandle shooter, ObjectHandle dest, float x, float y, float z, float damage, int headshot)
    {
        try
        {
            var args = new PlayerShootPlayerEventArg(new Player(shooter), new Player(dest), x, y, z, damage, headshot != 0);
            PlayerShootPlayer?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerShootInternal(ObjectHandle player, ObjectHandle item, int weaponattach)
    {
        try
        {
            var args = new PlayerShootEventArg(new Player(player), new Items(item), weaponattach);
            PlayerShoot?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerPressPlayerInternal(ObjectHandle src, ObjectHandle dest)
    {
        try
        {
            var args = new PlayerPressPlayerEventArg(new Player(src), new Player(dest));
            PlayerPressPlayer?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerConsoleInternal(ObjectHandle player, IntPtr input)
    {
        try
        {
            var args = new PlayerConsoleEventArg(new Player(player), Marshal.PtrToStringUTF8(input)!);
            PlayerConsole?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerDeathInternal(ObjectHandle player, ObjectHandle corpse)
    {
        try
        {
            var args = new PlayerDeathEventArg(new Player(player), new Corpse(corpse));
            PlayerDeath?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerRespawnInternal(ObjectHandle player)
    {
        try
        {
            var args = new PlayerRespawnEventArg(new Player(player));
            PlayerRespawn?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerHitPlayerInternal(ObjectHandle src, ObjectHandle dest, int mousedata, float distance)
    {
        try
        {
            var args = new PlayerHitPlayerEventArg(new Player(src), new Player(dest), mousedata, distance);
            PlayerHitPlayer?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerExploreCorpseInternal(ObjectHandle player, ObjectHandle corpse)
    {
        try
        {
            var args = new PlayerExploreCorpseEventArg(new Player(player), new Corpse(corpse));
            PlayerExploreCorpse?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerClickObjectInternal(ObjectHandle player, ObjectHandle @object)
    {
        try
        {
            var args = new PlayerClickObjectEventArg(new Player(player), new Object(@object));
            PlayerClickObject?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerShootObjectInternal(ObjectHandle player, ObjectHandle @object)
    {
        try
        {
            var args = new PlayerShootObjectEventArg(new Player(player), new Object(@object));
            PlayerShootObject?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerUseDoorButtonInternal(ObjectHandle player, ObjectHandle door, ObjectHandle useditem)
    {
        try
        {
            var args = new PlayerUseDoorButtonEventArg(new Player(player), new Door(door), new Items(useditem));
            PlayerUseDoorButton?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerUseItemInternal(ObjectHandle player, ObjectHandle item)
    {
        try
        {
            var args = new PlayerUseItemEventArg(new Player(player), new Items(item));
            PlayerUseItem?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerSelectItemInternal(ObjectHandle player, ObjectHandle item)
    {
        try
        {
            var args = new PlayerSelectItemEventArg(new Player(player), new Items(item));
            PlayerSelectItem?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerUse914Internal(ObjectHandle player, int fineid)
    {
        try
        {
            var args = new PlayerUse914EventArg(new Player(player), fineid);
            PlayerUse914?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerClickGuiInternal(ObjectHandle player, ObjectHandle element)
    {
        try
        {
            var args = new PlayerClickGuiEventArg(new Player(player), new GUIElement(element));
            PlayerClickGui?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerVoiceInternal(ObjectHandle player, int bank, int radio)
    {
        try
        {
            var args = new PlayerVoiceEventArg(new Player(player), bank, radio != 0);
            PlayerVoice?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerTeleportElevatorInternal(ObjectHandle player, ObjectHandle room, ObjectHandle firstentity, ObjectHandle secondentity, float offsetx, float offsety)
    {
        try
        {
            var args = new PlayerTeleportElevatorEventArg(new Player(player), new Room(room), new Entity(firstentity), new Entity(secondentity), offsetx, offsety);
            PlayerTeleportElevator?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerShootNPCInternal(ObjectHandle player, ObjectHandle npc)
    {
        try
        {
            var args = new PlayerShootNPCEventArg(new Player(player), new NPC(npc));
            PlayerShootNPC?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerKeyActionInternal(ObjectHandle player, int newmask, int prevmask)
    {
        try
        {
            var args = new PlayerKeyActionEventArg(new Player(player), newmask, prevmask);
            PlayerKeyAction?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnPlayerSpectateActionInternal(ObjectHandle player, ObjectHandle target, int mode)
    {
        try
        {
            var args = new PlayerSpectateActionEventArg(new Player(player), new Player(target), mode);
            PlayerSpectateAction?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnIncomingConnectionInternal(ObjectHandle conn)
    {
        try
        {
            var args = new IncomingConnectionEventArg(new Connection(conn));
            IncomingConnection?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnConnectionLoadedInternal(ObjectHandle conn)
    {
        try
        {
            var args = new ConnectionLoadedEventArg(new Connection(conn));
            ConnectionLoaded?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnConnectionClosedInternal(ObjectHandle conn)
    {
        try
        {
            var args = new ConnectionClosedEventArg(new Connection(conn));
            ConnectionClosed?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnShellDamagePlayerInternal(ObjectHandle shell, ObjectHandle player, float damage)
    {
        try
        {
            var args = new ShellDamagePlayerEventArg(new Shell(shell), new Player(player), damage);
            ShellDamagePlayer?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnShellExplodeInternal(ObjectHandle shell)
    {
        try
        {
            var args = new ShellExplodeEventArg(new Shell(shell));
            ShellExplode?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnLogInternal(IntPtr message)
    {
        try
        {
            var args = new OnLogEventArg(Marshal.PtrToStringUTF8(message)!);
            OnLog?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static int OnFineItemInternal(ObjectHandle item, int settings, float x, float y, float z)
    {
        try
        {
            var args = new FineItemEventArg(new Items(item), settings, x, y, z);
            FineItem?.Invoke(args); return args.EventResult ? 1 : 0;
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
            return 1;
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnCreateItemInternal(ObjectHandle item)
    {
        try
        {
            var args = new CreateItemEventArg(new Items(item));
            CreateItem?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnRemoveItemInternal(ObjectHandle item)
    {
        try
        {
            var args = new RemoveItemEventArg(new Items(item));
            RemoveItem?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnCreateNPCInternal(ObjectHandle npc)
    {
        try
        {
            var args = new CreateNPCEventArg(new NPC(npc));
            CreateNPC?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnRemoveNPCInternal(ObjectHandle npc)
    {
        try
        {
            var args = new RemoveNPCEventArg(new NPC(npc));
            RemoveNPC?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnCreateCorpseInternal(ObjectHandle corpse)
    {
        try
        {
            var args = new CreateCorpseEventArg(new Corpse(corpse));
            CreateCorpse?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnRemoveCorpseInternal(ObjectHandle corpse)
    {
        try
        {
            var args = new RemoveCorpseEventArg(new Corpse(corpse));
            RemoveCorpse?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnCreateObjectInternal(ObjectHandle obj)
    {
        try
        {
            var args = new CreateObjectEventArg(new Object(obj));
            CreateObject?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnRemoveObjectInternal(ObjectHandle obj)
    {
        try
        {
            var args = new RemoveObjectEventArg(new Object(obj));
            RemoveObject?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnCreateLightInternal(ObjectHandle light)
    {
        try
        {
            var args = new CreateLightEventArg(new Light(light));
            CreateLight?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnRemoveLightInternal(ObjectHandle light)
    {
        try
        {
            var args = new RemoveLightEventArg(new Light(light));
            RemoveLight?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnCreateGUIElementInternal(ObjectHandle element)
    {
        try
        {
            var args = new CreateGUIElementEventArg(new GUIElement(element));
            CreateGUIElement?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnRemoveGUIElementInternal(ObjectHandle element)
    {
        try
        {
            var args = new RemoveGUIElementEventArg(new GUIElement(element));
            RemoveGUIElement?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnCreateShellInternal(ObjectHandle shell)
    {
        try
        {
            var args = new CreateShellEventArg(new Shell(shell));
            CreateShell?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnRemoveShellInternal(ObjectHandle shell)
    {
        try
        {
            var args = new RemoveShellEventArg(new Shell(shell));
            RemoveShell?.Invoke(args);
        }
        catch(Exception e)
        {
            ScriptFunctions.print(e.ToString());
        }
    }

    internal static unsafe void RegisterEventFunctions()
    {
        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_ServerUpdate()", (IntPtr)(delegate* unmanaged[Stdcall]<void>)(&OnServerUpdateInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_ServerConsole(const char)", (IntPtr)(delegate* unmanaged[Stdcall]<IntPtr, int>)(&OnServerConsoleInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_ServerRestart()", (IntPtr)(delegate* unmanaged[Stdcall]<void>)(&OnServerRestartInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_WorldLoaded()", (IntPtr)(delegate* unmanaged[Stdcall]<void>)(&OnWorldLoadedInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_WorldUpdate()", (IntPtr)(delegate* unmanaged[Stdcall]<void>)(&OnWorldUpdateInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerUpdate(Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnPlayerUpdateInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerConnect(Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnPlayerConnectInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerDisconnect(Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnPlayerDisconnectInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerChat(Player, const char)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, IntPtr, int>)(&OnPlayerChatInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerAttachesUpdate(Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnPlayerAttachesUpdateInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerTakeItem(Player, Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, int>)(&OnPlayerTakeItemInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerDropItem(Player, Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, int>)(&OnPlayerDropItemInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerDialogAction(Player, int, bool, const char, int)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int, int, IntPtr, int, void>)(&OnPlayerDialogActionInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerShootPlayer(Player, Player, float, float, float, float, bool)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, float, float, float, float, int, int>)(&OnPlayerShootPlayerInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerShoot(Player, Items, int)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, int, int>)(&OnPlayerShootInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerPressPlayer(Player, Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerPressPlayerInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerConsole(Player, const char)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, IntPtr, int>)(&OnPlayerConsoleInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerDeath(Player, Corpse)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerDeathInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerRespawn(Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnPlayerRespawnInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerHitPlayer(Player, Player, int, float)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, int, float, void>)(&OnPlayerHitPlayerInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerExploreCorpse(Player, Corpse)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, int>)(&OnPlayerExploreCorpseInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerClickObject(Player, Object)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerClickObjectInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerShootObject(Player, Object)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerShootObjectInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerUseDoorButton(Player, Door, Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, ObjectHandle, int>)(&OnPlayerUseDoorButtonInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerUseItem(Player, Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, int>)(&OnPlayerUseItemInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerSelectItem(Player, Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, int>)(&OnPlayerSelectItemInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerUse914(Player, int)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int, void>)(&OnPlayerUse914Internal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerClickGui(Player, GUIElement)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerClickGuiInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerVoice(Player, int, bool)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int, int, int>)(&OnPlayerVoiceInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerTeleportElevator(Player, Room, Entity, Entity, float, float)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, ObjectHandle, ObjectHandle, float, float, void>)(&OnPlayerTeleportElevatorInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerShootNPC(Player, NPC)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerShootNPCInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_PlayerKeyAction(Player, int, int)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int, int, void>)(&OnPlayerKeyActionInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_PlayerSpectateAction(Player, Player, int)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, int, int>)(&OnPlayerSpectateActionInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_IncomingConnection(Connection)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnIncomingConnectionInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_ConnectionLoaded(Connection)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int>)(&OnConnectionLoadedInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_ConnectionClosed(Connection)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnConnectionClosedInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_ShellDamagePlayer(Shell, Player, float)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, float, int>)(&OnShellDamagePlayerInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_ShellExplode(Shell)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int>)(&OnShellExplodeInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_OnLog(const char)", (IntPtr)(delegate* unmanaged[Stdcall]<IntPtr, void>)(&OnOnLogInternal));

        NativeBindings.RegisterGlobalFunction("bool ccb_internal_invoke_FineItem(Items, int, float, float, float)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int, float, float, float, int>)(&OnFineItemInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_CreateItem(Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnCreateItemInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_RemoveItem(Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnRemoveItemInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_CreateNPC(NPC)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnCreateNPCInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_RemoveNPC(NPC)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnRemoveNPCInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_CreateCorpse(Corpse)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnCreateCorpseInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_RemoveCorpse(Corpse)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnRemoveCorpseInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_CreateObject(Object)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnCreateObjectInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_RemoveObject(Object)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnRemoveObjectInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_CreateLight(Light)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnCreateLightInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_RemoveLight(Light)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnRemoveLightInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_CreateGUIElement(GUIElement)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnCreateGUIElementInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_RemoveGUIElement(GUIElement)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnRemoveGUIElementInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_CreateShell(Shell)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnCreateShellInternal));

        NativeBindings.RegisterGlobalFunction("void ccb_internal_invoke_RemoveShell(Shell)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnRemoveShellInternal));
    }
    public class ServerUpdateEventArg()
    {
    }

    public delegate void OnServerUpdate(ServerUpdateEventArg args);

    public static event OnServerUpdate? ServerUpdate;

    public class ServerConsoleEventArg(string command)
    {
        public string Command { get; } = command;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnServerConsole(ServerConsoleEventArg args);

    public static event OnServerConsole? ServerConsole;

    public class ServerRestartEventArg()
    {
    }

    public delegate void OnServerRestart(ServerRestartEventArg args);

    public static event OnServerRestart? ServerRestart;

    public class WorldLoadedEventArg()
    {
    }

    public delegate void OnWorldLoaded(WorldLoadedEventArg args);

    public static event OnWorldLoaded? WorldLoaded;

    public class WorldUpdateEventArg()
    {
    }

    public delegate void OnWorldUpdate(WorldUpdateEventArg args);

    public static event OnWorldUpdate? WorldUpdate;

    public class PlayerUpdateEventArg(Player player)
    {
        public Player Player { get; } = player;

    }

    public delegate void OnPlayerUpdate(PlayerUpdateEventArg args);

    public static event OnPlayerUpdate? PlayerUpdate;

    public class PlayerConnectEventArg(Player player)
    {
        public Player Player { get; } = player;

    }

    public delegate void OnPlayerConnect(PlayerConnectEventArg args);

    public static event OnPlayerConnect? PlayerConnect;

    public class PlayerDisconnectEventArg(Player player)
    {
        public Player Player { get; } = player;

    }

    public delegate void OnPlayerDisconnect(PlayerDisconnectEventArg args);

    public static event OnPlayerDisconnect? PlayerDisconnect;

    public class PlayerChatEventArg(Player player, string text)
    {
        public Player Player { get; } = player;

        public string Text { get; } = text;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerChat(PlayerChatEventArg args);

    public static event OnPlayerChat? PlayerChat;

    public class PlayerAttachesUpdateEventArg(Player player)
    {
        public Player Player { get; } = player;

    }

    public delegate void OnPlayerAttachesUpdate(PlayerAttachesUpdateEventArg args);

    public static event OnPlayerAttachesUpdate? PlayerAttachesUpdate;

    public class PlayerTakeItemEventArg(Player player, Items item)
    {
        public Player Player { get; } = player;

        public Items Item { get; } = item;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerTakeItem(PlayerTakeItemEventArg args);

    public static event OnPlayerTakeItem? PlayerTakeItem;

    public class PlayerDropItemEventArg(Player player, Items item)
    {
        public Player Player { get; } = player;

        public Items Item { get; } = item;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerDropItem(PlayerDropItemEventArg args);

    public static event OnPlayerDropItem? PlayerDropItem;

    public class PlayerDialogActionEventArg(Player player, int index, bool response, string input, int selecteditem)
    {
        public Player Player { get; } = player;

        public int Index { get; } = index;

        public bool Response { get; } = response;

        public string Input { get; } = input;

        public int Selecteditem { get; } = selecteditem;

    }

    public delegate void OnPlayerDialogAction(PlayerDialogActionEventArg args);

    public static event OnPlayerDialogAction? PlayerDialogAction;

    public class PlayerShootPlayerEventArg(Player shooter, Player dest, float x, float y, float z, float damage, bool headshot)
    {
        public Player Shooter { get; } = shooter;

        public Player Dest { get; } = dest;

        public float X { get; } = x;

        public float Y { get; } = y;

        public float Z { get; } = z;

        public float Damage { get; } = damage;

        public bool Headshot { get; } = headshot;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerShootPlayer(PlayerShootPlayerEventArg args);

    public static event OnPlayerShootPlayer? PlayerShootPlayer;

    public class PlayerShootEventArg(Player player, Items item, int weaponattach)
    {
        public Player Player { get; } = player;

        public Items Item { get; } = item;

        public int Weaponattach { get; } = weaponattach;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerShoot(PlayerShootEventArg args);

    public static event OnPlayerShoot? PlayerShoot;

    public class PlayerPressPlayerEventArg(Player src, Player dest)
    {
        public Player Src { get; } = src;

        public Player Dest { get; } = dest;

    }

    public delegate void OnPlayerPressPlayer(PlayerPressPlayerEventArg args);

    public static event OnPlayerPressPlayer? PlayerPressPlayer;

    public class PlayerConsoleEventArg(Player player, string input)
    {
        public Player Player { get; } = player;

        public string Input { get; } = input;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerConsole(PlayerConsoleEventArg args);

    public static event OnPlayerConsole? PlayerConsole;

    public class PlayerDeathEventArg(Player player, Corpse corpse)
    {
        public Player Player { get; } = player;

        public Corpse Corpse { get; } = corpse;

    }

    public delegate void OnPlayerDeath(PlayerDeathEventArg args);

    public static event OnPlayerDeath? PlayerDeath;

    public class PlayerRespawnEventArg(Player player)
    {
        public Player Player { get; } = player;

    }

    public delegate void OnPlayerRespawn(PlayerRespawnEventArg args);

    public static event OnPlayerRespawn? PlayerRespawn;

    public class PlayerHitPlayerEventArg(Player src, Player dest, int mousedata, float distance)
    {
        public Player Src { get; } = src;

        public Player Dest { get; } = dest;

        public int Mousedata { get; } = mousedata;

        public float Distance { get; } = distance;

    }

    public delegate void OnPlayerHitPlayer(PlayerHitPlayerEventArg args);

    public static event OnPlayerHitPlayer? PlayerHitPlayer;

    public class PlayerExploreCorpseEventArg(Player player, Corpse corpse)
    {
        public Player Player { get; } = player;

        public Corpse Corpse { get; } = corpse;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerExploreCorpse(PlayerExploreCorpseEventArg args);

    public static event OnPlayerExploreCorpse? PlayerExploreCorpse;

    public class PlayerClickObjectEventArg(Player player, Object @object)
    {
        public Player Player { get; } = player;

        public Object @Object { get; } = @object;

    }

    public delegate void OnPlayerClickObject(PlayerClickObjectEventArg args);

    public static event OnPlayerClickObject? PlayerClickObject;

    public class PlayerShootObjectEventArg(Player player, Object @object)
    {
        public Player Player { get; } = player;

        public Object @Object { get; } = @object;

    }

    public delegate void OnPlayerShootObject(PlayerShootObjectEventArg args);

    public static event OnPlayerShootObject? PlayerShootObject;

    public class PlayerUseDoorButtonEventArg(Player player, Door door, Items useditem)
    {
        public Player Player { get; } = player;

        public Door Door { get; } = door;

        public Items Useditem { get; } = useditem;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerUseDoorButton(PlayerUseDoorButtonEventArg args);

    public static event OnPlayerUseDoorButton? PlayerUseDoorButton;

    public class PlayerUseItemEventArg(Player player, Items item)
    {
        public Player Player { get; } = player;

        public Items Item { get; } = item;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerUseItem(PlayerUseItemEventArg args);

    public static event OnPlayerUseItem? PlayerUseItem;

    public class PlayerSelectItemEventArg(Player player, Items item)
    {
        public Player Player { get; } = player;

        public Items Item { get; } = item;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerSelectItem(PlayerSelectItemEventArg args);

    public static event OnPlayerSelectItem? PlayerSelectItem;

    public class PlayerUse914EventArg(Player player, int fineid)
    {
        public Player Player { get; } = player;

        public int Fineid { get; } = fineid;

    }

    public delegate void OnPlayerUse914(PlayerUse914EventArg args);

    public static event OnPlayerUse914? PlayerUse914;

    public class PlayerClickGuiEventArg(Player player, GUIElement element)
    {
        public Player Player { get; } = player;

        public GUIElement Element { get; } = element;

    }

    public delegate void OnPlayerClickGui(PlayerClickGuiEventArg args);

    public static event OnPlayerClickGui? PlayerClickGui;

    public class PlayerVoiceEventArg(Player player, int bank, bool radio)
    {
        public Player Player { get; } = player;

        public int Bank { get; } = bank;

        public bool Radio { get; } = radio;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerVoice(PlayerVoiceEventArg args);

    public static event OnPlayerVoice? PlayerVoice;

    public class PlayerTeleportElevatorEventArg(Player player, Room room, Entity firstentity, Entity secondentity, float offsetx, float offsety)
    {
        public Player Player { get; } = player;

        public Room Room { get; } = room;

        public Entity Firstentity { get; } = firstentity;

        public Entity Secondentity { get; } = secondentity;

        public float Offsetx { get; } = offsetx;

        public float Offsety { get; } = offsety;

    }

    public delegate void OnPlayerTeleportElevator(PlayerTeleportElevatorEventArg args);

    public static event OnPlayerTeleportElevator? PlayerTeleportElevator;

    public class PlayerShootNPCEventArg(Player player, NPC npc)
    {
        public Player Player { get; } = player;

        public NPC Npc { get; } = npc;

    }

    public delegate void OnPlayerShootNPC(PlayerShootNPCEventArg args);

    public static event OnPlayerShootNPC? PlayerShootNPC;

    public class PlayerKeyActionEventArg(Player player, int newmask, int prevmask)
    {
        public Player Player { get; } = player;

        public int Newmask { get; } = newmask;

        public int Prevmask { get; } = prevmask;

    }

    public delegate void OnPlayerKeyAction(PlayerKeyActionEventArg args);

    public static event OnPlayerKeyAction? PlayerKeyAction;

    public class PlayerSpectateActionEventArg(Player player, Player target, int mode)
    {
        public Player Player { get; } = player;

        public Player Target { get; } = target;

        public int Mode { get; } = mode;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnPlayerSpectateAction(PlayerSpectateActionEventArg args);

    public static event OnPlayerSpectateAction? PlayerSpectateAction;

    public class IncomingConnectionEventArg(Connection conn)
    {
        public Connection Conn { get; } = conn;

    }

    public delegate void OnIncomingConnection(IncomingConnectionEventArg args);

    public static event OnIncomingConnection? IncomingConnection;

    public class ConnectionLoadedEventArg(Connection conn)
    {
        public Connection Conn { get; } = conn;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnConnectionLoaded(ConnectionLoadedEventArg args);

    public static event OnConnectionLoaded? ConnectionLoaded;

    public class ConnectionClosedEventArg(Connection conn)
    {
        public Connection Conn { get; } = conn;

    }

    public delegate void OnConnectionClosed(ConnectionClosedEventArg args);

    public static event OnConnectionClosed? ConnectionClosed;

    public class ShellDamagePlayerEventArg(Shell shell, Player player, float damage)
    {
        public Shell Shell { get; } = shell;

        public Player Player { get; } = player;

        public float Damage { get; } = damage;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnShellDamagePlayer(ShellDamagePlayerEventArg args);

    public static event OnShellDamagePlayer? ShellDamagePlayer;

    public class ShellExplodeEventArg(Shell shell)
    {
        public Shell Shell { get; } = shell;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnShellExplode(ShellExplodeEventArg args);

    public static event OnShellExplode? ShellExplode;

    public class OnLogEventArg(string message)
    {
        public string Message { get; } = message;

    }

    public delegate void OnOnLog(OnLogEventArg args);

    public static event OnOnLog? OnLog;

    public class FineItemEventArg(Items item, int settings, float x, float y, float z)
    {
        public Items Item { get; } = item;

        public int Settings { get; } = settings;

        public float X { get; } = x;

        public float Y { get; } = y;

        public float Z { get; } = z;

        public bool EventResult { get; set; } = true;
    }

    public delegate void OnFineItem(FineItemEventArg args);

    public static event OnFineItem? FineItem;

    public class CreateItemEventArg(Items item)
    {
        public Items Item { get; } = item;

    }

    public delegate void OnCreateItem(CreateItemEventArg args);

    public static event OnCreateItem? CreateItem;

    public class RemoveItemEventArg(Items item)
    {
        public Items Item { get; } = item;

    }

    public delegate void OnRemoveItem(RemoveItemEventArg args);

    public static event OnRemoveItem? RemoveItem;

    public class CreateNPCEventArg(NPC npc)
    {
        public NPC Npc { get; } = npc;

    }

    public delegate void OnCreateNPC(CreateNPCEventArg args);

    public static event OnCreateNPC? CreateNPC;

    public class RemoveNPCEventArg(NPC npc)
    {
        public NPC Npc { get; } = npc;

    }

    public delegate void OnRemoveNPC(RemoveNPCEventArg args);

    public static event OnRemoveNPC? RemoveNPC;

    public class CreateCorpseEventArg(Corpse corpse)
    {
        public Corpse Corpse { get; } = corpse;

    }

    public delegate void OnCreateCorpse(CreateCorpseEventArg args);

    public static event OnCreateCorpse? CreateCorpse;

    public class RemoveCorpseEventArg(Corpse corpse)
    {
        public Corpse Corpse { get; } = corpse;

    }

    public delegate void OnRemoveCorpse(RemoveCorpseEventArg args);

    public static event OnRemoveCorpse? RemoveCorpse;

    public class CreateObjectEventArg(Object obj)
    {
        public Object Obj { get; } = obj;

    }

    public delegate void OnCreateObject(CreateObjectEventArg args);

    public static event OnCreateObject? CreateObject;

    public class RemoveObjectEventArg(Object obj)
    {
        public Object Obj { get; } = obj;

    }

    public delegate void OnRemoveObject(RemoveObjectEventArg args);

    public static event OnRemoveObject? RemoveObject;

    public class CreateLightEventArg(Light light)
    {
        public Light Light { get; } = light;

    }

    public delegate void OnCreateLight(CreateLightEventArg args);

    public static event OnCreateLight? CreateLight;

    public class RemoveLightEventArg(Light light)
    {
        public Light Light { get; } = light;

    }

    public delegate void OnRemoveLight(RemoveLightEventArg args);

    public static event OnRemoveLight? RemoveLight;

    public class CreateGUIElementEventArg(GUIElement element)
    {
        public GUIElement Element { get; } = element;

    }

    public delegate void OnCreateGUIElement(CreateGUIElementEventArg args);

    public static event OnCreateGUIElement? CreateGUIElement;

    public class RemoveGUIElementEventArg(GUIElement element)
    {
        public GUIElement Element { get; } = element;

    }

    public delegate void OnRemoveGUIElement(RemoveGUIElementEventArg args);

    public static event OnRemoveGUIElement? RemoveGUIElement;

    public class CreateShellEventArg(Shell shell)
    {
        public Shell Shell { get; } = shell;

    }

    public delegate void OnCreateShell(CreateShellEventArg args);

    public static event OnCreateShell? CreateShell;

    public class RemoveShellEventArg(Shell shell)
    {
        public Shell Shell { get; } = shell;

    }

    public delegate void OnRemoveShell(RemoveShellEventArg args);

    public static event OnRemoveShell? RemoveShell;
}
