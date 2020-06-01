using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game.Engine.Interactions.MyInteractions
{
    [Serializable]
    class FrostCave : ListBoxInteraction
    {
        private HintEncounter hint;
        public FrostCave(GameSession ses, HintEncounter hint) : base (ses)
        {
            Name = "interaction1704";
            this.hint = hint;
        }
        protected override void RunContent()
        {
            parentSession.SendText("You enter some frosty cave");

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
                if (hint.frostHint == 0)
                {
                    Frost();
                }
                else
                {
                    parentSession.SendText("Frost hint already collected");
                }
            }
            

        }
        private void Frost()
        {
            parentSession.SendText("Frost energy flashes around whole room!");
            int choice = GetListBoxChoice(new List<string>() { "Keep freezing light source", "Run away", "Stop using frost spells and wait what will happen" });
            if (choice == 0)
            {
                parentSession.SendText("Frozen orb explodes, u gather rest of it \n Hint Found!");
                hint.frostHint = 1;
                CheckReward();
            }
            else if (choice == 1)
            {
                parentSession.SendText("You run away!");
                hint.failedCounter++;
            }
            else
            {
                parentSession.SendText("Unstable energy errupts and damages you, u wake up few hours later and notice ur missing sack of gold! \n U were roobbed for 100 gold");
                parentSession.UpdateStat(8, -100);
                hint.failedCounter++;
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
        private void CheckKnown()
        {
            if (hint.earthHint == 1)
            {
                parentSession.SendText("EARTH HINT DONE");
            }
            if (hint.fireHint == 1)
            {
                parentSession.SendText("FIRE HINT DONE");
            }
        }
    }
}
