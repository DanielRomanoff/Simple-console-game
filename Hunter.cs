namespace MyProgram
{
    partial class Program
    {
        class Hunter : Hero
        {
            public Hunter() : base()
            {
                this.Name = "NoName";
                this.special = Special.Охотник;
                this.MaxHealth = 240;
                this.MinHealth = 130;
                this.TempDamage = 20;
            }

            public Hunter(string name) : this()
            {
                this.Name = name;
            }

            protected override double WhatArmorBuff(bool HeadIsArmor, bool BodyIsArmor, bool ArmsIsArmor, bool LegsIsArmor)
            {
                uint WhatArmorBuff = 0;
                if (HeadIsArmor)
                    WhatArmorBuff += 20;
                if (BodyIsArmor)
                    WhatArmorBuff += 80;
                if (ArmsIsArmor)
                    WhatArmorBuff += 10;
                if (LegsIsArmor)
                    WhatArmorBuff += 30;
                return WhatArmorBuff;
            }

            public override void DeBuff()
            {
                base.DeBuff();
                this.TempDamage -= 100;
            }
            public override void Ability()
            {
                System.Console.WriteLine("Выстрел из лука! +100 к урону на следующий ход");
                this.TempDamage += 100;
                this.IsBuff = true;
                System.Console.ReadKey();
            }

        }
    }
}