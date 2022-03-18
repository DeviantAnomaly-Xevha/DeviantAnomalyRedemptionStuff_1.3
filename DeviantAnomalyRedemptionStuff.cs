
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace DeviantAnomalyRedemptionStuff
{
    public class DeviantAnomalyRedemptionStuff : Mod
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup XenomiteCrystalBombtier1 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "tier 1/orange Xenomite Crystal Bomb weapon", new int[]
            {
                ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBomb1"),
                ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBomb1b")
            });
            RecipeGroup.RegisterGroup("DeviantAnomalyRedemptionStuff:tier 1/orange Xenomite Crystal Bomb weapon", XenomiteCrystalBombtier1);

            RecipeGroup XenomiteCrystalBombtier2 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "tier 2/light red Xenomite Crystal Bomb weapon", new int[]
            {
                ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBomb2"),
                ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBomb2b")
            });
            RecipeGroup.RegisterGroup("DeviantAnomalyRedemptionStuff:tier 2/light red Xenomite Crystal Bomb weapon", XenomiteCrystalBombtier2);

            RecipeGroup XenomiteCrystalBombtier3 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "tier 3/pink Xenomite Crystal Bomb weapon", new int[]
            {
                ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBomb3"),
                ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBomb3b")
            });
            RecipeGroup.RegisterGroup("DeviantAnomalyRedemptionStuff:tier 3/pink Xenomite Crystal Bomb weapon", XenomiteCrystalBombtier3);

            RecipeGroup XenomiteCrystalBombtier4 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "tier 4/light purple Xenomite Crystal Bomb weapon", new int[]
            {
                ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBomb4"),
                ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBomb4b")
            });
            RecipeGroup.RegisterGroup("DeviantAnomalyRedemptionStuff:tier 4/light purple Xenomite Crystal Bomb weapon", XenomiteCrystalBombtier4);

            RecipeGroup XenomiteCrystalBombtier5 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "tier 5/red Xenomite Crystal Bomb weapon", new int[]
            {
                ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBomb5"),
                ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBomb5b")
            });
            RecipeGroup.RegisterGroup("DeviantAnomalyRedemptionStuff:tier 5/red Xenomite Crystal Bomb weapon", XenomiteCrystalBombtier5);
        }
    }
}