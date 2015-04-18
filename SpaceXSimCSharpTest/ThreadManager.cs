using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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

            ThreadStart method = null;
            List<Thread> threadList = new List<Thread>();
            Queue<TaskList> actions = new Queue<TaskList>();

            Thread thread1 = null;
            Thread thread2 = null;
            Thread thread3 = null;
            Thread thread4 = null;
        public ThreadManager()
        {
            threadList.Add(thread1);
            threadList.Add(thread2);
            threadList.Add(thread3);
            threadList.Add(thread4);
        }

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

    }
}
