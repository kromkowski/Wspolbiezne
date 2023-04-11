﻿using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logika
{
    public abstract class AbstractLogicAPI
    {
        public static AbstractLogicAPI CreateAPI(AbstractDataAPI abstractDataAPI = null)
        {
            return LogicAPI(abstractDataAPI);
        }
        public abstract void createPlane(int width, int height, int numberOfSpheres);
        public abstract List<SphereLogic> GetSphereLogics();
        public abstract void Stop();
        internal class LogicAPI : AbstractLogicAPI
        {
            private AbstractDataAPI dataAPI;
            private List<SphereLogic> SphereLogics = new List<SphereLogic>();
            bool enabled = false;
            public LogicAPI(AbstractDataAPI abstractDataAPI = null)
            {
                this.dataAPI = abstractDataAPI;
            }
            public List<SphereLogic> sphereLogics
            {
                get { return SphereLogics; }
                set { SphereLogics = value; }   
            }

            public bool Enabled { get => enabled; set => enabled = value; }
            public override void createPlane(int width, int height, int numberOfSpheres)
            {
                dataAPI.CreatePlane(width, height, numberOfSpheres);
                foreach (Dane.Sphere sphere in dataAPI.GetSpheres())
                {
                    this.SphereLogics.Add(new SphereLogic(sphere));
                }
                this.enabled = true;
                foreach (SphereLogic sphereLogic in this.SphereLogics)
                {
                    Task task = new Task(() =>
                    {
                        if (sphereLogic.X + sphereLogic.Xspeed >= (width - sphereLogic.Radius))
                        {
                            sphereLogic.Xspeed *= -1;
                        }
                        if (sphereLogic.Y + sphereLogic.Y >= (height - sphereLogic.Radius))
                        {
                            sphereLogic.Yspeed *= -1;
                        }
                        if (sphereLogic.X + sphereLogic.Xspeed <= 0)
                        {
                            sphereLogic.Xspeed *= -1;
                        }
                        if (sphereLogic.Y + sphereLogic.Yspeed <= 0)
                        {
                            sphereLogic.Yspeed *= -1;
                        }
                        sphereLogic.X += sphereLogic.Xspeed;
                        sphereLogic.Y += sphereLogic.Yspeed;
                        Thread.Sleep(20);
                    });
                    task.Start();
                }
            }
            public override void Stop()
            {
                this.enabled = false;
            }
            public override List<SphereLogic> GetSphereLogics()
            {
                return this.SphereLogics;
            }
        }
        
    }
}