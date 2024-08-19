﻿using ResoniteModLoader;

namespace Nexis
{
    /// <summary>
    /// This mod is an implementation based on the example given in https://github.com/resonite-modding-group/ResoniteModLoader/blob/main/doc/making_mods.md.
    /// </summary>
    public class NexisRML : ResoniteMod, INexis
    {
        public override string Name => "Nexis";
        public override string Author => "SkylerZero";
        public override string Version => "1.0.0"; //Version of the mod, should match the AssemblyVersion
        public override string Link => "https://github.com/Skyler-code101/ss";


        //The following
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> enabled = new ModConfigurationKey<bool>("enabled", "Should the mod be enabled", () => true); //Optional config settings

        private static ModConfiguration Config;//If you use config settings, this will be where you interface with them

        public bool Enabled => Config.GetValue(enabled);

        public override void OnEngineInit()
        {
            Config = GetConfiguration(); //Get this mods' current ModConfiguration
            Config.Save(true); //If you'd like to save the default config values to file
            PatchesHarmony.Apply(this);

            //Various log methods provided by the mod loader, below is an example of how they will look
            //3:14:42 AM.069 ( -1 FPS)  [INFO] [ResoniteModLoader/Nexis] a regular log
            Debug("a debug log");
            Msg("a regular log");
            Warn("a warn log");
            Error("an error log");
        }

        public void DoSomething()
        {
            Warn("Hello World!");
        }
    }
}