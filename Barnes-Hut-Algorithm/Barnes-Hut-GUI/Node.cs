﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Barnes_Hut_GUI
{
    class Node
    {
        public enum parentQuadrant
        {
            SE, NE, SW, NW
        }

        public List<Particle> nodeParticles { get; set; }
        public Point BottomLeftCorner { get; set; }
        public Point TopRightCorner { get; set; }
        public double TotalMass { get; set; }
        public Point CenterOfMass { get; set; }

        public double SideLength { get; }

        public Node SeChild { get; set; }
        public Node NeChild { get; set; }
        public Node NwChild { get; set; }
        public Node SwChild { get; set; }

        public bool IsLeaf { get; set; }
        public bool IsInternal { get; set; }
        public bool IsRoot { get; set; }

        public bool IsPartitioned { get; set; }

        public Point centerOfMass { get; set; }

        public double totalWeight = 0;

        public double topCenterOfMassCoefX = 0;
        public double topCenterOfMassCoefY = 0;

        public Node(Point trc, Point blc)
        {
            TopRightCorner = trc;
            BottomLeftCorner = blc;
            SideLength = TopRightCorner.X - BottomLeftCorner.X;
            nodeParticles = new List<Particle>();
            IsInternal = false;
        }


        //Function is called if there is more than 1 child in the node;
        void partitionNode()
        {
            double halfOfSideLength = SideLength / 2;
            Point SETopRight = new Point(TopRightCorner.X, (int)halfOfSideLength + TopRightCorner.Y);
            Point SEBottomLeft = new Point((int)halfOfSideLength + BottomLeftCorner.X, BottomLeftCorner.Y);
            SeChild = new Node(SETopRight, SEBottomLeft);

            Point NETopRight = new Point(TopRightCorner.X, TopRightCorner.Y);
            Point NEBottomLeft = new Point((int)halfOfSideLength + BottomLeftCorner.X, (int)halfOfSideLength + TopRightCorner.Y);
            NeChild = new Node(NETopRight, NEBottomLeft);

            Point NWTopRight = new Point((int)halfOfSideLength + BottomLeftCorner.X, TopRightCorner.Y);
            Point NWBottomLeft = new Point(BottomLeftCorner.X, (int)halfOfSideLength + TopRightCorner.Y);
            NwChild = new Node(NWTopRight, NWBottomLeft);

            Point SWTopRight = new Point((int)halfOfSideLength + BottomLeftCorner.X, (int)halfOfSideLength + TopRightCorner.Y);
            Point SWBottomLeft = new Point(BottomLeftCorner.X, BottomLeftCorner.Y);
            SwChild = new Node(SWTopRight, SWBottomLeft);
            parentQuadrant firstParticleQuadrant = determineQuadrant(nodeParticles[0]);
            AddParticleToChild(firstParticleQuadrant, nodeParticles[0]);

        }

        public void AddParticleToChild(parentQuadrant quadrant, Particle particle)
        {
            switch (quadrant)
            {
                case parentQuadrant.SE:
                    SeChild.AddParticle(particle);
                    break;
                case parentQuadrant.NE:
                    NeChild.AddParticle(particle);
                    break;
                case parentQuadrant.SW:
                    SwChild.AddParticle(particle);
                    break;
                case parentQuadrant.NW:
                    NwChild.AddParticle(particle);
                    break;
                default:
                    return;
            }
        }

        public void AddParticle(Particle particleToAdd)
        {
            nodeParticles.Add(particleToAdd);
            CalculateCenterOfMass(particleToAdd);

            if (nodeParticles.Count > 1 && !IsPartitioned)
            {
                partitionNode();
                IsInternal = true;
                IsLeaf = false;
                IsPartitioned = true;
            }
            else
            {
                //IsLeaf = true;
            }

            if (IsInternal && IsPartitioned)
            {
                parentQuadrant particleQuadrant = determineQuadrant(particleToAdd);
                AddParticleToChild(particleQuadrant, particleToAdd);
            }
        }

        public void CalculateCenterOfMass(Particle newPartice)
        {
            totalWeight += newPartice.Mass;
            topCenterOfMassCoefX += (newPartice.CenterPoint.X * newPartice.Mass);
            topCenterOfMassCoefX += (newPartice.CenterPoint.Y * newPartice.Mass);

            double xCOM = topCenterOfMassCoefX / totalWeight;
            double yCOM = topCenterOfMassCoefY / totalWeight;

            centerOfMass= new Point((int)xCOM, (int)yCOM);

        }

        parentQuadrant determineQuadrant(Particle particle)
        {
            parentQuadrant quadrant = parentQuadrant.SE;

            double halfOfSide = SideLength / 2;
            int xMiddle = BottomLeftCorner.X + (int)halfOfSide;
            int yMiddle = TopRightCorner.Y + (int) halfOfSide;

            if (particle.CenterPoint.X >= xMiddle)
            {
                //if (xMiddle - particle.CenterPoint.X <= 3)
                //{
                //    particle.CenterPoint = new Point(particle.CenterPoint.X + 3, particle.CenterPoint.Y);
                //}

                if (particle.CenterPoint.Y <= yMiddle)
                {
                    quadrant = parentQuadrant.NE;
                    //if (yMiddle - particle.CenterPoint.Y <= 3)
                    //{
                    //    particle.CenterPoint = new Point(particle.CenterPoint.X - 3, particle.CenterPoint.Y);
                    //}
                }

                if (particle.CenterPoint.Y > yMiddle)
                {
                    quadrant = parentQuadrant.SE;
                    //if (yMiddle - particle.CenterPoint.Y <= 3)
                    //{
                    //    particle.CenterPoint = new Point(particle.CenterPoint.X + 3, particle.CenterPoint.Y);
                    //}
                }

               
            }

            if (particle.CenterPoint.X < xMiddle)
            {
                //if (xMiddle - particle.CenterPoint.X <= 3)
                //{
                //    particle.CenterPoint = new Point(particle.CenterPoint.X - 3, particle.CenterPoint.Y);
                //}

                if (particle.CenterPoint.Y <= yMiddle)
                {
                    quadrant = parentQuadrant.NW;
                    //if (yMiddle - particle.CenterPoint.Y <= 3)
                    //{
                    //    particle.CenterPoint = new Point(particle.CenterPoint.X - 3, particle.CenterPoint.Y);
                    //}
                }

                if (particle.CenterPoint.Y > yMiddle)
                {
                    quadrant = parentQuadrant.SW;
                    //if (yMiddle - particle.CenterPoint.Y <= 3)
                    //{
                    //    particle.CenterPoint = new Point(particle.CenterPoint.X + 3, particle.CenterPoint.Y);
                    //}
                }
            }
            return quadrant;
        }

    }
}
