namespace MyProgram
{
    partial class Program
    {
        class Healer: Hero
        {
            public Healer() : base()
            {
                this.Name = "NoName";
                this.special = Special.Лекарь;
                this.MaxHealth = 280;
                this.MinHealth = 100;
                this.TempDamage = 25;
            }

            public Healer(string name) : this()
            {
                this.Name = name;
            }

            protected override double WhatArmorBuff(bool HeadIsArmor, bool BodyIsArmor, bool ArmsIsArmor, bool LegsIsArmor)
            {
                uint WhatArmorBuff = 0;
                if (HeadIsArmor)
                    WhatArmorBuff += 10;
                if (BodyIsArmor)
                    WhatArmorBuff += 50;
                if (ArmsIsArmor)
                    WhatArmorBuff += 10;
                if (LegsIsArmor)
                    WhatArmorBuff += 20;
                return WhatArmorBuff;
            }

            public override void Ability()
            {
                System.Console.WriteLine("Лечение!");
                this.TempHealth = this.MaxHealth;
                System.Console.ReadKey();
            }
        }
    }
}