using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeviantAnomalyRedemptionStuff.Projectiles.X2
{
    public class X2XenomiteCrystalBombChargedLeftHalf_Proj : ModProjectile
    {
        public float Charge;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Bomb");
            Main.projFrames[projectile.type] = 12;
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 16;
            projectile.aiStyle = 1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.timeLeft = 600;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalPillar_grow"), projectile.position);

            int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 18f, 0, 12f, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType($"X2XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_1_Proj"), (projectile.damage) / 2, 0, projectile.owner);
            Main.projectile[a].aiStyle = 1;
            Main.projectile[a].tileCollide = true;

            int b = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 9f, 0, 12f, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType($"X2XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_2_Proj"), (projectile.damage) / 2, 0, projectile.owner);
            Main.projectile[b].aiStyle = 1;
            Main.projectile[b].position.X = Main.projectile[a].position.X - 25;
            Main.projectile[b].tileCollide = true;

            int c = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 9f, 0, 12f, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType($"X2XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_2_Proj"), (projectile.damage) / 2, 0, projectile.owner);
            Main.projectile[c].aiStyle = 1;
            Main.projectile[c].position.X = Main.projectile[a].position.X + 25;
            Main.projectile[c].tileCollide = true;

            return true;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
        {
            projectile.velocity.Y += 0.25f;
            projectile.rotation = 0;

            if (++projectile.frameCounter >= 1)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 12)
                {
                    projectile.frame = 0;
                }
            }
        }
    }
}