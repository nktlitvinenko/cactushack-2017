﻿using System;
using Newtonsoft.Json;

namespace HealthyFood.ViewModels
{
    public sealed class Profile
    {
        public Profile(
            int age,
            int weight,
            int height,
            PhysicalActivity physicalActivityType)
        {
            if (age <= 0)
                throw new ArgumentException($"{nameof(age)} can't be lass than 0");
            if (weight <= 0)
                throw new ArgumentException($"{nameof(weight)} can't be lass than 0");
            if (height <= 0)
                throw new ArgumentException($"{nameof(height)} can't be lass than 0");

            Age = age;
            Weight = weight;
            Height = height;
            PhysicalActivityType = physicalActivityType;
        }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; }

        [JsonProperty(PropertyName = "weight")]
        public int Weight { get; }

        [JsonProperty(PropertyName = "  ")]
        public int Height { get; }

        [JsonProperty(PropertyName = "physicalActivityType")]
        public PhysicalActivity PhysicalActivityType { get; }

        [JsonProperty(PropertyName = "dailyCalorieRate")]
        public double DailyCalorieRate 
            => 10 * Weight + 6.25 * Height - 5 * Age + 5 * GetPhysicalActivityRate(PhysicalActivityType);

        private double GetPhysicalActivityRate(PhysicalActivity activity)
        {
            switch (activity)
            {
                case PhysicalActivity.Low:
                    return 1.2;
                case PhysicalActivity.Small:
                    return 1.4;
                case PhysicalActivity.Average:
                    return 1.6;
                case PhysicalActivity.Tall:
                    return 1.7;
            }

            throw new ArgumentException($"{nameof(activity)} haven't found any type");
        }
    }
}
