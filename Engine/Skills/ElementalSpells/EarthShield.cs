using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.ElementalSpells
{
    class EarthShield : Skill
    {
        public EarthShield() : base ("Earth Shield", 10, 2)
        {
            PublicName = "Earth Shield: Gain temporary shield in value of 2*MP stat";
            RequiredItem = "Staff";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            player.Health += player.MagicPower*2; 
            StatPackage response = new StatPackage("earth");
            response.CustomText = "You use shield and gain "+(2*player.MagicPower)+" temporary increased health";
            return new List<StatPackage>() { response };
        }
    }
}
