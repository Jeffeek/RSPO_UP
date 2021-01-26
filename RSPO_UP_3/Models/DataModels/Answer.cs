#region Using namespaces

using System;
using System.Runtime.Serialization;

#endregion

namespace RSPO_UP_3.Models.DataModels
{
	[DataContract]
	public sealed class Answer : IEquatable<Answer>
	{
		/// <summary>
		///     Текст ответа
		/// </summary>
		[DataMember]
		public string Text { get; set; }

		/// <summary>
		///     Булево значение, показывающее правильный ли это ответ
		/// </summary>
		[DataMember]
		public bool IsRight { get; set; }

		/// <inheritdoc />
		public bool Equals(Answer other) => Text == other?.Text && IsRight == other?.IsRight;
	}
}