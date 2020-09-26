using System;
using System.Runtime.Serialization;

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
