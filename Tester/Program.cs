using TimeClockData;
using TimeClock.Security;


namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = UserSecurity.CreateHash("123456");

            var t2 = UserSecurity.VerifyPassword("password", test);
            
            
        }
    }
}
