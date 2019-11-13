using System;
using System.Collections.Generic;
using System.Text;
using Raylib;


namespace ConsoleApp1
{
    class AABB
    {
        public Vector3 min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

        public Vector3 max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        public bool IsEmpty()
        {
            if (float.IsNegativeInfinity(min.x) &&
                float.IsNegativeInfinity(min.y) &&
                float.IsNegativeInfinity(min.z) &&
                float.IsInfinity(max.x) &&
                float.IsInfinity(max.y) &&
                float.IsInfinity(max.z))
                return true;
            return false;
        }

        public void Fit(List<Vector3> points)
        {
            Vector3 min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

            Vector3 max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        }

        public AABB()
        {

        }

        public AABB(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }

        public Vector3 Center()
        {
            return (min + max) * 0.5f;
        }

        public List<Vector3> Corners()
        {
            //ignoring z axis for 2D
            List<Vector3> corners = new List<Vector3>(4);
            corners[0] = min;
            corners[1] = new Vector3(min.x, max.y, min.z);
            corners[2] = max;
            corners[3] = new Vector3(max.x, min.y, min.z);
            return corners;

        }

        public Vector3 Extents()
        {
            return new Vector3(Math.Abs(max.x - min.x) * 0.5f, Math.Abs(max.y - min.y) * 0.5f, Math.Abs(max.z - min.z) * 0.5f);
        }

        void SetToTransformedBox(AABB box, Matrix3 m)
        {
            if (box.IsEmpty())
            {
                IsEmpty();
                return;
            }

            if (m.m1 > 0.0f)
            {
                min.x += m.m1 * box.min.x; max.x += m.m1 * box.max.x;
            }
            else
            {
                min.x += m.m1 * box.max.x; max.x += m.m1 * box.min.x;
            }

            if(m.m2 > 0.0f)
            {
                min.y += m.m2 * box.min.x; max.y += m.m2 * box.max.x;
            }
            else
            {
                min.y += m.m2 + box.max.x; max.y += m.m2 * box.min.x;
            }

            if (m.m3 > 0.0f)
            {
                min.z += m.m3 * box.min.x; max.z += m.m3 * box.max.x;
            }
            else
            {
                min.z += m.m3 * box.max.x; max.z += m.m3 * box.min.x;
            }
            //may be incorrect below this line
            if(m.m4 > 0.0f)
            {
                min.x += m.m4 * box.min.x; max.x += m.m4 * box.max.x;
            }
            else
            {
                min.x += m.m4 * box.max.x; max.x += m.m4 * box.min.x;
            }

            if (m.m5 > 0.0f)
            {
                min.y += m.m5 * box.min.x; max.y += m.m5 * box.max.x;
            }
            else
            {
                min.y += m.m5 + box.max.x; max.y += m.m5 * box.min.x;
            }

            if (m.m6 > 0.0f)
            {
                min.z += m.m6 * box.min.x; max.z += m.m6 * box.max.x;
            }
            else
            {
                min.z += m.m6 * box.max.x; max.z += m.m6 * box.min.x;
            }

            if (m.m7 > 0.0f)
            {
                min.x += m.m7 * box.min.x; max.x += m.m7 * box.max.x;
            }
            else
            {
                min.x += m.m7 * box.max.x; max.x += m.m7 * box.min.x;
            }

            if (m.m8 > 0.0f)
            {
                min.y += m.m8 * box.min.x; max.y += m.m8 * box.max.x;
            }
            else
            {
                min.y += m.m8 + box.max.x; max.y += m.m8 * box.min.x;
            }

            if (m.m9 > 0.0f)
            {
                min.z += m.m9 * box.min.x; max.z += m.m9 * box.max.x;
            }
            else
            {
                min.z += m.m9 * box.max.x; max.z += m.m9 * box.min.x;
            }


        }


    }

}
