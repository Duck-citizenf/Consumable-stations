using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace LuiAFKLite.Items
{
	public class SliceofCake : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Slice of Cake");
            Tooltip.SetDefault("Gives a Sugar Rush buff");
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
            item.buffType = BuffID.SugarRush; //Specify an existing buff to be applied when used.
            item.buffTime = 5400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
    }
}