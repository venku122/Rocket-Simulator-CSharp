using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    class Stage
    {
        Tank kerosene;
        Tank oxygen;
        ControlSystem[] stageControl;

        public Stage()
        {
            kerosene = new Tank();
            oxygen = new Tank();
            stageControl= new ControlSystem[3];
        }
    }
}
