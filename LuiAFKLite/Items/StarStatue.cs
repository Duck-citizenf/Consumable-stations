using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.UI.Chat;
using System.Collections.ObjectModel;
using System.Linq;

namespace LuiAFKLite.Items
{
	public class StarStatue : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Spawn 1 stars every 3.4 seconds \n CHEAT STATION");
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
			recipe.AddIngredient(ItemID.StarStatue, 10);
			recipe.AddIngredient(ItemID.Wire, 50);
			recipe.AddIngredient(ItemID.Timer5Second, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
		
		int timer = 0;
		
		public override void UpdateInventory(Player player) {
			int starCount = 0;
			for (int i = 0; i < Main.item.Length; i++){
			if (Main.item[i].type == ItemID.Star | Main.item[i].type == ItemID.SoulCake | Main.item[i].type == ItemID.SugarPlum)
				starCount++;
			}
			if(starCount < 7){
				timer++;
				if(timer > 200){
					player.QuickSpawnItem(ItemID.Star, 1);
					timer = 0;
				}
			}
		}
    }
}