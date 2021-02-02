using System.Collections.Generic;
using System.Linq;

namespace RSPO_UP_12
{
	public class ExpressionTree
	{
		private readonly Node _root;

		private sealed class Node
		{
			public readonly char Data;
			public Node Left, Right;

			public Node(char item)
			{
				Data = item;
				Left = Right = null;
			}
		}

		public ExpressionTree(string postExpression) => _root = ConstructTree(postExpression.ToCharArray());

		private readonly char[] _operators =
		{
			'+',
			'-',
			'*',
			'/',
			'^'
		};

		public string Inorder() => InternalInorder(_root);

		private string InternalInorder(Node node)
		{
			var result = "";
	        var stack = new Stack<Node>();
	        while (node != null ||
	               stack.Count > 0)
	        {
		        while (node != null)
		        {
			        stack.Push(node);
			        node = node.Left;
		        }

		        node = stack.Pop();
		        result += node.Data;
		        node = node.Right;
	        }

	        return result;
		}

		private Node ConstructTree(char[] postfix)
		{
			var st = new Stack<Node>();
			Node currentNode;

			foreach (var character in postfix)
			{
				if (!_operators.Contains(character))
				{
					currentNode = new Node(character);
					st.Push(currentNode);
				}
				else
				{
					currentNode = new Node(character);
					var t1 = st.Pop();
					var t2 = st.Pop();
					currentNode.Right = t1;
					currentNode.Left = t2;
					st.Push(currentNode);
				}
			}

			currentNode = st.Peek();
			st.Pop();
			return currentNode;
		}
	}
}
