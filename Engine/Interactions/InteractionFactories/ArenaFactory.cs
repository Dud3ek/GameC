using Game.Engine.Interactions.MyInteractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class ArenaFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession ses)
        {
            BoulderEncounter bld = new BoulderEncounter(ses);
            return new List<Interaction>() { bld };
        }
    }
}
