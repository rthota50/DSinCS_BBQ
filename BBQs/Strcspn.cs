using System;

public class Strcspn{
	public static void Test(){
		Strcspn s = new Strcspn();
		char[] a = {'f','c','b','a','7','3'};
		char[] b = {'1','2','3','4','5','6','7','8','9','0'};
		for(int i=0; i<a.Length; i++)
			Console.Write((int)a[i]+" ");
		Console.Write("\n");
		for(int i=0; i<b.Length; i++)
			Console.Write((int)b[i]+" ");		
	}
	
	public void Sort(char[] a){
		
	}
	public void QuickSort(char[] a, int lo, int hi){
		if(lo<=hi) return;
		int p = Partition(a, lo, hi);
		QuickSort(a,lo, p-1);
		QuickSort(a,p+1, hi);
	}
	public int Partition(char[] a, int lo, int hi){
		int p = lo;
		int i=lo+1, j=hi;
		while(i<j){
			while(a[i++]<a[p]){
				
			}
		}
		return p;
	}
}