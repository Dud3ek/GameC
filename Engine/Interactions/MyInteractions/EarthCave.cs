using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MyInteractions
{
    [Serializable]
    class EarthCave : ListBoxInteraction
    {
        private HintEncounter hint;
        public EarthCave(GameSession ses, HintEncounter hint) : base(ses)
        {
            Name = "interaction1700";
            this.hint = hint;
        }
        protected override void RunContent()
        {
            parentSession.SendText("You enter some strange cave, earth seems to be living here");

            if (hint.treasureFound == 1)
            {
                parentSession.SendText("Treasure already found");
            }
            else if (hint.failedCounter >= 2)
            {
                parentSession.SendText("Caves are closed now, u failed to obtain a treasure");
            }
            else
            {
                CheckKnown();
                if (hint.earthHint == 0)
                {
                    Earth();
                }
                else
                {
                    parentSession.SendText("Earth hint already collected");
                }
            }
            
            
        }
        private void Earth()
        {
            parentSession.SendText("You notice this is some kind of living boulder! \n It starts errupting and causing little earthquake");
            int choice = GetListBoxChoice(new List<string>() { "Run away", "Wait what will happen" });
            if (choice == 0)
            {
                parentSession.SendText("You run away, u feel like u might have angered someone");
                hint.failedCounter++;
            }
            else
            {
                parentSession.SendText("Boulder explodes, u have gathered it remains! \n Mystery Treasure hint found!");
                hint.earthHint = 1;
                CheckReward();
            }
        }
        private void CheckKnown()
        {
            if (hint.fireHint == 1)
            {
                parentSession.SendText("FIRE HINT DONE");
            }
            if (hint.frostHint == 1)
            {
                parentSession.SendText("FROST HINT DONE");
            }
        }
        private void CheckReward()
        {
            if ((hint.earthHint == 1) && (hint.frostHint == 1) && (hint.fireHint == 1))
            {
                parentSession.AddRandomClassItem();
                parentSession.SendText("Congratulations u solved mystery of caves");
                hint.treasureFound = 1;
            }
        }
    }
}
