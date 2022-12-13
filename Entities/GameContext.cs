using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GameContext
    {
        public GameContext()
        {
            PlayingField = new FieldCellStatus[Common.NumberOfColumns,Common.NumberOfRows];
            PlayerOne = new Player();
            PlayerTwo = new Player();
        }

        public FieldCellStatus[,] PlayingField { get; set; }

        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }

        public TimeSpan PlayTime { get; set; }
    }
}
