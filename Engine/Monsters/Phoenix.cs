using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class Phoenix : Monster
    {
        public Phoenix(int phoLevel)
        {
            Health = 200 + 5 * phoLevel*4;
            Strength = 0;
            Armor = 50;
            Precision = 80;
            MagicPower = 35 + phoLevel * 7;
            Stamina = 40;
            XPValue = 100 + phoLevel * 15;
            Name = "monster1704";
            BattleGreetings = "Big bird rises from flames of fire!";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;

                return new List<StatPackage>() 
                { 
                new StatPackage("fire", MagicPower + 10, "Big flames starts errupting everywhere! Deals (" + (MagicPower + 10) + " fire damage)"),
                new StatPackage("fire", 0, (MagicPower/10),(MagicPower/10),(MagicPower/10), (MagicPower/10), "Phoenix breath weakeans you! U gain - "+(MagicPower/10)+" to all statistics!")
                };
            }
            else
            {
                Stamina += 30;
                return new List<StatPackage>() { new StatPackage("none", 0, "Phoenix lost all his energy! He is harmless to you now!") };
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
