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

        public OctoWeb(Stage_Type type)
        {
            switch(type)
            {
                case Stage_Type.firstStage:
                    merlinStack = new Merlin[9];
                    for (int i = 0; i < merlinStack.Length;i++ )
                    {
                        merlinStack[i] = new Merlin(Engine_Type.SL); 
                    }
                        break;
                case Stage_Type.secondStage:
                    merlinStack = new Merlin[1];
                    for (int i = 0; i < merlinStack.Length; i++)
                    {
                        merlinStack[i] = new Merlin(Engine_Type.Vac);
                    }
                    break;
            }
            
        }

    }
}
