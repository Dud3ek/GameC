using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    class ArcaneFactory : MonsterFactory
    {
        // this factory will produce ArcanePortal into GnomeMage event 

        private int encounterNumber = 0; // number of use
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new ArcanePortal(playerLevel);
            }
            else if (encounterNumber == 1)
            {
                encounterNumber++;
                return new GnomeMage(playerLevel);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new ArcanePortal(0).GetImage();
            else if (encounterNumber == 1) return new GnomeMage(0).GetImage();
            else return null;
        }
    }
}
