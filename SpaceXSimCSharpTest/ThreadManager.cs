using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpaceXSimCSharpTest
{
    class ThreadManager
    {

        private Queue<TaskList> masterList = new Queue<TaskList>();
        Queue<TaskList>[] subLists = new Queue<TaskList>[4];
        ThreadStart method = null;
        Thread[] threadList = new Thread[4];
        /*
        Thread thread1;
        Thread thread2;
        Thread thread3;
        Thread thread4;*/

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
             * */
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
            */

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


    }
}
