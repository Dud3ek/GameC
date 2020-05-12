using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class FireDrake : Monster
    {
        public FireDrake(int drakeLevel)
        {
            Health = 150 + 5 * drakeLevel*2;
            Strength = 15 + drakeLevel*3;
            Armor = 30;
            Precision = 50;
            MagicPower = 35 + drakeLevel * 2;
            Stamina = 50;
            XPValue = 40 + drakeLevel*15;
            Name = "monster1703";
            BattleGreetings = "Wild fire drake appears!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;

                int tmp = Index.RNG(1, 3);

                if (tmp == 1)
                {
                    return new List<StatPackage>() { new StatPackage("fire", (10 + magicPower / 8), 0, 0, 0, (MagicPower/5 + 2), "Fire drake creates cone of fire to distract you! You gain " + (MagicPower / 2) + " magic damage debuff! And take " + (5 + MagicPower / 10) + " damage!") };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage("fire", (5 + MagicPower), "Fire breath! Deals (" + (5 + MagicPower) + " fire damage)") };
                }
            }
            else
            {
                Stamina += 10;
                return new List<StatPackage>() { new StatPackage("cut", (10 + Strength), "Drake needs some time to recharge mana! Hits you with claw (" + (10 + Strength) + " cut damage)!") };
            }
        }
        public override void React(List<StatPackage> packs) // receive the result of your opponent's action
        {
            foreach (StatPackage pack in packs)
            {
                if (pack.DamageType == "fire")
                {
                    Health -= pack.HealthDmg * (100 - Armor) / 500;
                }
                else
                {
                    Health -= pack.HealthDmg * (100 - Armor) / 100;
                }
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
            }
        }
    }
}
