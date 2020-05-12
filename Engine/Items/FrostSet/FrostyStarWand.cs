using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.FrostSet
{
    class FrostyStarWand : Staff
    {
        public FrostyStarWand() : base("item1702")
        {
            MgcMod = 20;
            GoldValue = 50;
            PublicName = "Frosty Star Wand";
            StaMod = 20;
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            pack.PrecisionDmg += 12;
            return pack;
        }

    }
}
