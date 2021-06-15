using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuiAFKLite.Items
{
    public class Omnistation : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gives effects of all vanilla buff stations");
        }

        public override void SetDefaults()
        {
            Mod fargos = ModLoader.GetMod("Fargowiltas");
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
            item.buffType = fargos.BuffType("Omnistation");
            item.buffTime = 5400;
        }
        public override void AddRecipes()
        {
            Mod fargos = ModLoader.GetMod("Fargowiltas");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(fargos.ItemType("Omnistation"));
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this, 60);
            recipe.AddRecipe();
        }
        public override void UpdateInventory(Player player)
        {
            Item item = Main.LocalPlayer.HeldItem;
            if (item.melee)
            {
                player.AddBuff(BuffID.Sharpened, 2);
            }
            if (item.magic)
            {
                player.AddBuff(BuffID.Clairvoyance, 2);
            }
            if (item.summon)
            {
                player.AddBuff(BuffID.Bewitched, 2);
            }
        }
    }
}