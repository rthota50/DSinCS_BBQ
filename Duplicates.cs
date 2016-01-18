using System;
using System.Collections.Generic;

public class Duplicates
{
<<<<<<< HEAD
	public List<int> FindDups(int[] a)
	{
		Array.Sort(a);
		var dups = new List<int>();
		int prev = a[0];
		bool skip = false;
		for(int i=1, k=0; i < a.Length ; i++)
		{
			if(prev == a[i])
			{
				if(!skip)
				{
					dups.Add( a[i]);
					skip = true;
				}			
			}
			else
			{
				skip = false;
				prev = a[i];
			}
		}
		return dups;
	}
	
	public static void Test()
	{
		int[] a = {2,3,4,5,6,6,3,3,4};
		Duplicates ds = new Duplicates();
		var res = ds.FindDups(a);
		//Console.Write(res.Length);
		foreach (var e in res)
		{
			Console.Write(e+" ");
		}
	}
=======
    public int[] FindTotalDups(int[] a)
    {
        Array.Sort(a);
        int[] dups = new int[a.Length];
        int prev = a[0];
        bool skip = false;
        for (int i = 1, k = 0; i < a.Length; i++)
        {
            if (prev == a[i])
            {
                if (!skip)
                {
                    dups[k++] = prev;
                    skip = true;
                }
            }
            else
            {
                skip = false;
                prev = a[i];
            }
        }
        return dups;
    }

    public static void Test()
    {
		int[] a = {4,5,6,2,2,6,2,5,7,3,7,3,8,8};
		Duplicates ds = new Duplicates();
		var dups = ds.FindTotalDups(a);
		foreach(var e in dups)
		{
			Console.Write(e + " ");
		}
    }
>>>>>>> saving before merge
}