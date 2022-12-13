using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Player
    {
        public Player()
        {
            IsPlaying = false;
            Moves = 0;
        }

        public string Name { get; set; }
        public int Moves { get; set; }
        public bool IsPlaying { get; set; }

        public Color PlayFieldColor { get; set; }

    }
}
