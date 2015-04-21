using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SpaceXSimCSharpTest
{

    class Stage
    {
        #region Fields
        Tank kerosene;
        Tank oxygen;
        ControlSystem[] stageControl;
        Stage_Type type;
        OctoWeb engineStructure;
        #endregion



        #region Properties
        public Tank Kerosene
        {
            get { return kerosene; }
        }

        public Tank Oxygen
        {
            get { return oxygen; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a stage with dynamically sized tanks based on stage type
        /// </summary>
        /// <param name="type">Type of stage this is</param>
        public Stage(Stage_Type type)
        {
            //2.56 to 1 LOX to RP1
            this.type = type;
            switch (type)
            {
                case Stage_Type.firstStage:
                    #region FirstStage
                    /*
                    kerosene = new Tank(10.477, Global.RADIUS, Fuel_Type.RP1);
                    oxygen = new Tank(26.822, Global.RADIUS, Fuel_Type.LO2);
                    

                    kerosene = new Tank(12.996, Global.RADIUS, Fuel_Type.RP1);
                    oxygen = new Tank(24.304, Global.RADIUS, Fuel_Type.LO2);
                    */
                    kerosene = new Tank(Global.FIRSTSTAGELENGTHRP1, Global.RADIUS, Fuel_Type.RP1);
                    oxygen = new Tank(Global.FIRSTSTAGELENGTHLO2, Global.RADIUS, Fuel_Type.LO2);
                    stageControl = new ControlSystem[3];
                    engineStructure = new OctoWeb(type);
                    // engineStructure= new OctoWeb()
                    #endregion
                    break;
                case Stage_Type.secondStage:
                    #region SecondStage
                    /*
                    kerosene = new Tank(3.932, Global.RADIUS, Fuel_Type.RP1);
                    oxygen = new Tank(10.068, Global.RADIUS, Fuel_Type.LO2);
                    
                    kerosene = new Tank(4.464, Global.RADIUS, Fuel_Type.RP1);
                    oxygen = new Tank(10.536, Global.RADIUS, Fuel_Type.LO2);
                    
                    kerosene = new Tank(5.190, Global.RADIUS, Fuel_Type.RP1);
                    oxygen = new Tank(9.81, Global.RADIUS, Fuel_Type.LO2);
                     * */
                    kerosene = new Tank(Global.SECONDSTAGELENGTHRP1, Global.RADIUS, Fuel_Type.RP1);
                    oxygen = new Tank(Global.SECONDSTAGELENGTHLO2, Global.RADIUS, Fuel_Type.LO2);
                    stageControl = new ControlSystem[2];
                    engineStructure = new OctoWeb(type);
                    #endregion
                    break;
            }


        }
        #endregion

        #region Methods
        #region Deprecated ThreadFill
        //Deprecated, currently implemented in ThreadManager
        /*
        /// <summary>
        /// Creates two threads to fill up both propellant tanks
        /// </summary>
        public void FillThreaded()
        {
            Thread fill1 = new Thread(this.FillLO2);
            Thread fill2 = new Thread(this.FillRP1);
            fill1.Start();
            fill2.Start();
            fill2.Join();

        }

        */
        /// <summary>
        /// Fills up a LO2 tank
        /// </summary>
        #endregion

        public void FillLO2()
        {
            if (oxygen.FilledVolume < oxygen.MaxVolume)
            {
                oxygen.Fill(Global.LO2FillRate);
            }
        }
        /// <summary>
        /// Fills up an RP1 tank
        /// </summary>
        public void FillRP1()
        {
            if (kerosene.FilledVolume < kerosene.MaxVolume)
            {
                kerosene.Fill(Global.RP1FillRate);
            }
        }

        public bool IsFilled()
        {
            if (oxygen.FilledVolume >= oxygen.MaxVolume && kerosene.FilledVolume >= kerosene.MaxVolume)
            {
                Console.WriteLine("isFilled is true" + type.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FireEngines()
        {
            Console.WriteLine("engines have been fired");
            for (int i = 0; i < engineStructure.merlinStack.Length; i++)
            {
                engineStructure.merlinStack[i].Update(this);
            }
        
        }

        public double TotalThrust()
        {
            double total = 0;
            for (int i = 0; i < engineStructure.merlinStack.Length; i++)
            {
                total += engineStructure.merlinStack[i].Thrust;
            }
            return total;
        }

        public double SingleThrust()
        {
            return engineStructure.merlinStack[1].Thrust;
        }

        public double TotalMass()
        {
            return oxygen.Mass + kerosene.Mass + engineStructure.Mass;
        }

        public void ChangeThrottle(double v)
        {
            for (int i = 0; i < engineStructure.merlinStack.Length; i++)
            {
                engineStructure.merlinStack[i].ChangeThrottle(v);
            }
        }
        #endregion
    }
}
