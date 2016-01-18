using System;
public class ArrayAddition
{
    public int[] Sum(int[] A, int[] B)
    {
        int[] res;
        int m = Math.Max(A.Length, B.Length);
        int a = A.Length, b = B.Length;
        if(a==b && A[0]+B[0]==9) m++;
        else { 
            var L = (a>b)?A:B;
            if(L[0] == 9) m++;
        }
        res = new int[m];
        int d = res.Length;
        int c = 0; //carry
        for (int i = a - 1, j = b - 1, k = d-1; k>=0;k--)
        {
            int s = (i < 0 ? 0 : A[i--]) + (j < 0 ? 0 : B[j--]) + c;
            if (s > 9)
            {
                res[k] = s - 10; c = 1;
            }
            else
            {
                res[k] = s; c = 0;
            }
        }
        return res;
    }
    public static void Test()
    {
        int[] a = { 9, 9, 9 };
        int[] b = { 9, 9 };
        var aa = new ArrayAddition();
        var s = aa.Sum(a, b);
        for (int i = 0; i < s.Length; i++)
            Console.Write(s[i]);
    }
}