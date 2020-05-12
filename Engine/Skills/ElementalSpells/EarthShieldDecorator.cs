using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Skills.ElementalSpells
{
    class EarthShieldDecorator : SkillDecorator
    {
        public EarthShieldDecorator(Skill skill) : base("Earth Shield", 10, 2, skill)
        {
            MinimumLevel = Math.Max(1, skill.MinimumLevel) + 1;
            PublicName = "COMBO - Add EARTH SHIELD to your already known " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Staff";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            player.Health += player.MagicPower * 2;
            StatPackage response = new StatPackage("earth");
            response.CustomText = "You use shield and gain " + (2 * player.MagicPower) + " temporary increased health";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
