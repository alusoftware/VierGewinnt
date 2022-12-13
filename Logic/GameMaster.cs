using Data;
using System.Drawing;

namespace Logic
{
    public class GameMaster : IGameMaster
    {
        private readonly GameContext gameContext;

        public GameMaster(/*GameContext gameContext, Player playerOne, Player playerTwo*/) //Todo: DI
        {
            //this.gameContext = gameContext;



            //remove after DI
            this.gameContext = new GameContext();
            this.gameContext.PlayerOne = new Player() {  IsPlaying = true, PlayFieldColor = Color.Red };
            this.gameContext.PlayerTwo = new Player() { IsPlaying = false, PlayFieldColor = Color.Yellow };
        }

        public void GameMove(int columnIndex)
        {
            for (int i = Common.NumberOfRows - 1; i >= 0; i--)
            {
                if (gameContext.PlayingField[columnIndex, i] == FieldCellStatus.Empty)
                {
                    gameContext.PlayingField[columnIndex, i] = ConvertPlayerColorToPlayFieldStatus(GetCurrentPlayer().PlayFieldColor);
                    SwitchPlayer();
                    break;
                }
            }

            bool isFieldFilled = true;

            foreach (var item in gameContext.PlayingField)
            {
                if (item == FieldCellStatus.Empty)
                {
                    isFieldFilled = false;
                    break;
                }
            }

            if (isFieldFilled)
            {
                //Handle the GameOver-Screen. Check for a win also
            }

        }

        private FieldCellStatus ConvertPlayerColorToPlayFieldStatus(Color color)
        {
            //These Colors should be set in a central space (context? common?
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
            return gameContext.PlayerTwo.IsPlaying ? gameContext.PlayerTwo : gameContext.PlayerOne;
        }

        private void SwitchPlayer()
        {
            gameContext.PlayerOne.IsPlaying = !gameContext.PlayerOne.IsPlaying;
            gameContext.PlayerTwo.IsPlaying = !gameContext.PlayerTwo.IsPlaying;
        }

        public TimeSpan GetPlayTime()
        {
            throw new NotImplementedException();
        }

        public Player GetWinner()
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

        public bool IsWin()
        {
            throw new NotImplementedException();
        }
    }
}