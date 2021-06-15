using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace LuiAFKLite.Items
{
	public class PhilosophersPotion : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Philosopher's Potion");
            Tooltip.SetDefault("Grants effect of Philosopher's Stone");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(copper: 1);
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PhilosophersStone, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
		
		public override void UpdateInventory(Player player) {
			player.pStone = true;
		}	
    }
}