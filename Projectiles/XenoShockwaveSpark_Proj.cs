using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeviantAnomalyRedemptionStuff.Projectiles
{
	internal class XenoShockwaveSpark_Proj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 8;
		}

		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = 1;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.tileCollide = false;
		}

		public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}

		public override void AI()
		{
			projectile.velocity.X = 0f;
			projectile.velocity.Y = 0f;
			if (++projectile.frameCounter >= 1) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 7) {
					projectile.Kill();
				}
			}
		}

	}
}