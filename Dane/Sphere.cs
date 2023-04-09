using System;

namespace Dane
{
    public class Sphere
    {
        private double x;
        private double y;
        private double radius;
        private double[] velocity = new double[2];
        private double mass;


        public Sphere(double x, double y, double radius, double mass)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.mass = mass;
        }

        public void randomizeSpeed()
        {
           
            Random random = new Random();
            velocity[0] = random.NextDouble();
            velocity[1] = random.NextDouble();

        }
    }
}