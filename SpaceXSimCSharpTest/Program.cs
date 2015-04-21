using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpaceXSimCSharpTest
{
    public delegate void TaskList();
    class Program
    {
        

        static void Main(string[] args)
        {
            bool run = true;
            Flight_State state=Flight_State.Initialize;

            Falcon9 rocket = null;
            CSVWriter fileWriter = null;
            

            #region Threading
            
            Queue<TaskList> actions = new Queue<TaskList>();
            ThreadManager threader = new ThreadManager();

            #endregion



            double timePassed = 0;

            while (run)
            {
                timePassed += Global.TIMESTEP;
                
                switch(state)
                {
                    case Flight_State.Initialize:
                        #region Initialization
                        rocket = new Falcon9("Falcon 9 1.1", "Test Rocket");
                        fileWriter = new CSVWriter(rocket);
                        rocket.LoadPayload(new Payload(10, "Mass Simulator"));
                        Console.WriteLine("stage 1 mass: " + String.Format("{0:0.000}", (rocket.Stage1.Kerosene.Mass + rocket.Stage1.Oxygen.Mass)));
                        Console.WriteLine("stage 2 mass: " + String.Format("{0:0.000}", (rocket.Stage2.Kerosene.Mass + rocket.Stage2.Oxygen.Mass)));
                        //Console.WriteLine("total mass: " + String.Format("{0:0.000}", (rocket.Stage1.Kerosene.Mass + rocket.Stage1.Oxygen.Mass + rocket.Stage2.Kerosene.Mass + rocket.Stage2.Oxygen.Mass)));
                        Console.WriteLine("total mass: " + Math.Round((rocket.Stage1.Kerosene.Mass + rocket.Stage1.Oxygen.Mass + rocket.Stage2.Kerosene.Mass + rocket.Stage2.Oxygen.Mass), 3));
                        //fileWriter.StoreData(timePassed);
                        state = Flight_State.Prelaunch;
                        Console.WriteLine("Done with initialization");
                        #endregion

                        break;
                    case Flight_State.Prelaunch:
                        #region Prelaunch

                        if (!rocket.Stage1.IsFilled() || !rocket.Stage2.IsFilled())
                        {
                            actions.Enqueue(rocket.Stage1.FillLO2);
                            actions.Enqueue(rocket.Stage1.FillRP1);
                            actions.Enqueue(rocket.Stage2.FillLO2);
                            actions.Enqueue(rocket.Stage2.FillRP1);
                        }
                
                        

                        if (rocket.Stage1.IsFilled() && rocket.Stage2.IsFilled())
                        {
                            
                            Console.WriteLine("Rocket is fully fueled");

                            
                            state = Flight_State.Launch;
                        }

#endregion
                        break;
                    case Flight_State.Launch:
                        #region Launch
                        
                        actions.Enqueue(rocket.Stage1.FireEngines);

                        if((rocket.CalculateAcceleration(state)/9.8)>2)
                        {
                            rocket.Stage1.ChangeThrottle(-0.01);
                        }
                        if(rocket.Stage1.Kerosene.FilledVolume<0||rocket.Stage1.Oxygen.FilledVolume<0)
                        {
                            state = Flight_State.Flight;
                            //fileWriter.CreateFile("rocketSimData.csv");
                            //run = false; 
                        }
                       
                        #endregion
                        break;
                    case Flight_State.Flight:
                        #region Flight

                        actions.Enqueue(rocket.Stage2.FireEngines);
                        if ((rocket.CalculateAcceleration(state) / 9.8) > 10)
                        {
                            rocket.Stage2.ChangeThrottle(-0.01);
                        }
                        if (rocket.Stage2.Kerosene.FilledVolume < 0 || rocket.Stage2.Oxygen.FilledVolume < 0)
                        {
                            state = Flight_State.Flight;
                            fileWriter.CreateFile("rocketSimData.csv");
                            run = false;
                        }
                        #endregion
                        break;
                }

                #region Update
                #region OldSingleThread
                /*
                while (actions.Count != 0)
                {
                    method = new ThreadStart(actions.Dequeue());
                    thread1 = new Thread(method);
                    method = new ThreadStart(actions.Dequeue());
                    thread2 = new Thread(method);
                    method = new ThreadStart(actions.Dequeue());
                    thread3 = new Thread(method);
                    method = new ThreadStart(actions.Dequeue());
                    thread4 = new Thread(method);


                    if (thread1 != null)
                    {
                        thread1.Start();
                        thread2.Start();
                        thread3.Start();
                        thread4.Start();

                        thread1.Join();
                        thread2.Join();
                        thread3.Join();
                        thread4.Join();
                        fileWriter.StoreData(timePassed);
                    }
                }
                */
                #endregion

                //threader.Update(actions);
                threader.TaskMaker(actions);
                fileWriter.StoreData(timePassed, state);

                #endregion

            }
        }      
    }
}
