using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    class OctoWeb
    {
        public Merlin[] merlinStack;
        private double mass;

        public double Mass
        {
            get { return mass; }
        }

        public OctoWeb(Stage_Type type)
        {
            switch(type)
            {
                case Stage_Type.firstStage:
                    merlinStack = new Merlin[9];
                    mass += 500;
                    for (int i = 0; i < merlinStack.Length;i++ )
                    {
                        merlinStack[i] = new Merlin(Engine_Type.SL);
                        mass += merlinStack[i].Mass;
                    }
                        break;
                case Stage_Type.secondStage:
                    merlinStack = new Merlin[1];
                    mass += 100;
                    for (int i = 0; i < merlinStack.Length; i++)
                    {
                        merlinStack[i] = new Merlin(Engine_Type.Vac);
                        mass += merlinStack[i].Mass;
                    }
                    break;
            }
            
        }

    }
}
