using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    public enum Stage_Type
    {
        firstStage, secondStage
    };

    class Stage
    {

        Tank kerosene;
        Tank oxygen;
        ControlSystem[] stageControl;

        const double RADIUS = 1.83;

        Stage_Type type;

        public Tank Kerosene
        {
            get { return kerosene; }
        }

        public Tank Oxygen
        {
            get { return oxygen; }
        }
        //2.56 to 1 LOX to RP1
        public Stage(Stage_Type type)
        {
            this.type = type;
            switch(type)
            {
                case Stage_Type.firstStage:
                     kerosene = new Tank(10.477, RADIUS, Fuel_Type.RP1);
                     oxygen = new Tank(26.822, RADIUS, Fuel_Type.LO2);
                     stageControl = new ControlSystem[3];
                    break;
                case Stage_Type.secondStage:
                     kerosene = new Tank(3.932, RADIUS, Fuel_Type.RP1);
                     oxygen = new Tank(10.068, RADIUS, Fuel_Type.LO2);
                     stageControl = new ControlSystem[2];
                    break;
            }


        }
    }
}
