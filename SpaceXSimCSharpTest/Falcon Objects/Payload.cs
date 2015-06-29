using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    class Payload
    {
        double mass;
        String name;

        public String Name
        {
            get { return name; }
        }

        public double Mass
        { get { return mass; } }

        public Payload(double m, String s)
        {
            mass = m;
            name = s;
        }
    }
}
