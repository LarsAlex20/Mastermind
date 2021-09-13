using NUnit.Framework;
using Mastermind;
using Mastermind.Models;
using System.Collections.Generic;

namespace Mastermind.Tests
{
    public class FarbcodeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SetPin_PositionFalse_ReturnNullCode()
        {
            //arrange
            Farbcode TestCode = new Farbcode(4);
            Farbcode ExpextedCode = new Farbcode(4);


            //act
            TestCode.setPin(-1, new Farbpin(Colors.Red));
            //assert
            Assert.AreEqual(ExpextedCode.getPins(), TestCode.getPins());
        }

        [Test]
        public void SetPin_PinFalse_ReturnNullCode()
        {
            //arrange
            Farbcode TestCode = new Farbcode(4);
            Farbcode ExpextedCode = new Farbcode(4);


            //act
            TestCode.setPin(2, null);

            //assert
            Assert.AreEqual(ExpextedCode.getPins(), TestCode.getPins());
        }

        [Test]
        public void SetPin_AllCorrect_ReturnRightCode()
        {
            //arrange
            Farbcode TestCode = new Farbcode(4);
            Colors ExpectedColor = Colors.Red;


            //act
            TestCode.setPin(0, new Farbpin(Colors.Red));

            //assert
            Assert.AreEqual(ExpectedColor, TestCode.getPins()[0].Color);
        }


        [Test]
        public void Generieren_NoColors_ReturnNullCode()
        {
            //arrange
            Farbcode TestCode = new Farbcode(4);
            Farbcode ExpextedCode = new Farbcode(4);


            //act
            TestCode.generieren(null);

            //assert
            Assert.AreEqual(ExpextedCode.getPins(), TestCode.getPins());
        }
        [Test]
        public void Generieren_RightColors_ReturnRandomCode()
        {
            //arrange
            Farbcode TestCode = new Farbcode(4);
            Farbcode ExpextedCode = new Farbcode(4);
            Colors[] farben = new Colors[6];
            int counter = 0;

            foreach (Colors color in Colors.GetValues(typeof(Colors)))
            {
                if (counter < 6)
                {
                    farben[counter] = color;
                }
                counter++;
            }


            //act
            TestCode.generieren(farben);

            //assert
            Assert.AreEqual(ExpextedCode.getPins(), TestCode.getPins());
        }
    }
}