using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TehtavaLotto
{
    class BLLotto
    {
        public int type;
        private int smallestNumber;
        private int largestNumber;
        private int numberCount;

        static Random random = new Random();

        /** 
        * Antaa halutun määrän satunnaisia numeroita. Voimassa oleva "type" vaikuttaa numeroiden joukkoon ja määrään.
        **/
        public List<int> ArvoRivi()
        {
            List<int> numbers = new List<int>();

            // Asetetaan halutun pelin asetukset
            if (this.type == 0)
            {
                this.numberCount = 7;
                this.smallestNumber = 1;
                this.largestNumber = 39;
            }
            else if (this.type == 1)
            {
                this.numberCount = 6;
                this.smallestNumber = 1;
                this.largestNumber = 48;
            }
            else if (this.type == 2)
            {
                this.numberCount = 5;
                this.smallestNumber = 1;
                this.largestNumber = 50;
            }
            else if (this.type == 3) // EuroJackpotin lisänumerot, tyyppi valikoituu automaattisesti.
            {
                this.numberCount = 2;
                this.smallestNumber = 1;
                this.largestNumber = 10;
            }

            // Luodaan taulukko, josta tarkistetaan, ettei tule duplikaatteja
            int[] usedNumbers = new int[this.largestNumber + 1];

            do
            {
                // laukeaa, jos numero on jo käytetty
                bool isNumberUsed = false;

                // Arvotaan numero
                int number = random.Next(this.smallestNumber, this.largestNumber + 1);

                // Onko numero käytetty?
                for (int i = 0; i < this.largestNumber; i++)
                {
                    if (number == usedNumbers[i])
                    {
                        isNumberUsed = true;
                    }
                }

                // Jos numero ei käytetty
                if (!isNumberUsed)
                {
                    usedNumbers[number] = number;
                    numbers.Add(number);
                    this.numberCount--;
                }


            } while (this.numberCount > 0);

            return numbers;
        }
    }
}
