using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PlayingField
    {
        public FieldCellStatus FieldCellStatus { get; set; }

        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }

        public TimeSpan PlayTime { get; set; }
    }
}
