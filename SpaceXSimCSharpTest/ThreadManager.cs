using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSimCSharpTest
{
    class ThreadManager
    {

        Queue<TaskList> masterList = new Queue<TaskList>();

        public Queue<TaskList> MasterList
        {
            get { return masterList; }
            set { masterList.Union<TaskList>(value); }
        }

        public ThreadManager()
        {
            
        }

        public void DelegateTasks(List<ThreadManager> list)
        {

        }
    }
}
