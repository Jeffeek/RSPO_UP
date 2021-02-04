using System;
using System.Collections.Generic;
using System.Text;
using RSPO_UP_15.Interfaces;

namespace RSPO_UP_15.Entities.Tasks
{
    public class Job
    {
        public Worker Worker { get; }

        public IEnumerable<Operation> Operations { get; }

        public Job(Worker worker, IEnumerable<Operation> operations)
        {
            Worker = worker;
            Operations = operations;
        }
    }
}
