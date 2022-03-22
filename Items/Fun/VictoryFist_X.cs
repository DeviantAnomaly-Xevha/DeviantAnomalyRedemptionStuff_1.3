using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DeviantAnomalyRedemptionStuff.Items.Fun
{
    public class VictoryFist_X : ModItem
    {
        public bool HidePlayer = false;
        public bool ArmUp = false;
        public float VictoryFistTimer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega Man X Victory Fist");
            Tooltip.SetDefault("'Mission accomplished!'");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 50;
            item.useTime = 0;
            item.useAnimation = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.value = 0;
            item.rare = ItemRarityID.Green;
            item.autoReuse = false;
            item.noUseGraphic = true;
        }

        public override void HoldItem(Player player)
        {
            if (ArmUp == true && VictoryFistTimer != 59f)
            {
                VictoryFistTimer += 1f;

                if (ArmUp == true && VictoryFistTimer == 1f)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/X_victory"), player.position);
                }

                if (VictoryFistTimer >= 59f)
                {
                    ArmUp = false;
                    VictoryFistTimer = 0f;
                }
            }
        }

        public override bool HoldItemFrame(Player player)
        {
            if (ArmUp == true)
            {
                player.bodyFrame.Y = player.bodyFrame.Height;
            }
            else
            {
                return false;
            }
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (ArmUp == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public override bool UseItem(Player player)
        {
            ArmUp = true;
            player.bodyFrame.Y = player.bodyFrame.Height;
            int a = Projectile.NewProjectile(new Vector2(player.position.X + 12 - (9f * player.direction), player.position.Y + 17), player.velocity, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType("VictoryFist_ProjX"), 0, 0, item.owner);
            Main.projectile[a].velocity = new Vector2(Main.projectile[a].velocity.X + player.velocity.X, Main.projectile[a].velocity.Y + player.velocity.Y) / 3;

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