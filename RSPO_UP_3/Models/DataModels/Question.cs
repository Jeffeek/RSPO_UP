#region Using namespaces

using System;
using System.Linq;
using System.Runtime.Serialization;

#endregion

namespace RSPO_UP_3.Models.DataModels
{
	/// <inheritdoc />
	[DataContract]
	public sealed class Question : IEquatable<Question>
	{
		/// <summary>
		///     конструктор для инициализации ответов сразу
		/// </summary>
		/// <param name="allAnswers">ответы с ходу</param>
		public Question(Answer[] allAnswers)
		{
			if (allAnswers?.Length != 5)
				throw new ArgumentException(nameof(allAnswers));

			Answers = allAnswers;
		}

		/// <summary>
		///     конструктор по умолчанию
		/// </summary>
		public Question() { }

		/// <summary>
		///     уникальный идентификатор вопроса
		/// </summary>
		[DataMember]
		public int Id { get; set; }

		/// <summary>
		///     текст вопроса
		/// </summary>
		[DataMember]
		public string Text { get; set; }

		/// <summary>
		///     массив ответов на данный вопрос
		///     по умолчанию - 5
		/// </summary>
		[DataMember]
		public Answer[] Answers { get; set; }

		/// <summary>
		///     коллекция ответов для десериализации
		/// </summary>
		/// <param name="index">индекс нужного ответа</param>
		/// <returns></returns>
		public Answer this[int index] => Answers[index];

		/// <summary>
		///     коллекция правильный ответов на данный вопрос
		/// </summary>
		public Answer[] RightAnswers => Answers.Where(x => x.IsRight).ToArray();

		/// <inheritdoc />
		public bool Equals(Question other) => Id == other?.Id;
	}
}