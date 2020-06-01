using Game.Engine.CharacterClasses;
using Game.Engine.Items;
using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MyInteractions
{
    [Serializable]
    class WizardEncounter : ListBoxInteraction
    {
        private int state = 0; // if 1 then goblin dont want to interact with you again
        private Item it1, it2, it3;
        private int priceMultiplier;
        private int fight = 0;
        private Monster goblinMage;
        private Monster support;
        public WizardEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction1702";
            goblinMage = new GnomeMage(10); //vendors are always level 10 creatures
            support = new GnomeMage(parentSession.currentPlayer.Level);
            it1 = Index.RandomClassItem(parentSession.currentPlayer);
            it2 = Index.RandomClassItem(parentSession.currentPlayer);
            it3 = Index.RandomClassItem(parentSession.currentPlayer);
            priceMultiplier = Index.RNG(1, 101); // if 40 is the result price of item is the same as value
        }
        protected override void RunContent()
        {
            if(state == 0)
            {
                parentSession.SendText("Welcome to goblin wizard black market!");
                parentSession.SendText("Goblin has such items to sell today: ");
                parentSession.RemovableItems = true;
                parentSession.ItemSellFlag = true;
                int choice = GetListBoxChoice(new List<string>()
            {
                it1.PublicName + " costs " + ((it1.GoldValue * priceMultiplier / 40)) + " gold",
                it2.PublicName + " costs " + ((it2.GoldValue * priceMultiplier / 40)) + " gold",
                it3.PublicName + " costs " + ((it3.GoldValue * priceMultiplier / 40)) + " gold",
                "Wait for goblin vendor to go away and try to steal item",
                "Exit Shop"
            });
                switch (choice)
                {
                    case 0:
                        BuyItem(it1);
                        break;
                    case 1:
                        BuyItem(it2);
                        break;
                    case 2:
                        BuyItem(it3);
                        break;
                    case 3:
                        Steal();
                        break;
                    case 4:
                        parentSession.SendText("You exit goblin smuggler shop");
                        break;
                }
                parentSession.RemovableItems = false;
                parentSession.ItemSellFlag = false;
                if (fight == 1)
                {
                    parentSession.FightThisMonster(goblinMage);
                }
            }
            else if (state == 1)
            {
                parentSession.SendText("Goblin does not want to talk with you, \n If you come back again you might get hurt");
                state = 2;
            }
            else if (state == 2)
            {
                parentSession.SendText("Goblin mage attacks you!");
                parentSession.FightThisMonster(support);
                state = 3;
            }
            else
            {
                parentSession.SendText("Goblin owning store is dead");
                Enterable = false;
            }
        }
        protected void BuyItem(Item it)
        {
            if(parentSession.currentPlayer.Gold >= (it.GoldValue * priceMultiplier / 40))
            {
                parentSession.AddThisItem(it);
                parentSession.UpdateStat(8, -1 * (it.GoldValue * priceMultiplier / 40));
            }
            else
            {
                parentSession.SendText("You don't have enough money!");
            }
        }
        protected void Steal()
        {
            parentSession.SendText("Goblin vendor went away \n What do you do?");
            int choice = GetListBoxChoice(new List<string>()
            {
                "Attempt to steal " + it1.PublicName + " item before vendor comes back",
                "Grab " + it2.PublicName + " and run away",
                "Reach for " + it3.PublicName + " and slowly start going out",
                "Seems like goblin is not interested in trade with you, return world exploration"
            });

            if (choice == 0)
            {
                parentSession.SendText("Goblin grabs you and calls for his homies \n They steal gold from you");
                parentSession.UpdateStat(8, -50);
                state = 1;
            }
            else if (choice == 1)
            {
                parentSession.SendText("Item sucessfully stolen \n Goblin got angered");
                parentSession.AddThisItem(it2);
                state = 1;
            }
            else if (choice == 2)
            {
                parentSession.SendText("Goblin grabs you and you start a fight with him");
                state = 1;
                fight = 1;
            }
            else
            {
                parentSession.SendText("You leave store");
            }            
        }
    }
}

