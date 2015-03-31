using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    #region FlightStateEnum
    /// <summary>
    /// List of stages of flight
    /// </summary>
    enum Flight_State
    {
        Prelaunch,
        Launch,
        Flight
    };
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            Flight_State state=Flight_State.Prelaunch;
            while (run)
            {
                #region FiniteStateMachine
                switch (state)
                {
                    case Flight_State.Prelaunch:
                        #region Prelaunch
                        Falcon9 rocket = new Falcon9("Falcon 9 1.1", "Test Rocket");

                        Console.WriteLine(rocket.Name);
                        Console.WriteLine(rocket.Mission);
                        rocket.LoadPayload(new Payload(10, "Mass Simulator"));

                        rocket.FillTanks();
                        Console.WriteLine("stage 1 mass: " + (rocket.Stage1.Kerosene.Mass + rocket.Stage1.Oxygen.Mass));
                        Console.WriteLine("stage 2 mass: " + (rocket.Stage2.Kerosene.Mass + rocket.Stage2.Oxygen.Mass));
                        Console.WriteLine("total mass: " + (rocket.Stage1.Kerosene.Mass + rocket.Stage1.Oxygen.Mass + rocket.Stage2.Kerosene.Mass + rocket.Stage2.Oxygen.Mass));
                        run = false;
                        #endregion 
                        break;
                    case Flight_State.Launch:
                        break;
                    case Flight_State.Flight:
                        break;
                }
                #endregion
            }
 
            


            
        }
    }
}
