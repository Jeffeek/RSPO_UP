using System;
using System.IO;
using System.Linq;

namespace RSPO_UP_10.Library
{
    public class First
    {
	    public int FirstNumber { get; }
	    public int SecondNumber { get; }

	    public First(int first, int second)
	    {
		    FirstNumber = first;
		    SecondNumber = second;
	    }
	    
	    public First(int maxRandom)
	    {
		    var rnd = new Random();
		    FirstNumber = rnd.Next(1, maxRandom);
		    SecondNumber = rnd.Next(1, maxRandom);
	    }

	    public First(string path)
	    {
		    if(!File.Exists(path)) throw new ArgumentException(nameof(path));
		    var numbers = File.ReadAllText(path)
							                   .Split()
							                   .Select(int.Parse)
							                   .ToArray();
		    FirstNumber = numbers[0];
		    SecondNumber = numbers[1];
	    }

	    public int PowOfMul() => (int)Math.Pow(FirstNumber * SecondNumber, 2);
    }
}
