using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DeviantAnomalyRedemptionStuff.Buffs
{
    public class XenomiteClaw6CBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Energy Surge");
            Description.SetDefault("Grants increased defense\nand movement speed.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 20; //Grants a +15 defense boost to the player while the buff is active.
            player.moveSpeed += 0.5f;//Grants +50% movement speed to the player while the buff is active. 
        }
    }
}