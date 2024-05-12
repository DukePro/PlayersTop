using static System.Console;

namespace PlayersTop
{
    class Programm
    {
        static void Main()
        {
            Menu menu = new Menu();
            menu.Run();
        }
    }

    class Menu
    {
        private const string ShowAllCommand = "1";
        private const string LevelSortCommand = "2";
        private const string PowerSortCommand = "3";
        private const string Exit = "0";

        public void Run()
        {
            string userInput;
            bool isExit = false;

            Database database = new Database();
            database.CreatePlayers();

            while (isExit == false)
            {
                WriteLine();
                WriteLine(ShowAllCommand + " - Показать всех");
                WriteLine(LevelSortCommand + " - Топ 3 игроков по уровню");
                WriteLine(PowerSortCommand + " - Топ 3 игроков по силе");
                WriteLine(Exit + " - Выход\n");

                userInput = ReadLine();

                switch (userInput)
                {
                    case ShowAllCommand:
                        database.ShowPlayers();
                        break;

                    case LevelSortCommand:
                        database.ShowTop3Level();
                        break;

                    case PowerSortCommand:
                        database.ShowTop3Power();
                        break;

                    case Exit:
                        isExit = true;
                        break;
                }
            }
        }
    }

    class Player
    {
        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }
    }

    class Database
    {
        private int _ammountOfRecords = 20;
        private List<Player> _players = new List<Player>();

        public void ShowPlayers(List<Player>? players = null)
        {
            if (players == null)
            {
                players = _players;
            }

            foreach (var player in players)
            {
                WriteLine($"{player.Name}, Уровень {player.Level}, Сила {player.Power}");
            }
        }

        public void ShowTop3Level()
        {
            WriteLine("Топ игроков по уровню");

            var playersByLevel = _players.OrderByDescending(player => player.Level).Take(3).ToList();

            ShowPlayers(playersByLevel);
        }

        public void ShowTop3Power()
        {
            WriteLine("Топ игроков по силе");

            var playersByPower = _players.OrderByDescending(player => player.Power ).Take(3).ToList();

            ShowPlayers(playersByPower);
        }

        public void CreatePlayers()
        {
            for (int i = 0; i < _ammountOfRecords; i++)
            {
                _players.Add(new Player(GetName(), GetLevel(), GetPower()));
            }
        }

        private string GetName()
        {
            string[] PlayerNames =
            [
        "Толя Руль",
        "Вася Шнырь",
        "Петруха Кабан",
        "Гриша Гопник",
        "Дима Толкач",
        "Санек Бульба",
        "Женя Лапоть",
        "Коля Барсук",
        "Леша Халтурка",
        "Сергей Косой",
        "Миша Череп",
        "Олег Огурец",
        "Игорь Чебурек",
        "Витя Колотушка",
        "Юра Мясник",
        "Андрей Бычок",
        "Макс Карась",
        "Павел Колесо",
        "Саша Котлета",
        "Кирилл Бутерброд",
        "Артем Брызгало",
        "Денис Крошка",
        "Никита Пельмень",
        "Стас Пельменище",
        "Ольга Гречка",
        "Елена Блинная",
        "Таня Лапша",
        "Алиса Пирожок",
        "Вика Щи",
        "Яна Афёра",
        "Витя Застрелю",
        "Паша Кабриолет",
        "Коля Чмырь",
        "Миша Мафиозник"
            ];

            string name = PlayerNames[Utils.GetRandomNumber(PlayerNames.Length - 1)];
            return name;
        }

        private int GetLevel()
        {
            int minLevel = 1;
            int maxLevel = 80;

            return Utils.GetRandomNumber(minLevel, maxLevel);
        }

        private int GetPower()
        {
            int minPower = 5;
            int maxPower = 100;

            return Utils.GetRandomNumber(minPower, maxPower);
        }
    }

    class Utils
    {
        private static Random s_random = new Random();

        public static int GetRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }

        public static int GetRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }
    }
}

//У нас есть список всех игроков(минимум 10). У каждого игрока есть поля: имя, уровень, сила.
//Требуется написать запрос для определения топ 3 игроков по уровню и топ 3 игроков по силе, после чего вывести каждый топ.
//2 запроса получится. 
