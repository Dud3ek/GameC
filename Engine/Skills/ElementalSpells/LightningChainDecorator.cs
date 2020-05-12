using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.ElementalSpells
{
    class LightningChainDecorator : SkillDecorator
    {
        public LightningChainDecorator(Skill skill) : base("Lightning Chain", 30, 3, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Add Lightning Chain to your already known " + decoratedSkill.PublicName.Replace("COMBO: ", "");
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
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
