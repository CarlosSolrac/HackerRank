
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;


namespace HackerRank
{
    class MainClass
    {
        struct Point {
            public int r;
            public int c;

            public Point(int y, int x)
            {
                r = y;
                c = x;
            }

        }

        static Point Next(int R, int C, Point p)
        {
            if (p.r == 0)
                if (p.c == 0)
                    p.r = 1;
                else
                    p.c--;
            else if (p.r == R)
                if (p.c == C)
                    p.r--;
                else
                    p.c++;
            else if (p.c == 0)
                if (p.r == R)
                    p.c++;
                else
                    p.r++;
            else if (p.c == C)
                if (p.r == 0)
                    p.c--;
                else
                    p.r--;

            return p;
        }

        static void PrintMatrix(int[][] matrix)
        {
            foreach (var r in matrix)
            {
                string s = "";
                foreach (int c in r)
                {
                    Console.Write("{0}{1}", s, c);
                    if (string.IsNullOrEmpty(s))
                    {
                        s = " ";
                    }
                }
                Console.WriteLine();
            }
        }

        static int[][] old = null;

        static void matrixRotation(int[][] matrix)
        {
            Point pC, pN, pO;

            if (old == null)
            {
                old = new int[matrix.Length][];
                for (int i = 0; i < matrix.Length; i++)
                {
                    old[i] = (int[])matrix[i].Clone();
                }
            }
            else
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i].CopyTo(old[i], 0);
                }
            }

            int maxR = matrix.Length - 1;
            int maxC = matrix[0].Length - 1;

            pO = new Point(0, 0);
            do
            {
                pC = new Point(0, 0);
                do
                {
                    pN = Next(maxR, maxC, pC);

                    matrix[pN.r + pO.r][pN.c + pO.c] = old[pC.r + pO.r][pC.c + pO.c];

                    pC = pN;
                }
                while (!(pN.r == 0 && pN.c == 0));

                pO.r++;
                pO.c++;

                maxR -= 2;
                maxC -= 2;
            } while (maxR > 0 && maxC > 0);
        }


        static void matrixRotation2(int[][] matrix, int rotations)
        {
            Point pC, pN, pO;

            if (old == null)
            {
                old = new int[matrix.Length][];
                for (int i = 0; i < matrix.Length; i++)
                {
                    old[i] = (int[])matrix[i].Clone();
                }
            }
            else
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i].CopyTo(old[i], 0);
                }
            }

            int maxR = matrix.Length - 1;
            int maxC = matrix[0].Length - 1;

            pO = new Point(0, 0);
            do
            {
                pC = new Point(0, 0);
                pN = pC;

                int oneFullRotation = (maxR + maxC + 2) * 2 - 4;
                int rots = rotations % oneFullRotation;

                for (int i = 0; i < rots; i++)
                {
                    pN = Next(maxR, maxC, pN);
                }

                for (int i = 0; i < oneFullRotation; i++)
                {
                    matrix[pN.r + pO.r][pN.c + pO.c] = old[pC.r + pO.r][pC.c + pO.c];

                    pC = Next(maxR, maxC, pC);
                    pN = Next(maxR, maxC, pN);
                }

                pO.r++;
                pO.c++;

                maxR -= 2;
                maxC -= 2;
            } while (maxR > 0 && maxC > 0);
        }

        public static bool ArraysEqual(int[][] m1, int[][] m2)
        {
            if (m1.Length != m2.Length)
                return false;
            
            for (int r = 0; r < m1.Length; r++)
            {
                if (m1[0].Length != m2[0].Length)
                    return false;
                
                for (int c = 0; c < m1[0].Length; c++)
                {
                    if (m1[r][c] != m2[r][c])
                        return false;
                }
            }

            return true;
        }

        public static void Main(string[] args)
        {
            int m;
            int n;
            int r;
            int[][] matrix;
            int[][] matrix2;
            int[][] answer;

            using (StreamReader reader = File.OpenText(@"../../test01.txt"))
            {
                string[] tokens_m = reader.ReadLine().Split(' ');
                m = Convert.ToInt32(tokens_m[0]);
                n = Convert.ToInt32(tokens_m[1]);
                r = Convert.ToInt32(tokens_m[2]);
                matrix = new int[m][];
                matrix2 = new int[m][];
                for (int matrix_i = 0; matrix_i < m; matrix_i++)
                {
                    string[] matrix_temp = reader.ReadLine().Split(' ');
                    matrix[matrix_i] = Array.ConvertAll(matrix_temp, Int32.Parse);
                    matrix2[matrix_i] = Array.ConvertAll(matrix_temp, Int32.Parse);
                }
            }

            using (StreamReader reader = File.OpenText(@"../../answer01.txt"))
            {
                answer = new int[m][];
                for (int matrix_i = 0; matrix_i < m; matrix_i++)
                {
                    string[] matrix_temp = reader.ReadLine().Split(' ');
                    answer[matrix_i] = Array.ConvertAll(matrix_temp, Int32.Parse);
                }
            }

            //for (int i = 0; i < r; i++)
            //{
            //    matrixRotation(matrix);
            //}
            matrixRotation2(matrix2, r);

            if (!ArraysEqual(matrix2, answer))
                return;
            //if (!ArraysEqual(matrix, answer))
            //    return;
            //if(!ArraysEqual(matrix, matrix2))
                //return;

            //PrintMatrix(matrix);
            //Console.WriteLine();
            //PrintMatrix(answer);

            //matrix[0][0] = 33333;
        }
    }
}
