#region Using namespaces

using System.Collections.Generic;
using System.Linq;

#endregion

namespace RSPO_UP_12
{
	public class PostfixToInfixConverter
	{
		private readonly char[] _operators = {'*', '-', '+', '/', '^'};

		public string Convert(string input)
		{
			var s = new Stack<string>();

			foreach (var c in input)
			{
				if (_operators.Contains(c))
				{
					var b = s.Pop();
					var a = s.Pop();
					s.Push($"({a}{c}{b})");
				}
				else
					s.Push(c.ToString());
			}

			return s.Pop();
		}
	}
}