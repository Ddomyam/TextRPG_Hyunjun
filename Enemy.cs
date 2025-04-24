using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG
{
    internal class Enemy
    {
        Random rand = new Random();
        public int str = 10;
        public string Name { get; set; }
        public int health { get; set; }
        public int AttackPower { get; set; }

        public Enemy(string name, int hp, int attackPower)
        {
            Name = name;
            health = hp;
            AttackPower = attackPower;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0) health = 0;
        }

        public void Attack(Player player)
        {

            int AttackPower = str - (player.def / 2) * (rand.Next(1, 3));

            if (AttackPower >= 0)
            {
                Console.WriteLine($"\n{Name}가 {player.name}을(를) 공격합니다! {AttackPower}의 피해를 입혔습니다.");
                player.TakeDamage(AttackPower);
            }
            else
            {
                Console.WriteLine("적의 공격을 방어했습니다!");
            }

        }
    }
}
