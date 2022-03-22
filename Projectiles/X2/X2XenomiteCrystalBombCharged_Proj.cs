using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeviantAnomalyRedemptionStuff.Projectiles.X2
{
    public class X2XenomiteCrystalBombCharged_Proj : ModProjectile
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
            projectile.localNPCHitCooldown = projectile.timeLeft;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Mod RedeMod = ModLoader.GetMod("Redemption");
            if (target.defDefense >= projectile.damage * .75 || target.takenDamageMultiplier <= .25)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalPillar_shatter"), projectile.position);

                Projectile.NewProjectile(projectile.Center.X - 2, projectile.Center.Y, -1f, -0.25f, ModContent.ProjectileType<X2XenomiteCrystalBombChargedLeftHalf_Proj>(), projectile.damage / 6, 0, projectile.owner);

                Projectile.NewProjectile(projectile.Center.X + 2, projectile.Center.Y, 1f, -0.25f, ModContent.ProjectileType<X2XenomiteCrystalBombChargedRightHalf_Proj>(), projectile.damage / 6, 0, projectile.owner);
            }

            if (RedeMod != null)
            {
                target.AddBuff(RedeMod.BuffType("XenomiteDebuff2"), 203, false);
            }
            else
            {
                target.AddBuff(BuffID.Poisoned, 203, false);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ModContent.ProjectileType<X2XenomiteCrystalBombChargedPillarSpawner_Proj>(), projectile.damage / 6, 0, projectile.owner);
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