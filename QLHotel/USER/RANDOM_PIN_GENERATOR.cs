using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20142178_20110370_Nhom15_QLHotel
{
    internal static class RANDOM_PIN_GENERATOR
    {
        private static readonly Random random = new Random();

        public static string GenerateRandomPIN(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
