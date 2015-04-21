using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    class Falcon9
    {
        #region Fields
        //Each Falcon 9 is made of two stages
        Stage stage1;
        Stage stage2;

        //Payload is not simulated, Consists of a name and mass
        Payload missionPayload;

        //Rocket has a name and a mission
        string name;
        string mission;
        
        #endregion

        #region Properties
        /// <summary>
        /// Returns the model name of the rocket
        /// </summary>
        public string Name
        {
            get { return name; }
        }
        /// <summary>
        /// Returns the mission name 
        /// </summary>
        public string Mission
        {
            get { return mission; }
        }
        /// <summary>
        /// returns a stage object of the first stage
        /// </summary>
        public Stage Stage1
        {
            get { return stage1; }
        }
        /// <summary>
        /// returns a stage object of the second stage
        /// </summary>
        public Stage Stage2
        {
            get { return stage2; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Falcon 9
        /// </summary>
        /// <param name="n">Model name of the Rocket</param>
        /// <param name="m">Mission Title</param>
        public Falcon9(string n, string m)
        {


            stage1 = new Stage(Stage_Type.firstStage);
            stage2 = new Stage(Stage_Type.secondStage);

            missionPayload = null;

            name = n;
            mission = m;

            Console.WriteLine(Name);
            Console.WriteLine(Mission);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Loads a payload onto the rocket
        /// </summary>
        /// <param name="p">Payload object to be loaded</param>
        public void LoadPayload(Payload p)
        {
            if (missionPayload == null)
            {
                missionPayload = p;
                Console.WriteLine(missionPayload.Name + " has been loaded onto " + this.name);
            }
            else
            {
                Console.WriteLine("Payload already loaded. Load command failed");
            }
        }

        /// <summary>
        /// Removes the current payload from the rocket
        /// </summary>
        public void UnloadPayload()
        {
            Console.WriteLine(missionPayload.Name + " has been unloaded from " + this.name);
            missionPayload = null;
        }

        /// <summary>
        /// Fills the tanks on the Falcon 9 until full
        /// </summary>
        public void FillTanks()
        {
            /*
            stage1.FillThreaded();
            stage2.FillThreaded();
            */
        }

        public double CalculateMass()
        {
            double massSum = 0;
            massSum += stage1.TotalMass();
            massSum += stage2.TotalMass();
            return massSum;
        }

        public double CalculateAcceleration(Flight_State s)
        {
            switch(s)
            {
                case Flight_State.Launch:
                    #region Launch

                    return stage1.TotalThrust() / CalculateMass();
                    #endregion
                    break;
                case Flight_State.Flight:
                    #region Flight
                    return stage2.TotalThrust()/CalculateMass();
                    #endregion
                    break;
                default:
                    return 0;
                    break;
            }
        }
        #endregion
    }
}
