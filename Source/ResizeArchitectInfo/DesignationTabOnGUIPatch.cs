using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ResizeArchitectInfo
{
    [HarmonyPatch(typeof(ArchitectCategoryTab), "DesignationTabOnGUI")]
    public class DesignationTabOnGUIPatch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var getHeightMethod = SymbolExtensions.GetMethodInfo(() => GetHeight());

            var found = false;
            foreach (var instruction in instructions)
            {
                if (!found && instruction.LoadsConstant(MyModSettings.DefaultHeight))
                {
                    found = true;
                    yield return new CodeInstruction(OpCodes.Call, getHeightMethod);
                }
                else
                {
                    yield return instruction;
                }
            }

            if (!found)
                Log.Error("[ResizeArchitectInfo] Cannot find target instruction");
        }

        public static float GetHeight()
        {
            var settings = LoadedModManager.GetMod<MyMod>().GetSettings<MyModSettings>();
            return settings.height;
        }
    }
}
