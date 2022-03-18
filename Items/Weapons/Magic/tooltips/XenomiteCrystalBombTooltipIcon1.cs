using Terraria.ID;
using Terraria.ModLoader;

namespace DeviantAnomalyRedemptionStuff.Items.Weapons.Magic.tooltips
{
    public class XenomiteCrystalBombTooltipIcon1 : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("a tooltip icon");
            Tooltip.SetDefault("?!");
        }

        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.noMelee = true;
            item.value = 0;
            item.rare = ItemRarityID.Orange;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/X_victory").WithPitchVariance(0);
            item.autoReuse = false;
            item.noUseGraphic = true;
        }
    }
}