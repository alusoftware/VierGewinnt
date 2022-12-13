using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    //define better, what exactly should be in the interface and what not; (what do i need in Form1.cs?)
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
