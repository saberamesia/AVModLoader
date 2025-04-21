using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OuterBeyond.Mod
{
    public class ModLoader : IModLoader, IMod
    {
        class LoadedMod
        {
            HashSet<string> methodOverridden;
            Mod mod;

            public LoadedMod(HashSet<string> methodOverrides, Mod newMod) { 
                foreach (var methodName in methodOverrides)
                {
                    THDebug.Print(THLogPriority.INFO, $"storing override for method {methodName}");
                }
                methodOverridden = methodOverrides;
                mod = newMod;
            }

            public bool Overrides(string methodName)
            {
                return methodOverridden.Contains(methodName);
            }

            public Mod Mod()
            {
                return mod;
            }
        }

        List<LoadedMod> mods = new List<LoadedMod>();

        public ModLoader() { }

        void LoadMod(string filename)
        {
            var DLL = Assembly.LoadFile(filename);
            var modName = DLL.GetName().Name.Substring(3);
            var modType = DLL.GetType($"{modName}.Mod");
            if (modType == null)
            {
                return;
            }

            var methods = modType.GetMethods();
            HashSet<string> methodOverrides = new HashSet<string>();
            foreach ( var method in methods )
            {
                methodOverrides.Add(method.Name);
            }

            dynamic mod = Activator.CreateInstance(modType);
            THDebug.Print(THLogPriority.INFO, $"Initializing {mod.Name()} {mod.Version()} by {mod.Author()}");
            mod.Initialize(THGame.mGame);
            mods.Add(new LoadedMod(methodOverrides, mod));
            
        }

        public void LoadMods()
        {
            THDebug.Print(THLogPriority.INFO, $"Begin mod loading");

            string searchDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            DirectoryInfo d = new DirectoryInfo(searchDirectory);

            FileInfo[] Files = d.GetFiles("*.dll");

            foreach (FileInfo file in Files)
            {
                THDebug.Print(THLogPriority.INFO, $"Attempting to load mod {file.Name}");
                LoadMod(file.FullName);
            }

            THDebug.Print(THLogPriority.INFO, $"Loaded {mods.Count} mods");
        }

        public void Initialize(THGame game)
        {
            foreach (LoadedMod mod in mods)
            {
                mod.Mod().Initialize(game);
            }
        }

        public void PreHudDraw(SpriteBatch spriteBatch)
        {
            // PreHudDraw is called before several CustomDraws that use a different SpriteBatch state,
            // so it both cannot rely on spriteBatch.Begin already having been called, and it must
            // call spriteBatch.End before it terminates.
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
            foreach (LoadedMod mod in mods)
            {
                if (!mod.Overrides("PreHudDraw")) { continue; }
                mod.Mod().PreHudDraw(spriteBatch);
            }
            spriteBatch.End();
        }

        public void PostHudDraw(SpriteBatch spriteBatch)
        {
            foreach (LoadedMod mod in mods)
            {
                if (!mod.Overrides("PostHudDraw")) { continue; }

                mod.Mod().PostHudDraw(spriteBatch);
            }
        }

        public void PreSpeedrunUIDraw(SpriteBatch spriteBatch)
        {
            foreach (LoadedMod mod in mods)
            {
                if (!mod.Overrides("PreSpeedrunUIDraw")) { continue; }
                mod.Mod().PreSpeedrunUIDraw(spriteBatch);
            }
        }

        public void PostSpeedrunUIDraw(SpriteBatch spriteBatch)
        {
            foreach (LoadedMod mod in mods)
            {
                if (!mod.Overrides("PostSpeedrunUIDraw")) { continue; }

                mod.Mod().PostSpeedrunUIDraw(spriteBatch);
            }
        }

        public void PreGameUpdate()
        {
            foreach (LoadedMod mod in mods)
            {
                if (!mod.Overrides("PreGameUpdate")) { continue; }

                mod.Mod().PreGameUpdate();
            }
        }

        public void OnDoorEnter()
        {
            foreach (LoadedMod mod in mods)
            {
                if (!mod.Overrides("OnDoorEnter")) { continue; }

                mod.Mod().OnDoorEnter();
            }

        }

        public void PostRoomTransition()
        {
            foreach (LoadedMod mod in mods)
            {
                if (!mod.Overrides("PostRoomTransition")) { continue; }

                mod.Mod().PostRoomTransition();
            }

        }

        public void PostAreaTransition()
        {
            foreach (LoadedMod mod in mods)
            {
                if (!mod.Overrides("PostAreaTransition")) { continue; }

                mod.Mod().PostAreaTransition();
            }
        }

        public void OnDamageBoss(THWeapon weapon, THCharacter attacker, ref THCollisionResults collisionResults)
        {
            foreach (LoadedMod mod in mods)
            {
                if (!mod.Overrides("OnDamageBoss")) { continue; }

                mod.Mod().OnDamageBoss(weapon, attacker, ref collisionResults);
            }
        }

        public void OnBossDeathStart()
        {
            foreach (LoadedMod mod in mods)
            {
                if (!mod.Overrides("OnBossDeathStart")) { continue; }

                mod.Mod().OnBossDeathStart();
            }
        }

        public void OnBossDeath()
        {
            foreach (LoadedMod mod in mods)
            {
                if (!mod.Overrides("OnBossDeath")) { continue; }

                mod.Mod().OnBossDeath();
            }
        }
    }
}
