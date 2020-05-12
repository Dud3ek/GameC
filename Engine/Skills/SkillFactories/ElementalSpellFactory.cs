using Game.Engine.CharacterClasses;
using Game.Engine.Skills.ElementalSpells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace Game.Engine.Skills.SkillFactories
{
    class ElementalSpellFactory : SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); 
            if (known == null) 
            {
                Blizzard s1 = new Blizzard();
                LightningChain s2 = new LightningChain();
                EarthShield s3 = new EarthShield();

                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); 
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; 
            }
            else if (known.decoratedSkill == null) 
            {
                BlizzardDecorator s1 = new BlizzardDecorator(known);
                LightningChainDecorator s2 = new LightningChainDecorator(known);
                EarthShieldDecorator s3 = new EarthShieldDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); 
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null; 
        }
        private Skill CheckContent(List<Skill> skills) 
        {
            foreach (Skill skill in skills)
            {
                if (skill is EarthShield || skill is LightningChain || skill is Blizzard || skill is EarthShieldDecorator || skill is LightningChainDecorator || skill is BlizzardDecorator) return skill;
            }
            return null;
        }
    }
}
