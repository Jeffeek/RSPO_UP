﻿#region Using namespaces

using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using RSPO_UP_3.ViewModel.Base;

#endregion

namespace RSPO_UP_3.ViewModel
{
	internal class FinishTestWindowViewModel : ViewModelBase
	{
		/// <summary>
		///     конструктор по умолчанию
		/// </summary>
		/// <param name="points"></param>
		public FinishTestWindowViewModel(int points)
		{
			Points = points;
			ChangePicture();
			ChangeTextBox();
		}

		#region fields

		/// <summary>
		///     кол-во баллов, которое набрал пользователь
		/// </summary>
		private int _points;

		/// <summary>
		///     картинка, которую надо поставить в форме
		/// </summary>
		private ImageSource _resultImage;

		/// <summary>
		///     результирующая строка для показа баллов пользователю
		/// </summary>
		private string _resultString;

		#endregion

		#region props

		public int Points
		{
			get => _points;
			set => SetValue(ref _points, value, nameof(Points));
		}

		public ImageSource ResultImage
		{
			get => _resultImage;
			set => SetValue(ref _resultImage, value, nameof(ResultImage));
		}

		public string ResultString
		{
			get => _resultString;
			set => SetValue(ref _resultString, value, nameof(ResultString));
		}

		#endregion

		#region methods

		/// <summary>
		///     метод, который выставляет нужный текст для информирования
		/// </summary>
		private void ChangeTextBox()
		{
			ResultString = "Вы набрали: {0} баллов!".Replace("{0}", $"{Points}");
		}

		/// <summary>
		///     метод, меняющий картинку по результатам теста
		/// </summary>
		private void ChangePicture()
		{
			var imagesPath = $"{Directory.GetCurrentDirectory()}\\Images\\ResultImages\\";
			if (Points == 0) ResultImage = new BitmapImage(new Uri($"{imagesPath}sad.jpg"));
			if (Points < 3) ResultImage = new BitmapImage(new Uri($"{imagesPath}normy.png"));
			if (Points >= 3) ResultImage = new BitmapImage(new Uri($"{imagesPath}happy.png"));
		}

		#endregion
	}
}