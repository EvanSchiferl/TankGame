﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Plane
    {
        Vector3 N;
        float d;

        public Plane()
        {

        }

        public Plane(float x, float y, float d)
        {
            this.N = new Vector3(x, y, 0);
            this.d = d;
        }

        public Plane(Vector3 n, float d)
        {
            this.N = n;
            this.d = d;
        }

        public Plane (Vector3 p1, Vector3 p2)
        {
            //calculate normalised Vector from p0 to p1
            Vector3 v = p2 - p1;
            v.Normalize();

            //set normal perpendicular to the vector
            N.x = -v.y;
            N.y = v.x;

            //calculate d
            d = -p1.Dot(N);
        }
    }
}
