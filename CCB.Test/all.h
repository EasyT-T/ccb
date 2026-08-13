class Audio
{
    Sound Play3DSound(string& in filenameorurl, Player player, float range, float volume, bool norange = false) ;
    Sound Play3DSound(string& in filenameorurl, Entity entity, float range, float volume, bool norange = false) ;
    Sound Play3DSound(string& in filenameorurl, float x, float y, float z, float range, float volume, bool norange = false) ;
    Sound PlaySound(string& in filenameorurl) ;
    Sound PlaySoundForPlayer(Player player, string& in filenameorurl) ;
    Sound Play3DSoundForPlayer(Player player, string& in filenameorurl, Entity entity, float range, float volume, bool norange = false) ;
    Sound Play3DSoundForPlayer(Player player, string& in filenameorurl, float x, float y, float z, float range, float volume, bool norange = false) ;
    Sound Play3DSoundForPlayer(Player player, string& in filenameorurl, Player player, float range, float volume, bool norange = false) ;
}
class Chat
{
    void Send(string& in message) ;
    void SendPlayer(Player player, string& in message) ;
}
class Config
{
    bool Exist(string& in key, int index = 0) ;
    string& Get(string& in key, int index = 0) ;
    void Remove() ;
}
class Connection
{
    int GetPort() ;
    string& GetName() ;
    string& GetLanguage() ;
    string& GetHWID(int wmid = 0) ;
    string& GetIP() ;
    string& GetSteamID() ;
    int GetQueue() ;
    bool Join() ;
    void Accept() ;
    void Cancel(int code) ;
    void Cancel(string& in custom = "") ;
    void Remove() ;
}
class Corpse
{
    int GetIndex() ;
    Player GetPlayer() ;
    Entity GetEntity() ;
    float GetTimeout() ;
    void SetTimeout(float) ;
    bool PushItem(Items) ;
    bool ExploreItem(int slot) ;
    Items GetItem(int slot) ;
    int GetModel() ;
    int GetItemsCount() ;
    bool IsExplored() ;
    void SetExplore(bool explore) ;
    bool Explore() ;
    void SetData(string& in data) ;
    string& GetData() ;
    void Remove() ;
}
class Door
{
    void Use() ;
    void SetOpen(bool) ;
    bool IsOpened() ;
    bool IsBreak() ;
    void SetLockState(int) ;
    int GetLockState() ;
    float GetOpenState() ;
    bool BreakDoor(float x, float y, float z) ;
    void Decompose() ;
    int GetDoorAccess() ;
    int GetDoorType() ;
    void SetKeycard(int) ;
    int GetKeycard() ;
    Entity GetEntity() ;
    Entity GetButton(int index) ;
    int GetIndex() ;
}
class Entity
{
    void SetPosition(float x, float y, float z, bool global = false) ;
    void SetRotation(float pitch, float yaw, float roll, bool global = false) ;
    void SetScale(float x, float y, float z, bool global = false) ;
    float PositionX(bool global = false, float tween = 1.0) ;
    float PositionY(bool global = false, float tween = 1.0) ;
    float PositionZ(bool global = false, float tween = 1.0) ;
    void Translate(float x, float y, float z, bool global = false) ;
    void Move(float x, float y, float z, bool global = false) ;
    float Pitch(bool global = false, float tween = 1.0) ;
    float Yaw(bool global = false, float tween = 1.0) ;
    float Roll(bool global = false, float tween = 1.0) ;
    float Turn(float pitch, float yaw, float roll, bool global = false) ;
    float ScaleX(bool global = false, float tween = 1.0) ;
    float ScaleY(bool global = false, float tween = 1.0) ;
    float ScaleZ(bool global = false, float tween = 1.0) ;
    void SetAnimTime(float time, int sequence = 0) ;
    float GetAnimTime() ;
    float Point(Entity target, float roll = 0.0) ;
    Entity Pick(float distance) ;
    void SetPickMode(int pickmode, bool obscurer = false) ;
    bool Visible(Entity target, float radius = 0.0f) ;
    float Distance(Entity target) ;
    float DistanceSquared(Entity target) ;
    void SetParent(Entity target, bool retain = true) ;
    Entity GetParent() ;
    int CountChildren() ;
    Entity GetChild(int) ;
    string& GetName() ;
    void SetName(string& in name) ;
    bool Collided(int colltype) ;
    int CountCollisions() ;
    float CollisionX(int index) ;
    float CollisionY(int index) ;
    float CollisionZ(int index) ;
    float CollisionNX(int index) ;
    float CollisionNY(int index) ;
    float CollisionNZ(int index) ;
    float CollisionImpulse(int index) const ;
    float CollisionDistance(int index) const ;
    float CollisionTime(int index) const ;
    Entity CollisionEntity(int index) const ;
    int CollisionTriangle(int index) const ;
    void SetType(int colltype, bool recursive = false) ;
    void SetRadius(float x, float y = 0.0) ;
    void SetCylinder(float x_radius, float y_radius = 0.0) ;
    void SetBox(float x, float y, float z, float w, float h, float d) ;
    int GetType() const ;
    int GetShape(float &out x, float &out y, float &out z, float &out width, float &out height, float &out depth) const ;
    void Reset() ;
    bool InView(Entity target) ;
    void Show() ;
    void Hide() ;
    void Remove() ;
    void SetMass(float mass) ;
    void SetPhysics(bool enable) ;
    void SetKinematic(bool enable) ;
    void SetCenter(float x, float y, float z) ;
    void SetLinearCast(bool enable) ;
    void SetFriction(float friction) ;
    void SetRollFriction(float friction) ;
    void SetRestitution(float res) ;
    void SetGravity(float factor) ;
    void SetLinearFactor(float x, float y, float z) ;
    void SetAngularFactor(float x, float y, float z) ;
    void SetLinearDamping(float damping) ;
    void SetAngularDamping(float damping) ;
    void SetConstraint(float normalAngle, float planeAngle, float twistMinAngle, float twistMaxAngle, float torqueFriction) ;
    void Activate(bool enable) ;
    void Sleep(bool enable) ;
    void Freeze(bool enable) ;
    bool IsFreezed() const ;
    bool IsActive() const ;
    void SetLinearVelocity(float x, float y, float z) ;
    void SetAngularVelocity(float x, float y, float z) ;
    void GetLinearVelocity(float &out x, float &out y, float &out z) const ;
    void GetAngularVelocity(float &out x, float &out y, float &out z) const ;
    void Impulse(float x, float y, float z) ;
    void Torque(float x, float y, float z) ;
    void ClearForces() ;
}
class Event
{
    Room GetRoom() ;
    int GetIndex() ;
    int GetIdentifier() ;
    float GetState() ;
    float GetState2() ;
    float GetState3() ;
    float GetState4() ;
    float SetState(float state) ;
    float SetState2(float state) ;
    float SetState3(float state) ;
    float SetState4(float state) ;
    void Remove() ;
}
class GUIElement
{
    void GetPosition(float& out x, float& out y) ;
    void SetPosition(float x, float y) ;
    void SetScale(float width, float height) ;
    void GetScale(float& out width, float& out height) ;
    void SetRotation(int degrees) ;
    void GetRotation(int& out degrees) ;
    void SetData(string& in data) ;
    void SetText(string& in text) ;
    void SetFont(int fontid) ;
    void SetSelectable(bool selectable) ;
    void SetShadow(bool shadowed) ;
    void SetAspect(bool keep) ;
    void SetOpacity(float target, float lerp) ;
    void SetColor(int r, int g, int b) ;
    void SetTechnique(string& in technique) ;
    Player GetPlayer() ;
    void SetAttach(Player player) ;
    void SetAttach(bool enable, float x = 0.0, float y = 0.0, float z = 0.0) ;
    Player GetAttach() ;
    bool GetAttach(float& out x, float& out y, float& out z) ;
    int GetFont() ;
    string& GetText() ;
    string& GetData() ;
    bool IsSelectable() ;
    bool IsHidden() ;
    void SetCallback(string& in funcname) ;
    void SetCallback(GUICALLBACK @gc) ;
    void Hide() ;
    void Show() ;
    void Remove() ;
}
class Graphics
{
    GUIElement CreateOval(Player player, float x, float y, float width, float height, bool align = false) ;
    GUIElement CreateRect(Player player, float x, float y, float width, float height, bool align = false) ;
    GUIElement CreateProgressBar(Player player, float time, float x, float y, float width, float height, bool align = false) ;
    GUIElement CreateProgressBar(Player player, float time, float x, float y, float width, float height, bool align, string &in callback) ;
    GUIElement CreateProgressBar(Player player, float time, float x, float y, float width, float height, bool align, ref &in callback) ;
    GUIElement CreateText(Player player, int fontid, string& in text, float x, float y, bool align = false) ;
    GUIElement CreateImage(Player player, string& in filename, float x, float y, float width, float height, bool align = false) ;
    GUIElement CreatePostEffect(Player player, string& in filename, string& in defines = "") ;
}
class Items
{
    bool IsPicked() ;
    Player GetPicker() ;
    bool SetPicker(Player player, float throwforce = 0.0) ;
    Entity GetEntity() ;
    int GetIndex() ;
    string& GetName() ;
    string& GetTemplateName() ;
    int GetTemplateIndex() ;
    bool IsWeapon() ;
    void SetState(float state) ;
    void SetState2(float state) ;
    void SetState3(float state) ;
    float GetState() ;
    float GetState2() ;
    float GetState3() ;
    Items Fine(int) ;
    int GetSlots() ;
    Items GetParentItem() ;
    Items GetSlotItem(int) ;
    bool PushItem(Items) ;
    bool RemoveSlotItem(int) ;
    void Remove() ;
}
class Light
{
    int GetIndex() ;
    void SetFOV(float fov) ;
    void SetRange(float range) ;
    void SetScattering(float scattering) ;
    void SetColor(int r, int g, int b) ;
    void SetCastShadows(bool shadows) ;
    void SetIntensity(float intensity) ;
    void SetLength(float length) ;
    float GetFOV() ;
    float GetRange() ;
    float GetScattering() ;
    void GetColor(int& out r, int& out g, int& out b) ;
    bool GetCastShadows() ;
    float GetIntensity() ;
    float GetLength() ;
    void SetAttach(Player player) ;
    Player GetAttach() ;
    void SetRoom(Room) ;
    Room GetRoom() ;
    Entity GetEntity() ;
    Entity GetLight() ;
    void SetMovement(float speed, float maxdistance) ;
    void Remove() ;
}
class ModelPreset
{
    const string& headbone;
    const string& spinebone;
    const string& handbone;
    const string& forearmbone;
    const int maximumspinepitch;
    const int maximumspinepitchdist;
    const int maximumheadpitch;
    const int fixedspinerotation;
    const bool usedefaultrolls;
    const float offsetyaw;
    const float offsety;
    const float collisionradius;
    const float scale;
    const string& stepsound;
    const float blobshadowsize;
    const float forearmholdingpitch;
    const float forearmholdingyaw;
    const float forearmholdingroll;
    const float holdingitemoffsetx;
    const float holdingitemoffsety;
    const float holdingitemoffsetz;
    const float holdingitemoffsetpitch;
    const float holdingitemoffsetyaw;
    const float holdingitemoffsetroll;
    const float hitboxwidth;
    const float hitboxheight;
    const float hitboxdepth;
    const float speed;
    const float stamina;
    const string& movesound;
    const bool disablejump;
    const int collisiontype;
    const float viewoffsety;
    const bool disableroll;
    const bool disablebloodloss;
    const bool disableinjuries;
    const bool flippitch;
    const bool disableinteractitems;
    const int rotationmode;
    const int comparedspinerotation;
    const int material;
    const bool constantinvisibility;
    const float lightradius;
    const int lightshadows;
    const int lightr;
    const int lightg;
    const int lightb;
    const float lightscattering;
}
class NPC
{
    Entity GetEntity() ;
    Entity GetModel() ;
    void SetPickable(bool pickable) ;
    void SetDead(bool state) ;
    bool IsDead() ;
    void SetHealth(int health) ;
    int GetHealth() ;
    void SetIdle(float state) ;
    void SetState1(float state) ;
    void SetState2(float state) ;
    void SetState3(float state) ;
    float GetIdle() ;
    float GetState1() ;
    float GetState2() ;
    float GetState3() ;
    void Remove() ;
}
class Object
{
    void SetAttach(Player player) ;
    Player GetAttach() ;
    void SetRoom(Room) ;
    Room GetRoom() ;
    int GetIndex() ;
    Entity GetEntity() ;
    Entity GetModel() ;
    void SetMovement(float speed, float maxdistance) ;
    void SetTexture(int textureid) ;
    void SetTouchable(bool val) ;
    void SetClickCallback(OBJECTCALLBACK@ callback) ;
    void Remove() ;
}
class Player
{
    Entity GetHitbox() ;
    Entity GetHead() ;
    Entity GetEntity() ;
    void GetScreenSize(int& out width, int& out height) ;
    string& GetLanguage() ;
    string& GetIP() ;
    string& GetSteamID() ;
    string& GetHWID(int wmid = 0) ;
    string& GetName() ;
    void SetSteamID(string &in steamid64) ;
    void SetName(string &in name) ;
    int GetPing() ;
    int GetTime() ;
    int GetIndex() ;
    string& GetVersion() ;
    bool IsInvisible() ;
    bool IsInvisibleForPlayer(Player player) ;
    void SetInvisible(bool inv) ;
    void SetLocalInvisible(Player player, bool inv) ;
    void Kick(int code = 0, string& in custom = "") ;
    void ShowDialog(int type, int index, string& in header, string& in message, string& in leftbutton, string& in rightbutton = "", bool align = true) ;
    void ShowDialog(int type, DIALOGCALLBACK@ callback, string& in header, string& in message, string& in leftbutton, string& in rightbutton = "", bool align = true) ;
    void SetDialogData(string& in data) ;
    string& GetDialogData() ;
    void HideDialog() ;
    void SendMessage(string& in message, float time = 6.0, bool localized = false) ;
    void Desync(bool value) ;
    bool IsDesync() ;
    void SetSpectatePlayer(Player target) ;
    void SetSpectateMode(int mode) ;
    Player GetSpectatePlayer() ;
    int GetSpectateMode() ;
    bool Kill(bool bloody = false, bool createcorpse = true) ;
    bool Respawn() ;
    bool IsDead() ;
    void SetInjuries(float val) ;
    float GetInjuries() ;
    void SetBloodloss(float val) ;
    float GetBloodloss() ;
    bool GetGodmode() ;
    void SetGodmode(bool val) ;
    void SetColor(uint hx) ;
    uint GetColor() ;
    void GetNetworkPosition(float& out x, float& out y, float& out z) ;
    void GetNetworkRotation(float& out pitch, float& out yaw) ;
    void SetNetworkPosition(float x, float y, float z) ;
    void SetNetworkRotation(float pitch, float yaw) ;
    void SetPosition(float x, float y, float z, Room room = NULL, bool updatepivot = true) ;
    void SetRotation(float pitch, float yaw) ;
    void Teleport(Room room, float x, float y, float z, bool updatepivot = true) ;
    void SetRoom(Room room) ;
    Room GetRoom() ;
    void SetPositionBounds(Room room, float x = 0.0, float y = 0.0, float z = 0.0, float distance = 0.0) ;
    void Explode(bool thrust = false) ;
    void MovePlayer(float speedmult, float angle) ;
    void IgnoreProximity(bool value) ;
    void SendDamage(Player player, float force, bool headshot, float offsetx, float offsety, float offsetz) ;
    void SetAdmin(bool val) ;
    bool IsAdmin() ;
    void SetGlobalTransmission(bool val) ;
    bool IsGlobalTransmission() ;
    bool SendVoice(int bank, int radio = 0, bool global = false, Player target = NULL) ;
    int GetItemsCount() ;
    Items GetInventory(int) ;
    Items GetSelectedItem() ;
    float GetBlinkTimer() ;
    void SetBlinkTimer(float time) ;
    bool IsBlinking() ;
    void SetBlinkEffect(float effectvalue, float time) ;
    void GetBlinkEffect(float &out effectvalue, float &out time) ;
    void EnableBlinking(bool blink) ;
    bool IsBlinkingEnabled() ;
    int GetRadio() ;
    void PlayAnimation(int animid) ;
    void SetNetworkAnimation(int animid) ;
    void SetAnimation(int animid) ;
    int GetAnimation() ;
    void SetSpeedMultiplier(float multiplier) ;
    void SetStaminaMultiplier(float multiplier) ;
    float GetSpeedMultiplier() ;
    float GetStaminaMultiplier() ;
    void SetAttach(int bodyindex, int attachmodelindex, Items item = NULL) ;
    int GetAttach(int bodyindex) ;
    Items GetAttachItem(int bodyindex) ;
    int GetModel() ;
    void SetModel(int modelid, int textureid = -1) ;
    void SetModelSize(float) ;
    float GetModelSize() ;
    void SetModelTexture(int textureid) ;
    int GetModelTexture() ;
    void SetCollisionRadius(float) ;
    float GetCollisionRadius() ;
    float GetVolume() ;
    bool IsCrouch() ;
    void SetGravity(float multiplier) ;
    float GetGravity() ;
    void SetTagText(int index, string& in) ;
    void SetTagScales(int index, float, float) ;
    void SetTagOffset(int index, float) ;
    void SetTagColors(int index, int, int) ;
    void SetTagFont(int index, string& in) ;
    string& GetTagText(int index) ;
    void GetTagScales(int index, float&out scalex, float&out scaley) ;
    float GetTagOffset(int index) ;
    void GetTagColors(int index, uint&out start, uint&out end) ;
    string& GetTagFont(int index) ;
    int GetShootsCount() ;
    void SetShootsCount(int count) ;
    void RedirectMove(bool move) ;
    bool IsBot() ;
    bool IsAiming() ;
    void SetWearData(int bodyindex, Items item) ;
    void Console(string& in message) ;
    bool GetKeyState(int keytype) ;
    void GetTeleportData(float&out x, float&out y, float&out z, Room&out room, int&out tick) /* Get latest SetPosition data */;
}
class Room
{
    string& GetName() ;
    int GetIndex() ;
    int GetIdentifier() ;
    Entity GetEntity() ;
    Entity GetObject(int index) ;
    Entity GetLever(int index) ;
    bool IsAdjacent(Room) ;
    Room GetAdjacentRoom(int index) ;
    Door GetAdjacentDoor(int index) ;
    Door GetDoor(int) ;
    bool IsInside(Entity) ;
}
class Server
{
    void Restart() ;
    void Console(string& in) ;
    string& GetVersion() ;
    void AddVersion(string& in version) ;
    void RemoveVersion(string& in version) ;
    int GetUPS() ;
    Config ParseConfig(string& in filename) ;
    string& hostname;
    int port;
    int corpsealivetime;
    int timeout;
    bool chat;
    bool console;
    int voicebitrate;
    int maxplayers;
    string& mapseed;
    string& adminpassword;
    int difficulty;
    string& gamemode;
    int emptybehaviour;
    bool scriptsautoload;
    bool disablenpcs;
    float proximityplayers;
    float mapbounds;
    int respawntime;
    string& contenturl;
    string& password;
    bool improvedgates;
    int mapsize;
    bool allowjump;
    string& description;
    bool fastslots;
    float gravity;
    int holiday;
    string& addonsfile;
    bool enablehud;
    int max_items;
    int max_objects;
    int max_corpses;
    int max_lights;
    bool player_culling;
    bool steam_auth;
    bool fall_damage;
}
class Shell
{
    Entity GetEntity();
    int GetIndex() ;
    void GetVelocity(float& out x, float& out y, float& out z) ;
    string& GetActionEmitter() ;
    int GetEmitter() ;
    string& GetActionSound() ;
    string& GetCollisionSound() ;
    string& GetSound() ;
    float GetSpeed() ;
    float GetForce() ;
    float GetRestitution() ;
    float GetGravity() ;
    float GetCollisionRadius() ;
    float GetDamage() ;
    float GetTimeout() ;
    float GetImpactTime() ;
    int GetAction() ;
    float GetActionRadius() ;
    bool IsSticky() ;
    uint GetStickFlags() ;
    int GetStickIndex() ;
    int GetWeapon() ;
    Player GetShooter() ;
    void Unstick() ;
    void SetSticky(bool sticky) ;
    void SetVelocity(float x, float y, float z) ;
    void SetActionEmitter(string& in emitters) ;
    void SetEmitter(int id) ;
    void SetActionSound(string& in sound) ;
    void SetCollisionSound(string& in sound) ;
    void SetSound(string& in sound) ;
    void SetSpeed(float speed) ;
    void SetForce(float force) ;
    void SetRestitution(float restitution) ;
    void SetGravity(float gravity) ;
    void SetCollisionRadius(float radius) ;
    void SetTimeout(float time) ;
    void SetImpactTime(float time) ;
    void SetDamage(float damage) ;
    void SetAction(int action) ;
    void SetActionRadius(float radius) ;
    void SetShooter(Player player) ;
    void Remove(bool action = false) ;
}
class Sound
{
    void SetVolume(float vol) ;
    void Seek(float time) ;
    void Stop() ;
}
class Waypoint
{
    Entity GetEntity() ;
    Door GetDoor() ;
    Room GetRoom() ;
}
class World
{
    void CreateDecal(int decalid, float x, float y, float z, float pitch, float yaw, float roll, Room room = NULL, float lifetime = 1.0f, float alpha = 1.0f, float size = 1.0f, float sizechange = 0.0f, float maxsize = 1.0f, float alphachange = 0.0f, int r = 0, int g = 0, int b = 0, float timer = 0.0);
    void CreateEmitter(Player target, int id, float x, float y, float z) ;
    void CreateEmitter(Player target, int id, float x, float y, float z, Player attachPlayer) ;
    void CreateEmitter(Player target, int id, float x, float y, float z, Object attachObject) ;
    Waypoint FindWaypoint(float fromx, float fromy, float fromz, float targetX, float targetY, float targetZ) ;
    Waypoint FindWaypoint(Entity from, Entity to) ;
    int GetZone(float x, float y, float z) ;
    Player CreateBot(string& in) ;
    void RaycastItems() ;
    Items FindItem(int index) ;
    Items CreateItem(string& in templatename, bool collision = true, float x = 0, float y = 0, float z = 0, int r = 0, int g = 0, int b = 0, float alpha = 1.0, int invslots = 0) ;
    Items CreateItem(int templateindex, bool collision = true, float x = 0, float y = 0, float z = 0, int r = 0, int g = 0, int b = 0, float alpha = 1.0, int invslots = 0) ;
    Room GetRoomByName(string& in) ;
    Room GetRoomByIndex(int) ;
    Room GetRoomByIdentifier(int) ;
    Corpse FindCorpse(int index) ;
    Door GetDoor(int) ;
    Event GetEvent(int index) ;
    Event GetEventByIdentifier(int index) ;
    Object CreateObject(int objectid, Room room = NULL, bool animated = false) ;
    Object FindObject(int index) ;
    Light CreateLight(int type, float range = 10.0, Room room = NULL) ;
    Light FindLight(int index) ;
    NPC CreateNPC(int npctype, float x, float y, float z) ;
    NPC GetNPC(int index) ;
    ModelPreset GetModelPreset(int modelid) /* Get model data by modelid */;
    Shell CreateShell(int weaponid, Player shooter = NULL) ;
    Shell FindShell(int index) ;
}