using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LuiAFKLite.Items
{
    public class NormalOmnibuff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(@"Grants Endurance, Ironskin, Regeneration, Honey, Heart Lamp, Cozy Fire, Well Fed, Wrath
If Wall of Flesh was defeated grants: Life Force, Omnistation
If you hold melee weapon grants: Sharpened, Tipsy, Ichor Flask
If you hold bow weapon grants: Archery
If you hold magic weapon grants: Clairvoyance, Magic Power
If you hold summoner weapon grants: Bewitched, Summoning
Nymph's Perfume effect
If Wall of Flesh was defeated you have Mystic Skull effect
If Wall of Flesh was defeated restores 300 mana when needed
If Wall of Flesh was defeated you have Tribal Charm effect
Press the Quick Heal key to restore 150 life
If Celesteal Pillars was defeated restores 200 life
Right click to get Nohit Omnibuff");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.maxStack = 1;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(copper: 1);
            item.UseSound = SoundID.Item3;
        }

        public override void UpdateInventory(Player player)
        {
            LuiAFKLitePlayer LuiAFKLitePlayer = player.GetModPlayer<LuiAFKLitePlayer>();
            LuiAFKLitePlayer.NymphsPerfumeRespawn = true;
            player.GetModPlayer<LuiAFKLitePlayer>().NohitOmnibuff = true;
            player.AddBuff(BuffID.Endurance, 2);
            player.AddBuff(BuffID.Ironskin, 2);
            player.AddBuff(BuffID.Regeneration, 2);
            if (Main.hardMode)
            {
                Mod fargos = ModLoader.GetMod("Fargowiltas");
                player.AddBuff(BuffID.Lifeforce, 2);
                player.AddBuff(fargos.BuffType("Omnistation"), 2);
                LuiAFKLitePlayer.TribalCharm = true;
                player.manaFlower = true;
                player.buffImmune[BuffID.Suffocation] = true;
            }
            else
            {
                player.AddBuff(BuffID.Honey, 2);
                player.AddBuff(BuffID.HeartLamp, 2);
                player.AddBuff(BuffID.Campfire, 2);
            }

            Item item = Main.LocalPlayer.HeldItem;
            player.AddBuff(BuffID.WellFed, 2);
            player.AddBuff(BuffID.Wrath, 2);
            if (item.melee)
            {
                player.AddBuff(BuffID.Sharpened, 2);
                player.AddBuff(BuffID.Tipsy, 2);
                if (Main.hardMode)
                {
                    player.AddBuff(BuffID.WeaponImbueIchor, 2);
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
            player.QuickSpawnItem(ModContent.ItemType<NohitOmnibuff>(), 1);
        }

    }
    public class NohitOmnibuffGlobalItem : GlobalItem
    {
        public override void OnMissingMana(Item item, Player player, int neededMana)
        {
            if (player.GetModPlayer<LuiAFKLitePlayer>().NohitOmnibuff && Main.hardMode)
            {
                player.AddBuff(BuffID.ManaSickness, 300);
                player.statMana += 300;
            }
        }
    }
}