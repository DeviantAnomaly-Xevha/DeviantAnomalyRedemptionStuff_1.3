using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

using DeviantAnomalyRedemptionStuff.Projectiles.X1;

namespace DeviantAnomalyRedemptionStuff.Items.Weapons.Magic
{
    [AutoloadEquip(EquipType.HandsOn)]

    public class XenomiteCrystalBomb3 : ModItem
    {
        public float Charge;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Bomb");
            Mod RedeMod = ModLoader.GetMod("Redemption");
            if (RedeMod != null)
            {
                Tooltip.SetDefault("[i:" + ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBombTooltipIcon3") + "]\nLaunch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\n[c/64ff64:-Can be charged!-]\nPillars can reflect enemy projectiles.\nHolding this weapon may infect you...");
            }
            else
            {
                Tooltip.SetDefault("[i:" + ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBombTooltipIcon3") + "]\nLaunch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\n[c/64ff64:-Can be charged!-]\nPillars can reflect enemy projectiles.\nHolding this weapon may poison you...");
            }
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(2, 15));
        }

        public override void SetDefaults()
        {
            item.damage = 80;
            item.magic = true;
            item.mana = 9;
            item.channel = true;
            item.width = 16;
            item.height = 12;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = 40000;
            item.rare = ItemRarityID.Pink;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalBomb_shoot");
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<X1XenomiteCrystalBomb_Proj>();
            item.shootSpeed = 12f;
            item.noUseGraphic = true;
            item.crit = 8;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Charge >= 30f && Charge < 90f && player.statMana >= item.mana)//for shots below charge level 1
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalBomb_shoot"), player.position);
                type = ModContent.ProjectileType<X1XenomiteCrystalBomb_Proj>();//basic projectile
                player.statMana -= item.mana;//making sure mana's still spent when the use button's released before reaching a level 1 charge
                damage = damage;
            }
            else if (Charge >= 90f && Charge < 180f && player.statMana >= item.mana * 2)//charge level 1
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalBomb_shoot"), player.position);
                type = ModContent.ProjectileType<X1XenomiteCrystalBombCharged_Proj>();//level 1 charge projectile
                player.statMana -= item.mana * 2;
                damage *= 3;
            }
            else if (Charge >= 180f && player.statMana >= item.mana * 3)//charge level 2
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalBomb_shoot"), player.position);
                type = ModContent.ProjectileType<X1XenomiteCrystalBombCharged_Proj>();//level 2 charge projectile
                player.statMana -= item.mana * 3;
                damage *= 3;
            }
            Charge = 0f;//built-up charge resets to 0f whenever a shot is fired
            return true;
        }

        public override void HoldItem(Player player)
        {
            Vector2 AimDirection = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition - player.Center;
            AimDirection.Normalize();

            base.HoldItem(player);
            player.handon = player.HeldItem.handOnSlot;
            player.cHandOn = 5;

            if (player.channel && Charge < 181f)//if the use button is held and the value of "Charge" is less than 181f
            {
                Charge += 1f;

                if (player.channel && Charge == 30)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalBomb_chargehalfway"), player.position);
                }

                if (player.channel && Charge == 90)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalBomb_chargeLv1"), player.position);
                }

                if (player.channel && Charge == 180)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalBomb_chargeLv2"), player.position);
                }
            }


            if (player.channel && Charge >= 30 && Charge < 90)//charge level dust
            {
                int variable_A = Main.rand.Next(0, 50);
                int variable_B = Main.rand.Next(0, 50);
                int variable_C = Main.rand.Next(0, 50);
                int variable_D = Main.rand.Next(0, 50);

                int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A))/10 + player.velocity;
                Main.dust[a].noGravity = true;
                Main.dust[a].color = new Color(0, 98, 93);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[a].scale *= 1.5f;
                }

                int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                Main.dust[b].noGravity = true;
                Main.dust[b].color = new Color(0, 98, 93);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[b].scale *= 1.5f;
                }

                int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                Main.dust[c].noGravity = true;
                Main.dust[c].color = new Color(0, 98, 93);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[c].scale *= 1.5f;
                }

                int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                Main.dust[d].noGravity = true;
                Main.dust[d].color = new Color(0, 98, 93);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[d].scale *= 1.5f;
                }
            }
            else if (player.channel && Charge >= 90 && Charge < 180)
            {
                int variable_A = Main.rand.Next(0, 50);
                int variable_B = Main.rand.Next(0, 50);
                int variable_C = Main.rand.Next(0, 50);
                int variable_D = Main.rand.Next(0, 50);

                int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                Main.dust[a].noGravity = true;
                Main.dust[a].color = new Color(43, 194, 48);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[a].scale *= 2f;
                }

                int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                Main.dust[b].noGravity = true;
                Main.dust[b].color = new Color(43, 194, 48);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[b].scale *= 2f;
                }

                int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                Main.dust[c].noGravity = true;
                Main.dust[c].color = new Color(43, 194, 48);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[c].scale *= 2f;
                }

                int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                Main.dust[d].noGravity = true;
                Main.dust[d].color = new Color(43, 194, 48);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[d].scale *= 2f;
                }
            }
            else if (player.channel && Charge >= 180)
            {
                int variable_A = Main.rand.Next(0, 50);
                int variable_B = Main.rand.Next(0, 50);
                int variable_C = Main.rand.Next(0, 50);
                int variable_D = Main.rand.Next(0, 50);

                int a = Dust.NewDust(new Vector2((player.position.X + 6 + variable_A), (player.position.Y + 18 + (variable_A - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[a].velocity = new Vector2(-variable_A, (50 - variable_A)) / 10 + player.velocity;
                Main.dust[a].noGravity = true;
                Main.dust[a].color = new Color(185, 242, 84);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[a].scale *= 2.5f;
                }

                int b = Dust.NewDust(new Vector2((player.position.X + 6 + variable_B), (player.position.Y + 18 + (50 - variable_B))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[b].velocity = new Vector2(-variable_B, (variable_B - 50)) / 10 + player.velocity;
                Main.dust[b].noGravity = true;
                Main.dust[b].color = new Color(185, 242, 84);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[b].scale *= 2.5f;
                }

                int c = Dust.NewDust(new Vector2((player.position.X + 6 - variable_C), (player.position.Y + 18 + (50 - variable_C))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[c].velocity = new Vector2(variable_C, (variable_C - 50)) / 10 + player.velocity;
                Main.dust[c].noGravity = true;
                Main.dust[c].color = new Color(185, 242, 84);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[c].scale *= 2.5f;
                }

                int d = Dust.NewDust(new Vector2((player.position.X + 6 - variable_D), (player.position.Y + 18 + (variable_D - 50))), 0, 0, DustID.CursedTorch, player.velocity.X, player.velocity.Y, 100, default(Color), .5f);
                Main.dust[d].velocity = new Vector2(variable_D, (50 - variable_D)) / 10 + player.velocity;
                Main.dust[d].noGravity = true;
                Main.dust[d].color = new Color(185, 242, 84);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[d].scale *= 2.5f;
                }
            }


            if (!player.channel && Charge >= 30f)//if the use button is released after charging for at least 30 frames
            {
                if (player.statMana < item.mana)
                {
                    Charge = 0;
                }
                else if (player.statMana >= item.mana)
                {
                    player.itemAnimation = player.itemAnimationMax;
                    player.itemRotation = (float)Math.Atan2(((Main.mouseY + Main.screenPosition.Y - player.Center.Y) * player.direction), ((Main.mouseX + Main.screenPosition.X - player.Center.X) * player.direction));
                    if (Charge >= 180f && player.statMana >= item.mana * 3)
                    {
                        int a = Projectile.NewProjectile(player.Center.X, player.Center.Y, (AimDirection.X * item.shootSpeed) * .625f, (AimDirection.Y - 11f), ModContent.ProjectileType<X1XenomiteCrystalBombCharged_Proj>(), item.damage * 3, 0, item.owner);
                        Main.projectile[a].aiStyle = 1;
                        Main.projectile[a].tileCollide = true;
                    }
                }
            }

            Mod RedeMod = ModLoader.GetMod("Redemption");
            if (RedeMod != null)
            {
                player.AddBuff(RedeMod.BuffType("XenomiteDebuff"), 203);
            }
            else
            {
                player.AddBuff(BuffID.Poisoned, 203);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod RedeMod = ModLoader.GetMod("Redemption");
            if (RedeMod != null)
            {
                recipe.AddRecipeGroup("DeviantAnomalyRedemptionStuff:tier 2/light red Xenomite Crystal Bomb weapon");
                recipe.AddIngredient(RedeMod.ItemType("Xenomite"), 12);
                recipe.AddIngredient(RedeMod.ItemType("StarliteBar"), 7);
                recipe.AddIngredient(ItemID.SoulofFright, 7);
                recipe.AddIngredient(ItemID.SoulofMight, 7);
                recipe.AddIngredient(ItemID.SoulofSight, 7);
                recipe.AddTile(TileID.MythrilAnvil);//Mythril or Orichalcum Anvil
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
            else
            {
            }
        }
    }
}