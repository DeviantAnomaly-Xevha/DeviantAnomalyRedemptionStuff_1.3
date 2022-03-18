using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DeviantAnomalyRedemptionStuff.Items.Weapons.Magic;

namespace DeviantAnomalyRedemptionStuff.Projectiles.X2
{
    public class X2XenomiteCrystalBombChargedPillarSpawner_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Bomb");
        }

        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.timeLeft = 7;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalPillar_grow"), projectile.position);

            if (Main.rand.Next(1, 3) == 1)
            {
                int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 18f, 0, 12f, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType($"X2XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_1_Proj"), (projectile.damage / 2), 0, projectile.owner); Main.projectile[a].aiStyle = 1;
                Main.projectile[a].friendly = true;
                Main.projectile[a].hostile = false;
                Main.projectile[a].ignoreWater = false;
                Main.projectile[a].tileCollide = true;
            }
            else
            {
                int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 9f, 0, 12f, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType($"X2XenomiteCrystalPillar_{Main.rand.Next(1, 5)}_2_Proj"), (projectile.damage / 2), 0, projectile.owner); Main.projectile[a].aiStyle = 1;
                Main.projectile[a].friendly = true;
                Main.projectile[a].hostile = false;
                Main.projectile[a].ignoreWater = false;
                Main.projectile[a].tileCollide = true;
            }
        }
    }
}