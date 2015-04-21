using System;
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

    public static class Global
    {

        #region FillRateConstants
        public const double RADIUS = 1.83;
        public const double RP1FillRate = 0.3333; //temporary
        public const double LO2FillRate = 0.1667; //temporary
        #endregion

        #region FuelDensityConstants
        public const double RP1DENSITY = 915;
        public const double LO2DENSITY = 1141;
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
