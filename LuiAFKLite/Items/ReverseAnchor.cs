using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace LuiAFKLite.Items
{
	public class ReverseAnchor : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Grants you Flipped debuff \nFor challenge runs \nPREPARE YOUR RESPAWN POINT BEFORE CRAFTING IT");
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
			player.AddBuff(fargos.BuffType("Flipped"), 1);
			player.buffImmune[BuffID.Gravitation] = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}		
    }
}