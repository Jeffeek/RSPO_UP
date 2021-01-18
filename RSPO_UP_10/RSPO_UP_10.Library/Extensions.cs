using System;
using System.Text;

namespace RSPO_UP_10.Library
{
    public static class Extensions
    {
        public static bool IsPrime(this int number)
        {
            for (var i = 2; i < Math.Sqrt(number); i++)
            {
	            if(number % i == 0)
		            return false;
            }

            return true;
        }


        //В результате конкатенации двух строк получается строка в которой
        //идет все символы, стоящие на четных местах в первой строке,
        //затем все символы, стоящие на четных во второй, затем на нечетных
        //в первой и во второй. Пример С1=’ABCD’, C2=’EFGHJK’, C1+C2=’BDFHKACEGJ’
        public static string StrangeConcat(this string first, string second)
        {
	        var sb = new StringBuilder();
            int i;
	        for(i = 0; i < first.Length; i++)
		        if(i % 2 != 0)
			        sb.Append(first[i]);
	        for (i = 0; i < second.Length; i++)
		        if (i % 2 != 0)
			        sb.Append(second[i]);
	        for (i = 0; i < first.Length; i++)
			        if (i % 2 == 0)
						sb.Append(first[i]);
			for (i = 0; i < second.Length; i++)
				if (i % 2 == 0)
					sb.Append(second[i]);

			return sb.ToString();
        }
    }
}
