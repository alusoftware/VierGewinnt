using Data;
using Logic.Exceptions;
using System.Drawing;

namespace Logic
{
    public class GameMaster : IGameMaster
    {
        private readonly GameContext gameContext;
        private readonly IWinChecker winChecker;

        public GameMaster(string playerRed, string playerYellow, bool playerRedStart)
        {
            gameContext = new GameContext(playerRedStart);
            winChecker = new WinChecker(gameContext);

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

        public bool IsWin()
        {
            bool isWin = winChecker.IsWin();
            if (isWin)
                StopTimeMeasure();
            return isWin;
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
            {
                return gameContext.PlayerYellow.IsPlaying ? gameContext.PlayerRed : gameContext.PlayerYellow;
            }

            throw new NoWinnerFoundException();
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