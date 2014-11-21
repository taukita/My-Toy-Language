using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprache;

namespace MyToyLanguage.Expression.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var expression1 = ToyExpressionParser.ParseExpression("1.5 + 2");
			var expression2 = ToyExpressionParser.ParseExpression("  (1.5+2)  ");

			Assert.AreEqual("(1.5 + 2)", expression1.ToString());
			Assert.AreEqual("(1.5 + 2)", expression2.ToString());
		}

		[TestMethod]
		public void TestMethod2()
		{
			var expression = ToyExpressionParser.ParseExpression("1*2+3/4");
			Assert.AreEqual("((1 * 2) + (3 / 4))", expression.ToString());
		}

		[TestMethod]
		public void TestMethod3()
		{
			var expression = ToyExpressionParser.ParseExpression("(.5 + 1 - 2)*(-2)");
			Assert.AreEqual("1", expression.Reduce(null).ToString());
		}

		[TestMethod]
		public void TestMethod4()
		{
			var expression = ToyExpressionParser.ParseExpression(" - (- 2) ");
			Assert.AreEqual("2", expression.Reduce(null).ToString());

			expression = ToyExpressionParser.ParseExpression(" + (+ 2) ");
			Assert.AreEqual("2", expression.Reduce(null).ToString());
		}
	}
}
