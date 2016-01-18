/*
Number	Binary
0		0000
1		0001
2		0010
3		0011
4		0100
5		0101
6		0110
7		0111
8		1000
So, print the character in the set corresponding the bit set in the binary string
*/
using System;
using System.Collections.Generic;
public class Subsets{
	public Subsets(char[] a){
		double N = Math.Pow(2,a.Length);
		for(int i=0; i<N; i++) {
			for(int j=0; j<a.Length; j++){
				if((i & (1<<j)) > 0)
					Console.Write(a[j]);
			}
			Console.Write("\n");
		}
	}
	public IEnumerable<int> AllSets() {
		throw new NotImplementedException();
	}
	
	public static void Test(){
		char[] a = {'a','b','c','d'};
		Subsets s = new Subsets(a);
	}
}