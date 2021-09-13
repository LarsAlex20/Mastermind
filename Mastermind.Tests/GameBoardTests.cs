using Mastermind.Models;
using Mastermind.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mastermind.Tests
{
    class GameBoardTests
    {
        [Test]
        public void ChangeColor_RightDataColorWasChanged_ChangeColorOfPin()
        {
            //arrange
            AViewModel aviewmodel = new AViewModel();

            
            ViewModelGameBoard viewmodel = new ViewModelGameBoard();
            int counter = 0;
            viewmodel.Versuch = 0;
            foreach (Colors color in Colors.GetValues(typeof(Colors)))
            {
                if (counter < 6)
                {
                    viewmodel.Farben.Add(color);
                }
                counter++;
            }
            
            InputModel Data = new InputModel();
            Data.InputFarben = 6;
            Data.CommandParameter = 0;


            viewmodel.GameBoardData.PinColors = new BindableTwoDArray<string>(15, 5);
            viewmodel.GameBoardData.PinColors[0, 0] = "Red";

            //act
            viewmodel.ChangeColor();
            //assert
            Assert.AreEqual(viewmodel.UserCode.getPins()[0].Color, viewmodel.GameBoardData.PinColors[0, 0]);
        }

        [Test]
        public void CompareCodes_RightData_RightControlPins()
        {
            //arrange
            ViewModelGameBoard viewmodel = new ViewModelGameBoard();
            viewmodel.UserCode = new Farbcode(4);
            viewmodel.ComputerCode = new Farbcode(4);
            viewmodel.GameBoardData.PinColors = new BindableTwoDArray<string>(15, 5);
            viewmodel.Versuch = 0;

            viewmodel.UserCode.setPin(0, new Farbpin(Colors.Red));
            viewmodel.UserCode.setPin(1, new Farbpin(Colors.Red));
            viewmodel.UserCode.setPin(2, new Farbpin(Colors.Blue));
            viewmodel.UserCode.setPin(3, new Farbpin(Colors.Orange));

            viewmodel.ComputerCode.setPin(0, new Farbpin(Colors.Red));
            viewmodel.ComputerCode.setPin(1, new Farbpin(Colors.Red));
            viewmodel.ComputerCode.setPin(2, new Farbpin(Colors.Orange));
            viewmodel.ComputerCode.setPin(3, new Farbpin(Colors.Blue));

            //act
            viewmodel.CompareCodes();
            //assert
            Assert.AreEqual(viewmodel.GameBoardData.CheckPinColors[0, 0], "Red");
            Assert.AreEqual(viewmodel.GameBoardData.CheckPinColors[0, 1], "Red");
            Assert.AreEqual(viewmodel.GameBoardData.CheckPinColors[0, 2], "White");
            Assert.AreEqual(viewmodel.GameBoardData.CheckPinColors[0, 3], "White");
        }
    }
}
