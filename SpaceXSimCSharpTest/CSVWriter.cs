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

        private Falcon9 data;
        private StringBuilder sb;

        public CSVWriter(Falcon9 d)
        {
            data = d;
            sb = new StringBuilder();
            CSVHeaders();
        }

        public void CreateFile(String filePath)
        {
            StreamWriter output = null;

            try
            {
                output = new StreamWriter(filePath);
                output.Write(sb);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(output!= null)
                {
                    output.Close();
                }
            }
        }

        public void StoreData(double timeStamp)
        {
            sb.Append(timeStamp + ",");
            sb.Append(data.Stage1.Oxygen.FilledVolume+",");
            sb.Append(data.Stage1.Kerosene.FilledVolume+",");
            sb.Append(data.Stage2.Oxygen.FilledVolume+",");
            sb.Append(data.Stage2.Kerosene.FilledVolume+",");
            sb.Append(data.TotalMass() + ",");
            sb.Append(data.Stage1.TotalThrust() + ",");
            sb.Append("\n");
            //Console.WriteLine("New Line Created");
            
            


        }

        public void CSVHeaders()
        {
            sb.Append("elapsed time,");
            sb.Append("stage 1 oxygen tank filled volume,");
            sb.Append("stage 1 kerosene tank filled volume,");
            sb.Append("stage 2 oxygen tank filled volume,");
            sb.Append("stage 2 kerosene tank filled volume,");
            sb.Append("total rocket mass,");
            sb.Append("stage 1 total thrust");
            sb.Append("\n");
            
        }

        public void AppendSingle(String s)
        {
            sb.Append(s + ",");
        }
    }
}
