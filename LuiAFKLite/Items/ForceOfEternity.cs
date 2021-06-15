using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace LuiAFKLite.Items
{
	public class ForceOfEternity : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Force of Eternity");
            Tooltip.SetDefault("'The weak must be allowed to suffer and die, so that the strong may continue'");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = -12;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<LuiAFKLitePlayer>().Nebula = true;
            player.dash = 1;
            player.GetModPlayer<LuiAFKLitePlayer>().IronEnchant = true;
            player.GetModPlayer<LuiAFKLitePlayer>().TinEnchant = true;
        }

        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").ItemType("TinEnchant"), 1);
            recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").ItemType("FossilEnchant"), 1);
            recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").ItemType("NebulaEnchant"), 1);
            recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").ItemType("GoldEnchant"), 1);
            recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").ItemType("ShinobiEnchant"), 1);
            recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").ItemType("IronEnchant"), 1);
            recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").ItemType("SpiderEnchant"), 1);
            recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").ItemType("MutantScale"), 10);
            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));
            recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
    }
    public class LuiAFKLiteGlobalItem : GlobalItem
    {
        public override void GrabRange(Item item, Player player, ref int grabRange)
        {
            if (player.GetModPlayer<LuiAFKLitePlayer>().IronEnchant && item.type != ItemID.CopperCoin && item.type != ItemID.SilverCoin && item.type != ItemID.GoldCoin && item.type != ItemID.PlatinumCoin && item.type != ItemID.HermesBoots && item.type != ItemID.CandyApple && item.type != ItemID.SoulCake &&
               item.type != ItemID.Star && item.type != ItemID.CandyCane && item.type != ItemID.SugarPlum)
                grabRange *= 1000;
        }
    }
}