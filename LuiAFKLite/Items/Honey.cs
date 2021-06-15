using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace LuiAFKLite.Items
{
	public class Honey : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gives a Honey buff");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(copper: 1);
            item.buffType = BuffID.Honey; //Specify an existing buff to be applied when used.
            item.buffTime = 5400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledHoney, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 60);
			recipe.AddRecipe();
		}
    }
}