#region Using derectives

using System;

#endregion

namespace RSPO_UP_15.Entities.Tasks
{
    public class Operation
    {
        public Operation(string task, DateTime? start) : this(task, start, null) { }

        public Operation(string task, DateTime? start = null, DateTime? finish = null)
        {
            Task = task;
            Start = start;
            Finish = finish;
        }

        public string Task { get; }
        public DateTime? Start { get; set; }
        public DateTime? Finish { get; set; }

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString() => $"{Task} : {Start.Value:Y} -> {Finish.Value:Y}";

        #endregion
    }
}