using System.Runtime.Serialization;

namespace RSPO_UP_3.Models
{
    
    public class Question
    {
        
        private AnswerVariant rightAnswerVariant;
        private AnswerVariant[] answers = new AnswerVariant[5];
    }
}
