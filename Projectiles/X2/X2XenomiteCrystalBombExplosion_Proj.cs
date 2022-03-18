using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeviantAnomalyRedemptionStuff.Projectiles.X2
{
	internal class X2XenomiteCrystalBombExplosion_Proj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xenomite Crystal Bomb");
			Main.projFrames[projectile.type] = 8;
		}

		public override void SetDefaults()
		{
			projectile.penetrate = -1;
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 30;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Mod RedeMod = ModLoader.GetMod("Redemption");
			if (RedeMod != null)
			{
				target.AddBuff(RedeMod.BuffType("XenomiteDebuff2"), 203, false);
			}
			else
			{
				target.AddBuff(BuffID.Poisoned, 203, false);
			}
		}

		public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}

		public override void AI()
		{
			projectile.rotation = 0;
			projectile.velocity.X = 0f;
			projectile.velocity.Y = 0f;
			if (++projectile.frameCounter >= 2) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 7) {
					projectile.Kill();
				}
			}

			Lighting.AddLight(projectile.position, 0.16f, 0.76f, 0.19f);
		}

	}
}