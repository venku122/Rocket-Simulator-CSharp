using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    public enum Fuel_Type
    {
        RP1, LO2
    };
    class Tank
    {
        const double RP1DENSITY = 915;
        const double LO2DENSITY = 1141;

        double length;
        double radius;
        double maxVolume;
        double filledVolume;
        double mass;
        Fuel_Type type;

        public double FilledVolume
        {
            get { return filledVolume; }
        }

        public double MaxVolume
        {
            get { return maxVolume; }
        }

        public double Mass
        {
            get { return mass; }
        }
        public Tank(double l, double r, Fuel_Type ft)
        {
            length = l;
            radius = r;
            //V=πr2h
            maxVolume = Math.PI * (radius * radius) * length;
            type = ft;
            mass += 100;
            
        }

        public void Fill(double v)
        {
            if (v < 0)
            {
                return;
            }

            if (v > maxVolume||((filledVolume+v)>maxVolume))
            {
                filledVolume = maxVolume;
            }
            else
            {
                filledVolume += v;
            }
            Update();

        }

        private void Update()
        {
            switch(type)
            {
                case Fuel_Type.RP1:
                    mass = filledVolume * RP1DENSITY;
                    break;
                case Fuel_Type.LO2:
                    mass = filledVolume * LO2DENSITY;
                    break;
            }
        }
    }
}
