using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Falcon9 rocket = new Falcon9("Falcon 9 1.0", "Test Rocket");

            Console.WriteLine(rocket.Name);
            Console.WriteLine(rocket.Mission);
        }
    }
}
