using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop
    {
        Player player = Player.GetInstance();
        static Items item = new Items();
        public static List<Items> items = new List<Items>();
        bool start = true;

        public void Itemlists()
        {
            
            if (start == true)
            {
                items.Add(new Items
                {
                    Id = 1,
                    Name = "수련자 갑옷",
                    Type = ItemType.Defense,
                    Stats = 5,
                    Description = "수련에 도움을 주는 갑옷입니다.",
                    Price = 500,
                    isHaving = false
                });

                items.Add(new Items
                {
                    Id = 2,
                    Name = "무쇠갑옷",
                    Type = ItemType.Defense,
                    Stats = 9,
                    Description = "무쇠로 만들어져 튼튼한 갑옷입니다.",
                    Price = 1000,
                    isHaving = false
                });

                items.Add(new Items
                {
                    Id = 3,
                    Name = "스파르타의 갑옷",
                    Type = ItemType.Defense,
                    Stats = 15,
                    Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                    Price = 1000,
                    isHaving = false
                });

                items.Add(new Items
                {
                    Id = 4,
                    Name = "낡은 검",
                    Type = ItemType.Attack,
                    Stats = 2,
                    Description = "쉽게 볼 수 있는 낡은 검 입니다.",
                    Price = 1000,
                    isHaving = false
                });

                items.Add(new Items
                {
                    Id = 5,
                    Name = "청동 도끼",
                    Type = ItemType.Attack,
                    Stats = 5,
                    Description = "어디선가 사용됐던거 같은 도끼입니다.",
                    Price = 1000,
                    isHaving = false
                });

                items.Add(new Items
                {
                    Id = 6,
                    Name = "스파르타의 창",
                    Type = ItemType.Attack,
                    Stats = 7,
                    Description = "스파르타의 전사들이 사용했다는 전설의 창입니다.",
                    Price = 1000,
                    isHaving = false
                });
            }

            start = false;

            Console.Clear();
            Console.WriteLine("[상점]" +
                "\n\n필요한 아이템을 얻을 수 있는 상점입니다." +
                $"\n\n보유 골드: {player.gold}\n");

            ShowLists();
            Thread.Sleep(1000);

            Console.WriteLine("\n1. 아이템 구매\n2. 나가기");

            string input1 = Console.ReadLine();

            switch (input1)
            {
                case "1":
                    Buying();
                    break;

                case "2":
                    Console.Clear();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("올바른 값을 입력해주세요!");
                    break;
            }
        }
        public void ShowLists()
        {
            foreach (Items item in items)
            {
                string statInfo = "";
                string havingInfo = "";
                string equipInfo = item.isEquipped ? "[E]" : "";

                if (item.Type == ItemType.Attack && item.Stats.HasValue)
                {
                    statInfo = $"공격력: {item.Stats}";
                }
                else if (item.Type == ItemType.Defense && item.Stats.HasValue)
                {
                    statInfo = $"방어력: {item.Stats}";
                }

                if (item.isHaving == false)
                {
                    havingInfo = $"{item.Price}";
                }
                else
                {
                    havingInfo = "보유중";
                }

                Console.WriteLine($"{item.Id}:{equipInfo}{item.Name}  |  {statInfo} | {item.Description} | {havingInfo}G");
            }
        }
        public void Buying()
        {


            Console.Clear();
            Console.WriteLine("[상점]" +
                "\n\n필요한 아이템을 얻을 수 있는 상점입니다." +
                $"\n\n보유 골드: {player.gold}\n");

            ShowLists();
            Thread.Sleep(1000);
            Console.WriteLine("\n구매할 상품의 번호를 눌러주세요.");
            string input2 = Console.ReadLine();
            
            foreach (var item in items)
            {
                if (int.TryParse(input2, out int itemId))
                {
                    string itemName = items.FirstOrDefault(item => item.Id == itemId)?.Name;
                    Items selectedItem = items.FirstOrDefault(item => item.Id == itemId);

                    Console.Clear();
                    ShowLists();
                    if (itemId >= 1 && itemId <= 6)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine($"\n선택한 아이템: {itemName}");

                        if (selectedItem.isHaving == false)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("\n1. 구매 \n2. 나가기");
                            string input3 = Console.ReadLine();
                            if (itemId >= 1 && itemId <= 6 && selectedItem != null)
                            {
                                if (player.gold >= selectedItem.Price)
                                {
                                    Console.Clear();
                                    player.gold -= selectedItem.Price;
                                    selectedItem.isHaving = true;
                                    Console.WriteLine($"{itemName}를 구매했습니다!");
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("보유한 골드가 부족합니다!");
                                    break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"이미 보유 중인 아이템입니다!");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("올바른 값을 입력해주세요!");
                        break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("올바른 값을 입력해주세요!");
                    break;
                }              
            }
        }
    }
}
