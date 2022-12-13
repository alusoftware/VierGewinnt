using System.Drawing;

namespace Data
{
    public class GameContext
    {
        public GameContext(bool isRedStarting)
        {
            PlayingField = new FieldCellStatus[Common.NumberOfColumns,Common.NumberOfRows];
            PlayerRed = new Player(Color.Red);
            PlayerYellow = new Player(Color.Yellow);

            if (isRedStarting)
                PlayerRed.IsPlaying = true;
            else
                PlayerYellow.IsPlaying = true;
        }

        public FieldCellStatus[,] PlayingField { get; set; }

        public Player PlayerRed { get; set; }
        public Player PlayerYellow { get; set; }

        public DateTime StartTime { get; set; }
        public TimeSpan ElapsedTime { get; set; }
    }
}