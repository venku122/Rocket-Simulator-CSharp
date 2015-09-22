using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest.Utilities
{
    class FlightSystem
    {
        //Position in 2D space of the vehicle
        double xPos;
        double yPos;

        //Velocity of the vehicle along 2 axes.
        double xVelocity;
        double yVelocity;
        double speed;

        //State of Vehicle in Flight
        Flight_State state;

        //Vehicle being tracked
        Falcon9 vehicle;

        //Plane of Wing
        double PoW;
        //Direction of Thrust
        double DoT;
        //Direction of Flight
        double DoF;

        //time from launch to thrust termination
        double time;
        //Thrust force Newtons
        double thrust;
        //Instantaneous Vehicle Mass
        double mIst;
        //Coefficient of Drag
        double CoD;
        //Mass Density
        double mDen;
        //Frontal Area m^3
        double areaF;
        //Coefficent of Lift
        double CoL;
        //Propellant Mass Fraction (Mp/Mo)
        double PropellantMassFraction;
        //Initial Vehicle Mass
        double initialMass;
        //Mass Fraction at start time
        double startMassFraction;


        public FlightSystem(Falcon9 target, Flight_State s)
        {
            vehicle = target;
            state = s;

            xPos = 0;
            yPos = 0;

            xVelocity = 0;
            yVelocity = 0;

            UpdateSpeed();



        }

        private void UpdatePosition()
        {
            xPos += xVelocity * Global.TIMESTEP;
            yPos += yVelocity * Global.TIMESTEP;
        }

        private void UpdateVelocity()
        {
            //xVelocity = (-Global.GRAVITY) + (thrust/mIst);
            yVelocity += vehicle.CalculateAcceleration(state)*Global.TIMESTEP;
        }
        private void UpdateSpeed()
        {
            speed = Math.Pow(Math.Pow(xVelocity, 2) + Math.Pow(yVelocity, 2), 1/2);
    
        }
        private void UpdateVehicleStats()
        {

           // mIst = vehicle.CalculateMass(state);
        }
        public void Update(Flight_State s)
        {
            state = s;
            UpdateVehicleStats();
            UpdateVelocity();
            UpdateSpeed();
            UpdatePosition();
            Console.WriteLine("Altitude: {0} X-Velocity: {1} Y-Velocity: {2}", yPos, xVelocity, yVelocity);
        }
    }
}
