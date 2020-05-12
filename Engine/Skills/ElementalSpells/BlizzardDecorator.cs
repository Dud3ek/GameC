using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.ElementalSpells
{
    class BlizzardDecorator : SkillDecorator
    {
        public BlizzardDecorator(Skill skill) : base("Blizzard", 20, 4, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Add BLIZZARD to your already known " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Staff";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("water");
            response.HealthDmg = 20 + (int)(0.3 * player.MagicPower);
            if (Index.RNG(1, 100) <= 40)
            {
                response.StrengthDmg = (int)(0.2 * player.MagicPower);
                response.CustomText = "Blizzard deals " + (20 + (int)(0.3 * player.MagicPower)) + " water damage\n Enemy strength reduced by " + (int)(0.2 * player.MagicPower);
            }
            else
            {
                response.CustomText = "Blizzard deals " + (20 + (int)(0.3 * player.MagicPower)) + " water damage";
            }
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
