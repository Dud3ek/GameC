using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.FrostSet
{
    class RustyFrozenSpear : Spear
    {
        public RustyFrozenSpear() : base("item1700")
        {
            StrMod = 15;
            GoldValue = 30;
            PublicName = "Rusty Frozen Spear";
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            // staff gives resistances to fire type precision and magic power damage debuffs
            if(pack.DamageType == "fire")
            {
                pack.PrecisionDmg = 0;
                pack.MagicPowerDmg = 0;
            }
            return pack;
        }
    }
}
