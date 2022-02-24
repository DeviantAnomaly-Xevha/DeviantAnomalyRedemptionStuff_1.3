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
    public class DeviantAnomalyHead : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = 5;
            item.vanity = true;
        }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DeviantAnomaly's Head");
			Tooltip.SetDefault("Crystals are growing from your head!\n...\nIt's probably fine.");
		}
		public override bool DrawHead()
		{
			return false;
		}
    }
}