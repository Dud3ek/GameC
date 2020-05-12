using Game.Engine.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    class FireDrakesFactory : MonsterFactory
    {
        // production of fire sphere, fire drake and phoenix event
        private int encounterNumber = 0;
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new FireSphere(playerLevel);
            }
            else if (encounterNumber == 1)
            {
                encounterNumber++;
                return new FireDrake(playerLevel);
            }
            else if (encounterNumber == 2)
            {
                encounterNumber++;
                return new Phoenix(playerLevel);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new FireSphere(0).GetImage();
            else if (encounterNumber == 1) return new FireDrake(0).GetImage();
            else if (encounterNumber == 2) return new Phoenix(0).GetImage();
            else return null;
        }
    }
}


