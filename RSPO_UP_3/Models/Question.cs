using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace RSPO_UP_3.Models
{
    /// <summary>
    /// модель полноценного вопроса,
    /// в котором содержится коллекция ответов
    /// </summary>
    [DataContract]
    public class Question : IEquatable<Question>
    {
        /// <summary>
        /// уникальный идентификатор вопроса
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// текст вопроса
        /// </summary>
        [DataMember]
        public string Text { get; set; }
        /// <summary>
        /// массив ответов на данный вопрос
        /// по умолчанию - 5
        /// </summary>
        [DataMember] 
        public Answer[] Answers { get; set; }

        /// <summary>
        /// коллекция ответов, которая отслеживается
        /// </summary>
        public ObservableCollection<Answer> CurrentAnswers { get; set; }

        /// <summary>
        /// коллекция ответов для десериализации
        /// </summary>
        /// <param name="index">индекс нужного ответа</param>
        /// <returns></returns>
        public Answer this[int index] => Answers[index];

        /// <summary>
        /// коллекция правильный ответов на данный вопрос
        /// </summary>
        public Answer[] RightAnswers => Answers.Where(x => x.IsRight).ToArray();

        /// <summary>
        /// конструктор для инициализации ответов сразу
        /// </summary>
        /// <param name="allAnswers">ответы с ходу</param>
        public Question(Answer[] allAnswers)
        {
            if (allAnswers == null || allAnswers.Length != 5) 
                throw new ArgumentException(nameof(allAnswers));
            Answers = allAnswers;
        }

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Question()
        {
            
        }

        /// <summary>
        /// метод для сравнения двух вопросов
        /// </summary>
        /// <param name="other">объект вопроса для сравнения</param>
        /// <returns></returns>
        public bool Equals(Question other)
        {
            return this.Id == other?.Id;
        }
    }
}
