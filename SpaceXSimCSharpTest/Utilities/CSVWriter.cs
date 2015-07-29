using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceXSimCSharpTest
{
    class CSVWriter
    {
        #region Fields
        //The Falcon 9 that is being recorded
        private Falcon9 data;
        //holds all captured data before being dumped to fiel
        private StringBuilder sb;
        //FileIOStream
        private StreamWriter output;
        #endregion

        #region Constructor
        public CSVWriter(Falcon9 d)
        {
            data = d;
            sb = new StringBuilder();
            CSVHeaders();
        }
        #endregion

        #region Methods

        #region CreateFile()
        /// <summary>
        /// Creates a file with the given path name and writes the stringbuilder to file
        /// </summary>
        /// <param name="filePath"></param>
        public void CreateFile()
        {
            output = null;
            string input = null;
            Console.Write("Please enter a file name: ");
            input = Console.ReadLine();
            if(input==null)
            {
                throw new Exception();
            }
            try
            {
                output = new StreamWriter(input + ".csv");
                output.Write(sb);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region StoreData()
        /// <summary>
        /// Called every loop, records the timestamp and records data about the rocket in a .csv format
        /// </summary>
        /// <param name="timeStamp">time action occurs</param>
        /// <param name="s">current flight state of the rocket</param>
        public void StoreData(double timeStamp, Flight_State s)
        {
            sb.Append(timeStamp + ",");
            sb.Append(data.Stage1.Oxygen.FilledVolume+",");
            sb.Append(data.Stage1.Kerosene.FilledVolume+",");
            sb.Append(data.Stage2.Oxygen.FilledVolume+",");
            sb.Append(data.Stage2.Kerosene.FilledVolume+",");
            sb.Append(data.CalculateMass(s) + ",");
            sb.Append(data.Stage1.TotalThrust() + ",");
            sb.Append(data.Stage2.TotalThrust() + ",");
            sb.Append(data.CalculateAcceleration(s) + ",");
            sb.Append("\n");
            if(sb.Length>100000)
            {
                WriteFile();
            }
        }
        #endregion

        #region CSVHeaders()
        /// <summary>
        /// Creates the column headers for the CSV file
        /// </summary>
        public void CSVHeaders()
        {
            sb.Append("elapsed time,");
            sb.Append("stage 1 oxygen tank filled volume,");
            sb.Append("stage 1 kerosene tank filled volume,");
            sb.Append("stage 2 oxygen tank filled volume,");
            sb.Append("stage 2 kerosene tank filled volume,");
            sb.Append("total rocket mass,");
            sb.Append("stage 1 total thrust,");
            sb.Append("stage 2 total thrust,");
            sb.Append("total acceleration,");
            sb.Append("\n");
            
        }
        public void WriteFile()
        {
            output.Write(sb);
            sb.Clear();
        }
        public void CloseFile()
        {
            if (output != null)
            {
                output.Close();
            }
        }
        #endregion

        #region AppendSingle()
        //Allows the creation of a single data entry in that row, for debugging purposes
        public void AppendSingle(String s)
        {
            sb.Append(s + ",");
        }
        #endregion
        #endregion
    }
}
