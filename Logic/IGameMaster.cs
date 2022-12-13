using Data;

namespace Logic
{
    public interface IGameMaster
    {
        public bool IsWin();

        public void GameMove(int column);

        public Player GetWinner();

        public FieldCellStatus[,] GetPlayingField();


        public bool IsGameOver();

        public TimeSpan GetElapsedTime();
    }
}
