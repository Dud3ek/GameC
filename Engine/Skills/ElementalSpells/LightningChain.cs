using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.ElementalSpells
{
    class LightningChain : Skill
    {
        public LightningChain() : base("Lightning Chain", 30, 3)
        {
            PublicName = "Lightning Chain: 0.7*MP damage [fire] \n Precision stat chance to crit for double damage";
            RequiredItem = "Staff";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("fire");
            int rand = Index.RNG(0, 100);
            if (player.Precision > rand)
            {
                response.HealthDmg = (int)(1.4 * player.MagicPower);
                response.CustomText = "Chain of lightning crits (" + (int)(1.4 * player.MagicPower) + " fire damage)";
            }
            else
            {
                response.HealthDmg = (int)(0.7 * player.MagicPower);
                response.CustomText = "Chain of lightning deals (" + (int)(0.7 * player.MagicPower) + " fire damage)";
            }
            return new List<StatPackage>() { response };
        }
    }
}
