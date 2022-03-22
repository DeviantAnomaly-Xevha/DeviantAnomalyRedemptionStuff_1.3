using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DeviantAnomalyRedemptionStuff.Projectiles
{
	internal class VictoryFist_ProjX : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 6;
		}

		public override void SetDefaults()
		{
			projectile.width = 38;
			projectile.height = 50;
			projectile.aiStyle = 1;
			projectile.friendly = false;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.hide = false;
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
				if (++projectile.frame >= 5) {
					projectile.Kill();
				}
			}
		}

	}
}