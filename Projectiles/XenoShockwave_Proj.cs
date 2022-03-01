using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeviantAnomalyRedemptionStuff.Projectiles
{
	internal class XenoShockwave_Proj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.arrow = true;
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.tileCollide = false;
			aiType = ProjectileID.Bullet;
			projectile.timeLeft = 20;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			Mod DARSMod = ModLoader.GetMod("DeviantAnomalyRedemptionStuff");
			Projectile.NewProjectile(projectile.Center, projectile.velocity, DARSMod.ProjectileType ("XenoShockwaveSpark_Proj"), projectile.damage, projectile.knockBack, projectile.owner);
        }

		public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}

		public override void AI()
		{
			int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 75, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.2f);
			Main.dust[num].position = (Main.dust[num].position + projectile.Center) / 2f;
			Main.dust[num].noGravity = true;
			Main.dust[num].color = new Color(0, 255, 0);
			if (Main.rand.Next(3) == 0)
			{
			Main.dust[num].scale *= 2f;
			}
		}

	}
}