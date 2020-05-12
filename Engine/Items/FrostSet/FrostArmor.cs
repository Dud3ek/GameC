using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.FrostSet
{
    class FrostArmor : Item
    {
        public FrostArmor() : base ("item1703")
        {
            ArMod = 60;
            GoldValue = 80;
            PublicName = "Frosty Chestpiece of Soryona";
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            // 50 % resistance against armor reduction
            pack.ArmorDmg = (int)(pack.ArmorDmg / 2);
            return pack;
        }
    }
}
