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
    class HintEncounter : ListBoxInteraction
    {
        // event about collecting 3 hints in cave to discover item
        private int fight = 0;
        private Monster cavePhoenix;
        private int earthHint = 0;
        private int fireHint = 0;
        private int frostHint = 0;
        private int treasureFound = 0;
        private int failedCounter = 0; // u can fail only 2 times
        public HintEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction1700";
            cavePhoenix = new Phoenix(parentSession.currentPlayer.Level); //scales with player level
        }
        protected override void RunContent()
        {
            if (failedCounter == 2)
            {
                parentSession.SendText("This cave will remains mystery for you forever");
            }
            else
            {
                if (treasureFound == 0)
                {
                    if ((fireHint == 1)&&(frostHint==1)&&(earthHint==1))
                    {
                        parentSession.SendText("You found some mystery item! Enjoy your drop!");
                        parentSession.AddRandomItem();
                        treasureFound = 1;
                        return;
                    }
                    else
                    {
                        parentSession.SendText("\n You found some strange shining element! \n" +
                        "Collect 3 hints and come back for reward");

                        int choice = GetListBoxChoice(new List<string>() { "Hit it with earth spell", "Freeze it to crack open", "Light it up with fire spell" });
                        switch (choice)
                        {
                            case 0:
                                Earth();
                                break;
                            case 1:
                                Frost();
                                break;
                            case 2:
                                Fire();
                                break;
                        }
                        if (fight == 1)
                        {
                            parentSession.FightThisMonster(cavePhoenix);
                            fight = -1;
                        }
                    }
                }
                else
                {
                    parentSession.SendText("U already discovered a mystery treasure!");
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
                failedCounter++;
            }
            else
            {
                parentSession.SendText("Boulder explodes, u have gathered it remains! \n Mystery Treasure hint found!");
                earthHint = 1;
            }
        }
        private void Frost()
        {
            parentSession.SendText("Frost energy flashes around whole room!");
            int choice = GetListBoxChoice(new List<string>() { "Keep freezing light source", "Run away", "Stop using frost spells and wait what will happen" });
            if (choice == 0)
            {
                parentSession.SendText("Frozen orb explodes, u gather rest of it \n Hint Found!");
                frostHint = 1;
            }
            else if (choice == 1)
            {
                parentSession.SendText("You run away!");
                failedCounter++;
            }
            else
            {
                parentSession.SendText("Unstable energy errupts and damages you, u wake up few hours later and notice ur missing sack of gold! \n U were roobbed for 100 gold");
                parentSession.UpdateStat(8, -100);
                failedCounter++;
            }
        }
        private void Fire()
        {
            parentSession.SendText("Orb starts to errupt with some fire energy!");
            int choice = GetListBoxChoice(new List<string>() { "Keep lighting it up", "Break fire spell and evacuate", "Try increasing heat of spell" });
            if(choice == 0)
            {
                parentSession.SendText("U find some mystery fire ring \n Fire hint found");
                fireHint = 1;
            }
            else if(choice == 1)
            {
                parentSession.SendText("U succesfully ran away");
                failedCounter++;
            }
            else
            {
                fireHint = 1;
                if (fight == -1)
                {
                    parentSession.SendText("Phoenix is dead already");
                }
                else
                {
                    parentSession.SendText("U take some burining stone but then, \n Phoenix rises from the ashes!");
                    fight = 1;
                }
                
            }
        }
    }
}