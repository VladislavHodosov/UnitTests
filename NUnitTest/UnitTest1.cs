using NUnit.Framework;
using Pen;
using System.IO;

namespace NUnitTest
{
    public class Tests
    {
        private int inkContainerValue = 1000;
        private double sizeLetter = 1.0;
        private string color = "red";

        //bug 1
        //[TestMethod]
        //public void CheckGetColor()
        //{
        //    var penColor = new PenClass(inkContainerValue, sizeLetter, color);
        //    string actual = penColor.getColor();
        //    Assert.AreEqual(actual, color, $"{actual} is not equal {color}");
        //}

        [Test]
        public void CheckDefaultColor()
        {
            var penColor = new PenClass(inkContainerValue, sizeLetter);
            string actual = penColor.getColor();
            Assert.AreEqual(actual, "BLUE", $"{actual} is not equal {color}");
        }

        [Test]
        public void CheckIsWorkMethodNegativeValue()
        {
            var value = -1;
            var actual = new PenClass(value).isWork();
            Assert.IsFalse(actual, "Pen work without ink");
        }

        [Test]
        public void CheckIsWorkMethod()
        {
            var value = 3;
            var actual = new PenClass(value).isWork();
            Assert.IsTrue(actual, "Value is not positiv");
        }

        [Test]
        public void CheckDoSomthingElse()
        {
            var penColor = new PenClass(inkContainerValue, sizeLetter, color);
            var path = "1.txt";
            penColor.doSomethingElse();
            StreamReader fileRead = new StreamReader(path);
            var expectedResult = fileRead.ReadToEnd().Trim();
            Assert.AreEqual(expectedResult, color, $"Color {expectedResult} is not equal {color} in text file");
        }

        [Test]
        public void CheckWriteMethodInkZero()
        {
            var inkContainerValueZero = 0;
            var word = "A";
            var penColor = new PenClass(inkContainerValueZero);
            var actualResult = penColor.write(word);
            Assert.AreEqual("", actualResult, "Pen is work without ink");
        }

        [Test]
        public void CheckWriteMethodInkFull()
        {
            var word = "Abc";
            var penColor = new PenClass(inkContainerValue, sizeLetter);
            var actualResult = penColor.write(word);
            Assert.AreEqual(word, actualResult, $"{word} is not equal {actualResult}");
        }

        [Test]
        public void CheckWriteMethodWithSizeLetter()
        {
            var word = "Abc";
            var sizeLetter = 1;
            var inkContainerValue = 1;
            var penColor = new PenClass(inkContainerValue, sizeLetter);
            var actualResult = penColor.write(word);
            Assert.AreEqual("A", actualResult, $"{word} is not equal {actualResult}");
        }

        [Test]
        public void CheckWriteMethodWithOnlyInkValue()
        {
            var word = "Ab";
            var sizeLetter = 0.5;
            var inkContainerValue = 1;
            var penColor = new PenClass(inkContainerValue, sizeLetter);
            var actualResult = penColor.write(word);
            Assert.AreEqual("Ab", actualResult, $"{word} is not equal {actualResult}");
        }

        //bug2
        //[TestMethod]
        //public void CheckWriteMethodWithSizeletterBigger()
        //{
        //    var word = "Ab";
        //    var sizeLetter = 11;
        //    var inkContainerValue = 10;
        //    var penColor = new PenClass(inkContainerValue, sizeLetter);
        //    var actualResult = penColor.write(word);
        //    Assert.AreEqual("", actualResult, "Pen is write word, when sizeLetter bigger than inkContainerValue");
        //}

        //bug3
        //[TestMethod]
        //public void CheckWriteMethodWithBigWord()
        //{
        //    var word = "abcdef";
        //    var sizeLetter = 2;
        //    var inkContainerValue = 4;
        //    var penColor = new PenClass(inkContainerValue, sizeLetter);
        //    var actualResult = penColor.write(word);
        //    Assert.AreEqual("ab", actualResult, $"Pen is write {actualResult} word, when it should {"ab"}");
        //}

        //bug4
        //[TestMethod]
        //public void CheckWriteMethodWithSpaces()
        //{
        //    var word = "a b c d e f ";
        //    var sizeLetter = 1;
        //    var inkContainerValue = 6;
        //    var penColor = new PenClass(inkContainerValue, sizeLetter);
        //    var actualResult = penColor.write(word);
        //    Assert.AreEqual(word, actualResult, $"Pen is write {actualResult} word, when it should {word}");
        //}
    }
}