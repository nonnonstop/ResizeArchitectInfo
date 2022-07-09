using HarmonyLib;
using UnityEngine;
using Verse;

namespace ResizeArchitectInfo
{
    public class MyMod : Mod
    {
        private readonly MyModSettings settings;

        public MyMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<MyModSettings>();
            var harmony = new Harmony("Nonnonstop.ResizeArchitectInfo");
            harmony.PatchAll();
        }

        public override string SettingsCategory()
        {
            return "Resize Architect Info";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoSettingsWindowContents(inRect);
            base.DoSettingsWindowContents(inRect);
        }
    }
}
