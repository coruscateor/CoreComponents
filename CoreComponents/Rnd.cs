using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public static class Rnd
    {

        public static int Next()
        {

            return new SRandom().Next();

        }

        public static int Next(int maxValue)
        {

            return new SRandom().Next(maxValue);

        }

        public static int Next(int minValue, int maxValue)
        {

            return new SRandom().Next(minValue, maxValue);

        }

        public static void NextBytes(byte[] buffer)
        {

            new SRandom().NextBytes(buffer);

        }

        public static double NextDouble()
        {

            return new SRandom().NextDouble();

        }

        public static int NextSeeded(int seed)
        {

            return new SRandom(seed).Next();

        }

        public static int NextSeeded(int seed, int maxValue)
        {

            return new SRandom(seed).Next(maxValue);

        }

        public static int NextSeeded(int seed, int minValue, int maxValue)
        {

            return new SRandom(seed).Next(minValue, maxValue);

        }

        public static void NextBytesSeeded(int seed, byte[] buffer)
        {

            new SRandom(seed).NextBytes(buffer);

        }

        public static double NextDoubleSeeded(int seed)
        {

            return new SRandom(seed).NextDouble();

        }

    }

}
