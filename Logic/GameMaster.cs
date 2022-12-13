using Data;
using System.Drawing;

namespace Logic
{
    public class GameMaster : IGameMaster
    {
        private readonly GameContext gameContext;

        public GameMaster(string playerRed, string playerYellow, bool playerRedStart)
        {
            gameContext = new GameContext(playerRedStart);

            gameContext.PlayerRed.Name = playerRed;
            gameContext.PlayerYellow.Name = playerYellow;
            StartTimeMeasure();
        }

        public void GameMove(int columnIndex)
        {
            for (int i = Common.NumberOfRows - 1; i >= 0; i--)
            {
                if (gameContext.PlayingField[columnIndex, i] == FieldCellStatus.Empty)
                {
                    gameContext.PlayingField[columnIndex, i] = ConvertPlayerColorToPlayFieldStatus(GetCurrentPlayer().PlayFieldColor);
                    GetCurrentPlayer().Moves++;
                    SwitchPlayer();
                    break;
                }
            }
        }

        private FieldCellStatus ConvertPlayerColorToPlayFieldStatus(Color color)
        {
            if (color == Color.Red)
                return FieldCellStatus.Red;
            else if (color == Color.Yellow)
                return FieldCellStatus.Yellow;
            else
                return FieldCellStatus.Empty;
        }

        public FieldCellStatus[,] GetPlayingField()
        {
            return gameContext.PlayingField;
        }

        private Player GetCurrentPlayer()
        {
            return gameContext.PlayerYellow.IsPlaying ? gameContext.PlayerYellow : gameContext.PlayerRed;
        }

        private void SwitchPlayer()
        {
            gameContext.PlayerRed.IsPlaying = !gameContext.PlayerRed.IsPlaying;
            gameContext.PlayerYellow.IsPlaying = !gameContext.PlayerYellow.IsPlaying;
        }

        public bool IsGameOver()
        {
            bool isFieldFilled = true;

            foreach (var item in gameContext.PlayingField)
            {
                if (item == FieldCellStatus.Empty)
                {
                    isFieldFilled = false;
                    break;
                }
            }
            return isFieldFilled;
        }

        public Player GetWinner()
        {
            if (IsWin())
                return gameContext.PlayerYellow.IsPlaying ? gameContext.PlayerRed : gameContext.PlayerYellow;
            else
                return null;
        }

        public bool IsWin()
        {
            bool isWin = CheckHorizontal() || CheckVertical() || CheckDiagonalUp() || CheckDiagonalDown();
            if (isWin)
                StopTimeMeasure();
            return isWin;
        }

        private bool CheckHorizontal()
        {
            for (int i = 0; i < Common.NumberOfRows; i++)
            {
                int counter = 1;
                FieldCellStatus tempStatus = FieldCellStatus.Empty;
                FieldCellStatus currentStatus;

                for (int j = 0; j < Common.NumberOfColumns; j++)
                {
                    currentStatus = gameContext.PlayingField[j, i];

                    if (tempStatus == currentStatus && currentStatus != FieldCellStatus.Empty)
                        counter++;
                    else
                        counter = 1;

                    if (counter >= 4)
                        return true;

                    tempStatus = currentStatus;
                }
            }
            return false;
        }

        private bool CheckVertical()
        {
            for (int i = 0; i < Common.NumberOfColumns; i++)
            {
                int counter = 1;
                FieldCellStatus tempStatus = FieldCellStatus.Empty;
                FieldCellStatus currentStatus;

                for (int j = 0; j < Common.NumberOfRows; j++)
                {
                    currentStatus = gameContext.PlayingField[i, j];

                    if (tempStatus == currentStatus && currentStatus != FieldCellStatus.Empty)
                        counter++;
                    else
                        counter = 1;

                    if (counter >= 4)
                        return true;

                    tempStatus = currentStatus;
                }
            }
            return false;
        }

        private bool CheckDiagonalUp()
        {
            for (int i = 0; i < Common.NumberOfColumns; i++)
            {
                for (int j = 0; j < Common.NumberOfRows; j++)
                {
                    if (i + 3 >= Common.NumberOfColumns || j - 3 < 0)
                        continue;

                    int counter = 1;
                    FieldCellStatus currentStatus;
                    currentStatus = gameContext.PlayingField[i, j];

                    for (int k = 1; k < 4; k++)
                    {
                        if (gameContext.PlayingField[i + k, j - k] == currentStatus && currentStatus != FieldCellStatus.Empty)
                            counter++;
                        else
                            counter = 1;
                    }

                    if (counter >= 4)
                        return true;
                }
            }
            return false;
        }

        private bool CheckDiagonalDown()
        {
            for (int i = 0; i < Common.NumberOfColumns; i++)
            {
                for (int j = 0; j < Common.NumberOfRows; j++)
                {
                    if (i + 3 >= Common.NumberOfColumns || j + 3 >= Common.NumberOfRows)
                        continue;

                    int counter = 1;
                    FieldCellStatus currentStatus;
                    currentStatus = gameContext.PlayingField[i, j];

                    for (int k = 1; k < 4; k++)
                    {
                        if (gameContext.PlayingField[i + k, j + k] == currentStatus && currentStatus != FieldCellStatus.Empty)
                            counter++;
                        else
                            counter = 1;
                    }

                    if (counter >= 4)
                        return true;
                }
            }
            return false;
        }

        private void StartTimeMeasure()
        {
            gameContext.StartTime = DateTime.Now;
        }

        private void StopTimeMeasure()
        {
            gameContext.ElapsedTime = DateTime.Now - gameContext.StartTime;
        }

        public TimeSpan GetElapsedTime()
        {
            return gameContext.ElapsedTime;
        }
    }
}