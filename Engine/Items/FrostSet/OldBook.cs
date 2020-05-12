using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.FrostSet
{
    class OldBook : Staff
    {
        public OldBook() : base("item1701")
        {
            PrMod = 20;
            GoldValue = 100;
            PublicName = "Old Frosty Book";
        }
        public override void ApplyBuffs(Player currentPlayer, List<string> otherItems)
        {
            // this book doubles basic magic power of holder

            currentPlayer.HealthBuff += HpMod;
            currentPlayer.StrengthBuff += StrMod;
            currentPlayer.ArmorBuff += ArMod;
            currentPlayer.PrecisionBuff += PrMod;
            currentPlayer.StaminaBuff += StaMod;

            currentPlayer.MagicPowerBuff = currentPlayer.MagicPower;
        }
    }
}
