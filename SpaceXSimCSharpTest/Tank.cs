using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    #region FuelTypeEnum
    public enum Fuel_Type
    {
        RP1, LO2
    };
    #endregion

    class Tank
    {

        #region FuelDensityConstants
        const double RP1DENSITY = 915;
        const double LO2DENSITY = 1141;
        #endregion

        #region Fields
        double length;
        double radius;
        double maxVolume;
        double filledVolume;
        double mass;
        Fuel_Type type;
        #endregion

        #region Properties
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
        #endregion

        #region Constructor
        public Tank(double l, double r, Fuel_Type ft)
        {
            length = l;
            radius = r;
            //V=πr2h
            maxVolume = Math.PI * (radius * radius) * length;
            type = ft;
            mass += 100;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Fills the fuel tank with fuel
        /// </summary>
        /// <param name="v">volume of fuel to add to the tank</param>
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
            //Debug Print statement
            Console.WriteLine("Filled Volume: " + String.Format("{0:0.000}", filledVolume) + " Max Volume: " + String.Format("{0:0.000}", MaxVolume) + " Mass: " + String.Format("{0:0.000}", mass) + type.ToString());
            //Updates the mass of the tank
            Update();

        }
        /// <summary>
        /// Based on fuel type, Updates the tank mass based on density and fuel amount
        /// </summary>
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
        #endregion
    }
}
