using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{

    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            Flight_State state=Flight_State.Prelaunch;
            Queue myq = new Queue();
            while (run)
            {

                //processInput()
                //update()
                //render()
                
                switch (state)
                {
                    case Flight_State.Prelaunch:
                        #region Prelaunch
                        Falcon9 rocket = new Falcon9("Falcon 9 1.1", "Test Rocket");

                        rocket.LoadPayload(new Payload(10, "Mass Simulator"));

                        rocket.FillTanks();
                        Console.WriteLine("stage 1 mass: " + String.Format("{0:0.000}",(rocket.Stage1.Kerosene.Mass + rocket.Stage1.Oxygen.Mass)));
                        Console.WriteLine("stage 2 mass: " + String.Format("{0:0.000}",(rocket.Stage2.Kerosene.Mass + rocket.Stage2.Oxygen.Mass)));
                        Console.WriteLine("total mass: " + String.Format("{0:0.000}",(rocket.Stage1.Kerosene.Mass + rocket.Stage1.Oxygen.Mass + rocket.Stage2.Kerosene.Mass + rocket.Stage2.Oxygen.Mass)));
                        run = false;
                        #endregion 
                        break;
                    case Flight_State.Launch:
                        break;
                    case Flight_State.Flight:
                        break;
                }
               
            }
        }      
    }
}
