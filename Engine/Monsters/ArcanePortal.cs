using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class ArcanePortal : Monster
    {
        public ArcanePortal(int portalLevel)
        {
            Health = 1 + 5 * portalLevel;
            Strength = 0;
            Armor = 0;
            Precision = 0;
            MagicPower = 5 + portalLevel;
            Stamina = 10;
            XPValue = 0 + portalLevel;
            Name = "monster1700";
            BattleGreetings = "Strange looking portal seems to be hiding something"; 
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                Stamina -= 10;
                // portal can burn you with strange air magic energy
                return new List<StatPackage>() { new StatPackage("air", MagicPower*10, "Portal consumes air around and sends beam! Deals (" + (MagicPower*10) + " air damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, "Portal weakens, lack of energy to harm you") };
            }
        }
    }
}
