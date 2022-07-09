using UnityEngine;
using Verse;

namespace ResizeArchitectInfo
{
    public class MyModSettings : ModSettings
    {
        public float width = 200f;
        public string widthBuf;
        public float height = 270f;
        public string heightBuf;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref width, "width", 200f);
            Scribe_Values.Look(ref height, "height", 270f);
            base.ExposeData();
        }

        public void DoSettingsWindowContents(Rect inRect)
        {
            var listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.TextFieldNumericLabeled(
                "ResizeArchitectInfo.Width".Translate(),
                ref width, ref widthBuf, 0f, 7680f);
            listingStandard.TextFieldNumericLabeled(
                "ResizeArchitectInfo.Height".Translate(),
                ref height, ref heightBuf, 0f, 7680f);
            listingStandard.End();
        }
    }
}
