using Microsoft.Xna.Framework.Graphics;

namespace OuterBeyond.Mod
{
    public interface IMod
    {
        void Initialize(THGame game);

        void PreHudDraw(SpriteBatch spriteBatch);
        void PostHudDraw(SpriteBatch spriteBatch);
        void PreSpeedrunUIDraw(SpriteBatch spriteBatch);
        void PostSpeedrunUIDraw(SpriteBatch spriteBatch);
        void PreGameUpdate();
        void OnDoorEnter();
        void PostRoomTransition();
        void PostAreaTransition();
        void OnDamageBoss(THWeapon weapon, THCharacter attacker, ref THCollisionResults collisionResults);
        void OnBossDeathStart();
        void OnBossDeath();
    }
}
