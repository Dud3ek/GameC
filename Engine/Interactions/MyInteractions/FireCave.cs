using Game.Engine.Interactions.MyInteractions;
using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class FireCave : ListBoxInteraction
    {
        private HintEncounter hint;
        private int fight = 0;
        private Monster cavePhoenix;
        public FireCave(GameSession ses, HintEncounter hint) : base(ses)
        {
            Name = "interaction1703";
            this.hint = hint;
            cavePhoenix = new Phoenix(parentSession.currentPlayer.Level); //scales with player level
        }
        protected override void RunContent()
        {
            parentSession.SendText("Fiery cave is in front of you");

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
                if(hint.fireHint == 0)
                {
                    Fire();
                }
                else
                {
                    parentSession.SendText("Fire hint already collected");
                }
                if (fight == 1)
                {
                    parentSession.FightThisMonster(cavePhoenix);
                    fight = -1;
                    CheckReward();
                }
            }
        }
        private void Fire()
        {
            parentSession.SendText("Orb starts to errupt with some fire energy!");
            int choice = GetListBoxChoice(new List<string>() { "Keep lighting it up", "Break fire spell and evacuate", "Try increasing heat of spell" });
            if (choice == 0)
            {
                parentSession.SendText("U find some mystery fire ring \n Fire hint found");
                hint.fireHint = 1;
                CheckReward();
            }
            else if (choice == 1)
            {
                parentSession.SendText("U succesfully ran away");
                hint.failedCounter++;
            }
            else
            {
                hint.fireHint = 1;
                if (fight == -1)
                {
                    parentSession.SendText("Phoenix is dead already");
                    parentSession.SendText("U already have this hint");
                }
                else
                {
                    parentSession.SendText("U take some burining stone but then, \n Phoenix rises from the ashes!");
                    fight = 1;
                }
            }
        }
        private void CheckKnown()
        {
            if (hint.earthHint == 1)
            {
                parentSession.SendText("EARTH HINT DONE");
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
