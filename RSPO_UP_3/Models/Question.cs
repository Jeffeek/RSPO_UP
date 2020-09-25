using System;
using System.Runtime.Serialization;

namespace RSPO_UP_3.Models
{
    [DataContract]
    public class Question : IEquatable<Question>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public AnswerVariant[] _rightAnswerVariants = new AnswerVariant[2];
        [DataMember]
        private AnswerVariant[] _answers = new AnswerVariant[5];

        public string GetTextQuestionByIndex(int index)
        {
            return _answers[index].Text;
        }

        public bool Equals(Question other)
        {
            return this.Id == other?.Id;
        }
    }
}
