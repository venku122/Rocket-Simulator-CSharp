using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    class ThreadManager
    {
        #region Old Implementation
        /*
        private Queue<TaskList> masterList = new Queue<TaskList>();
        Queue<TaskList>[] subLists = new Queue<TaskList>[4];
        ThreadStart method = null;
        Thread[] threadList = new Thread[4];
        /*
        Thread thread1;
        Thread thread2;
        Thread thread3;
        Thread thread4;

        public Queue<TaskList> MasterList
        {
            get { return masterList; }
            set { masterList.Union<TaskList>(value); }
        }

        public ThreadManager()
        {
            /*
            thread1 = null;
            thread2 = null;
            thread3 = null;
            thread4 = null;
             * 
        }

        public void DelegateTasks()
        {
            while(masterList.Count>3)
            {
                for(int i=0; i<4; i++)
                {
                    subLists[i].Enqueue(masterList.Dequeue());
                }
            }
            if(masterList.Count<3)
            {
                while(masterList.Count!=0)
                {
                    subLists[1].Enqueue(masterList.Dequeue());
                }
            }
        }

        public void StartThreads()
        {
            /*
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            

            for(int i = 0; i<4; i++)
            {
                while (subLists[i]!=null && subLists[i].Count != 0)
                {
                    method = new ThreadStart(subLists[i].Dequeue());
                    threadList[i] = new Thread(method);
                }

                if (threadList[i] != null)
                {
                    threadList[i].Start();
                    threadList[i].Join();
                    
                }
            }

        }
        */
        #endregion

        #region fields
        //temporarily holds the delegate as ThreadStartable
        ThreadStart method = null;
        //Holds all the threads
        List<Thread> threadList = new List<Thread>();
        //Holds all delegates needed to be processed
        Queue<TaskList> actions = new Queue<TaskList>();

        //Threads used for processing
        Thread thread1 = null;
        Thread thread2 = null;
        Thread thread3 = null;
        Thread thread4 = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Adds thread object to the threadList
        /// </summary>
        public ThreadManager()
        {
            threadList.Add(thread1);
            threadList.Add(thread2);
            threadList.Add(thread3);
            threadList.Add(thread4);
        }
        #endregion

        #region Methods

        #region Update()
        /// <summary>
        /// Once passed a queue of tasks, will assign them to threads and execute them
        /// </summary>
        /// <param name="a"></param>
        public void Update(Queue<TaskList> a)
        {
            actions = a;

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


                if (thread1 != null || thread2 != null || thread3 != null || thread4 != null)
                {
                    thread1.Start();
                    thread2.Start();
                    thread3.Start();
                    thread4.Start();

                    thread1.Join();
                    thread2.Join();
                    thread3.Join();
                    thread4.Join();
                    //fileWriter.StoreData(timePassed);
                }
            }
        }
        #endregion

        #region TaskMaker
        /// <summary>
        /// Takes a queue of actions, creates tasks for them, and gives them to the tsk manager to process
        /// </summary>
        /// <param name="a"></param>
        public void TaskMaker(Queue<TaskList> a)
        {

            if (a.Count >= 1)
            {
                var tasks = new Task[a.Count - 1];
                for (int i = 0; i < a.Count - 1; i++)
                {
                    if (a.Count != 0)
                    {
                        tasks[i] = Task.Factory.StartNew(new Action(a.Dequeue()));
                        //Console.WriteLine("Task Created");
                    }

                }
                try
                {
                    Task.WaitAll();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }


            //Console.WriteLine("All done");
        }
        #endregion
        #endregion


    }
}
