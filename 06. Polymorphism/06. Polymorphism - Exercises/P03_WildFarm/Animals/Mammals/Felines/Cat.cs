﻿namespace P03_WildFarm.Animals.Mammals.Felines
{
    using System;
    using Foods;

    public class Cat : Feline
    {
        private const double WEIGHT_INCREASE_FOR_PIECE_OF_FOOD = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void EatFood(Food inputFood)
        {
            var foodType = inputFood.GetType().Name;

            if (foodType == "Vegetable" || foodType == "Meat")
            {
                var weightIncrease = inputFood.Quantity * WEIGHT_INCREASE_FOR_PIECE_OF_FOOD;
                this.Weight += weightIncrease;
                this.FoodEaten += inputFood.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {inputFood.GetType().Name}!");
            }
        }

        public override string ProducingSound()
        {
            return $"Meow";
        }
    }
}