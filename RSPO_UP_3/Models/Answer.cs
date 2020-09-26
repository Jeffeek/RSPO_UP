using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_3.Models
{
    [DataContract]
    public class Answer : IEquatable<Answer>
    {
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public bool IsRight { get; set; }

        public bool Equals(Answer other)
        {
            return Text == other?.Text;
        }
    }
}
