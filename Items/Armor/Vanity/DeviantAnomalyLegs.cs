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
	[AutoloadEquip(EquipType.Legs)]
    public class DeviantAnomalyLegs : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = 5;
            item.vanity = true;
        }

        public override bool DrawLegs()
        {
            return false;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DeviantAnomaly's Legs");
			Tooltip.SetDefault("What's up with your feet?");
		}
    }
}