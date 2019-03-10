using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class FruitTree
    {
        public string typeOfFruit;
        public int piecesOfFruitLeft;

        public string TypeOfFruit
        {
            get
            {
                return typeOfFruit;
            }
        }
        public int PiecesOfFruitLeft
        {
            get
            {
                return piecesOfFruitLeft;
            }
            private set
            {
                piecesOfFruitLeft = value;
            }
        }

        public bool PickFruit(int numberOfPiecesToRemove)
        {
            if (piecesOfFruitLeft > 0)
            {
                piecesOfFruitLeft -= numberOfPiecesToRemove;
                return true;
            }
            return false;
        }

        public FruitTree(string typeOfFruit, int startingPiecesOfFruit)
        {
            this.typeOfFruit = typeOfFruit;
            this.piecesOfFruitLeft = startingPiecesOfFruit;
        }
    }
}
