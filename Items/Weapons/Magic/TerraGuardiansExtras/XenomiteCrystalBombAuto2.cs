using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

using DeviantAnomalyRedemptionStuff.Projectiles.X1;

namespace DeviantAnomalyRedemptionStuff.Items.Weapons.Magic.TerraGuardiansExtras
{
    public class XenomiteCrystalBombAuto2 : ModItem
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
                Tooltip.SetDefault("[i:" + ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBombTooltipIcon2") + "]\nLaunch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\n[c/ff6464:-Cannot be charged!-]\nPillars can reflect enemy projectiles.\nHolding this weapon may infect you...\nPrimarily for use by TerraGuardians companions");
            }
            else
            {
                Tooltip.SetDefault("[i:" + ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBombTooltipIcon2") + "]\nLaunch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\n[c/ff6464:-Cannot be charged!-]\nPillars can reflect enemy projectiles.\nHolding this weapon may poison you...\nPrimarily for use by TerraGuardians companions");
            }
        }

        public override void SetDefaults()
        {
            item.damage = 40;
            item.magic = true;
            item.mana = 7;
            item.channel = true;
            item.width = 16;
            item.height = 12;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = 20000;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalBomb_shoot");
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<X1XenomiteCrystalBomb_Proj>();
            item.shootSpeed = 12f;
            item.noUseGraphic = false;
            item.crit = 4;
        }

        public override void HoldItem(Player player)
        {
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
                recipe.AddTile(TileID.Anvils);//Iron or Lead Anvil
                recipe.SetResult(this);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                if (RedeMod != null)
                {
                    recipe.AddIngredient(ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBombAuto1"));
                    recipe.AddIngredient(RedeMod.ItemType("Xenomite"), 12);
                    recipe.AddIngredient(RedeMod.ItemType("StarliteBar"), 7);
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
}