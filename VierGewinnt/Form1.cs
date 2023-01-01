using Data;
using Logic;
using Logic.Exceptions;

namespace VierGewinnt
{
    public partial class Form_VierGewinnt : Form
    {
        private IGameMaster gameMaster;
        private TextBox[,] fieldCells;

        public Form_VierGewinnt()
        {
            InitializeComponent();

            PlayField.Visible = false;
            RadioButton_StartRedPlayer.Checked = true;
            fieldCells = new TextBox[Common.NumberOfColumns, Common.NumberOfRows];
        }

        private void OnStartGameClick(object sender, EventArgs e)
        {
            if (IsPlayerInputValid(TextBox_PlayerRed.Text, TextBox_PlayerYellow.Text))
            {
                InitializePlayfield();
                GetTextBoxesInArrays();
                gameMaster = new GameMaster(TextBox_PlayerRed.Text, TextBox_PlayerYellow.Text, RadioButton_StartRedPlayer.Checked);
            }
            else
                MessageBox.Show("Beide Spieler müssen einen Namen haben!");
        }

        private bool IsPlayerInputValid(string playerOne, string playerTwo)
        {
            return !String.IsNullOrWhiteSpace(playerOne) && !String.IsNullOrWhiteSpace(playerTwo);
        }

        private void InitializePlayfield()
        {
            PlayerInput.Visible = false;
            PlayField.Visible = true;

            foreach (Control x in PlayField.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Enabled = false;
                }
            }
        }

        private void Paint()
        {
            var playField = gameMaster.GetPlayingField();

            for (int i = 0; i < Common.NumberOfColumns; i++)
            {
                for (int j = 0; j < Common.NumberOfRows; j++)
                {
                    if (playField[i, j] == FieldCellStatus.Red)
                        fieldCells[i, j].BackColor = Color.Red;
                    else if (playField[i, j] == FieldCellStatus.Yellow)
                        fieldCells[i, j].BackColor = Color.Yellow;
                }
            }

            try
            {
                if (gameMaster.IsWin())
                {
                    var timespan = gameMaster.GetElapsedTime();
                    ShowWinnerDetails(gameMaster.GetWinner().Name, gameMaster.GetWinner().Moves, timespan.Minutes, timespan.Seconds);
                }
                else if (gameMaster.IsGameOver())
                {
                    MessageBox.Show("Niemand hat gewonnen!");
                }

            }
            catch (NoWinnerFoundException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ShowWinnerDetails(string winnerName, int moves, int minutes, int seconds)
        {
            MessageBox.Show("Spieler " + winnerName + " hat nach " + moves + " Zügen und einer Zeit von "
                + minutes + " Minuten und " + seconds + " Sekunden gewonnen.");
        }

        private void Button_ColA_Click(object sender, EventArgs e)
        {
            gameMaster.GameMove(0);
            Paint();
        }

        private void Button_ColB_Click(object sender, EventArgs e)
        {
            gameMaster.GameMove(1);
            Paint();
        }

        private void Button_ColC_Click(object sender, EventArgs e)
        {
            gameMaster.GameMove(2);
            Paint();
        }

        private void Button_ColD_Click(object sender, EventArgs e)
        {
            gameMaster.GameMove(3);
            Paint();
        }

        private void Button_ColE_Click(object sender, EventArgs e)
        {
            gameMaster.GameMove(4);
            Paint();
        }

        private void Button_ColF_Click(object sender, EventArgs e)
        {
            gameMaster.GameMove(5);
            Paint();
        }

        private void Button_ColG_Click(object sender, EventArgs e)
        {
            gameMaster.GameMove(6);
            Paint();
        }

        private void GetTextBoxesInArrays()
        {
            fieldCells[0, 0] = TextBoxA1;
            fieldCells[0, 1] = TextBoxA2;
            fieldCells[0, 2] = TextBoxA3;
            fieldCells[0, 3] = TextBoxA4;
            fieldCells[0, 4] = TextBoxA5;
            fieldCells[0, 5] = TextBoxA6;

            fieldCells[1, 0] = TextBoxB1;
            fieldCells[1, 1] = TextBoxB2;
            fieldCells[1, 2] = TextBoxB3;
            fieldCells[1, 3] = TextBoxB4;
            fieldCells[1, 4] = TextBoxB5;
            fieldCells[1, 5] = TextBoxB6;

            fieldCells[2, 0] = TextBoxC1;
            fieldCells[2, 1] = TextBoxC2;
            fieldCells[2, 2] = TextBoxC3;
            fieldCells[2, 3] = TextBoxC4;
            fieldCells[2, 4] = TextBoxC5;
            fieldCells[2, 5] = TextBoxC6;

            fieldCells[3, 0] = TextBoxD1;
            fieldCells[3, 1] = TextBoxD2;
            fieldCells[3, 2] = TextBoxD3;
            fieldCells[3, 3] = TextBoxD4;
            fieldCells[3, 4] = TextBoxD5;
            fieldCells[3, 5] = TextBoxD6;

            fieldCells[4, 0] = TextBoxE1;
            fieldCells[4, 1] = TextBoxE2;
            fieldCells[4, 2] = TextBoxE3;
            fieldCells[4, 3] = TextBoxE4;
            fieldCells[4, 4] = TextBoxE5;
            fieldCells[4, 5] = TextBoxE6;

            fieldCells[5, 0] = TextBoxF1;
            fieldCells[5, 1] = TextBoxF2;
            fieldCells[5, 2] = TextBoxF3;
            fieldCells[5, 3] = TextBoxF4;
            fieldCells[5, 4] = TextBoxF5;
            fieldCells[5, 5] = TextBoxF6;

            fieldCells[6, 0] = TextBoxG1;
            fieldCells[6, 1] = TextBoxG2;
            fieldCells[6, 2] = TextBoxG3;
            fieldCells[6, 3] = TextBoxG4;
            fieldCells[6, 4] = TextBoxG5;
            fieldCells[6, 5] = TextBoxG6;
        }

    }
}