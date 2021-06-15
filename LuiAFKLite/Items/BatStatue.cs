using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuiAFKLite.Items
{
	public class BatStatue : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Spawn bat inside of you when Feral Bite debuff wears off");
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
			recipe.AddIngredient(ItemID.BatStatue, 1);
			recipe.AddIngredient(ItemID.Wire, 50);
			recipe.AddIngredient(ItemID.Timer5Second, 6);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}


//if (NPC.type == NPCID.CaveBat)