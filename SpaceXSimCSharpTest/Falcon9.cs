using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    class Falcon9
    {
        Stage stage1;
        Stage stage2;
        Payload missionPayload;

        string name;
        string mission;

        public string Name
        {
            get { return name; }
        }

        public string Mission
        {
            get { return mission; }
        }
        public Falcon9(string n, string m)
        {


            stage1 = new Stage();
            stage2 = new Stage();
            missionPayload = new Payload();

            name = n;
            mission = m;
        }

    }
}
