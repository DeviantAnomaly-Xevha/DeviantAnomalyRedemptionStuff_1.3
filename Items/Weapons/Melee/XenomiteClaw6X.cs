using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Redemption.Dusts;

namespace DeviantAnomalyRedemptionStuff.Items.Weapons.Melee
{
	public class XenomiteClaw6X : ModItem
	{
		public static short customGlowMask = 0;

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Xenium Claw");
			Mod RedeMod = ModLoader.GetMod("Redemption");
			if(RedeMod != null)
			Tooltip.SetDefault("[i:" + RedeMod.ItemType("BluePrints") + "]Large and deadly!");
			else {
			Tooltip.SetDefault("Large and deadly!");
			}
    if (Main.netMode != NetmodeID.Server)
    {
        Texture2D[] glowMasks = new Texture2D[Main.glowMaskTexture.Length + 1];
        for (int i = 0; i < Main.glowMaskTexture.Length; i++)
        {
            glowMasks[i] = Main.glowMaskTexture[i];
        }
        glowMasks[glowMasks.Length - 1] = mod.GetTexture("Items/Weapons/Melee/" + GetType().Name + "_Glow");
        customGlowMask = (short)(glowMasks.Length - 1);
        Main.glowMaskTexture = glowMasks;
    }
    item.glowMask = customGlowMask;
		}


		public override void SetDefaults() 
		{
			item.glowMask = customGlowMask;
			item.damage = 480;
			item.melee = true;
			item.width = 44;
			item.height = 22;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 320000;
			item.rare = 12;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = false;
			item.crit = 26;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Mod RedeMod = ModLoader.GetMod("Redemption");
			if (RedeMod != null) {
			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<XenoDust>(), 0f, 0f, 0, default(Color), 1f);
				}
			}
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
		drawHands = false;// This doesn't work. Please help me figure out layering so these claws can be in front, like a Bladed Glove.
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod RedeMod = ModLoader.GetMod("Redemption");
			Mod DARSMod = ModLoader.GetMod("DeviantAnomalyRedemptionStuff");
			if (RedeMod != null) {
			recipe.AddIngredient(DARSMod.ItemType("XenomiteClaw5"));
			recipe.AddIngredient(RedeMod.ItemType("XeniumBar"), 15);
			recipe.AddIngredient(RedeMod.ItemType("BluePrints"), 1);
			recipe.AddTile(RedeMod.TileType("XenoTank1"));//Xenium Refinery
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			if (RedeMod != null) {
			recipe.AddIngredient(DARSMod.ItemType("XenomiteClaw5b"));
			recipe.AddIngredient(RedeMod.ItemType("XeniumBar"), 15);
			recipe.AddIngredient(RedeMod.ItemType("BluePrints"), 1);
			recipe.AddTile(RedeMod.TileType("XenoTank1"));//Xenium Refinery
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			if (RedeMod != null) {
			recipe.AddIngredient(DARSMod.ItemType("XenomiteClaw5X"));
			recipe.AddIngredient(RedeMod.ItemType("XeniumBar"), 15);
			recipe.AddIngredient(RedeMod.ItemType("BluePrints"), 1);
			recipe.AddTile(RedeMod.TileType("XenoTank1"));//Xenium Refinery
			recipe.SetResult(this);
			recipe.AddRecipe();}
			else {
					}
				}
			}
		}
	}
}