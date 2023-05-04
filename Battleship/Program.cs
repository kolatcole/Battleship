// See https://aka.ms/new-console-template for more information
using Battleship.Data;

var battleShip = new BattleShipGame();
var player1 = battleShip.getPlayerById(1);
var player2 = battleShip.getPlayerById(2);
Random random = new Random();
int currentPlayerId = random.Next(1, 2);

while (player1.TotalRemainingHoles > 0 && player2.TotalRemainingHoles > 0)
{
    if (currentPlayerId == 2)
    {
        Console.WriteLine("Computer's remaining shiphole(s) is " + player2.TotalRemainingHoles);
        int randomComputerSelection = random.Next(0, 99);
        string targetCoordinate = player1.Grid.ElementAt(randomComputerSelection).Key;
        battleShip.SelectTargetCoordinate(player2, player1, targetCoordinate);
        Console.WriteLine("Computer's Grid");
        battleShip.DisplayGrid(player2);
        if (player1.TotalRemainingHoles == 0)
            break;
        
        currentPlayerId--;
    }

    if (currentPlayerId == 1)
    {
        Console.WriteLine("Computer's remaining shiphole(s) is " + player2.TotalRemainingHoles);
        Console.WriteLine("Your remaining shiphole(s) is " + player1.TotalRemainingHoles);
        Console.WriteLine("Enter the coordinate to target on the opponent's grid");
        string targetCoordinate = Console.ReadLine().ToUpper();
        battleShip.SelectTargetCoordinate(player1, player2, targetCoordinate);
        Console.WriteLine("Your Grid");
        battleShip.DisplayGrid(player1);
        if (player2.TotalRemainingHoles == 0)
            break;

        currentPlayerId++;
    }
}

battleShip.DeclareWinner(player1, player2);
public class BattleShipGame
{
    private Player player1;
    private Player player2;
    public BattleShipGame()
    {
        player1 = new Player { Id = 1, OccupiedGridCells = new List<int>() };
        player2 = new Player { Id = 2, OccupiedGridCells= new List<int>() };

        foreach(var ship in player1.Ships)
        {
            PlaceShips(player1, ship);
        }
        foreach (var ship in player2.Ships)
        {
            PlaceShips(player2, ship);
        }
        Console.WriteLine("Computer's Grid");
        DisplayGrid(player2);
        Console.WriteLine("Player's Grid");
        DisplayGrid(player1);
    }

    public void DisplayGrid(Player player)
    {
        for(int i=0; i<player.Grid.Count; i++)
        {
            if (i % 10 == 0)
                Console.Write("\n");
            Console.Write(player.Grid.ElementAt(i).Value? player.Grid.ElementAt(i).Key + "*|" : player.Grid.ElementAt(i).Key + " |"); 
        }
        Console.Write("\n");
    }
    public Player getPlayerById(int id)
    {
        return new Player[] { player1, player2 }.Where(x => x.Id == id).First();
    }
    public void PlaceShips(Player player, Ship ship)
    {
        List<string> directions =new List<string>{ "Up", "Down", "Left", "Right" }; 
        RandomizePlacing(directions, player, ship);
    }
    public void RandomizePlacing(List<string> directions, Player player, Ship ship)
    {
        Random random = new Random();
        int directionIndex = random.Next(directions.Count);
        int index = random.Next(player.Grid.Count);
        string shipDirection = directions.ElementAt(directionIndex);

        if (shipDirection == "Right")
        {
            if ((index + (int)ship.Name - 1 <= (((index + 9) / 10) * 10) - 1) || index % 10 == 0 )
            {
                List<int> tempIndexList = new List<int>();
                int count = 0;
                for (int i = index; i <= index + (int)ship.Name - 1; i++)
                {
                    if (player.OccupiedGridCells.Contains(i))
                        RandomizePlacing(directions, player, ship);
                    else
                    {
                        var cell = player.Grid.ElementAt(i);
                        ship.ShipHoles.Add(cell.Key, ++count);
                        player.Grid[cell.Key] = true;
                        tempIndexList.Add(i);
                    }
                        
                }
                player.OccupiedGridCells.AddRange(tempIndexList);
            }
            else
                RandomizePlacing(directions, player, ship);
        }
        else if (shipDirection == "Left")
        {
            if (index + 1 - (int)ship.Name >= ((index / 10) * 10))
            {
                List<int> tempIndexList = new List<int>();
                int count = 0;
                for (int i = index; i >= index + 1 - (int)ship.Name; i--)
                {
                    if (player.OccupiedGridCells.Contains(i))
                        RandomizePlacing(directions, player, ship);
                    else
                    {
                        var cell = player.Grid.ElementAt(i);
                        ship.ShipHoles.Add(cell.Key, ++count);
                        player.Grid[cell.Key] = true;
                        tempIndexList.Add(i);
                    }
                }
                player.OccupiedGridCells.AddRange(tempIndexList);
            }
            else
                RandomizePlacing(directions, player, ship);
        }
        else if (shipDirection == "Up")
        {
            if ((index / 10) + 1 >= (int)ship.Name)
            {
                List<int> tempIndexList = new List<int>();
                int count = 0;
                for (int i = index; i >= (((index / 10) - (int)ship.Name + 1) * 10) + (index % 10); i-=10)
                {
                    if (player.OccupiedGridCells.Contains(i))
                        RandomizePlacing(directions, player, ship);
                    else
                    {
                        var cell = player.Grid.ElementAt(i);
                        ship.ShipHoles.Add(cell.Key, ++count);
                        player.Grid[cell.Key] = true;
                        tempIndexList.Add(i);
                    }
                }
                player.OccupiedGridCells.AddRange(tempIndexList);
            }
            else
                RandomizePlacing(directions, player, ship);
        }
        else if (shipDirection == "Down")
        {
            if(10 - (index / 10) >= (int)ship.Name)
            {
                List<int> tempIndexList = new List<int>();
                int count = 0;
                for (int i = index; i <= (((index / 10) + (int)ship.Name - 1) * 10) + (index % 10); i += 10)
                {
                    if (player.OccupiedGridCells.Contains(i))
                        RandomizePlacing(directions, player, ship);
                    else
                    {
                        var cell = player.Grid.ElementAt(i);
                        ship.ShipHoles.Add(cell.Key, ++count);
                        player.Grid[cell.Key] = true;
                        tempIndexList.Add(i);
                    }
                }
                player.OccupiedGridCells.AddRange(tempIndexList);
            }
            else
                RandomizePlacing(directions, player, ship);
        }
        else
            RandomizePlacing(directions, player, ship);

    }

    public void SelectTargetCoordinate(Player player1, Player player2, string coordinate)
    {
        var isOpponentShip = player2.Grid[coordinate];
        if (isOpponentShip)
        {
            player2.Grid[coordinate] = false;
            player2.TotalRemainingHoles--;
            Console.WriteLine("It's a Hit");
        }
        else
            Console.WriteLine("It's a Miss");

    }

    public void DeclareWinner(Player player1, Player player2)
    {
        if (player1.TotalRemainingHoles == 0 )
        {
            DisplayGrid(player1);
            Console.WriteLine("Computer Wins");
        }  
        else if (player2.TotalRemainingHoles == 0 )
        {
            DisplayGrid(player2);
            Console.WriteLine("You Win");
        }
    }
}

