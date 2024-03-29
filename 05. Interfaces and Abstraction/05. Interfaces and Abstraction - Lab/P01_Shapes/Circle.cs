﻿using System;

public class Circle : IDrawable
{
    private int radius;

    public Circle(int radius)
    {
        this.Radius = radius;
    }

    public int Radius
    {
        get => this.radius;
        private set
        {
            Validator.ValidateInt(value, nameof(Radius));
            this.radius = value;
        }
    }

    public void Draw()
    {
        var rIn = this.Radius - 0.4;
        var rOut = this.Radius + 0.4;

        for (double y = this.Radius; y >= -this.Radius; y--)
        {
            for (double x = -this.Radius; x < rOut; x += 0.5)
            {
                var value = x * x + y * y;

                if (value >= rIn * rIn && value <= rOut * rOut)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}