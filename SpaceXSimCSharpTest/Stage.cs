using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SpaceXSimCSharpTest
{
    #region StageTypeEnum
    public enum Stage_Type
    {
        firstStage, secondStage
    };
    #endregion
    class Stage
    {
        #region Fields
        Tank kerosene;
        Tank oxygen;
        ControlSystem[] stageControl;
        Stage_Type type;
        #endregion

        #region FillRateConstants
        const double RADIUS = 1.83;
        const double RP1FillRate = 10;
        const double LO2FillRate = 25;
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
            switch(type)
            {
                case Stage_Type.firstStage:
                    #region FirstStage
                     kerosene = new Tank(10.477, RADIUS, Fuel_Type.RP1);
                     oxygen = new Tank(26.822, RADIUS, Fuel_Type.LO2);
                     stageControl = new ControlSystem[3];
                    #endregion
                    break;
                case Stage_Type.secondStage:
                    #region SecondStage
                     kerosene = new Tank(3.932, RADIUS, Fuel_Type.RP1);
                     oxygen = new Tank(10.068, RADIUS, Fuel_Type.LO2);
                     stageControl = new ControlSystem[2];
                    #endregion
                    break;
            }


        }
        #endregion

        #region Methods
        public void FillThreaded()
        {
            Thread fill1 = new Thread(this.FillLO2);
            Thread fill2 = new Thread(this.FillRP1);
            fill1.Start();
            fill2.Start();

        }

        private void FillLO2()
        {
            while (oxygen.FilledVolume < oxygen.MaxVolume)
            {
                oxygen.Fill(LO2FillRate);
            }
        }

        private void FillRP1()
        {
            while (kerosene.FilledVolume < kerosene.MaxVolume)
            {
                kerosene.Fill(RP1FillRate);
            }
        }
        #endregion
    }
}
