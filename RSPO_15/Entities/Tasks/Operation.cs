using System;

namespace RSPO_UP_15.Entities.Tasks
{
    public class Operation
    {
        public string Task { get; }
        public DateTime? Start { get; set; }
        public DateTime? Finish { get; set; }

        public Operation(string task, DateTime? start) : this(task, start, null) { }

        public Operation(string task, DateTime? start = null, DateTime? finish = null)
        {
            Task = task;
            Start = start;
            Finish = finish;
        }
    }
}
