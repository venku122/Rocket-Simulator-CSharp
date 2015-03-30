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

        const double RADIUS = 3.66;

        Stage_Type type;

        public Stage(Stage_Type type)
        {
            this.type = type;
            switch(type)
            {
                case Stage_Type.firstStage:
                     kerosene = new Tank(20, RADIUS, Fuel_Type.RP1);
                     oxygen = new Tank(20, RADIUS, Fuel_Type.LO2);
                     stageControl = new ControlSystem[3];
                    break;
                case Stage_Type.secondStage:
                     kerosene = new Tank(7, RADIUS, Fuel_Type.RP1);
                     oxygen = new Tank(7, RADIUS, Fuel_Type.LO2);
                     stageControl = new ControlSystem[2];
                    break;
            }


        }
    }
}
