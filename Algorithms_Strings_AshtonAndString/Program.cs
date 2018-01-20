using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        //int t = Convert.ToInt32(Console.ReadLine());
        //for (int i = 0; i < t; i++)
        //{
        //    string s = Console.ReadLine();
        //    int k = Convert.ToInt32(Console.ReadLine());
        //    Solve(s, k);
        //}
        //Solve("dbac", 3);
        //string st = "dbacdbacdbacdbacdbacdbacdbac";
        //BruteSolve(st, 35);
        //Solve(st, 35);
        var z = Directory.GetCurrentDirectory();
        using (StreamReader reader = File.OpenText(@"test10.txt"))
        {
            int t = Convert.ToInt32(reader.ReadLine());
            for (int i = 0; i < t; i++)
            {
                string s = reader.ReadLine();
                int k = Convert.ToInt32(reader.ReadLine());
                BruteSolve(s, k);
            }
        }
    }

    static void BruteSolve(string s, int k)
    {
        long l = s.Length;
        long perm = (l / 2) * (1 + l);
        StringBuilder sb = new StringBuilder();
        List<string> sl = new List<string>();

        for (int i = 0; i < l;i++)
        {
            for (int j = 1; j <= l-i; j++)
            {
                var st = s.Substring(i, j);
                sl.Add(st);
            }
        }
        sl.Sort();
        foreach (string ss in sl)
        {
            sb.Append(ss);
        }
        //Console.WriteLine(sb);
        Console.WriteLine(sb[k - 1]);
    }


    static void Solve(string s, int k)
    {
        char[] arr = s.ToCharArray();
        char[] arrSorted = (char[])arr.Clone();
        Array.Sort(arrSorted);
        int l = arr.Length;
        StringBuilder sb = new StringBuilder((l/2)*(1+l));
        int perm;

        int i = 0;
        foreach (var a in arrSorted)
        {
            i = Array.FindIndex(arr, i, (obj) => obj == a);
            int n = l - i;
            perm = (n / 2) * (1 + n);

            if (k <= perm)
            {
                List<string> sl = new List<string>(perm);
                for (int j = 1; j <= n; j++)
                {
                    var st = s.Substring(i, j);
                    sl.Add(st);
                }
                sl.Sort();
                foreach(string ss in sl)
                {
                    sb.Append(ss);
                }
                Console.WriteLine(sb[k-1]);
                return;
            }
            k -= perm;

            i++;
        }

    }
}