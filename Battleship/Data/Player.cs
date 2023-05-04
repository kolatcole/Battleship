using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Data
{
    public class Player
    {
        
        public Player()
        {

            Grid = new Dictionary<string, bool>()
            {
                {"1A",false },{"2A",false },{"3A",false },{"4A",false },{"5A",false },{"6A",false },{"7A",false },{"8A",false },{"9A",false },{"10A",false },
                {"1B",false },{"2B",false },{"3B",false },{"4B",false },{"5B",false },{"6B",false },{"7B",false },{"8B",false },{"9B",false },{"10B",false },
                {"1C",false },{"2C",false },{"3C",false },{"4C",false },{"5C",false },{"6C",false },{"7C",false },{"8C",false },{"9C",false },{"10C",false },
                {"1D",false },{"2D",false },{"3D",false },{"4D",false },{"5D",false },{"6D",false },{"7D",false },{"8D",false },{"9D",false },{"10D",false },
                {"1E",false },{"2E",false },{"3E",false },{"4E",false },{"5E",false },{"6E",false },{"7E",false },{"8E",false },{"9E",false },{"10E",false },
                {"1F",false },{"2F",false },{"3F",false },{"4F",false },{"5F",false },{"6F",false },{"7F",false },{"8F",false },{"9F",false },{"10F",false },
                {"1G",false },{"2G",false },{"3G",false },{"4G",false },{"5G",false },{"6G",false },{"7G",false },{"8G",false },{"9G",false },{"10G",false },
                {"1H",false },{"2H",false },{"3H",false },{"4H",false },{"5H",false },{"6H",false },{"7H",false },{"8H",false },{"9H",false },{"10H",false },
                {"1I",false },{"2I",false },{"3I",false },{"4I",false },{"5I",false },{"6I",false },{"7I",false },{"8I",false },{"9I",false },{"10I",false },
                {"1J",false },{"2J",false },{"3J",false },{"4J",false },{"5J",false },{"6J",false },{"7J",false },{"8J",false },{"9J",false },{"10J",false }
            };

            Ship BattleShip = new Ship
            {
                Name = ShipType.BattleShip,
                Id = 1,
                ShipHoles = new Dictionary<string, int>()
            };
            Ship Destroyer1 = new Ship
            {
                Name = ShipType.Destroyer,
                Id = 2,
                ShipHoles = new Dictionary<string, int>()
            };
            Ship Destroyer2 = new Ship
            {
                Name = ShipType.Destroyer,
                Id = 3,
                ShipHoles = new Dictionary<string, int>()
            };
            TotalRemainingHoles = 13;
            Ships = new List<Ship>()
            {
                BattleShip, Destroyer1, Destroyer2
            };
        }    
    
        public int Id { get; set; }
        public int TotalRemainingHoles { get; set; }
        public Dictionary<string, bool> Grid { get; set; }
        public List<Ship> Ships { get; set; }
        public List<int> OccupiedGridCells { get; set; }
    }

}    
