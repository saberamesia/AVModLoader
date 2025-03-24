using Microsoft.Xna.Framework.Graphics;
using System;

namespace OuterBeyond.Mod
{
    // Contains default do-nothing implementations for mod hooks
    // Mods should inherit this class and override the hooks they wish to utilize.
    public class Mod : IMod
    {
        public virtual string Name()
        {
            // Your mod MUST override Name, and it must return a value even if the mod is not initialized.
            throw new NotImplementedException();
        }

        public virtual string Version()
        {
            // Your mod MUST override Version, and it must return a value even if the mod is not initialized.
            throw new NotImplementedException();
        }

        public virtual string Author()
        {
            // Your mod MUST override Author, and it must return a value even if the mod is not initialized.
            throw new NotImplementedException();
        }

        public virtual void Initialize(THGame game)
        {
            // Your mod MUST override Initialize, even if the function does nothing.
            throw new NotImplementedException();
        }

        public virtual void OnBossDeath()
        {
            
        }

        public virtual void OnBossDeathStart()
        {
            
        }

        public virtual void OnDamageBoss(THWeapon weapon, THCharacter attacker, ref THCollisionResults collisionResults)
        {
            
        }

        public virtual void OnDoorEnter()
        {
            
        }

        public virtual void PostAreaTransition()
        {
            
        }

        public virtual void PostHudDraw(SpriteBatch spriteBatch)
        {
            
        }

        public virtual void PostRoomTransition()
        {
            
        }

        public virtual void PostSpeedrunUIDraw(SpriteBatch spriteBatch)
        {
            
        }

        public virtual void PreGameUpdate()
        {
            
        }

        public virtual void PreHudDraw(SpriteBatch spriteBatch)
        {
            
        }

        public virtual void PreSpeedrunUIDraw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
