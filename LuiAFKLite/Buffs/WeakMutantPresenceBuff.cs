using Terraria;
using Terraria.ModLoader;

namespace LuiAFKLite.Buffs
{
    public class WeakMutantPresenceBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mutant Presence");
            Description.SetDefault("Defense, damage reduction, and life regen reduced; Chaos State effect");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //also halves defense, DR, and cripples life regen
            player.GetModPlayer<LuiAFKLitePlayer>().WeakMutantPresenceBuff = true;
            player.moonLeech = true;
        }
    }
}