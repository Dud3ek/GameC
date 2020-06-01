using Game.Engine.Interactions.MyInteractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class MDFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession ses)
        {
            WizardEncounter wizard = new WizardEncounter(ses);
            BoulderEncounter bld = new BoulderEncounter(ses);
            HintEncounter hint = new HintEncounter(ses);
            return new List<Interaction>() { hint, bld, wizard };
        }
    }
}
