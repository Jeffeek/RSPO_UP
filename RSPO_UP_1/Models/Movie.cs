#region Using namespaces

using System;
using System.Runtime.Serialization;

#endregion

namespace RSPO_UP_1.Models
{
	[DataContract]
	public class Movie : IEquatable<Movie>
	{
		private string _name;

		private string _cinemaName;

		public Movie(string name, int price)
		{
			Name = name;
			Price = price;
		}

		public Movie() { }

		[DataMember]
		public string Name
		{
			get => _name;
			set
			{
				if (!string.IsNullOrEmpty(value) &&
				    !string.IsNullOrWhiteSpace(value))
					_name = value;
				else
					throw new ArgumentNullException(nameof(_name));
			}
		}

		[DataMember]
		public string CinemaName
		{
			get => _cinemaName;
			set
			{
				if (!string.IsNullOrEmpty(value) &&
				    !string.IsNullOrWhiteSpace(value))
					_cinemaName = value;
				else
					throw new ArgumentNullException(nameof(_cinemaName));
			}
		}

		[DataMember]
		public DateTime Date { get; set; }

		[DataMember]
		public int Price { get; private set; }

		public bool Equals(Movie other) => Price == other?.Price &&
		                                   CinemaName == other.CinemaName &&
		                                   Date == other.Date &&
		                                   Name == other.Name;

		public override string ToString() => "===============\n" +
		                                     $"Название фильма: {Name}\n" +
		                                     $"Название кинотеатра: {CinemaName}\n" +
		                                     $"Время сеанса: {Date.ToShortTimeString()}\n" +
		                                     $"Цена билета: {Price}";
	}
}