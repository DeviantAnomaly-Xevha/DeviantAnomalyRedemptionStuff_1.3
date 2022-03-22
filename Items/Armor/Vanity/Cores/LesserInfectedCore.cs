using Terraria;
using Terraria.ModLoader;
using Redemption;
using Redemption.Buffs.Debuffs;

namespace DeviantAnomalyRedemptionStuff.Items.Armor.Cores
{
    public class LesserInfectedCore : ModItem
    {

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("Redemption") != null;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser Infected Core");
            Tooltip.SetDefault("'Carnivorous crystals grow inside you'\n[c/64ff64:-Strengths-]\n+50 increased max life\nYou are immune to the Infection, Radioactive Fallout and Radiation Poisoning\nYou are stronger in the Wasteland, increasing all stats\nYou deal damage to any enemy that hits you\n[c/ff6464:-Weaknesses-]\nMovement speed is reduced, unless you are in the Wasteland\nThe Wasteland stat increase is half that of a regular Infected Core");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = 1;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (ModLoader.GetMod("Redemption") != null)
            {
                var druidDamagePlayer = DruidDamagePlayer.ModPlayer(player);
                var redePlayer = Main.LocalPlayer.GetModPlayer<RedePlayer>();
                player.statLifeMax2 += 50;
                player.thorns = 1f;
                player.buffImmune[ModContent.BuffType<XenomiteDebuff>()] = true;
                player.buffImmune[ModContent.BuffType<XenomiteDebuff2>()] = true;
                player.buffImmune[ModContent.BuffType<RadioactiveFalloutDebuff>()] = true;
                if (redePlayer.ZoneXeno || redePlayer.ZoneEvilXeno || redePlayer.ZoneEvilXeno2)
                {
                    druidDamagePlayer.druidDamage *= 1.05f;
                    player.magicDamage *= 1.05f;
                    player.meleeDamage *= 1.05f;
                    player.minionDamage *= 1.05f;
                    player.rangedDamage *= 1.05f;
                    player.thrownDamage *= 1.05f;
                    player.statDefense += 9;
                    player.statLifeMax2 += 100;
                    player.lifeRegen += 5;
                    player.nightVision = true;
                    player.moveSpeed += 25f;
                    player.jumpBoost = true;
                }
                else
                {
                    player.moveSpeed *= 0.85f;
                }
                player.GetModPlayer<RedePlayer>().irradiatedEffect = 0;
                player.GetModPlayer<RedePlayer>().irradiatedLevel = 0;
                player.GetModPlayer<RedePlayer>().irradiatedTimer = 0;
            }
            else
            {
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            if (ModLoader.GetMod("Redemption") != null)
            {
                recipe.AddIngredient(ModLoader.GetMod("Redemption").ItemType("EmptyCore"), 1);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
            else
            {
            }
        }
    }
}