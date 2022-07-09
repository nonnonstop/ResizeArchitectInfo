using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace ResizeArchitectInfo
{
    [HarmonyPatch(typeof(ArchitectCategoryTab), "InfoRect", MethodType.Getter)]
    public class InfoRectPatch
    {
        public static void Postfix(ref Rect __result)
        {
            var settings = LoadedModManager.GetMod<MyMod>().GetSettings<MyModSettings>();
            __result.y += 270f - settings.height;
            __result.width += settings.width - 200f;
            __result.height += settings.height - 270f;
        }
    }
}
