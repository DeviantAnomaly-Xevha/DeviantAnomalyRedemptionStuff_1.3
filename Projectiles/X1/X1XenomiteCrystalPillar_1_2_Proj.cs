using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DeviantAnomalyRedemptionStuff.Projectiles.X1
{
    public class X1XenomiteCrystalPillar_1_2_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Pillar");
            Main.projFrames[projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            projectile.penetrate = -1;
            projectile.width = 26;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.timeLeft = 120;
            projectile.ignoreWater = false;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            drawCacheProjsBehindNPCsAndTiles.Add(index);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
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
            projectile.penetrate = -1;
            projectile.maxPenetrate = -1;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.velocity = Vector2.Zero;
            return false;
        }

        public override void Kill(int timeLeft)
        {
            base.Kill(timeLeft);
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalPillar_shatter"), projectile.position);

            int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, 0, -.5f, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj"), projectile.damage, 0, projectile.owner);
            Main.projectile[a].aiStyle = 1;
            Main.projectile[a].velocity.X = 0f - (Main.rand.Next(1, 4));
            Main.projectile[a].velocity.Y = 0f - (Main.rand.Next(1, 4));
            Main.projectile[a].tileCollide = false;

            int b = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, 0, -.5f, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj"), projectile.damage, 0, projectile.owner);
            Main.projectile[b].aiStyle = 1;
            Main.projectile[b].velocity.X = 0f - (Main.rand.Next(1, 2));
            Main.projectile[b].velocity.Y = 0f - (Main.rand.Next(1, 12));
            Main.projectile[b].tileCollide = false;

            int c = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, 0, -.5f, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj"), projectile.damage, 0, projectile.owner);
            Main.projectile[c].aiStyle = 1;
            Main.projectile[c].velocity.X = 0f + (Main.rand.Next(1, 2));
            Main.projectile[c].velocity.Y = 0f - (Main.rand.Next(1, 12));
            Main.projectile[c].tileCollide = false;

            int d = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, 0, -.5f, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType($"XenomiteCrystalPillarShard{Main.rand.Next(1, 5)}_Proj"), projectile.damage, 0, projectile.owner);
            Main.projectile[d].aiStyle = 1;
            Main.projectile[d].velocity.X = 0f + (Main.rand.Next(1, 4));
            Main.projectile[d].velocity.Y = 0f - (Main.rand.Next(1, 4));
            Main.projectile[d].tileCollide = false;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
        {
            projectile.velocity.X = 0f;
            projectile.velocity.Y = projectile.velocity.Y + 0.1f;
            projectile.rotation = 0;

            if (++projectile.frame <= 6)
            {
                if (++projectile.frameCounter >= 1)
                {
                    projectile.frameCounter = 0;

                }
            }
            else
            {
                projectile.frame = 6;
            }

            for (int i = 0; i < Main.maxProjectiles; ++i)
            {
                Projectile p = Main.projectile[i];
                if (p.owner != projectile.owner)
                {
                    if (p.active && p.hostile && p.getRect().Intersects(projectile.getRect()))
                    {
                        p.velocity *= -1;
                        p.hostile = false;
                        p.friendly = true;
                        p.owner = projectile.owner;
                    }
                }
            }

            Lighting.AddLight(projectile.position, 0.16f, 0.76f, 0.19f);
        }
    }
}