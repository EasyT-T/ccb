namespace CCB.Internal;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal static class EventRegistry
{
    public static EventHandler GlobalHandler { get; internal set; }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnInitialize()
    {
        GlobalHandler.OnOnInitialize();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnTerminate()
    {
        GlobalHandler.OnOnTerminate();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnServerUpdate()
    {
        GlobalHandler.OnServerUpdate();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnServerConsole(IntPtr command)
    {
        return GlobalHandler.OnServerConsole(Marshal.PtrToStringUTF8(command)!);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnServerRestart()
    {
        GlobalHandler.OnServerRestart();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnWorldLoaded()
    {
        GlobalHandler.OnWorldLoaded();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnWorldUpdate()
    {
        GlobalHandler.OnWorldUpdate();
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerUpdate(ObjectHandle player)
    {
        GlobalHandler.OnPlayerUpdate(new Player(player));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerConnect(ObjectHandle player)
    {
        GlobalHandler.OnPlayerConnect(new Player(player));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerDisconnect(ObjectHandle player)
    {
        GlobalHandler.OnPlayerDisconnect(new Player(player));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerChat(ObjectHandle player, IntPtr text)
    {
        return GlobalHandler.OnPlayerChat(new Player(player), Marshal.PtrToStringUTF8(text)!);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerAttachesUpdate(ObjectHandle player)
    {
        GlobalHandler.OnPlayerAttachesUpdate(new Player(player));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerTakeItem(ObjectHandle player, ObjectHandle item)
    {
        return GlobalHandler.OnPlayerTakeItem(new Player(player), new Items(item));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerDropItem(ObjectHandle player, ObjectHandle item)
    {
        return GlobalHandler.OnPlayerDropItem(new Player(player), new Items(item));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerDialogAction(ObjectHandle player, int index, bool response, IntPtr input, int selecteditem)
    {
        GlobalHandler.OnPlayerDialogAction(new Player(player), index, response, Marshal.PtrToStringUTF8(input)!, selecteditem);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerShootPlayer(ObjectHandle shooter, ObjectHandle dest, float x, float y, float z, float damage, bool headshot)
    {
        return GlobalHandler.OnPlayerShootPlayer(new Player(shooter), new Player(dest), x, y, z, damage, headshot);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerShoot(ObjectHandle player, ObjectHandle item, int weaponattach)
    {
        return GlobalHandler.OnPlayerShoot(new Player(player), new Items(item), weaponattach);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerPressPlayer(ObjectHandle src, ObjectHandle dest)
    {
        GlobalHandler.OnPlayerPressPlayer(new Player(src), new Player(dest));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerConsole(ObjectHandle player, IntPtr input)
    {
        return GlobalHandler.OnPlayerConsole(new Player(player), Marshal.PtrToStringUTF8(input)!);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerDeath(ObjectHandle player, ObjectHandle corpse)
    {
        GlobalHandler.OnPlayerDeath(new Player(player), new Corpse(corpse));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerRespawn(ObjectHandle player)
    {
        GlobalHandler.OnPlayerRespawn(new Player(player));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerHitPlayer(ObjectHandle src, ObjectHandle dest, int mousedata, float distance)
    {
        GlobalHandler.OnPlayerHitPlayer(new Player(src), new Player(dest), mousedata, distance);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerExploreCorpse(ObjectHandle player, ObjectHandle corpse)
    {
        return GlobalHandler.OnPlayerExploreCorpse(new Player(player), new Corpse(corpse));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerClickObject(ObjectHandle player, ObjectHandle @object)
    {
        GlobalHandler.OnPlayerClickObject(new Player(player), new Object(@object));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerShootObject(ObjectHandle player, ObjectHandle @object)
    {
        GlobalHandler.OnPlayerShootObject(new Player(player), new Object(@object));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerUseDoorButton(ObjectHandle player, ObjectHandle door, ObjectHandle useditem)
    {
        return GlobalHandler.OnPlayerUseDoorButton(new Player(player), new Door(door), new Items(useditem));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerUseItem(ObjectHandle player, ObjectHandle item)
    {
        return GlobalHandler.OnPlayerUseItem(new Player(player), new Items(item));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerSelectItem(ObjectHandle player, ObjectHandle item)
    {
        return GlobalHandler.OnPlayerSelectItem(new Player(player), new Items(item));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerUse914(ObjectHandle player, int fineid)
    {
        GlobalHandler.OnPlayerUse914(new Player(player), fineid);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerSelectGUI(ObjectHandle player, ObjectHandle element)
    {
        GlobalHandler.OnPlayerSelectGUI(new Player(player), new GUIElement(element));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerVoice(ObjectHandle player, int bank, bool radio)
    {
        return GlobalHandler.OnPlayerVoice(new Player(player), bank, radio);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerTeleportElevator(ObjectHandle player, ObjectHandle room, ObjectHandle firstentity, ObjectHandle secondentity, float offsetx, float offsety)
    {
        GlobalHandler.OnPlayerTeleportElevator(new Player(player), new Room(room), new Entity(firstentity), new Entity(secondentity), offsetx, offsety);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerShootNPC(ObjectHandle player, ObjectHandle npc)
    {
        GlobalHandler.OnPlayerShootNPC(new Player(player), new NPC(npc));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnPlayerKeyAction(ObjectHandle player, int newmask, int prevmask)
    {
        GlobalHandler.OnPlayerKeyAction(new Player(player), newmask, prevmask);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnPlayerSpectateAction(ObjectHandle player, ObjectHandle target, int mode)
    {
        return GlobalHandler.OnPlayerSpectateAction(new Player(player), new Player(target), mode);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnIncomingConnection(ObjectHandle conn)
    {
        GlobalHandler.OnIncomingConnection(new Connection(conn));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnConnectionLoaded(ObjectHandle conn)
    {
        return GlobalHandler.OnConnectionLoaded(new Connection(conn));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnConnectionClosed(ObjectHandle conn)
    {
        GlobalHandler.OnConnectionClosed(new Connection(conn));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnShellDamagePlayer(ObjectHandle shell, ObjectHandle player, float damage)
    {
        return GlobalHandler.OnShellDamagePlayer(new Shell(shell), new Player(player), damage);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnShellExplode(ObjectHandle shell)
    {
        return GlobalHandler.OnShellExplode(new Shell(shell));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnLog(IntPtr message)
    {
        GlobalHandler.OnOnLog(Marshal.PtrToStringUTF8(message)!);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static bool OnFineItem(ObjectHandle item, int fineid)
    {
        return GlobalHandler.OnFineItem(new Items(item), fineid);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnCreateItem(ObjectHandle item)
    {
        GlobalHandler.OnOnCreateItem(new Items(item));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnRemoveItem(ObjectHandle item)
    {
        GlobalHandler.OnOnRemoveItem(new Items(item));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnCreateNPC(ObjectHandle npc)
    {
        GlobalHandler.OnOnCreateNPC(new NPC(npc));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnRemoveNPC(ObjectHandle npc)
    {
        GlobalHandler.OnOnRemoveNPC(new NPC(npc));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnCreateCorpse(ObjectHandle corpse)
    {
        GlobalHandler.OnOnCreateCorpse(new Corpse(corpse));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnRemoveCorpse(ObjectHandle corpse)
    {
        GlobalHandler.OnOnRemoveCorpse(new Corpse(corpse));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnCreateObject(ObjectHandle obj)
    {
        GlobalHandler.OnOnCreateObject(new Object(obj));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnRemoveObject(ObjectHandle obj)
    {
        GlobalHandler.OnOnRemoveObject(new Object(obj));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnCreateLight(ObjectHandle light)
    {
        GlobalHandler.OnOnCreateLight(new Light(light));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnRemoveLight(ObjectHandle light)
    {
        GlobalHandler.OnOnRemoveLight(new Light(light));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnCreateGUIElement(ObjectHandle element)
    {
        GlobalHandler.OnOnCreateGUIElement(new GUIElement(element));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnRemoveGUIElement(ObjectHandle element)
    {
        GlobalHandler.OnOnRemoveGUIElement(new GUIElement(element));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnCreateShell(ObjectHandle shell)
    {
        GlobalHandler.OnOnCreateShell(new Shell(shell));
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvStdcall)])]
    private static void OnOnRemoveShell(ObjectHandle shell)
    {
        GlobalHandler.OnOnRemoveShell(new Shell(shell));
    }

    internal static unsafe void RegisterEventFunctions()
    {
        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnInitialize()", (IntPtr)(delegate* unmanaged[Stdcall]<void>)(&OnOnInitialize));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnTerminate()", (IntPtr)(delegate* unmanaged[Stdcall]<void>)(&OnOnTerminate));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_ServerUpdate()", (IntPtr)(delegate* unmanaged[Stdcall]<void>)(&OnServerUpdate));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_ServerConsole(const char)", (IntPtr)(delegate* unmanaged[Stdcall]<IntPtr, bool>)(&OnServerConsole));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_ServerRestart()", (IntPtr)(delegate* unmanaged[Stdcall]<void>)(&OnServerRestart));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_WorldLoaded()", (IntPtr)(delegate* unmanaged[Stdcall]<void>)(&OnWorldLoaded));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_WorldUpdate()", (IntPtr)(delegate* unmanaged[Stdcall]<void>)(&OnWorldUpdate));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerUpdate(Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnPlayerUpdate));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerConnect(Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnPlayerConnect));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerDisconnect(Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnPlayerDisconnect));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerChat(Player, const char)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, IntPtr, bool>)(&OnPlayerChat));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerAttachesUpdate(Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnPlayerAttachesUpdate));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerTakeItem(Player, Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, bool>)(&OnPlayerTakeItem));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerDropItem(Player, Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, bool>)(&OnPlayerDropItem));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerDialogAction(Player, int, bool, const char, int)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int, bool, IntPtr, int, void>)(&OnPlayerDialogAction));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerShootPlayer(Player, Player, float, float, float, float, bool)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, float, float, float, float, bool, bool>)(&OnPlayerShootPlayer));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerShoot(Player, Items, int)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, int, bool>)(&OnPlayerShoot));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerPressPlayer(Player, Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerPressPlayer));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerConsole(Player, const char)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, IntPtr, bool>)(&OnPlayerConsole));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerDeath(Player, Corpse)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerDeath));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerRespawn(Player)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnPlayerRespawn));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerHitPlayer(Player, Player, int, float)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, int, float, void>)(&OnPlayerHitPlayer));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerExploreCorpse(Player, Corpse)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, bool>)(&OnPlayerExploreCorpse));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerClickObject(Player, Object)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerClickObject));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerShootObject(Player, Object)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerShootObject));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerUseDoorButton(Player, Door, Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, ObjectHandle, bool>)(&OnPlayerUseDoorButton));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerUseItem(Player, Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, bool>)(&OnPlayerUseItem));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerSelectItem(Player, Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, bool>)(&OnPlayerSelectItem));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerUse914(Player, int)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int, void>)(&OnPlayerUse914));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerSelectGUI(Player, GUIElement)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerSelectGUI));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerVoice(Player, int, bool)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int, bool, bool>)(&OnPlayerVoice));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerTeleportElevator(Player, Room, Entity, Entity, float, float)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, ObjectHandle, ObjectHandle, float, float, void>)(&OnPlayerTeleportElevator));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerShootNPC(Player, NPC)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, void>)(&OnPlayerShootNPC));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_PlayerKeyAction(Player, int, int)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int, int, void>)(&OnPlayerKeyAction));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_PlayerSpectateAction(Player, Player, int)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, int, bool>)(&OnPlayerSpectateAction));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_IncomingConnection(Connection)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnIncomingConnection));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_ConnectionLoaded(Connection)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, bool>)(&OnConnectionLoaded));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_ConnectionClosed(Connection)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnConnectionClosed));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_ShellDamagePlayer(Shell, Player, float)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, ObjectHandle, float, bool>)(&OnShellDamagePlayer));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_ShellExplode(Shell)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, bool>)(&OnShellExplode));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnLog(const char)", (IntPtr)(delegate* unmanaged[Stdcall]<IntPtr, void>)(&OnOnLog));

        NativeBindings.RegisterGlobalFunction("bool ccb::internal::invoke_FineItem(Items, int)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, int, bool>)(&OnFineItem));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnCreateItem(Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnCreateItem));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnRemoveItem(Items)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnRemoveItem));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnCreateNPC(NPC)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnCreateNPC));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnRemoveNPC(NPC)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnRemoveNPC));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnCreateCorpse(Corpse)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnCreateCorpse));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnRemoveCorpse(Corpse)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnRemoveCorpse));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnCreateObject(Object)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnCreateObject));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnRemoveObject(Object)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnRemoveObject));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnCreateLight(Light)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnCreateLight));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnRemoveLight(Light)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnRemoveLight));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnCreateGUIElement(GUIElement)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnCreateGUIElement));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnRemoveGUIElement(GUIElement)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnRemoveGUIElement));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnCreateShell(Shell)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnCreateShell));

        NativeBindings.RegisterGlobalFunction("void ccb::internal::invoke_OnRemoveShell(Shell)", (IntPtr)(delegate* unmanaged[Stdcall]<ObjectHandle, void>)(&OnOnRemoveShell));
    }
}

internal abstract class EventHandler
{
    public abstract void OnOnInitialize();

    public abstract void OnOnTerminate();

    public abstract void OnServerUpdate();

    public abstract bool OnServerConsole(string command);

    public abstract void OnServerRestart();

    public abstract void OnWorldLoaded();

    public abstract void OnWorldUpdate();

    public abstract void OnPlayerUpdate(Player player);

    public abstract void OnPlayerConnect(Player player);

    public abstract void OnPlayerDisconnect(Player player);

    public abstract bool OnPlayerChat(Player player, string text);

    public abstract void OnPlayerAttachesUpdate(Player player);

    public abstract bool OnPlayerTakeItem(Player player, Items item);

    public abstract bool OnPlayerDropItem(Player player, Items item);

    public abstract void OnPlayerDialogAction(Player player, int index, bool response, string input, int selecteditem);

    public abstract bool OnPlayerShootPlayer(Player shooter, Player dest, float x, float y, float z, float damage, bool headshot);

    public abstract bool OnPlayerShoot(Player player, Items item, int weaponattach);

    public abstract void OnPlayerPressPlayer(Player src, Player dest);

    public abstract bool OnPlayerConsole(Player player, string input);

    public abstract void OnPlayerDeath(Player player, Corpse corpse);

    public abstract void OnPlayerRespawn(Player player);

    public abstract void OnPlayerHitPlayer(Player src, Player dest, int mousedata, float distance);

    public abstract bool OnPlayerExploreCorpse(Player player, Corpse corpse);

    public abstract void OnPlayerClickObject(Player player, Object @object);

    public abstract void OnPlayerShootObject(Player player, Object @object);

    public abstract bool OnPlayerUseDoorButton(Player player, Door door, Items useditem);

    public abstract bool OnPlayerUseItem(Player player, Items item);

    public abstract bool OnPlayerSelectItem(Player player, Items item);

    public abstract void OnPlayerUse914(Player player, int fineid);

    public abstract void OnPlayerSelectGUI(Player player, GUIElement element);

    public abstract bool OnPlayerVoice(Player player, int bank, bool radio);

    public abstract void OnPlayerTeleportElevator(Player player, Room room, Entity firstentity, Entity secondentity, float offsetx, float offsety);

    public abstract void OnPlayerShootNPC(Player player, NPC npc);

    public abstract void OnPlayerKeyAction(Player player, int newmask, int prevmask);

    public abstract bool OnPlayerSpectateAction(Player player, Player target, int mode);

    public abstract void OnIncomingConnection(Connection conn);

    public abstract bool OnConnectionLoaded(Connection conn);

    public abstract void OnConnectionClosed(Connection conn);

    public abstract bool OnShellDamagePlayer(Shell shell, Player player, float damage);

    public abstract bool OnShellExplode(Shell shell);

    public abstract void OnOnLog(string message);

    public abstract bool OnFineItem(Items item, int fineid);

    public abstract void OnOnCreateItem(Items item);

    public abstract void OnOnRemoveItem(Items item);

    public abstract void OnOnCreateNPC(NPC npc);

    public abstract void OnOnRemoveNPC(NPC npc);

    public abstract void OnOnCreateCorpse(Corpse corpse);

    public abstract void OnOnRemoveCorpse(Corpse corpse);

    public abstract void OnOnCreateObject(Object obj);

    public abstract void OnOnRemoveObject(Object obj);

    public abstract void OnOnCreateLight(Light light);

    public abstract void OnOnRemoveLight(Light light);

    public abstract void OnOnCreateGUIElement(GUIElement element);

    public abstract void OnOnRemoveGUIElement(GUIElement element);

    public abstract void OnOnCreateShell(Shell shell);

    public abstract void OnOnRemoveShell(Shell shell);
}
