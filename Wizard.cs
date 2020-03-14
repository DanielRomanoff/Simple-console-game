namespace MyProgram
{
    partial class Program
    {
        class Wizard : Hero
        {
            public Wizard() : base()
            {
                this.Name = "NoName";
                this.special = Special.Маг;
                this.MaxHealth = 200;
                this.MinHealth = 70;
                this.TempDamage = 33;
            }

            protected override double WhatArmorBuff(bool HeadIsArmor, bool BodyIsArmor, bool ArmsIsArmor, bool LegsIsArmor)
            {
                uint WhatArmorBuff = 0;
                if (HeadIsArmor)
                    WhatArmorBuff += 15;
                if (BodyIsArmor)
                    WhatArmorBuff += 50;
                if (ArmsIsArmor)
                    WhatArmorBuff += 10;
                if (LegsIsArmor)
                    WhatArmorBuff += 20;
                return WhatArmorBuff;
            }

            public Wizard(string name) : this()
            {
                this.Name = name;
            }

            public override void DeBuff()
            {
                base.DeBuff();
                SwapHealthDamage();
            }

            public void SwapHealthDamage()
            {
                (TempDamage, TempHealth) = (TempHealth, TempDamage);
            }

            public override void Ability()
            {
                System.Console.WriteLine("Использует заклинание! Меняет местами урон и здоровье на 1 ход");
                SwapHealthDamage();
                this.IsBuff = true;
                System.Console.ReadKey();
            }

        }
    }
}