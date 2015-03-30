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
        Stage stage1;
        Stage stage2;
        Payload missionPayload;

        string name;
        string mission;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
        }

        public string Mission
        {
            get { return mission; }
        }

        public Stage Stage1
        {
            get { return stage1; }
        }

        public Stage Stage2
        {
            get { return stage2; }
        }
        #endregion
        public Falcon9(string n, string m)
        {


            stage1 = new Stage(Stage_Type.firstStage);
            stage2 = new Stage(Stage_Type.secondStage);
            

            name = n;
            mission = m;
        }

        public void LoadPayload(Payload p)
        {
            missionPayload = p;
            Console.WriteLine(missionPayload.Name+ " has been loaded onto " + this.name);
        }

        public void UnloadPayload()
        {
            Console.WriteLine(missionPayload.Name + " has been unloaded from " + this.name);
            missionPayload = null;
        }

        public void FillTanks()
        {
            stage1.Fill();
            stage2.Fill();
        }

    }
}
