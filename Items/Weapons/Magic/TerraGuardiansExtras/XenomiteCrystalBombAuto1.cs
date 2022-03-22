using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

using DeviantAnomalyRedemptionStuff.Projectiles.X1;

namespace DeviantAnomalyRedemptionStuff.Items.Weapons.Magic.TerraGuardiansExtras
{
    public class XenomiteCrystalBombAuto1 : ModItem
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
                Tooltip.SetDefault("[i:" + ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBombTooltipIcon1") + "]\nLaunch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\n[c/ff6464:-Cannot be charged!-]\nPillars can reflect enemy projectiles.\nHolding this weapon may infect you...\nPrimarily for use by TerraGuardians companions");
            }
            else
            {
                Tooltip.SetDefault("[i:" + ModLoader.GetMod("DeviantAnomalyRedemptionStuff").ItemType("XenomiteCrystalBombTooltipIcon1") + "]\nLaunch an unstable shard which rapidly forms crystal pillars upon contact with terrain.\n[c/ff6464:-Cannot be charged!-]\nPillars can reflect enemy projectiles.\nHolding this weapon may poison you...\nPrimarily for use by TerraGuardians companions");
            }
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.magic = true;
            item.mana = 5;
            item.channel = true;
            item.width = 16;
            item.height = 12;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/XenomiteCrystalBomb_shoot");
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<X1XenomiteCrystalBomb_Proj>();
            item.shootSpeed = 12f;
            item.noUseGraphic = false;
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
                recipe.AddRecipeGroup("DeviantAnomalyRedemptionStuff:tier 1/orange Xenomite Crystal Bomb weapon");
                recipe.AddTile(TileID.Anvils);//Iron or Lead Anvil
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
            else
            {
            }
        }
    }
}