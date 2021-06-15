using Terraria;
using Terraria.ModLoader;

namespace LuiAFKLite.Buffs
{
    public class WeakMutantFangBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mutant Fang");
            Description.SetDefault("The power of Eternity Mode compels you");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            LuiAFKLitePlayer LuiAFKLitePlayer = player.GetModPlayer<LuiAFKLitePlayer>();
            player.GetModPlayer<LuiAFKLitePlayer>().WeakMutantFangBuff = true;
            player.moonLeech = true;
            player.potionDelay = player.buffTime[buffIndex];
        }
    }
}