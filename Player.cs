using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    internal class Player
    {
        Items item = new Items();
        Random rand = new Random();
        public string name;

        public int level = 1;
        public int str = 10;
        public int def = 5;
        public int health = 100;
        public int gold = 0;
        string job = "모험가";


        private static Player instance;
        private Player() { }
        public static Player GetInstance()
        {
            if (instance == null)
            {
                instance = new Player();
            }
            return instance;
        }
        public void PlayerStats()
        {
            Console.Clear();
            Console.WriteLine("=============================" +
                $"\nLv: {level}" +
                $"\n직업: {job}" +
                $"\n공격력: {str}" +
                $"\n방어력: {def}" +
                $"\n체력: {health}" +
                $"\n보유 골드: {gold}" +
                $"\n=============================");
            Thread.Sleep(1000);
        }
        
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0) health = 0;
        }

        public void Attack(Enemy enemy)
        {
            int AttackPower = rand.Next(-3, 4) + str;

            Console.WriteLine($"{name}가 {enemy.Name}을 공격합니다! {AttackPower}의 피해를 입혔습니다.");
            enemy.TakeDamage(AttackPower);
        }
        public void SkillAttack(Enemy enemy)
        {
            float skill = rand.Next(3, 6) * (str / 2);
            int SkillPower = (int)skill;
            health -= 10;

            Console.WriteLine($"{name}가 체력 10을 소모하여 {enemy.Name}을 공격합니다! {SkillPower}의 피해를 입혔습니다.");
            enemy.TakeDamage(SkillPower);
        }
    }
}
