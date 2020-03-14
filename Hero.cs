using System;

namespace MyProgram
{
    partial class Program
    {
        class Hero
        {
            public Hero(string name, Hero.Special special, int Health, Hero.State state)
            {
                this.Name = name;
                this.special = special;
                this.MaxHealth = Health;
                this.TempHealth = MaxHealth;
                this.state = state;
            }

            public Hero()
            {
                this.Name = "NoName";
                this.Level = 1;
                this.MaxHealth = 100;
                this.TempHealth = MaxHealth;
                this.MaxHealth = 100;
                this.MinHealth = 100;
                this.HeroDamage = 20;
                this.state = State.Live;
            }

            protected string Name;
            protected double Level = 1;
            protected State state;
            protected Special special;
            protected double TempHealth;
            protected double TempArmor;
            protected double HeroDamage;
            protected double TempDamage;
            protected double MaxHealth;
            protected uint MinHealth;
            protected bool IsBuff;
            protected bool IsArmor;
            protected bool HeadIsArmor;
            protected bool BodyIsArmor;
            protected bool ArmsIsArmor;
            protected bool LegsIsArmor;

            public enum State
            {
                Live,
                Dead,
                Bashed
            }

            public enum Special
            {
                Маг,
                Воин,
                Друид,
                Охотник,
                Лекарь
            }

            public void Show()
            {
                Console.Write($"=================================\n"+
                    $"Имя - {Name} \n" +
                    $"Уровень - {Level}\n" +
                    $"Класс - {special}\n" +
                    $"Состояние - {state}\n" +
                    $"Здоровье - {TempHealth}\n" +
                    $"Урон - {TempDamage}\n" +
                    $"Броня - {TempArmor} ");
                if (IsArmor)
                {
                    if (IsArmor)
                        Console.Write("(");
                    if (HeadIsArmor)
                        Console.Write("Голова ");
                    if (BodyIsArmor)
                        Console.Write("Тело ");
                    if (ArmsIsArmor)
                        Console.Write("Руки ");
                    if (LegsIsArmor)
                        Console.Write("Ноги");
                    if (IsArmor)
                        Console.Write(")");
                }
                Console.WriteLine($"\n=================================");
            }

            public void KillAlive()
            {
                if (state == State.Live)
                {
                    state = State.Dead;
                    TempHealth = 0;
                }
                else if (state == State.Dead)
                {
                    state = State.Live;
                    TempHealth = MaxHealth;
                }
            }

            protected virtual double WhatArmorBuff(bool HeadIsArmor, bool BodyIsArmor, bool ArmsIsArmor, bool LegsIsArmor)
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

            public void EquipArmor()
            {
                Console.WriteLine(
                    "1. Голова\n" +
                    "2. Торс\n" +
                    "3. Руки\n" +
                    "4. Ноги\n" +
                    "5. Надеть всю экипировку\n" +
                    "6. Снять всю экипировку\n");
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            IsArmor = true;
                            HeadIsArmor = true;
                            break;
                        case 2:
                            IsArmor = true;
                            BodyIsArmor = true;
                            break;
                        case 3:
                            IsArmor = true;
                            ArmsIsArmor = true;
                            break;
                        case 4:
                            IsArmor = true;
                            LegsIsArmor = true;
                            break;
                        case 5:
                            IsArmor = true;
                            HeadIsArmor = true;
                            BodyIsArmor = true;
                            ArmsIsArmor = true;
                            LegsIsArmor = true;
                            break;
                        case 6:
                            IsArmor = false;
                            HeadIsArmor = false;
                            BodyIsArmor = false;
                            ArmsIsArmor = false;
                            LegsIsArmor = false;
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {

                }
                TempArmor = WhatArmorBuff(HeadIsArmor, BodyIsArmor, ArmsIsArmor, LegsIsArmor);
            }

            public static Hero operator -(Hero hero, uint damage)
            {
                if (hero.TempArmor > 0)
                {
                    if (damage >= hero.TempArmor)
                    {
                        damage -= Convert.ToUInt32(hero.TempArmor);
                        hero.TempArmor = 0;
                        hero.IsArmor = false;
                    }
                    else
                    {
                        hero.TempArmor -= damage;
                        return hero;
                    }
                }
                if (hero.TempHealth > damage)
                {
                    hero.TempHealth -= damage;
                    return hero;
                }
                else
                {
                    hero.state = State.Dead;
                    hero.TempHealth = 0;
                    return hero;
                }
            }

            public static Hero operator ++(Hero hero)
            {
                if (hero.Level < 10)
                {
                    hero.Level++;
                    hero.MaxHealth += Math.Ceiling(hero.MaxHealth * 1/10);
                    hero.TempHealth = hero.MaxHealth;
                    hero.TempDamage += Math.Ceiling(hero.TempDamage * 1 / 10);
                }
                return hero;
            }

            public virtual void Ability()
            {

            }

            public static Hero operator --(Hero hero)
            {
                hero.Level = 1;
                hero.MaxHealth = hero.MinHealth;
                hero.TempHealth = hero.MaxHealth;
                hero.TempDamage = hero.HeroDamage;
                return hero;
            }

            public virtual void DeBuff()
            {
                if (this.IsBuff)
                    this.IsBuff = false;
            }

            public bool GetBuff() { return this.IsBuff; }
            public string Get_name() { return this.Name; }
            public double Get_level() { return this.Level; }
            public Special Get_special() { return this.special; }
            public State Get_state() { return this.state; }
            public double Get_Health() { return this.TempHealth; }
        }
    }
}