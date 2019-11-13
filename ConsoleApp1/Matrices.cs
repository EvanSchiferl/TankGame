using System;
using System.Collections.Generic;
using System.Text;
using Raylib;

namespace ConsoleApp1
{
   public class Matrix3
    {
        
        
       
            public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

            public static Matrix3 identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);

            public Matrix3()
            {
                m1 = 1; m2 = 0; m3 = 0;
                m4 = 0; m5 = 1; m6 = 0;
                m7 = 0; m8 = 0; m9 = 1;
            }
            public Matrix3(float _m1,float _m2,float _m3,float _m4, float _m5, float _m6, float _m7, float _m8, float _m9)
            {
                m1 = _m1;
                m2 = _m2;
                m3 = _m3;
                m4 = _m4;
                m5 = _m5;
                m6 = _m6;
                m7 = _m7;
                m8 = _m8;
                m9 = _m9;


            }

            public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
            {
                return new Matrix3
                    (
                    //Top Row
                    lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,
                    lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3,
                    lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,

                    //Middle Row
                    lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6,
                    lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6,
                    lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6,

                     //Bottom Row
                    lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9,
                    lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9,
                    lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9
                    ); 
                             
            }

            public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
            {
                return new Vector3((lhs.m1 * rhs.x) + (lhs.m4 * rhs.y) + (lhs.m7 * rhs.z), (lhs.m2 * rhs.x) + (lhs.m5 * rhs.y) + (lhs.m8 * rhs.z), (lhs.m3 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m9 * rhs.z));
            }

            Matrix3 GetTransposed()
            {
                return new Matrix3
                    (
                    m1, m4, m7,
                    m2, m5, m8,
                    m3, m6, m9
                    );
            }
        }
        
    }

