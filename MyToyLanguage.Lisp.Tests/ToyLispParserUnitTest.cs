using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyToyLanguage.Lisp.Tests
{
	[TestClass]
	public class ToyLispParserUnitTest
	{
		[TestMethod]
		public void ShouldUnderstandEmptyList()
		{
			var expr = ToyLispParser.ParseExpression("()");

			Assert.AreEqual("()", expr.ToString());
		}

		[TestMethod]
		public void ShouldApplyFunctionToAtomsOrLists1()
		{
			var context = new LispContext();

			var expr1 = ToyLispParser.ParseExpression("(+ 1 2 3 4)").Reduce(context);
			var expr2 = ToyLispParser.ParseExpression("(+ (+ 1 2) (+ 3 4))").Reduce(context);

			Assert.AreEqual("10", expr1.ToString());
			Assert.AreEqual("10", expr2.ToString());
		}

		[TestMethod]
		public void ShouldApplyFunctionToAtomsOrLists2()
		{
			var context = new LispContext();

			var expr1 = ToyLispParser.ParseExpression("(- (* (/ (+ 1 2) 3) 4) 5)").Reduce(context);

			Assert.AreEqual("-1", expr1.ToString());
		}

		[TestMethod]
		public void ShouldApplyFunctionToAtomsOrLists3()
		{
			var context = new LispContext();

			var expr1 = ToyLispParser.ParseExpression("(+ (+ 3))").Reduce(context);
			var expr2 = ToyLispParser.ParseExpression("(- (- 3))").Reduce(context);

			Assert.AreEqual("3", expr1.ToString());
			Assert.AreEqual("3", expr2.ToString());
		}

		[TestMethod]
		public void ShouldReturnRightValueFromIfFunction()
		{
			var context = new LispContext();

			var expr1 = ToyLispParser.ParseExpression("(if 1 1 2)").Reduce(context);
			var expr2 = ToyLispParser.ParseExpression("(if '() 1 2)").Reduce(context);

			Assert.AreEqual("1", expr1.ToString());
			Assert.AreEqual("2", expr2.ToString());
		}

		[TestMethod]
		public void ShouldUnderstandLambdasAndApplyAnonymousFunctions()
		{
			var context = new LispContext();
			var expr = ToyLispParser.ParseExpression("((lambda (x y) (+ x y)) 1 2)").Reduce(context);
			Assert.AreEqual("3", expr.ToString());
		}
	}
}
