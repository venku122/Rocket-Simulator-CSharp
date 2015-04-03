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
            Queue<TaskList> actions = new Queue<TaskList>();
            Falcon9 rocket = null;
            ThreadStart method=null;

            List<Thread> threadList = new List<Thread>();
            Thread thread1 = null;
            Thread thread2 = null;
            Thread thread3 = null;
            Thread thread4 = null;

            threadList.Add(thread1);
            threadList.Add(thread2);
            threadList.Add(thread3);
            threadList.Add(thread4);
            


            double timePassed =0;

            while (run)
            {

                switch(state)
                {
                    case Flight_State.Initialize:
                        rocket= new Falcon9("Falcon 9 1.1", "Test Rocket");
                        rocket.LoadPayload(new Payload(10, "Mass Simulator"));
                        Console.WriteLine("stage 1 mass: " + String.Format("{0:0.000}", (rocket.Stage1.Kerosene.Mass + rocket.Stage1.Oxygen.Mass)));
                        Console.WriteLine("stage 2 mass: " + String.Format("{0:0.000}", (rocket.Stage2.Kerosene.Mass + rocket.Stage2.Oxygen.Mass)));
                        Console.WriteLine("total mass: " + String.Format("{0:0.000}", (rocket.Stage1.Kerosene.Mass + rocket.Stage1.Oxygen.Mass + rocket.Stage2.Kerosene.Mass + rocket.Stage2.Oxygen.Mass)));
                        state = Flight_State.Prelaunch;
                        Console.WriteLine("Done with initialization");
                        break;
                    case Flight_State.Prelaunch:
                        timePassed += Global.TIMESTEP;

                        actions.Enqueue(rocket.Stage1.FillLO2);
                        actions.Enqueue(rocket.Stage1.FillRP1);
                        actions.Enqueue(rocket.Stage2.FillLO2);
                        actions.Enqueue(rocket.Stage2.FillRP1);
                        /*
                        if (rocket.Stage1.Oxygen.FilledVolume>=rocket.Stage1.Oxygen.MaxVolume)
                        {
                            Console.WriteLine("Tank is full");
                            Console.WriteLine(rocket.Stage1.Oxygen.FilledVolume);
                            Console.WriteLine(timePassed);
                            run = false;
                        }*/
                        if (rocket.Stage2.Kerosene.IsFull() && rocket.Stage1.Kerosene.IsFull() && rocket.Stage1.Oxygen.IsFull() && rocket.Stage1.Oxygen.IsFull())
                        {
                            Console.WriteLine("Rocket is fully fueled");
                            run = false;
                        }


                        break;
                }
                if(actions.Count!=0)
                {
                    method = new ThreadStart(actions.Dequeue());
                    thread1 = new Thread(method);
                }

                if(thread1!=null)
                {
                    thread1.Start();
                    thread1.Join();
                }

                
               
                

                //processInput()

                //update()

                //render()

                #region OldLoop
                /*
                switch (state)
                {
                    case Flight_State.Prelaunch:
                        #region Prelaunch
                        Falcon9 rocket = new Falcon9("Falcon 9 1.1", "Test Rocket");

                        rocket.LoadPayload(new Payload(10, "Mass Simulator"));

                        rocket.FillTanks();
                        Console.WriteLine("stage 1 mass: " + String.Format("{0:0.000}",(rocket.Stage1.Kerosene.Mass + rocket.Stage1.Oxygen.Mass)));
                        Console.WriteLine("stage 2 mass: " + String.Format("{0:0.000}",(rocket.Stage2.Kerosene.Mass + rocket.Stage2.Oxygen.Mass)));
                        Console.WriteLine("total mass: " + String.Format("{0:0.000}",(rocket.Stage1.Kerosene.Mass + rocket.Stage1.Oxygen.Mass + rocket.Stage2.Kerosene.Mass + rocket.Stage2.Oxygen.Mass)));
                        run = false;
                       
                        #endregion 
                        break;
                    case Flight_State.Launch:
                        break;
                    case Flight_State.Flight:
                        break;
                }*/
                #endregion
            }
        }      
    }
}
