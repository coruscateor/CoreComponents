using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public static class Randoms
    {

        static readonly SRandom myRandom = new SRandom();

        public static int Next()
        {

            var random = myRandom;

            lock(random)
            {

                return random.Next();

            }

        }

        public static int Next(int maxValue)
        {

            var random = myRandom;

            lock(random)
            {

                return random.Next(maxValue);

            }

        }

        public static int Next(int minValue, int maxValue)
        {

            var random = myRandom;

            lock(random)
            {

                return random.Next(minValue, maxValue);

            }

        }

        public static void NextBytes(byte[] buffer)
        {

            var random = myRandom;

            lock(random)
            {

                random.NextBytes(buffer);

            }

        }

        public static double NextDounble()
        {

            var random = myRandom;

            lock(random)
            {

                return random.NextDouble();

            }

        }

    }

}
