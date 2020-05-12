using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class GnomeMage : Monster
    {
        public GnomeMage(int gnomeLevel)
        {
            Health = 100 + 5 * gnomeLevel;
            Strength = 3 + gnomeLevel;
            Armor = 10; // percentage reduction of damage for monsters
            Precision = 50;
            MagicPower = 35 + gnomeLevel * 2;
            Stamina = 30;
            XPValue = 30 + gnomeLevel * 10;
            Name = "monster1701";
            BattleGreetings = "AHH! You shouldn't disturb me you awful giant!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;

                int tmp = Index.RNG(1, 3);

                if (tmp == 1)
                {
                    // gnome mage can create a snow cones decreasing your armor
                    //return new List<StatPackage>() { new StatPackage("fire", (5 + MagicPower), "aahahahahahahahhah (" + (5 + MagicPower) + " fire damage)") };
                    return new List<StatPackage>() { new StatPackage("water", (5 + magicPower / 10), 0, (1 * MagicPower / 2), 10, 0, "Gnome mage uses his energy to create floating frost cones around you! You gain " + (MagicPower / 2) + " armor debuff, take " + (5 + MagicPower / 10) + " damage and decreased precision by 10!") };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage("fire", (5 + MagicPower), "Gnome mage casts fireball! Deals (" + (5 + MagicPower) + " fire damage)") };
                }
            }
            else
            {
                Stamina += 5;
                return new List<StatPackage>() { new StatPackage("stab", (2 + Strength), "Gnome lost all his energy to fight, needs some time to recharge mana! Hits you with his melee staff (" + (2 + Strength) + " stab damage)!") };
            }
        }
        public override void React(List<StatPackage> packs) // receive the result of your opponent's action
        {
            foreach (StatPackage pack in packs)
            {
                Health -= pack.HealthDmg * (100-Armor) / 100;
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
            }
        }

    }
}
