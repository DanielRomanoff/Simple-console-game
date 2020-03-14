namespace MyProgram
{
    partial class Program
    {
        class Warrior : Hero
        {
            public Warrior() : base()
            {
                this.Name = "NoName";
                this.special = Special.Воин;
                this.MaxHealth = 300;
                this.MinHealth = 150;
                this.TempDamage = 25;
            }

            protected override double WhatArmorBuff(bool HeadIsArmor, bool BodyIsArmor, bool ArmsIsArmor, bool LegsIsArmor)
            {
                uint WhatArmorBuff = 0;
                if (HeadIsArmor)
                    WhatArmorBuff += 25;
                if (BodyIsArmor)
                    WhatArmorBuff += 70;
                if (ArmsIsArmor)
                    WhatArmorBuff += 20;
                if (LegsIsArmor)
                    WhatArmorBuff += 40;
                return WhatArmorBuff;
            }

            public Warrior(string name) : this()
            {
                this.Name = name;
            }

            public override void DeBuff()
            {
                base.DeBuff();
                this.TempDamage -= 100;
            }

            public override void Ability()
            {
                System.Console.WriteLine("Удар щитом! +100 к урону на следующий ход");
                this.TempDamage += 100;
                this.IsBuff = true;
                System.Console.ReadKey();
            }

        }
    }
}