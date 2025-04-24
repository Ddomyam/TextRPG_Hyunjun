using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Inventory
    {
        public void Menu()
        {
           
            Console.Clear();
            Console.WriteLine("인벤토리" +
                "\n보유 중인 아이템을 관리할 수 있습니다.");

            ShowInventory();
            Thread.Sleep(1000);
            Console.WriteLine("\n\n장착하실 아이템의 번호를 눌러주세요. \n0.나가기");


            string input = Console.ReadLine();

            if (int.TryParse(input, out int itemId))
            {
                if (itemId == 0)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    return;
                }

                EquipItem(itemId); // 아이템 장착 실행
            }
            else
            {
                Console.Clear();
                Console.WriteLine("올바른 값을 입력해주세요.");
            }
            

            static void ShowInventory()
            {
                Console.WriteLine("▶ 내 인벤토리 ◀\n");

                foreach (Items item in Shop.items.Where(item => item.isHaving)) // 보유 중인 아이템만 출력
                {
                    string statInfo = "";
                    string equipInfo = item.isEquipped ? "[E]" : "";

                    if (item.Type == ItemType.Attack && item.Stats.HasValue)
                    {
                        statInfo = $"공격력: {item.Stats}";
                    }
                    else if (item.Type == ItemType.Defense && item.Stats.HasValue)
                    {
                        statInfo = $"방어력: {item.Stats}";
                    }

                    Console.WriteLine($"{item.Id}: {equipInfo}{item.Name} | {statInfo} | {item.Description}");
                }

            }

            static void EquipItem(int itemId)
            {
                // 해당 아이템 찾기
                Items itemToEquip = Shop.items.FirstOrDefault(item => item.Id == itemId && item.isHaving);

                if (itemToEquip != null && !itemToEquip.isEquipped)
                {
                    itemToEquip.isEquipped = true;  // 아이템 장착
                    ApplyStats(itemToEquip);
                    Console.Clear();
                    Console.WriteLine($"{itemToEquip.Name}을 장착했습니다.");
                }
                else if (itemToEquip != null && itemToEquip.isEquipped)
                {
                    Console.Clear();
                    Console.WriteLine($"{itemToEquip.Name}은 이미 장착되어 있습니다.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("해당 아이템을 찾을 수 없습니다.");
                }
            }
            static void ApplyStats(Items item)
            {
                Player player = Player.GetInstance();

                if (item.Type == ItemType.Attack && item.Stats.HasValue)
                    player.str += item.Stats.Value;
                else if (item.Type == ItemType.Defense && item.Stats.HasValue)
                    player.def += item.Stats.Value;
            }
        }
    }
}
