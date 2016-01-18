using System;
public class Freq{
	public int Leader(int[] a){
		int n = a.Length;
		Console.WriteLine("N "+n+" n/2 "+n/2);
		int l = a[n/2];
		int c =0 ;
		for(int i=0; i<n; i++)
			if(a[i]==l) c++;
		Console.WriteLine("count "+c);
		if(c>(n/2))
			return l;
		return -1;
	}
	public static  void Test(){
		int[] a = {1,3,3};
		Freq f = new Freq();
		Console.WriteLine(f.Leader(a));
	}
}