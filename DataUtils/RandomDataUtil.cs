using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.DataUtils
{
    public class RandomDataUtil
    {
        private static readonly Random random = new Random();

        public static String GenerateRandomString(int length)
        {
            const String chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] randomChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(randomChars);
        }

        public static int GenerateRandomInt(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue + 1);
        }

    }
}
