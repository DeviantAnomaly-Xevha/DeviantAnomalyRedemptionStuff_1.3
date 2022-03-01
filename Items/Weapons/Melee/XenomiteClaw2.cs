using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Redemption.Dusts;

namespace DeviantAnomalyRedemptionStuff.Items.Weapons.Melee
{
	public class XenomiteClaw2 : ModItem
	{
		public static short customGlowMask = 0;

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Xenomite Claw");
			Mod RedeMod = ModLoader.GetMod("Redemption");
			if(RedeMod != null)
			Tooltip.SetDefault("[i:" + RedeMod.ItemType("Xenomite") + "]Less small, more deadly... and infectious!\nHolding this may infect you...");
			else {
			Tooltip.SetDefault("Less small, more deadly... and poisonous!\nHolding this may poison you...");
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
			item.damage = 40;
			item.melee = true;
			item.width = 28;
			item.height = 21;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 20000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = false;
			item.crit = 6;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			Mod RedeMod = ModLoader.GetMod("Redemption");
			if (RedeMod != null) {
			target.AddBuff(RedeMod.BuffType("XenomiteDebuff"), 203);
			}
			else {
			target.AddBuff(BuffID.Poisoned, 203);
			}
		}

		public override void HoldItem(Player player)
		{
			Mod RedeMod = ModLoader.GetMod("Redemption");
			if (RedeMod != null) {
			player.AddBuff(RedeMod.BuffType("XenomiteDebuff"), 203);
			}
			else {
			player.AddBuff(BuffID.Poisoned, 203);
			}
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
			recipe.AddIngredient(DARSMod.ItemType("XenomiteClaw1"));
			recipe.AddIngredient(RedeMod.ItemType("Xenomite"), 10);
			recipe.AddIngredient(RedeMod.ItemType("StarliteBar"), 5);
			recipe.AddTile(134);//Mythril or Orichalcum Anvil
			recipe.SetResult(this);
			recipe.AddRecipe();}
			else {
			}
		}
	}
}