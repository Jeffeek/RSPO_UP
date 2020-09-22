using System;
using System.Runtime.Serialization;

namespace RSPO_UP_1.Models
{
    [DataContract]
    public class Movie : IEquatable<Movie>
    {
        private string _name;

        [DataMember]
        public string Name
        {
            get => _name;
            set
            {
                if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(_name));
                }
            }
        }

        private string _cinemaName;

        [DataMember]
        public string CinemaName
        {
            get => _cinemaName;
            set
            {
                if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value))
                {
                    _cinemaName = value;
                }
                else
                {
                    throw new ArgumentNullException(nameof(_cinemaName));
                }
            }
        }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int Price { get; private set; }

        public Movie(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public Movie()
        { }

        public override string ToString()
        {
            return "===============\n" +
                   $"Название фильма: {Name}\n" +
                   $"Название кинотеатра: {CinemaName}\n" +
                   $"Время сеанса: {Date.ToShortTimeString()}\n" +
                   $"Цена билета: {Price}";
        }

        public bool Equals(Movie other)
        {
            return this.Price == other.Price &&
                   this.CinemaName == other.CinemaName &&
                   this.Date == other.Date &&
                   this.Name == other.Name;
        }
    }
}
