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
int iteration = 1;
Console.WriteLine("Enter the number of games for this tourament");
gamestourney = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Write how boss mode should be handled. 1 for no boss mode. 2 for boss mode as the last game");
int bossmode = Convert.ToInt32(Console.ReadLine());
file = readlist.ReadToEnd();
string[] arrgamesttl = file.Split('\n');
List<Game> games = new List<Game>();
string[] currentgame = {};
int roller;
string curgenre;
try
{
    foreach (string str in arrgamesttl)
    {
        currentgame = str.Split(",");
        games.Add(new Game(currentgame[0], currentgame[1], Convert.ToInt32(currentgame[2]), Convert.ToInt32(currentgame[3])));
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
    if (bossmode == 1)
    {
        curgame = randomizer.Next(0, games.Count - 1);
        roller = randomizer.Next(0, games[curgame].timesPlayed * 2);
        if (roller == 0)
        {
            writer.WriteLine(games[curgame].Name);
            curgenre = games[curgame].Genre;
            game++;
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
        }
        else
        {
            games.RemoveAt(curgame);
        }
    }
    if (bossmode == 2)
    {
        for (iteration = 1; iteration < gamestourney;)
        {
            curgame = randomizer.Next(0, games.Count - 1);
            roller = randomizer.Next(0, games[curgame].timesPlayed * 2);
            if (games[curgame].BossMode != 1)
            {
                if (roller == 0)
                {
                    writer.WriteLine(games[curgame].Name);
                    curgenre = games[curgame].Genre;
                    iteration++;
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
                }
                else
                {
                    games.RemoveAt(curgame);
                }
            }
            else
            {

            }
        }
        game = iteration;
        if (game == gamestourney)
        {
            while (done != true)
            {
                curgame = randomizer.Next(0, games.Count - 1);
                if (games[curgame].BossMode >= 1)
                {
                    writer.WriteLine(games[curgame].Name);
                    done = true;
                    game++;
                }
                else
                {

                }
            }
        }
    }
}
writer.Close();