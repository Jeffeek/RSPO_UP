using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_3.Models
{
    [DataContract]
    public class AnswerVariant : IEquatable<AnswerVariant>
    {
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public bool IsRight { get; set; }

        public bool Equals(AnswerVariant other)
        {
            return Text == other?.Text;
        }
    }
}
