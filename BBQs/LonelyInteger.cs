using System.Collections.Generic;
using System;
public class LonelyInteger{
	public int Find(int[] a){
		int l = a[0];
		for(int i=1; i<a.Length; i++){
			l ^= a[i];	
		}
		return l;
	}
	public List<int> FindTwoNonRepeating(int[] a){
		
		return null;
	}
	public static void Test(){
		int[] a = {1,2,3,4,5,3,2,1};
		var li = new LonelyInteger();
		Console.WriteLine(li.Find(a));
	}
}