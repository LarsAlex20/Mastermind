using Mastermind.Commands;
using Mastermind.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Mastermind.ViewModels
{
    public class ViewModelGameBoard : AViewModel
    {
        public ObservableCollection<Colors> Farben { get; }
        public int Versuch { get; set; }
        public Colors[] ColorList { get; set; }
        public ExecuteCommand Btn_ChangeColor { get; set; }
        public ExecuteCommand Btn_CheckCode { get; set; }
        public ExecuteCommand Btn_BackToGameBoard { get; set; }
        public Farbcode ComputerCode { get; set; }
        public Farbcode UserCode { get; set; }
        public GameBoardModel GameBoardData { get; set; }



        public ViewModelGameBoard()
        {
            GameBoardData = new GameBoardModel();

            GameBoardData.PinColors = new BindableTwoDArray<string>(15, 5);
            GameBoardData.CheckPinColors = new BindableTwoDArray<string>(15, 5);
            GameBoardData.ColorPinVisibility = new BindableTwoDArray<string>(15, 5);

            Farben = new ObservableCollection<Colors>() { };

            Btn_ChangeColor = new ExecuteCommand(ChangeColor, Data);
            Btn_CheckCode = new ExecuteCommand(CheckCode, Data);
            Btn_BackToGameBoard = new ExecuteCommand(BackToGameBoard, Data);

            ComputerCode = new Farbcode(Data.InputCodeLaenge);
            UserCode = new Farbcode(Data.InputCodeLaenge);


            FillData(Data.InputFarben);
        }


        public void FillData(int farben)
        {
            // In dieser Methode werden viele Daten befüllt. 
            // Die Victory und GameOver Screens werden ausgeblendet, der Usercode wird mit roten Pins befüllt, 
            // die Pins die nicht in der ersten Reihe sind werden ausgeblendet und die Kontrollpins werden auf Black gesetzt.
            // Je nach dem wie lang der Code sein soll, wird das entsprechende Feld eingeblendet.

            Versuch = 0;
            GameBoardData.VictoryVisibility = "Hidden";
            GameBoardData.GameOverVisibility = "Hidden";            
            GameBoardData.Try = "Restliche Versuche: " + Data.InputVersuche;

            ColorList = FillColorList(farben);
            ComputerCode.generieren(ColorList);

            for (int i = 0; i < Data.InputCodeLaenge; i++)
            {
                UserCode.setPin(i, new Farbpin(Colors.Red));
            }

            for (int versuch = 0; versuch < 15; versuch++)
            {
                for (int position = 0; position < Data.InputCodeLaenge; position++)
                {
                    GameBoardData.ColorPinVisibility[versuch, position] = "Hidden";
                    GameBoardData.CheckPinColors[versuch, position] = "Black";
                    GameBoardData.PinColors[versuch, position] = Convert.ToString(Colors.Red);
                }
            }

            if (Data.InputCodeLaenge == 4)
            {
                GameBoardData.Code4Visibility = "Visible";
                GameBoardData.Code5Visibility = "Hidden";
            }
            else
            {
                GameBoardData.Code4Visibility = "Hidden";
                GameBoardData.Code5Visibility = "Visible";
            }
        }

        public Colors[] FillColorList(int anzahlFarben)
        {
            // In dieser Funktion wird eine Liste mit den zur Verfügung stehenden Farben erstellt.

            Colors[] farben = new Colors[anzahlFarben];
            int counter = 0;

            foreach (Colors color in Colors.GetValues(typeof(Colors)))
            {
                if (counter < anzahlFarben)
                {
                    farben[counter] = color;
                    Farben.Add(color);
                }
                counter++;
            }

            return farben;
        }

        public void ChangeColor()
        {
            // Diese Funktion kümmert sich um das ändern der Farbe eines Pins, wobei beim Click auf den Pin immer die nächste Farbe angezeigt wird.
            // Falls man am Ende der Liste angekommen ist, fängt es wieder mit Rot an.

            int counter = 0;
            bool check = false;
            foreach (Colors color in Farben)
            {
                if (counter == Data.InputFarben - 1)
                {
                    counter = -1;
                }

                if (color.ToString() == GameBoardData.PinColors[Versuch, Data.CommandParameter] && check == false)
                {
                    GameBoardData.PinColors[Versuch, Data.CommandParameter] = Farben[counter + 1].ToString();
                    UserCode.setPin(Data.CommandParameter, new Farbpin(Farben[counter + 1]));
                    check = true;
                }
                counter++;
            }
        }

        private void CheckCode()
        {
            // In dieser Funktion wird der UserCode mit dem ZufallsCode verglichen und dementsprechend die Kontrollpins Rot oder Weiß gefärbt.
            
            string[] SortedColors = new string[Data.InputCodeLaenge];
            bool victory = true;

            CompareCodes();

            // Hier wird aus dem zweidimensionalen Array ein eindimensionaler gemacht, um diesen zu Sortieren, damit der Spieler nicht sehen kann, welcher seiner Pins an der richtigen Stelle ist.
            for (int i = 0; i < Data.InputCodeLaenge; i++)
            {
                SortedColors[i] = GameBoardData.CheckPinColors[Versuch, i];
            }

            Array.Sort(SortedColors);
            Array.Reverse(SortedColors);

            for (int i = 0; i < Data.InputCodeLaenge; i++)
            {
                GameBoardData.CheckPinColors[Versuch, i] = SortedColors[i];
            }

            // Wenn man am Ende keine Versuche mehr hat, wird der GameOver-Screen gezeigt und falls man den Code des Computers erraten hat erscheint der Victory-Screen.
            for (int i = 0; i < Data.InputCodeLaenge; i++)
            {
                if (UserCode.getPins()[i].Color != ComputerCode.getPins()[i].Color)
                {
                    victory = false;
                }
            }
                        
            if (victory == true)
            {
                GameBoardData.VictoryVisibility = "Visible";

            }

            if (Versuch + 1 == Data.InputVersuche)
            {
                GameBoardData.GameOverVisibility = "Visible";
            }

            else
            {
                // Hier werden die restlichen Versuche angepasst und die nächste Reihe an Pins angezeigt.
                Versuch++;
                GameBoardData.Try = "Restliche Versuche: " + Convert.ToString(Data.InputVersuche - Versuch);
                for (int i = 0; i < Data.InputCodeLaenge; i++)
                {
                    GameBoardData.ColorPinVisibility[Versuch, i] = "Visible";
                    UserCode.setPin(i, new Farbpin(Colors.Red));
                }

            }
        }

        private void BackToGameBoard()
        {
            GameBoardData.VictoryVisibility = "Hidden";
            GameBoardData.GameOverVisibility = "Hidden";
        }

        public void CompareCodes()
        {
            //Vergleich der Codes.
            int UserCounter = 0;
            int ComputerCounter = 0;
            bool Hit = false;

            foreach (Farbpin UserPin in UserCode.getPins())
            {
                if (UserPin.Color == ComputerCode.getPins()[UserCounter].Color)
                {
                    GameBoardData.CheckPinColors[Versuch, UserCounter] = "Red";
                }
                UserCounter++;
            }
            UserCounter = 0;

            foreach (Farbpin UserPin in UserCode.getPins())
            {
                Hit = false;
                foreach (Farbpin ComputerPin in ComputerCode.getPins())
                {
                    if (UserPin.Color == ComputerPin.Color && GameBoardData.CheckPinColors[Versuch, UserCounter] != "Red" && GameBoardData.CheckPinColors[Versuch, ComputerCounter] != "Red" && Hit == false &&
                        GameBoardData.CheckPinColors[Versuch, ComputerCounter] !="White")
                    {
                        GameBoardData.CheckPinColors[Versuch, ComputerCounter] = "White";
                        Hit = true;
                    }

                    ComputerCounter++;
                }
                ComputerCounter = 0;
                UserCounter++;
            }
        }
    }
}
