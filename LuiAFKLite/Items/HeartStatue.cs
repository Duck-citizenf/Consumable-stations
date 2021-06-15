using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace LuiAFKLite.Items
{
	public class HeartStatue : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Spawn 3 hearts every 10 seconds");
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
			recipe.AddIngredient(ItemID.HeartStatue, 3);
			recipe.AddIngredient(ItemID.Wire, 50);
			recipe.AddIngredient(ItemID.Timer5Second, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
		
		int timer = 0;
		
		public override void UpdateInventory(Player player) {
			int heartCount = 0;
			for (int i = 0; i < Main.item.Length; i++){
			if (Main.item[i].type == ItemID.Heart | Main.item[i].type == ItemID.CandyApple | Main.item[i].type == ItemID.CandyCane)
				heartCount++;
			}
			if(heartCount < 7){
				timer++;
				if(timer > 600){
					player.QuickSpawnItem(ItemID.Heart, 1);
					player.QuickSpawnItem(ItemID.Heart, 1);
					player.QuickSpawnItem(ItemID.Heart, 1);
					timer = 0;
				}
			}	
		}	
    }
}