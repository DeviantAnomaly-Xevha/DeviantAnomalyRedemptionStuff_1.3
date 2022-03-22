using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

using DeviantAnomalyRedemptionStuff.Projectiles.X2;

namespace DeviantAnomalyRedemptionStuff.Items.Weapons.Magic.TerraGuardiansExtras
{
    public class XenomiteCrystalBombAuto6 : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("giantsummon") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xenomite Crystal Bomb - TerraGuardian companion version");
            Mod RedeMod = ModLoader.GetMod("Redemption");
            if (RedeMod != null)
            {
                Tooltip.SetDefault("[i:" + ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBombTooltipIcon6") + "]\nLaunch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\n[c/ff6464:-Cannot be charged!-]\nPillars can reflect enemy projectiles.\nHolding this weapon may heavily infect you...\nPrimarily for use by TerraGuardians companions");
            }
            else
            {
                Tooltip.SetDefault("[i:" + ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBombTooltipIcon6") + "]\nLaunch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\n[c/ff6464:-Cannot be charged!-]\nPillars can reflect enemy projectiles.\nHolding this weapon may poison you...\nPrimarily for use by TerraGuardians companions");
            }
        }

        public override void SetDefaults()
        {
            item.damage = 640;
            item.magic = true;
            item.mana = 15;
            item.channel = true;
            item.width = 16;
            item.height = 12;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = 320000;
            item.rare = ItemRarityID.Purple;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalBomb_shoot");
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<X2XenomiteCrystalBomb_Proj>();
            item.shootSpeed = 12f;
            item.noUseGraphic = false;
            item.crit = 20;
        }

        public override void HoldItem(Player player)
        {
            Mod RedeMod = ModLoader.GetMod("Redemption");
            if (RedeMod != null)
            {
                player.AddBuff(RedeMod.BuffType("XenomiteDebuff2"), 203);
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
                recipe.AddRecipeGroup("DeviantAnomalyRedemptionStuff:tier 6/red Xenomite Crystal Bomb weapon");
                recipe.AddTile(TileID.Anvils);//Iron or Lead Anvil
                recipe.SetResult(this);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                if (RedeMod != null)
                {
                    recipe.AddIngredient(ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBombAuto5"));
                    recipe.AddIngredient(RedeMod.ItemType("Xenomite"), 12);
                    recipe.AddIngredient(RedeMod.ItemType("StarliteBar"), 7);
                    recipe.AddIngredient(RedeMod.ItemType("BluePrints"), 1);
                    recipe.AddTile(TileID.LunarCraftingStation);//Ancient Manipulator
                    recipe.SetResult(this);
                    recipe.AddRecipe();
                }
                else
                {
                }
            }
        }
    }
}