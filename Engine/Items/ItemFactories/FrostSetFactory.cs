using Game.Engine.Items.FrostSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
    class FrostSetFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> frostSet = new List<Item>()
            {
            new OldBook(),
            new RustyFrozenSpear(),
            new FrostyStarWand(),
            new FrostArmor()
            };
            return frostSet[Index.RNG(0, frostSet.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> frostSet = new List<Item>()
            {
            new FrostArmor(),
            new RustyFrozenSpear()
            };
            return frostSet[Index.RNG(0, frostSet.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            List<Item> frostSet = new List<Item>()
            {
            new OldBook(),
            new FrostyStarWand(),
            new FrostArmor()
            };
            return frostSet[Index.RNG(0, frostSet.Count)];
        }
    }
}



