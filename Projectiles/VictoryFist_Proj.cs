using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeviantAnomalyRedemptionStuff.Projectiles
{
	internal class VictoryFist_Proj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 5;
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
			drawHeldProjInFrontOfHeldItemAndArms = true;
			Player p = Main.player[projectile.owner];
			p.heldProj = projectile.whoAmI;
			projectile.rotation = 0;
			if (++projectile.frameCounter >= 2) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4) {
					projectile.Kill();
				}
			}
		}

	}
}