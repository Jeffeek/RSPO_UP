using System;
using System.IO;

namespace RSPO_UP_10.Library
{
    public class Second
    {
        public int Number { get; }

        public Second()
        {
	        var rnd = new Random();
	        Number = rnd.Next(1, 10000);
        }
        
        public Second(int number) => Number = number;

        public Second(string path)
        {
	        if (!File.Exists(path)) throw new ArgumentException(nameof(path));
	        var number = int.Parse(File.ReadAllText(path));
        }

        public int CubePowSecondDigit()
        {
	        var strPresentation = Number.ToString();
	        if(strPresentation.Length < 2) throw new ArgumentException(nameof(Number));
	        return (int) Math.Pow(int.Parse(strPresentation[1].ToString()), 3);
        }
    }
}
