using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class FireSphere : Monster
    {   
        public FireSphere(int sphereLevel)
        {
            Health = 1 + 5 * sphereLevel;
            Strength = 0;
            Armor = 0;
            Precision = 0;
            MagicPower = 10 + sphereLevel * 2;
            Stamina = 10;
            XPValue = 0 + sphereLevel;
            Name = "monster1702";
            BattleGreetings = "Sphere seems to be burning, looks like alive source of power";
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                // portal can burn you with strange air magic energy
                return new List<StatPackage>() { new StatPackage("fire", MagicPower * 10, "Fire burn you OUCH! Deals (" + (MagicPower * 10) + " fire damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, "Sphere energy weakened, it has no way to harm you now") };
            }
        }
    }
}
