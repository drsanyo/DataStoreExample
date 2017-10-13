using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreExample.BusinessLogic
{
    public class UserRepositoryBase
    {
        public List<User> GetTestUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Age = 35,
                    Name = "Tomas"
                },
                new User()
                {
                    Age = 33,
                    Name = "Elisabeth"
                },

                new User()
                {
                    Age = 10,
                    Name = "Caroline"
                },

                new User()
                {
                    Age = 3,
                    Name = "Caterina"
                }
            };
        }

        protected int uDelay(long delay)
        {
            int result = 0;
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            long v = (delay * System.Diagnostics.Stopwatch.Frequency) / 1000000;
            while (stopwatch.ElapsedTicks < v)
            {
                result++;
            }
            return result;
        }

    }
}
