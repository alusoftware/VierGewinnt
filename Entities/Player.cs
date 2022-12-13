using System.Drawing;

namespace Data
{
    public class Player
    {
        public Player(Color color)
        {
            IsPlaying = false;
            Moves = 0;
            PlayFieldColor = color;
        }

        public string Name { get; set; }
        public int Moves { get; set; }
        public bool IsPlaying { get; set; }

        public Color PlayFieldColor { get; set; }

    }
}
