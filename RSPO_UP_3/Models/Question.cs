using System;
using System.Collections.ObjectModel;
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
        public Answer[] Answers { get; set; }

        public ObservableCollection<Answer> CurrentAnswers { get; set; }

        public Answer this[int index] => Answers[index];

        public Answer[] RightAnswers => Answers.Where(x => x.IsRight).ToArray();

        public Question(Answer[] allAnswers)
        {
            if (allAnswers == null || allAnswers.Length != 5) 
                throw new ArgumentException(nameof(allAnswers));
            Answers = allAnswers;
        }

        public Question()
        {
            
        }

        public bool Equals(Question other)
        {
            return this.Id == other?.Id;
        }
    }
}
