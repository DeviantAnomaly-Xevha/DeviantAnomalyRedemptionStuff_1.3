using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DeviantAnomalyRedemptionStuff.Items.Fun
{
    public class VictoryFist : ModItem
    {
        public bool HidePlayer = false;
        public bool RaiseArmWithNoVanity = false;
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
            item.autoReuse = false;
            item.noUseGraphic = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-14,0);
        }

        public override void HoldItem(Player player)
        {
            if (player.armor[10].type == mod.ItemType("DeviantAnomalyHead") && player.armor[11].type == mod.ItemType("DeviantAnomalyBody") && player.armor[12].type == mod.ItemType("DeviantAnomalyLegs") && item.useTime == 0)
            {
                item.useTime = 60;
                item.useAnimation = 60;
            }

            if (player.armor[10].type != mod.ItemType("DeviantAnomalyHead") && item.useTime == 60 || player.armor[11].type != mod.ItemType("DeviantAnomalyBody") && item.useTime == 60 || player.armor[12].type != mod.ItemType("DeviantAnomalyLegs") && item.useTime == 60)
            {
                item.useTime = 0;
                item.useAnimation = 0;
            }

            if (HidePlayer == true && VictoryFistTimer != 59f || RaiseArmWithNoVanity == true && VictoryFistTimer != 59f)
            {
                VictoryFistTimer += 1f;

                if (player.blind == true)
                {
                    item.color = new Color(179, 166, 255);//Experimenting to see what happens. Blindness darkens the character, so I want the item's icon to match when it appears.
                }

                if (HidePlayer == true && VictoryFistTimer > 0f && VictoryFistTimer < 59f)
                {
                    player.immuneAlpha = 255;
                }

                if (RaiseArmWithNoVanity == true && VictoryFistTimer == 1f)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/X_victory"), player.position);
                }

                if (VictoryFistTimer >= 59f)
                {
                    item.noUseGraphic = true;
                    player.immuneAlpha = 0;
                    HidePlayer = false;
                    RaiseArmWithNoVanity = false;
                    VictoryFistTimer = 0f;
                    item.color = Color.White;
                }
            }
        }

        public override bool HoldItemFrame(Player player)
        {
            if (RaiseArmWithNoVanity == true)
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
            if (RaiseArmWithNoVanity == true)
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
            if (player.armor[10].type == mod.ItemType("DeviantAnomalyHead") && player.armor[11].type == mod.ItemType("DeviantAnomalyBody") && player.armor[12].type == mod.ItemType("DeviantAnomalyLegs"))
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/X_victory"), player.position);
                HidePlayer = true;
                item.noUseGraphic = false;
                player.immuneAlpha = 255;
                int a = Projectile.NewProjectile(new Vector2(player.position.X + 10.5f - (9 * player.direction), player.position.Y + 10), player.velocity, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType("VictoryFist_Proj1"), 0, 0, item.owner);
                Main.projectile[a].velocity = new Vector2(Main.projectile[a].velocity.X + player.velocity.X, Main.projectile[a].velocity.Y + player.velocity.Y) / 3;
            }
            else
            {
                RaiseArmWithNoVanity = true;
                player.bodyFrame.Y = player.bodyFrame.Height;
                int a = Projectile.NewProjectile(new Vector2(player.position.X + 10.5f - (9 * player.direction), player.position.Y + 10), player.velocity, ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ProjectileType("VictoryFist_Proj2"), 0, 0, item.owner);
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