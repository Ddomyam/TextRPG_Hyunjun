namespace TextRPG
{
    internal class StartScene
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Inventory inv = new Inventory();
            Player player = Player.GetInstance();
            Enemy enemy = new Enemy("괴물", 80, 10);
            Shop shop = new Shop();
            Game game = new Game(player, enemy);
            Console.WriteLine("이름을 설정해주세요: ");
            string inputName = Console.ReadLine();

            player.name = inputName;


            Console.Clear();
            Console.WriteLine($"{player.name}님, 스파르타 마을에 오신걸 환영합니다." +
                "\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            string message = "Hello, World!";
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(100); // 하나씩 출력
            }
            while (true)
            {
                player.health = 100;
                if(player.level <= 3)
                {
                    enemy.health = rand.Next(70, 120);
                    enemy.str = rand.Next(9, 12);
                }
                else if(player.level >= 4)
                {
                    enemy.health = rand.Next(130, 200);
                    enemy.str = rand.Next(20, 30);
                }
                Console.WriteLine("\n1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 전장으로..." +
                    "\n\n원하시는 행동을 입력해주세요.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        player.PlayerStats();
                        break;

                    case "2":
                        inv.Menu();
                        break;

                    case "3":
                        shop.Itemlists();
                        break;

                    case "4":
                        game.Start();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("올바른 값을 입력해주세요!");
                        break;
                }
            }
        }
    }
}