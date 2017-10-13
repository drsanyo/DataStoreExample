using System;
using System.Security.Cryptography;

namespace DataStoreExample.Common
{
    public class RandomGenerator : RandomNumberGenerator
    {
        private static RandomNumberGenerator randomNumberGenerator;
    
        public RandomGenerator()
        {
            randomNumberGenerator = RandomNumberGenerator.Create();
        }
    
        public override void GetBytes(byte[] buffer)
        {
            randomNumberGenerator.GetBytes(buffer);
        }
    
        public double NextDouble()
        {
            byte[] b = new byte[4];
            randomNumberGenerator.GetBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }
    
        public int Next(int minValue, int maxValue)
        {
            return (int)Math.Round(NextDouble() * (maxValue - minValue - 1)) + minValue;
        }
    
        public int Next()
        {
            return Next(0, Int32.MaxValue);
        }
    
        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }
    }
}
