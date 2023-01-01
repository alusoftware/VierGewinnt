using Data;

namespace Logic
{
    public class WinChecker : IWinChecker
    {
        private readonly GameContext gameContext;

        public WinChecker(GameContext gameContext)
        {
            this.gameContext = gameContext; 
        }

        public bool IsWin()
        {
            return CheckHorizontal() || CheckVertical() || CheckDiagonalUp() || CheckDiagonalDown();
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
    }
}
