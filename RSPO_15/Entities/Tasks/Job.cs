#region Using derectives

using System.Collections.Generic;
using System.Text;

#endregion

namespace RSPO_UP_15.Entities.Tasks
{
    public class Job
    {
        public Job(Worker worker, IEnumerable<Operation> operations)
        {
            Worker = worker;
            Operations = operations;
        }

        public Worker Worker { get; }

        public IEnumerable<Operation> Operations { get; }

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Рабочий: {Worker}");
            foreach (var operation in Operations) sb.AppendLine($"\t{operation}");

            return sb.ToString();
        }

        #endregion
    }
}