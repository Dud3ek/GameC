using Game.Engine.Interactions.MyInteractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class SmugglerFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession ses)
        {
            WizardEncounter wiz = new WizardEncounter(ses);
            return new List<Interaction>() { wiz };
        }
    }
}
