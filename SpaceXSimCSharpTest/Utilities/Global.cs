using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    #region StageTypeEnum
    /// <summary>
    /// Contains the various stage types on a rocket
    /// </summary>
    public enum Stage_Type
    {
        firstStage, secondStage
    };
    #endregion

    #region FlightStateEnum
    /// <summary>
    /// List of stages of flight
    /// </summary>
    enum Flight_State
    {
        Initialize,
        Prelaunch,
        Launch,
        Flight
    };
    #endregion

    #region EngineTypeEnum
    /// <summary>
    /// Dictates the engine type and thus its performance characteristics
    /// </summary>
    
    enum Engine_Type
    {
        SL,
        Vac
    }
    #endregion

    #region FuelTypeEnum
    /// <summary>
    /// Dictates what kind of fuel the tank holds
    /// </summary>

     enum Fuel_Type
    {
        RP1, LO2
    }
    #endregion

    public static class Global
    {

        #region FillRateConstants
        //The rate in which the tanks are filled, m^3 per second
        public const double RP1FillRate = 0.3333; //temporary, much faster than real life in order to prevent graph skewing
        public const double LO2FillRate = 0.1667; //temporary, much faster than real life in order to prevent graph skewing
        #endregion
        
        #region FuelConstants
        //Densities of the fuels used in the rocket
        public const double RP1DENSITY = 915;
        public const double LO2DENSITY = 1141;

        //Ratio is LO2Density/RP1Density = fuel mass ratio(LO2-RP1)/X
        public const double FIRSTSTAGEFUELRATIO = 1.87;
        public const double SECONDSTAGEFUELRATIO = 1.89;
        #endregion

        #region Stage Tank Lengths
        //Radius of the rocket
        public const double RADIUS = 1.83;
        //Statistics taken from spaceflightnow.com, does not account for engine length or structures
        public const double FIRSTSTAGELENGTH = 37.3;
        public const double SECONDSTAGELENGTH = 15;
        
        //equals total length/(1 + FIRSTSTAGEFUELRATIO)
        public const double FIRSTSTAGELENGTHRP1= FIRSTSTAGELENGTH/(1+FIRSTSTAGEFUELRATIO);
        //equals total length-FIRSTSTAGELENGTHRP1
        public const double FIRSTSTAGELENGTHLO2 =FIRSTSTAGELENGTH-FIRSTSTAGELENGTHRP1;
        //equals total length(1+SECONDSTAGEFUELRATIO)
        public const double SECONDSTAGELENGTHRP1= SECONDSTAGELENGTH/(1+SECONDSTAGEFUELRATIO);
        //equals total length-SECONDSTAGELENGTHRP1
        public const double SECONDSTAGELENGTHLO2 = SECONDSTAGELENGTH - SECONDSTAGELENGTHRP1;
        #endregion

        #region Simulation
        /// <summary>
        /// This is the time that passes every loop. It is a # of Seconds. Currently set at 100 milliseconds
        /// </summary>
        public static double TIMESTEP = .1;

        public static double GRAVITY = 9.80665;
        #endregion  
    }
}
