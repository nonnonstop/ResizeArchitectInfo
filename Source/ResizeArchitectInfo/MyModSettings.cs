using UnityEngine;
using Verse;

namespace ResizeArchitectInfo
{
    public class MyModSettings : ModSettings
    {
        public const float DefaultWidth = 200f;
        public const float DefaultHeight = 270f;
        public float width = DefaultWidth;
        public string widthBuf;
        public float height = DefaultHeight;
        public string heightBuf;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref width, "width", DefaultWidth);
            Scribe_Values.Look(ref height, "height", DefaultHeight);
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
