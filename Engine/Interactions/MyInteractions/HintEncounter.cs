using Game.Engine.Items.FrostSet;
using Game.Engine.Monsters;
using Game.Engine.Skills.BasicSkills;
using Game.Engine.Skills.ElementalSpells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MyInteractions
{
    [Serializable]
    class HintEncounter
    {
        // event about collecting 3 hints in cave to discover item
        //private int fight = 0;
        //private Monster cavePhoenix;
        public int earthHint { get; set; } = 0;
        public int fireHint { get; set; } = 0;
        public int frostHint { get; set; } = 0;
        public int treasureFound { get; set; } = 0;
        public int failedCounter { get; set; } = 0; // u can fail only 2 times
    }
}