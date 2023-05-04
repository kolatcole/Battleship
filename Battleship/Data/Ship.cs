using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Data
{
    public class Ship
    {
        public int Id { get; set; }
        public ShipType Name { get; set; }
        public Dictionary<string,int> ShipHoles { get; set; } // points to the cells on the grid, int holds the index of the hole in the ship
    }
}
