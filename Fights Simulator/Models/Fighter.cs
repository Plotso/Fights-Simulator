﻿namespace Fights_Simulator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Fighter
    {
        public string Name { get; }
        private int age;
        private int height;
        private double weight;
        private double health;
        private double energy;
        private double speed;
        private double power;
        private double accuracy;
        private double deffence;
        private int discipline;
        private double intelligence;

        public Fighter(string name, int age, int height, double weight, double health, double energy, double speed, double power, double accuracy, double deffence, int discipline, double intelligence)
        {
            this.Name = name;
            this.age = age;
            this.height = height;
            this.weight = weight;
            this.health = health;
            this.energy = energy;
            this.speed = speed;
            this.power = power;
            this.accuracy = accuracy;
            this.deffence = deffence;
            this.discipline = discipline;
            this.intelligence = intelligence;
        }

        public int Age
        {
            get => age;
            set
            {
                if (this.age + value == 55)
                {
                    Retire();
                }
                this.age += value;
            }
        }

        public int Height
        {
            get => height;
            set => height = value;
        }

        public double Weight
        {
            get => weight;
            set => weight = value;
        }

        public double Health
        {
            get => health;
            set => health = value;
        }

        public double Energy
        {
            get => energy;
            set
            {
                //if (CheckPercentage(this.energy, value))
                //{
                //   throw new ArgumentException("Fighter has maximum energy!");
                //}
                this.energy += value;
            }
        }

        public double Speed
        {
            get => speed;
            set
            {
                if (CheckPercentage(this.speed,value))
                {
                  throw new ArgumentException("Figher has maximum speed!");
                }
                this.speed += value;
            }
        }

        public double Power
        {
            get => power;
            set
            {
                if (CheckPercentage(this.power, value))
                {
                    throw new ArgumentException("Figher has maximum power!");
                }
                this.power += value;
            }
        }

        public double Accuracy
        {
            get => accuracy;
            set
            {
                if (CheckPercentage(this.accuracy, value))
                {
                    throw new ArgumentException("Figher has maximum accuracy!");
                }
                this.accuracy += value;
            }
        }

        public double Deffence
        {
            get => deffence;
            set
            {
                if (CheckPercentage(this.deffence, value))
                {
                    throw new ArgumentException("Figher has maximum deffence!");
                }
                this.deffence += value;
            }
        }

        public int Discipline
        {
            get => discipline;
            set
            {
                if (value >= 0)
                {
                    if (this.discipline + value > 10)
                    {
                        throw new ArgumentException("Figher has maximum discipline!");
                    }
                }
                else
                {
                    if (this.discipline + value < 1)
                    {
                        throw new ArgumentException("Figher already has minimum discipline!");
                    }
                }
                this.discipline += value;
            }
        }

        public double Intelligence
        {
            get => intelligence;
            set => intelligence = value;
        }

        public double Overall()
        {
            var overall = GenerateOverall();

            if (energy < 75)
            {
                overall = overall - (overall * 10 / 100);
            }
            else if (energy < 50)
            {
                overall = overall - (overall * 25 / 100);
            }
            else if (energy < 25)
            {
                overall = overall - (overall * 50 / 100);
            }

            return Math.Round(overall,2);
        }

        private double GenerateOverall()
        {
            var overall = 0.0D;

            var speedImpact = speed * 1.75;
            var powerImpact = power * 1.5;
            var accuracyImpact = accuracy * 1.35;
            var deffenceImpact = deffence * 1.25;
            var disciplineImpact = discipline * 10;
            var intelligenceImpact = intelligence * 2;

            overall += speedImpact + powerImpact + accuracyImpact + deffenceImpact + disciplineImpact +
                       intelligenceImpact;
            overall /= 6;
            return overall;
        }

        public void Retire()
        {
            
        }


        public bool CheckPercentage(double currentValue, double aditional_value)
        {
            if (currentValue + aditional_value > 100)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return
                $"{this.Name} - {this.Age} years old with height {this.Height} and weights {this.Weight}. His discipline is rated as {this.Discipline} out of 10 and his intelligence is {this.Intelligence}%";
        }
    }
}
