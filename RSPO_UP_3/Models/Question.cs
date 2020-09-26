using System;
using System.Linq;
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
        public Answer[] _answers { get; set; }

        public Question(Answer[] allAnswers)
        {
            if (allAnswers == null || allAnswers.Length != 5) 
                throw new ArgumentException(nameof(allAnswers));
            _answers = _answers;
        }

        public Question()
        {
            
        }

        public string GetTextQuestionByIndex(int index)
        {
            if (index < 0 || index > 4) throw new IndexOutOfRangeException(nameof(_answers));
            return _answers[index].Text;
        }

        public bool Equals(Question other)
        {
            return this.Id == other?.Id;
        }
    }
}
