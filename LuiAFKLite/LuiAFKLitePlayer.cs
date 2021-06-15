using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using LuiAFKLite.Items;
using Terraria.GameInput;

namespace LuiAFKLite
{
	public class LuiAFKLitePlayer : ModPlayer
	{
		public bool WeakMutantPresenceBuff;
		public bool WeakMutantFangBuff;
		public int StatLifePrevious = -1;
		public bool NohitOmnibuff;
		public bool NymphsPerfumeRespawn;
		public bool TribalCharm;
		public bool TribalAutoFire;
		public bool IronEnchant;
		public bool Nebula;
		private int tinCD = 0;
		public int TinCrit = 25;
		public bool TinEnchant;

		public override void UpdateBadLifeRegen()
		{
			if (WeakMutantPresenceBuff)
			{
				if (player.lifeRegen > 4)
					player.lifeRegen = 4;

				if (player.lifeRegenCount > 0)
					player.lifeRegenCount -= 6;

				if (player.lifeRegenTime > 0)
					player.lifeRegenTime -= 6;
			}
			if (WeakMutantFangBuff)
			{
				if (player.lifeRegen > 0)
					player.lifeRegen = 0;

				if (player.lifeRegenCount > 0)
					player.lifeRegenCount = 0;

				player.lifeRegenTime = 0;
				player.lifeRegen -= 55;
			}
			int damage = 13;
			if (!(player.HasBuff(BuffID.Rabies)) && Main.LocalPlayer.HasItem(ModContent.ItemType<BatStatue>()))
			{
				if (Main.expertMode)
				{
					if (NPC.downedPlantBoss)
						damage = 116;
					else if (Main.hardMode)
						damage = 92;
					else
						damage = 26;
				}
				player.Hurt(PlayerDeathReason.ByOther(0), damage, 0, false, false, true);
				if (Main.expertMode)
				{
					player.AddBuff(BuffID.Rabies, 3600);
				}
				else player.AddBuff(BuffID.Rabies, 1800);
			}
			if (Nebula && !player.setNebula)
			{
				player.setNebula = true;

				if (player.nebulaCD > 0)
					player.nebulaCD--;
			}
		}
		public override void PostUpdateMiscEffects()
		{
			if (WeakMutantPresenceBuff)
			{
				player.statDefense /= 2;
				player.endurance /= 2;

				if (player.statLife > 0 && StatLifePrevious > 0 && player.statLife > StatLifePrevious)
					player.statLife = StatLifePrevious;
			}
			if (WeakMutantFangBuff)
			{
				player.statLifeMax2 -= player.statLifeMax / 5;
				player.statDefense -= 40;
				player.endurance -= 0.20f;
				player.meleeDamage -= 0.1f;
				player.magicDamage -= 0.1f;
				player.rangedDamage -= 0.1f;
				player.minionDamage -= 0.1f;
			}
			if (TinEnchant)
			{
				AllCritEquals(TinCrit);
			}
		}
		public override void UpdateDead()
		{
			WeakMutantPresenceBuff = false;
			WeakMutantFangBuff = false;
		}
		public override void ResetEffects()
		{
			WeakMutantPresenceBuff = false;
			WeakMutantFangBuff = false;
			NohitOmnibuff = false;
			NymphsPerfumeRespawn = false;
			TribalCharm = false;
			IronEnchant = false;
			Nebula = false;
			TinEnchant = false;
		}
		public override void PostUpdateEquips()
		{
			if (WeakMutantPresenceBuff)
			{
				player.onHitDodge = false;
				player.shadowDodge = false;
				player.blackBelt = false;
			}
		}
		public override void OnHitByNPC(NPC npc, int damage, bool crit)
		{
			Mod fargos = ModLoader.GetMod("FargowiltasSouls");
			if (player.statLife > 0 && NPC.AnyNPCs(fargos.NPCType("MutantBoss")) && Main.LocalPlayer.HasItem(ModContent.ItemType<WeakMutantPresence>()))
			{
				player.AddBuff(mod.BuffType("WeakMutantFangBuff"), 120);
			}
		}
		public override void OnHitByProjectile(Projectile projectile, int damage, bool crit)
		{
			Mod fargos = ModLoader.GetMod("FargowiltasSouls");
			if (player.statLife > 0 && NPC.AnyNPCs(fargos.NPCType("MutantBoss")) && Main.LocalPlayer.HasItem(ModContent.ItemType<WeakMutantPresence>()))
			{
				player.AddBuff(mod.BuffType("WeakMutantFangBuff"), 120);
			}
		}
		public override void OnRespawn(Player player)
		{
			if (NymphsPerfumeRespawn)
			{
				player.statLife = player.statLifeMax2;
			}
		}
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			Mod fargos = ModLoader.GetMod("FargowiltasSouls");
			if (SunflowerMod.RandomBuffHotKey.JustPressed && Main.LocalPlayer.HasItem(ModContent.ItemType<NormalOmnibuff>()) && !player.HasBuff(BuffID.PotionSickness) && !player.HasBuff(fargos.BuffType("MutantNibble")) && !player.HasBuff(fargos.BuffType("MutantFang")))
			{
				player.AddBuff(BuffID.PotionSickness, 2700);
				if (NPC.downedTowers) player.statLife += 200;
				else player.statLife += 150;
			}
		}
		public override bool PreItemCheck()
		{
			if (TribalCharm && player.HeldItem.type != ItemID.RodofDiscord && player.HeldItem.fishingPole == 0)
			{
				TribalAutoFire = player.HeldItem.autoReuse;
				player.HeldItem.autoReuse = true;
			}
			return true;
		}
		public override void PostItemCheck()
		{
			if (TribalCharm && player.HeldItem.type != ItemID.RodofDiscord)
			{
				player.HeldItem.autoReuse = TribalAutoFire;
			}
		}
		public override void PreUpdate()
		{
			if (TinCrit < 25)
				TinCrit = 25;

			if (tinCD > 0)
				tinCD--;
		}
		public void OnHitNPCEither(NPC target, int damage, float knockback, bool crit, int projectile = -1)
		{
			if (tinCD <= 0)
			{
				if (TinEnchant)
				{
					if (crit && TinCrit < 100)
					{
						TinCrit += 5;
						tinCD = 5;
					}
				}
			}
		}
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (TinEnchant)
			{
				if (TinCrit != 25)
				{
					TinCrit = 25;
				}
			}
		}
		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			bool retVal = true;
			if (TinEnchant)
			{
				if (TinCrit != 25)
				{
					TinCrit = 25;
				}
			}
			return retVal;
		}
		public void AllCritEquals(int crit)
		{
			player.meleeCrit = crit;
			player.rangedCrit = crit;
			player.magicCrit = crit;
		}
	}
}