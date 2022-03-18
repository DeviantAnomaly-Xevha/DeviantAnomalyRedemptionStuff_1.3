using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Redemption.Dusts;

namespace DeviantAnomalyRedemptionStuff.Items.Weapons.Melee
{
	public class XenomiteClaw5C : ModItem
	{
		public static short customGlowMask = 0;

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Corrupted Xenomite Claw");
			Mod RedeMod = ModLoader.GetMod("Redemption");
			if(RedeMod != null)
			Tooltip.SetDefault("[i:" + ItemID.LunarBar + "]Large and deadly!\nDefense and speed increased in combat.");
			else {
			Tooltip.SetDefault("Large and deadly!\nDefense and speed increased in combat.");
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
			item.damage = 320;
			item.melee = true;
			item.width = 40;
			item.height = 30;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 160000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = false;
			item.crit = 21;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.NextBool(1))
			player.AddBuff(ModLoader.GetMod("DeviantAnomalyRedemptionStuff").BuffType("XenomiteClaw5CBuff"), 120);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Mod RedeMod = ModLoader.GetMod("Redemption");
			if (RedeMod != null) {
			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<VlitchFlame>(), 0f, 0f, 0, default(Color), 1f);
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
			if (RedeMod != null) {
			recipe.AddIngredient(ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteClaw4"));
			recipe.AddIngredient(RedeMod.ItemType("CorruptedXenomite"), 10);
			recipe.AddIngredient(RedeMod.ItemType("CorruptedStarliteBar"), 5);
			recipe.AddIngredient(3467, 5);//Luminite Bars
			recipe.AddTile(412);//Ancient Manipulator
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			if (RedeMod != null) {
			recipe.AddIngredient(ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteClaw4C"));
			recipe.AddIngredient(RedeMod.ItemType("CorruptedXenomite"), 10);
			recipe.AddIngredient(RedeMod.ItemType("CorruptedStarliteBar"), 5);
			recipe.AddIngredient(3467, 5);//Luminite Bars
			recipe.AddTile(412);//Ancient Manipulator
			recipe.SetResult(this);
			recipe.AddRecipe();}
			else {
				}
			}
		}
	}
}