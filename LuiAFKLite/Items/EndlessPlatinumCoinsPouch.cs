using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using static Terraria.ID.ProjectileID;

namespace LuiAFKLite.Items
{
	public class EndlessPlatinumCoinsPouch : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Never ending Platinum coins");
		}

		public override void SetDefaults() {
			item.damage = 200;
			item.ranged = true;
			item.width = 14;
			item.height = 14;
			item.maxStack = 1;
			item.consumable = false;
			item.knockBack = 0;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = 8;
			item.shoot = ProjectileID.PlatinumCoin;
			item.ammo = AmmoID.Coin; // The first item in an ammo class sets the AmmoID to it's type
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumCoin, 3998);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}