using Game.Engine.Interactions.Built_In;
using Game.Engine.Interactions.MyInteractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class CaveFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession ses)
        {
            HintEncounter hint = new HintEncounter();
            EarthCave earth = new EarthCave(ses, hint);
            FrostCave frost = new FrostCave(ses, hint);
            FireCave fire = new FireCave(ses, hint);
            return new List<Interaction>() { fire, earth, frost };
        }
    }
}
