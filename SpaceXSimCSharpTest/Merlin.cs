using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{

    class Merlin
    {

        #region Merlin 1D Stats
        /// <summary>
        /// Statistics about the Merlin 1D engine sourced from nasaspaceflight forums
        /// not all values are used, stored here for reference or future need
        /// </summary>
        private  double chamberPressure = 9.7; //megaPascals
         
        private  double Pexhaust = 0.43; // bar
       
        private  double Athroat = 0.042; //square meters
        
        private  double Anozzle = 0.9; // square meters
        
        private  double Dnozzle = 1.07; // meters
         
        private  double fuelRatio = 2.34; // ratio of LOX to RP1
       
        private  double MaxMdot = 236; // kilograms
        private  double Mdot;
        
        private  double MaxThrustSL = 653.889; // kilonewtons
        
        private  double IspSL = 282; //seconds
        private  double IspVac = 347; // seconds
        
        private  double MaxThrustVac = 742.853; // kilonewtons

        //public double IspVac = 320; // seconds
        #endregion

        #region Fields
        //Mass of the engine
        private double mass;
        //double multiplier from 0.7 to 1.0, controls thrust via mass flow rate
        private double throttle;
        //Whether engine is vacuum or sea level type
        private Engine_Type type;
        #endregion

        #region Properties
        public double Throttle
        {
            get { return throttle; }
            set { throttle = value; }
        }

        public double Mass
        { get { return mass; } }

        /// <summary>
        /// Thrust is the combination of efficiency(Isp), mass flow rate(Mdot) and the force of gravity
        /// </summary>
        public double Thrust
        {
            get { 
                switch(type)
                {
                    case Engine_Type.SL:
                        //This is an ideal situation
                        //Isp is not constant as the rocket rises through the atmosphere
                        return IspSL * Mdot * Global.GRAVITY;
                        break;
                    case Engine_Type.Vac:
                        return IspVac*Mdot*Global.GRAVITY;
                        break;
                    default:
                        return -1;
                        break;
                }
                
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates an engine of a specific type
        /// </summary>
        /// <param name="t"></param>
        public Merlin(Engine_Type t)
        {
            mass = 450;
            //Engine starts at 100% throttle, idealized
            throttle = 1;
            type=t;
            switch(type)
            {
                case Engine_Type.SL:
                    Mdot = 236;
                    break;
                case Engine_Type.Vac:
                    Mdot = 240;
                    break;
            }
        }
        #endregion

        #region Methods
        #region Update()
        public double Update(Stage s)
        {

            //More accurate thrust calculation taking into consideration external pressure
            //F= mDot*Vexhaust +(pExhasut -pOutside)*AreaNozzle

            //used in the Thrust Property
            //F=Isp*mDot*G
            PullLOX(s.Oxygen);
            PullRP1(s.Kerosene);

            Mdot = MaxMdot * throttle;
            switch(type)
            {
                case Engine_Type.SL:
                    return (IspSL * Mdot * Global.GRAVITY);
                    break;
                case Engine_Type.Vac:
                    return (IspVac * Mdot * Global.GRAVITY);
                    break;
            }
            return (IspSL * Mdot * Global.GRAVITY);
        }
        #endregion

        #region ChangeThrottle()
        /// <summary>
        /// Takes in a value to change the throttle by, bounds it between 0.7 and 1.0
        /// </summary>
        /// <param name="v"></param>
        public void ChangeThrottle(double v)
        {
            if (throttle <= .7)
            {
                throttle = .7;
            }
            else if (v >= 1)
            {
                throttle = 1;
            }
            else
            {
                throttle += v;
            }
        }
        #endregion

        #region PullRP1
        /// <summary>
        /// converts the mass flow rate of the engine to volume and subtracts that amount from the specified tank
        /// </summary>
        /// <param name="t"></param>
        private void PullRP1(Tank t)
        {
            t.Empty(((Mdot / 3.34)/Global.RP1DENSITY)*Global.TIMESTEP);
            return;
        }
        #endregion

        #region PullLOX
        /// <summary>
        /// converts the mass flow rate of the engine to volume and subtracts that amount from the specified tank
        /// </summary>
        /// <param name="t"></param>
        private void PullLOX(Tank t)
        {
            t.Empty(((Mdot / 1.42735)/Global.LO2DENSITY)*Global.TIMESTEP);
            return;
        }
        #endregion
        #endregion

    }
}
