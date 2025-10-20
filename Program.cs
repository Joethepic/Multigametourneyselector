using Multigame_Tournament_game_decider;
using System.Text.RegularExpressions;
StreamWriter writer = new StreamWriter("games.txt");
StreamReader readlist = new StreamReader("list.txt");
int gamestourney;
int gamesttl;
int game = 1;
string file;
bool done = false;
int curgame;
Random randomizer = new Random();
int index;
Console.WriteLine("Enter the number of games for this tourament");
gamestourney = Convert.ToInt32(Console.ReadLine());
file = readlist.ReadToEnd();
string[] arrgamesttl = file.Split('\n');
List<Game> games = new List<Game>();
string[] currentgame = {"", "", ""};
try
{
    foreach (string str in arrgamesttl)
    {
        currentgame = str.Split(",");
        if (currentgame[2] != "")
        {
            games.Add(new Game(currentgame[0], currentgame[1], Convert.ToInt32(currentgame[2])));
        }
        else
        {
            games.Add(new Game(currentgame[0], currentgame[1], 0));
        }
    }
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine(currentgame[0]);
    Console.WriteLine("It broke :(");
}

readlist.Close();
while (game <= gamestourney)
{
    curgame = randomizer.Next(0, games.Count - 1);
    writer.WriteLine(games[curgame].Name);
    string curgenre = games[curgame].Genre;
    foreach (Game s in games.ToList())
    {
        if (s.Genre == curgenre)
        {
            games.Remove(s);
        }
        else
        {

        }
    }
    
    // For if boss game is the last game
/*
 * if (game == gamestourney)
     {
        while (done != true) 
        {
            curgame = randomizer.Next(0, games.Count - 1);
            if (games[curgame].BossMode >= 1)
            {
                writer.WriteLine(games[curgame].Name);
                done = true;
            }
            else
            {

            }
        }
     }
*/
     game++;
}
writer.Close();
