using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuiAFKLite.Items
{
	public class WeakMutantPresence : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Get your toggles back from his mutated claws");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(copper: 1);
        }
		public override void UpdateInventory(Player player) {
			Mod fargos = ModLoader.GetMod("FargowiltasSouls");
			if (player.statLife > 0) //&& NPC.AnyNPCs(fargos.NPCType("MutantBoss")))
				{
				player.AddBuff(mod.BuffType("WeakMutantPresenceBuff"), 1);
				player.buffImmune[fargos.BuffType("MutantPresence")] = true;
				player.buffImmune[fargos.BuffType("MutantFang")] = true;
				}
		}
    }
}