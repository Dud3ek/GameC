using Game.Engine.Items.BasicArmor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MyInteractions
{
    [Serializable]
    // it works like training arena
    // training for every stat, stacking cost
    // you can train it for money - cost increases every use
    // or summon mighty creature if you live, your stat will be increased 
    // only 2 summons per stat, infinite number of stacking gold
    class BoulderEncounter : ListBoxInteraction
    {
        // counters for number of summons
        private int summHP = 0;
        private int summStr = 0;
        private int summArm = 0;
        private int summPrec = 0;
        private int summMP = 0;
        private int summSta = 0;
        // multipliers for next stat upgrade cost
        private int multHP = 1;
        private int multStr = 1;
        private int multArm = 1;
        private int multPrec = 1;
        private int multMP = 1;
        private int multSta = 1;
        public BoulderEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction1701";
        }
        protected override void RunContent()
        {
            parentSession.SendText("Welcome to summoning boulder arena! \n You can train your stats here by taking challenge against monsters or paying for complex trainings!");
            int choice = GetListBoxChoice(new List<string>()
            {
                "Increase your durability [+ Health]",
                "Take strength training [+ Strength]",
                "Toughen up your skin [+ Armor]",
                "Aim training [+ Precision]",
                "Magic abilities training [+ MagicPower]",
                "Vital energy training [+ Stamina]"
            });
            switch (choice)
            {
                case 0:
                    Train("Health");
                    break;
                case 1:
                    Train("Strength");
                    break;
                case 2:
                    Train("Armor");
                    break;
                case 3:
                    Train("Precision");
                    break;
                case 4:
                    Train("MagicPower");
                    break;
                case 5:
                    Train("Stamina");
                    break;
            }
        }
        protected void Train(string stat)
        {
            switch (stat)
            {
                case "Stamina":
                    if(summSta <= 1)
                    {
                        ThreeChoice(stat, multSta, 20, 6);
                    }
                    else
                    {
                        TwoChoice(stat, multSta, 20, 6);
                    }
                    break;
                case "Strength":
                    if(summStr <= 1)
                    {
                        ThreeChoice(stat, multStr, 10, 2);
                    }
                    else
                    {
                        TwoChoice(stat, multStr, 10, 2);
                    }
                    break;
                case "Health":
                    if (summHP <= 1)
                    {
                        ThreeChoice(stat, multHP, 20, 1);
                    }
                    else
                    {
                        TwoChoice(stat, multHP, 20, 1);
                    }
                    break;
                case "MagicPower":
                    if (summMP <= 1)
                    {
                        ThreeChoice(stat, multMP, 20, 5);
                    }
                    else
                    {
                        TwoChoice(stat, multMP, 20, 5);
                    }
                    break;
                case "Precision":
                    if (summPrec <= 1)
                    {
                        ThreeChoice(stat, multPrec, 5, 4);
                    }
                    else
                    {
                        TwoChoice(stat, multPrec, 5, 4);
                    }
                    break;
                case "Armor":
                    if(summArm <= 1)
                    {
                        ThreeChoice(stat, multArm, 20, 3);
                    }
                    else
                    {
                        TwoChoice(stat, multArm, 20, 3);
                    }
                    break;
            }
        }
        protected void SummMonster(int stat, int amount, string statName)
        {
            parentSession.SendText("Creature appears! Duel!");
            parentSession.FightRandomMonster();
            parentSession.UpdateStat(stat, amount);
            switch (statName)
            {
                case "Stamina":
                    summSta++;
                    break;
                case "Health":
                    summHP++;
                    break;
                case "Armor":
                    summArm++;
                    break;
                case "Strength":
                    summStr++;
                    break;
                case "MagicPower":
                    summMP++;
                    break;
                case "Precision":
                    summPrec++;
                    break;
            }
            parentSession.SendText("Success! Stat boosted!");
        }
        protected void GoTrain(int cost, int stat, int amount, string multiplicator)
        {
            parentSession.SendText("Training went well \n Money well spent, u gain +" + amount + " Stamina");
            parentSession.UpdateStat(stat, amount);
            parentSession.UpdateStat(8, -1 * cost);
            switch(multiplicator)
            {
                case "Health":
                    multHP *= 5;
                break;
                case "Strength":
                    multStr *= 5;
                break;
                case "Armor":
                    multArm *= 5;
                break;
                case "Precision":
                    multPrec *= 5;
                break;
                case "MagicPower":
                    multMP *= 5;
                break;
                case "Stamina":
                    multSta *= 5;
                break;
            }
        }
        protected void ThreeChoice(string stat, int multi, int amount, int statno)
        {
            int choice = GetListBoxChoice(new List<string>()
            {
                "Summon creature to fight with [+20 "+stat+"]",
                "Pay " + (multi * 25) + " to train and increase "+stat+" by "+amount,
                "Exit arena"
            });
            if (choice == 0)
            {
                SummMonster(statno, amount, stat);
            }
            else if (choice == 1)
            {
                if (parentSession.currentPlayer.Gold >= multSta * 25)
                {
                    GoTrain(multi * 25, statno, amount, stat);
                }
                else
                {
                    parentSession.SendText("U dont have enough money!");
                }
            }
            else
            {
                parentSession.SendText("You exit training arena");
            }
        }
        protected void TwoChoice(string stat, int multi, int amount, int statno)
        {
            int choice = GetListBoxChoice(new List<string>()
                {
                    "Pay " + (multi * 25) + " to train and increase "+stat+" by "+amount,
                    "Exit Arena"
                });

            if (choice == 0)
            {
                if (parentSession.currentPlayer.Gold >= multSta * 25)
                {
                    GoTrain(multi * 25, statno, amount, stat);
                }
                else
                {
                    parentSession.SendText("U dont have enough money!");
                }
            }
            else
            {
                parentSession.SendText("You exit training arena");
            }
        }
    }
}




