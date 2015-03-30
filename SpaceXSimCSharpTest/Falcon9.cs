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


            stage1 = new Stage(Stage_Type.firstStage);
            stage2 = new Stage(Stage_Type.secondStage);
            

            name = n;
            mission = m;
        }

        public void LoadPayoad(Payload p)
        {
            missionPayload = p;
            Console.WriteLine(missionPayload.Name+ " has been loaded onto " + this.name);
        }

        public void UnloadPayload()
        {
            Console.WriteLine(missionPayload.Name + " has been unloaded from " + this.name);
            missionPayload = null;
        }

    }
}
