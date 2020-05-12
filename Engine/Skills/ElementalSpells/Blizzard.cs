using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.ElementalSpells
{
    class Blizzard : Skill
    {
        public Blizzard() : base("Blizzard", 20, 4)
        {
            PublicName = "Blizzard: 20 + 0.3*MP damage [water]\n 40% chance to reduce strength of enemy by 0.2*MP";
            RequiredItem = "Staff";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("water");
            response.HealthDmg = 20 + (int)(0.3 * player.MagicPower);
            if (Index.RNG(1,100) <= 40)
            {
                response.StrengthDmg = (int)(0.2 * player.MagicPower);
                response.CustomText = "Blizzard deals " + (20 + (int)(0.3 * player.MagicPower)) + " water damage\n Enemy strength reduced by "+ (int)(0.2*player.MagicPower);
            }
            else
            {
                response.CustomText = "Blizzard deals " + (20 + (int)(0.3 * player.MagicPower)) + " water damage";
            }
            return new List<StatPackage>() { response };
        }

    }
}
