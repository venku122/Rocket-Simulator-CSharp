using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{


    class Tank
    {

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
        /// <summary>
        /// Creates a tank holding the specified fuel type with a cylindrical volume defined by the given parameters
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <param name="ft"></param>
        public Tank(double l, double r, Fuel_Type ft)
        {
            length = l;
            radius = r;
            //V=πr2h
            maxVolume = Math.PI * (radius * radius) * length;
            type = ft;
            //Tankage mass is an underestimate, not dependent on tank size either
            mass += 100;
        }
        #endregion

        #region Methods
        #region Fill()
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
                //Console.WriteLine("tank method says 'im full'");
            }
            else
            {
                filledVolume += v;
            }
            //Debug Print statement
            //Console.WriteLine("Filled Volume: " + String.Format("{0:0.000}", filledVolume) + " Max Volume: " + String.Format("{0:0.000}", MaxVolume) + " Mass: " + String.Format("{0:0.000}", mass) + (" ")+type.ToString());
            //Console.WriteLine("Filled Volume: " + Math.Round(filledVolume, 3) + " Max Volume: " + Math.Round(MaxVolume, 3) + " Mass: " + Math.Round(mass, 3) + (" ") + type.ToString());

            //Updates the mass of the tank
            Update();
        }
        #endregion

        #region Update()
        /// <summary>
        /// Based on fuel type, Updates the tank mass based on density and fuel amount
        /// </summary>
        private void Update()
        {
            switch (type)
            {
                case Fuel_Type.RP1:
                    mass = filledVolume * Global.RP1DENSITY;
                    break;
                case Fuel_Type.LO2:
                    mass = filledVolume * Global.LO2DENSITY;
                    break;
            }
        }
        #endregion

        #region IsFull()
        /// <summary>
        /// Returns whether the tank is full or not
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return (filledVolume == maxVolume);

        }
        #endregion

        #region Empty()
        /// <summary>
        /// Removes a specified volumne of fuel from the tank and updates the tank mass
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double Empty(double v)
        {
            filledVolume -= v;
            Update();
            switch (type)
            {
                case Fuel_Type.RP1:
                    return v* Global.RP1DENSITY;
                    break;
                case Fuel_Type.LO2:
                     return v* Global.LO2DENSITY;
                    break;
                default:
                    return 0;
                    break;
            }
        }
        #endregion
        #endregion
    }
}
