using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuiAFKLite.Items
{
    public class NohitOmnibuff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(@"Grants Well Fed, Wrath
If you hold melee weapon grants: Sharpened, Tipsy, Ichor Flask
If you hold bow weapon grants: Archery
If you hold magic weapon grants: Clairvoyance, Magic Power
If you hold summoner weapon grants: Bewitched, Summoning
If Wall of Flesh was defeated you have Mystic Skull effect
If Wall of Flesh was defeated restores 300 mana when needed
If Wall of Flesh was defeated you have Tribal Charm effect
Right click to get Normal Omnibuff");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.rare = ItemRarityID.Orange;
        }

        public override void UpdateInventory(Player player)
        {
            LuiAFKLitePlayer LuiAFKLitePlayer = player.GetModPlayer<LuiAFKLitePlayer>();
            player.GetModPlayer<LuiAFKLitePlayer>().NohitOmnibuff = true;
            Item item = Main.LocalPlayer.HeldItem;
            player.AddBuff(BuffID.WellFed, 2);
            player.AddBuff(BuffID.Wrath, 2);
            if (Main.hardMode)
            {
                LuiAFKLitePlayer.TribalCharm = true;
            }
            if (item.melee)
            {
                player.AddBuff(BuffID.Sharpened, 2);
                player.AddBuff(BuffID.Tipsy, 2);
                if (Main.hardMode)
                {
                    player.AddBuff(BuffID.WeaponImbueIchor, 2);
                    player.manaFlower = true;
                    player.buffImmune[BuffID.Suffocation] = true;
                }
            }
            if (item.magic)
            {
                if (Main.hardMode)
                {
                    player.AddBuff(BuffID.Clairvoyance, 2);
                }
                player.AddBuff(BuffID.MagicPower, 2);
            }
            if (item.summon)
            {
                player.AddBuff(BuffID.Bewitched, 2);
                player.AddBuff(BuffID.Summoning, 2);
            }
            if (item.useAmmo == AmmoID.Arrow || item.useAmmo == AmmoID.Stake)
            {
                player.AddBuff(BuffID.Archery, 2);
            }
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(ModContent.ItemType<NormalOmnibuff>(), 1);
        }
    }
}