using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    enum Flight_State
    {
        Prelaunch,
        Launch,
        Flight
    };
    class Program
    {
        static void Main(string[] args)
        {
            Flight_State state=Flight_State.Prelaunch;
            switch(state)
            {
                case Flight_State.Prelaunch:

                     Falcon9 rocket = new Falcon9("Falcon 9 1.1", "Test Rocket");

                     Console.WriteLine(rocket.Name);
                     Console.WriteLine(rocket.Mission);
                     rocket.LoadPayload(new Payload(10, "Mass Simulator"));
                     rocket.Stage1.Kerosene.Fill(50);
                     rocket.Stage1.Oxygen.Fill(50);
                    break;
                case Flight_State.Launch:
                    break;
                case Flight_State.Flight:
                    break;
            }
 
            


            
        }
    }
}
