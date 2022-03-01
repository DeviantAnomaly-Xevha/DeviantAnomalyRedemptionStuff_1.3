using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.IO;
using Terraria.ObjectData;
using Terraria.Utilities;
using Terraria.ModLoader;
using Terraria.Localization;

namespace DeviantAnomalyRedemptionStuff.Items.Armor.Vanity
{
	[AutoloadEquip(EquipType.Head)]
    public class DeviantAnomalyHeadHairstyle22 : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = 2;
            item.vanity = true;
        }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DeviantAnomaly's Head - hairstyle 22");
			Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.");
		}
		public override bool DrawHead()
		{
			return false;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod RedeMod = ModLoader.GetMod("Redemption");
			if (RedeMod != null) {
			recipe.AddIngredient(RedeMod.ItemType("XenomiteShard"), 5);
			recipe.AddTile(26);//Demon Altar or Crimson Altar
			recipe.SetResult(this);
			recipe.AddRecipe();}
			else {
			}
		}
    }
}