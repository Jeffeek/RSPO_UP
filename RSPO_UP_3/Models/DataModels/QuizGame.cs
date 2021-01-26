#region Using namespaces

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using RSPO_UP_3.Services;
using RSPO_UP_3.View.Windows;

#endregion

namespace RSPO_UP_3.Models.DataModels 
{

	/// <summary>
	///     объект полноценной викторины, содержащей в себе вопросы
	/// </summary>
	public sealed class QuizGame : ObservableObject
	{
		/// <summary>
		///     коллекция вопросов
		/// </summary>
		private readonly ObservableCollection<Question> _questions;

		/// <summary>
		///     конструктов по умолчанию для инициализации полей
		/// </summary>
		public QuizGame()
		{
			var qlist = QuestionDeserializer.GetQuestionsFromFile();
			_questions = new ObservableCollection<Question>(qlist);

			CurrentQuestion = _questions[0] ?? throw new Exception("Вопросик был нуль");
		}

		/// <summary>
		///     объект вопроса, который на который в
		///     данный момент отвечает пользователь
		/// </summary>
		public Question CurrentQuestion { get; private set; }

		/// <summary>
		///     количество баллов в данной игре
		/// </summary>
		public int CurrentPoints { get; private set; }

		/// <summary>
		///     метод, проверяющий является ли текущий
		///     вопрос последним в данной игре
		/// </summary>
		/// <returns>
		///     true - если последний,
		///     false - если НЕ последний
		/// </returns>
		public bool IsLast => _questions.IndexOf(CurrentQuestion) == _questions.IndexOf(_questions.Last());

		/// <summary>
		///     метод для рассчёта следующего вопроса \
		///     либо открытия финальной формы с результатом
		/// </summary>
		public void NextQuestion()
		{
			var currentIndex = _questions.IndexOf(CurrentQuestion);
			if (IsLast)
			{
				OpenFinish();
				Application.Current.Shutdown();
			}
			else
				CurrentQuestion = _questions[currentIndex + 1];
		}

		/// <summary>
		///     проверка двух ответов на корректность
		/// </summary>
		/// <param name="first">первый ответ</param>
		/// <param name="second">второй ответ</param>
		/// <returns>
		///     true - если оба верные,
		///     false - если хоть один из них неверный
		/// </returns>
		public bool CheckForWinning(Answer first, Answer second)
		{
			if (first.IsRight &&
			    second.IsRight)
			{
				CurrentPoints++;
				return true;
			}

			return false;
		}

		/// <summary>
		///     метод для открытия финальной формы с результатом
		/// </summary>
		private void OpenFinish()
		{
			var w = new FinishTestWindow(CurrentPoints);
			w.ShowDialog();
		}
	}
}