using System;
public class Pit{
	public int FindPit(int[] a){
		int n = a.Length;
		int p=0,q=-1,r=-1, maxd = int.MinValue;
		int i=1;
		while(i<n){
			while(i<n && a[i]<a[i-1]) 
				q = i++;
			while(p<q && i<n && a[i]>a[i-1])
				r = i++;
			if(p != -1 && q != -1 && p<q && q<r){
				maxd = Math.Max(maxd, Math.Min(a[p]-a[q],a[r]-a[q]));
				p = r;
				q = r = -1;
			} else i++;
		}
		
		if(maxd != int.MinValue) return maxd;
		return -1;
	}
	public static void Test(){
		int[] a = {0, 1, 3, -2, 0, 1, 0, -3, 2, 3 };
		Pit p = new Pit();
		Console.WriteLine(p.FindPit(a));
	}
}