using System;
public class MergeArrays{
	public int[] Merge(int[] a, int[] b){
		Array.Sort(a); //m*log m
		Array.Sort(b); //n*log n
		int d = 0; //duplicates
		for(int i=1; i<a.Length; i++) // m
			if(a[i-1]==a[i]) d++;
		for(int i=1; i<b.Length; i++) // n
			if(b[i-1]==b[i]) d++;
		var r = new int[a.Length+b.Length-d];
		int p=0,prev;
		prev = a[0];
		r[p++]=a[0];
		for(int i=1; i<a.Length; i++){ // m
			if(a[i] != prev){
				r[p++] = a[i];
				prev = a[i];	
			}
		}
		r[p++] = prev = b[0];
		for(int i=1; i<b.Length; i++){ // n
			if(b[i] != prev){
				r[p++] = b[i];
				prev = b[i];
			}
		}
		return r;
	}
	public static void Test(){
		int[] a = {2,4,-1,0,2,7,10};
		int[] b = {3,2,-50,100,99,100,5};
		MergeArrays ma = new MergeArrays();
		var r = ma.Merge(a,b);
		for(int i=0; i<r.Length; i++){
			Console.Write(r[i]+" ");
		}
	}
}