using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyToyLanguage.Lisp.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var expr = ToyLispParser.ParseExpression("()");

			Assert.AreEqual("()", expr.ToString());
		}

		[TestMethod]
		public void TestMethod2()
		{
			var context = new LispContext();

			var expr1 = ToyLispParser.ParseExpression("(+ 1 2 3 4)").Reduce(context);
			var expr2 = ToyLispParser.ParseExpression("(+ (+ 1 2) (+ 3 4))").Reduce(context);

			Assert.AreEqual("10", expr1.ToString());
			Assert.AreEqual("10", expr2.ToString());
		}

		[TestMethod]
		public void TestMethod3()
		{
			var context = new LispContext();

			var expr1 = ToyLispParser.ParseExpression("(- (* (/ (+ 1 2) 3) 4) 5)").Reduce(context);

			Assert.AreEqual("-1", expr1.ToString());
		}

		[TestMethod]
		public void TestMethod4()
		{
			var context = new LispContext();

			var expr1 = ToyLispParser.ParseExpression("(+ (+ 3))").Reduce(context);
			var expr2 = ToyLispParser.ParseExpression("(- (- 3))").Reduce(context);

			Assert.AreEqual("3", expr1.ToString());
			Assert.AreEqual("3", expr2.ToString());
		}

		[TestMethod]
		public void TestMethod5()
		{
			var context = new LispContext();

			var expr1 = ToyLispParser.ParseExpression("(if 1 1 2)").Reduce(context);
			var expr2 = ToyLispParser.ParseExpression("(if '() 1 2)").Reduce(context);

			Assert.AreEqual("1", expr1.ToString());
			Assert.AreEqual("2", expr2.ToString());
		}
	}
}
