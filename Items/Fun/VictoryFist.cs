using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace DeviantAnomalyRedemptionStuff.Items.Fun
{
    public class VictoryFist : ModItem
    {
        public bool HidePlayer = false;
        public float VictoryFistTimer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Victory Fist");
            Tooltip.SetDefault("YEAH!!");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 46;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.value = 0;
            item.rare = ItemRarityID.Green;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/X_victory");
            item.autoReuse = false;
            item.noUseGraphic = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-14,0);
        }

        public override void HoldItem(Player player)
        {
            if (HidePlayer == true && VictoryFistTimer != 59f)
            {
                VictoryFistTimer += 1f;

                if (VictoryFistTimer > 0f && VictoryFistTimer < 59f)
                {
                    player.immuneAlpha = 255;
                }

                if (VictoryFistTimer >= 59f)
                {
                    item.noUseGraphic = true;
                    player.immuneAlpha = 0;
                    HidePlayer = false;
                    VictoryFistTimer = 0f;
                }
            }
        }


        public override bool UseItem(Player player)
        {
            if (player.armor[10].type == mod.ItemType("DeviantAnomalyHead") && player.armor[11].type == mod.ItemType("DeviantAnomalyBody") && player.armor[12].type == mod.ItemType("DeviantAnomalyLegs"))
            {
                HidePlayer = true;
                item.noUseGraphic = false;
                player.immuneAlpha = 255;
                int a = Projectile.NewProjectile(new Vector2(player.position.X + 10.5f - (9 * player.direction), player.position.Y + 10), player.velocity, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType("VictoryFist_Proj"), 0, 0, item.owner);
                Main.projectile[a].velocity = new Vector2(Main.projectile[a].velocity.X + player.velocity.X, Main.projectile[a].velocity.Y + player.velocity.Y) / 3;
            }
            else
            {
                player.itemRotation = (-90 * player.direction);
                int a = Projectile.NewProjectile(new Vector2(player.position.X + 10.5f + (7 * player.direction), player.position.Y + 10), player.velocity, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType("VictoryFist_Proj"), 0, 0, item.owner);
                Main.projectile[a].velocity = new Vector2(Main.projectile[a].velocity.X + player.velocity.X, Main.projectile[a].velocity.Y + player.velocity.Y) / 3;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.WorkBenches);//Iron or Lead Anvil
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}