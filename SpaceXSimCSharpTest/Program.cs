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
            rocket.LoadPayoad(new Payload(10, "Mass Simulator"));
            rocket.UnloadPayload();
            Tank test = new Tank(20, 3.66, Fuel_Type.RP1);

            Console.WriteLine("Filled Volume: " + test.FilledVolume + " Max Volume: " + test.MaxVolume + " Mass: " + test.Mass);
            test.Fill(5);
            Console.WriteLine("Filled Volume: " + test.FilledVolume + " Max Volume: " + test.MaxVolume + " Mass: " + test.Mass);

            while(test.FilledVolume<test.MaxVolume)
            {
             test.Fill(10);
             Console.WriteLine("Filled Volume: " + test.FilledVolume + " Max Volume: " + test.MaxVolume + " Mass: " + test.Mass);
            }

            
        }
    }
}
