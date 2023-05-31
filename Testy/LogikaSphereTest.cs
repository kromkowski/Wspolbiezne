﻿using Dane;
namespace Testy
{
    [TestClass]
    public class LogikaSphereTest
    {
        [TestMethod]
        public void constructorTest()
        {
            Sphere sphere = new Sphere(1, 2, 3);
            Assert.IsNotNull(sphere);
            Assert.AreEqual(sphere.Radius, 3);
            Assert.AreEqual(sphere.X, 1);
            Assert.AreEqual(sphere.Y, 2);
            sphere.X = 2;
            Assert.AreEqual(sphere.X, 2);
            sphere.Y = 3;
            Assert.AreEqual(sphere.Y, 3);
            sphere.Radius = 5;
            Assert.AreEqual(sphere.Radius, 5);
        }
        [TestMethod]
        public void speedTest()
        {
            Sphere sphere = new Sphere(1, 2, 3);
            sphere.Yspeed = 1;
            Assert.AreEqual(sphere.Yspeed, 1);
            sphere.Xspeed = 1;  
            Assert.AreEqual(sphere.Xspeed, 1);
        }
    }
}