using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    enum Engine_Type
    {
        SL,
        Vac
    }
    class Merlin
    {

        #region Merlin 1D Stats

        public double chamberPressure = 9.7; //megaPascals

        public double Pexhaust = 0.43; // bar

        public double Athroat = 0.042; //square meters

        public double Anozzle = 0.9; // square meters

        public double Dnozzle = 1.07; // meters

        public double fuelRatio = 2.34; // ratio of LOX to RP1

        public double MaxMdot = 236; // kilograms
        private double Mdot;

        public double MaxThrustSL = 653.889; // kilonewtons

        public double IspSL = 282;
        public double IspVac = 347;// seconds

        public double MaxThrustVac = 742.853; // kilonewtons

        //public double IspVac = 320; // seconds
        #endregion

        private double mass;
        private double throttle;
        private Engine_Type type;
        public double Throttle
        {
            get { return throttle; }
            set { throttle = value; }
        }
        public double Thrust
        {
            get { 
                switch(type)
                {
                    case Engine_Type.SL:
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

        public Merlin(Engine_Type t)
        {
            mass = 450;
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

        public double Update(Stage s)
        {


            //F= mDot*Vexhaust +(pExhasut -pOutside)*AreaNozzle

            //F=Isp*mDot*G
            PullLOX(s.Oxygen);
            PullRP1(s.Kerosene);

            Mdot = MaxMdot * throttle;

            return (IspSL * Mdot * Global.GRAVITY);
        }
        public void ChangeThrottle(double v)
        {
            if (v <= .7)
            {
                throttle = .7;
            }
            else if (v >= 1)
            {
                throttle = 1;
            }
            else
            {
                throttle = v;
            }
        }

        private void PullRP1(Tank t)
        {
            t.Empty(((Mdot / 3.34)/Global.RP1DENSITY)*Global.TIMESTEP);
            return;
        }

        private void PullLOX(Tank t)
        {
            t.Empty(((Mdot / 1.42735)/Global.LO2DENSITY)*Global.TIMESTEP);
            return;
        }

    }
}
