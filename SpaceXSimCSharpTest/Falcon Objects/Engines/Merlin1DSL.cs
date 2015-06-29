/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    class Merlin1DSL : Merlin
    {

        #region Merlin 1D Stats

        public double chamberPressure = 9.7; //megaPascals

        public double Pexhaust = 0.43; // bar

        public double Athroat = 0.042; //square meters

        public double Anozzle = 0.9; // square meters

        public double Dnozzle = 1.07; // meters

        public double fuelRatio = 2.34; // ratio of LOX to RP1

        public double MaxMdot = 236; // kilograms
        private double Mdot = 236;

        public double MaxThrustSL = 653.889; // kilonewtons

        public double IspSL = 282; // seconds

        public double MaxThrustVac = 742.853; // kilonewtons

        public double IspVac = 320; // seconds
        #endregion

        private double mass;
        private double throttle;

        public double Throttle
        {
            get { return throttle; }
            set { throttle = value; }
        }
        
        public Merlin1DSL()
        {
            mass = 450;
        }

        public double Update(Tank t)
        {
            

            //F= mDot*Vexhaust +(pExhasut -pOutside)*AreaNozzle

            //F=Isp*mDot*G
            PullLOX(t);
            PullRP1(t);

            Mdot=MaxMdot*throttle;

            return (IspSL * Mdot * Global.GRAVITY);
        }
        public override void ChangeThrottle(double v)
        {
            if(v<=.7)
            {
                throttle = .7;
            }
            else if(v>=1)
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
            t.Empty(Mdot/3.34);
            return;
        }

        private void PullLOX(Tank t)
        {
            t.Empty(Mdot / 1.42735);
            return;
        }
        
    }
}*/
