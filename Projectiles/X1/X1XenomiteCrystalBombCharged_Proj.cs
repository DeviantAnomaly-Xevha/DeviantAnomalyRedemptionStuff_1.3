using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeviantAnomalyRedemptionStuff.Projectiles.X1
{
    public class X1XenomiteCrystalBombCharged_Proj : ModProjectile
    {
        public float Charge;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Bomb");
            Main.projFrames[projectile.type] = 12;
        }

        public override void SetDefaults()
        {
            projectile.penetrate = -1;
            projectile.knockBack = 4f;
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.timeLeft = 600;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.timeLeft = 1;
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalBomb_explode"), projectile.position);
            int a = Projectile.NewProjectile(projectile.Center.X - 8f, projectile.Center.Y, 0, 0, ModContent.ProjectileType<X1XenomiteCrystalBombExplosion_Proj>(), 0, 0, projectile.owner);

            Projectile.NewProjectile(Main.projectile[a].Center.X - 2, Main.projectile[a].Center.Y - 9, -1f, 1f, ModContent.ProjectileType<X1XenomiteCrystalBombChargedLeftHalf_Proj>(), projectile.damage, 0, projectile.owner);

            Projectile.NewProjectile(Main.projectile[a].Center.X + 2, Main.projectile[a].Center.Y - 9, 1f, 1f, ModContent.ProjectileType<X1XenomiteCrystalBombChargedRightHalf_Proj>(), projectile.damage, 0, projectile.owner);

            Mod RedeMod = ModLoader.GetMod("Redemption");
            if (RedeMod != null)
            {
                target.AddBuff(RedeMod.BuffType("XenomiteDebuff"), 203, false);
            }
            else
            {
                target.AddBuff(BuffID.Poisoned, 203, false);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<X1XenomiteCrystalBombChargedPillarSpawner_Proj>(), projectile.damage / 2, 0, projectile.owner);
            Main.projectile[a].aiStyle = 1;
            Main.projectile[a].tileCollide = false;
            Main.projectile[a].velocity.Y = 0;

            if (projectile.velocity.X > .01f)
            {
                Main.projectile[a].velocity.X = 25;
            }
            else if (projectile.velocity.X < .01f)
            {
                Main.projectile[a].velocity.X = -25;
            }

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

            int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.CursedTorch, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), .5f);
            Main.dust[num].position = (Main.dust[num].position + projectile.Center) / 2f;
            Main.dust[num].noGravity = true;
            Main.dust[num].color = new Color(43, 194, 48);
            if (Main.rand.Next(2) == 0)
            {
                Main.dust[num].scale *= 2f;
            }

            Lighting.AddLight(projectile.position, 0f, 0.58f, 0.30f);
        }
    }
}