using System;
using System.Runtime.Serialization;

namespace RSPO_UP_3.Models.DataModels
{
    /// <summary>
    /// Модель ответа на конкретный вопрос
    /// </summary>
    [DataContract]
    public class Answer : IEquatable<Answer>
    {
        /// <summary>
        /// Текст ответа
        /// </summary>
        [DataMember]
        public string Text { get; set; }
        /// <summary>
        /// Булево значение, показывающее правильный ли это ответ
        /// </summary>
        [DataMember]
        public bool IsRight { get; set; }

        /// <summary>
        /// метод для сравнения двух ответов
        /// </summary>
        /// <param name="other">экземпляр ответа для сравнения</param>
        /// <returns></returns>
        public bool Equals(Answer other)
        {
            return Text == other?.Text && IsRight == other?.IsRight;
        }
    }
}
