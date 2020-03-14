namespace MyProgram
{
    partial class Program
    {
        class Druid : Hero
        {
            public Druid() : base()
            {
                this.Name = "NoName";
                this.special = Special.Друид;
                this.MaxHealth = 300;
                this.MinHealth = 150;
                this.TempDamage = 25;
            }

            public Druid(string name) : this()
            {
                this.Name = name;
            }

            protected override double WhatArmorBuff(bool HeadIsArmor, bool BodyIsArmor, bool ArmsIsArmor, bool LegsIsArmor)
            {
                uint WhatArmorBuff = 0;
                if (HeadIsArmor)
                    WhatArmorBuff += 15;
                if (BodyIsArmor)
                    WhatArmorBuff += 60;
                if (ArmsIsArmor)
                    WhatArmorBuff += 10;
                if (LegsIsArmor)
                    WhatArmorBuff += 30;
                return WhatArmorBuff;
            }

            public override void DeBuff()
            {
                Bear bear = new Bear();
                bear.Show();
                base.DeBuff();
            }

            public override void Ability()
            {
                System.Console.WriteLine("Призван медведь!");
                this.IsBuff = true;
                System.Console.ReadKey();
            }

            private class Bear
            {
                public int Health;
                public int Damage;
                public Bear()
                {
                    Health = 100;
                    Damage = 50;
                }
                public void Show()
                {
                    System.Console.WriteLine($"=================================\n" +
                        "Медведь\n" +
                        $"Здоровье - {Health}\n" +
                        $"Урон - {Damage}\n" +
                        $"=================================\n");
                }
            }
        }
    }
}