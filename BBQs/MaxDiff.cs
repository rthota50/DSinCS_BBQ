using System;
public class MaxDiff{
	public MaxDiff(int[] a){
		this.a = a;			
	}
	public int Diff() { 
		int lo = 0, hi=1;
		for(int i=1; i<a.Length; i++){
			if(a[i]>a[hi])				hi = i;
			if(a[i]<a[lo] && i<=hi) lo = i;
		}
		return (lo == hi) ? -1 : a[hi] - a[lo];
	}
	private int[] a;
	public static void Test(){
		int[] a = new int[] {80, 2, 6, 3, 100};
		//  int[] a = new int[] {1,1,1,1,1,1,1,1};
		MaxDiff m = new MaxDiff(a);
		Console.Write(m.Diff());
	}
}