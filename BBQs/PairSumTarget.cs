using System.Collections.Generic;
using System;
public class PairSumTarget{
	public PairSumTarget(){
		
	}
	public IEnumerable<string> SumParis(int[] a, int target){
		Array.Sort(a);
		int i=0, j=a.Length -1;
		List<string> result = new List<string>();;
		while(i<j){
			int sum = a[i]+a[j];
			if(target == sum) {result.Add(a[i]+" "+a[j]);i++;}
			else if(target < sum) j--;
			else if(target > sum) i++;
		}
		return result;
	}
	public int LargestPairSum(int[] a){ //in a unsorted array
		int fh = a[0], sh = a[1];
		if(fh<sh){ fh = sh; sh = a[0];}
		for(int i=2; i<a.Length; i++){
			if(a[i]>fh){
				sh = fh; fh = a[i];
			} 
			else if(a[i]>sh) sh = a[i];
		}
		return fh+sh;
	}
	public string SubArraysWithSum_bruteforce(int[] a, int target){ //brute force soln
		int N = a.Length; List<int> pos = new List<int>();
		for(int i=0; i<N; i++){
			int sum = 0; 
			for(int j=i; j<N; j++){
				sum += a[j];
				if(sum == target) {
					return i+" "+j;
				}
				if(sum > target) break;
			}
		}
		return string.Empty;
	}
	public string SubArraySum(int[] a, int target){
		int N = a.Length, startIndex = 0, sum=0; 
		for(int i=0; i<N; i++){
			sum+= a[i];
			Console.WriteLine("sum "+sum);
			while(sum > target) {
				Console.WriteLine("removing "+a[startIndex]);
				sum -= a[startIndex];
				Console.WriteLine("sum "+sum);
				startIndex++;
			}
			if(sum == target) return startIndex+" "+i;
		}
		
		return string.Empty;
	}
	//  public int SubArraySumWithNegValues(int[] a, int target){
	//  	int N = a.Length;
	//  	int MaxTillHere=a[0], MaxSoFar=a[0];
	//  	for(int i=1; i<N; i++){
	//  		MaxTillHere = Math.Max(MaxTillHere+a[i], a[i]);
	//  		MaxSoFar = Math.Max(MaxSoFar, MaxTillHere);	
	//  	}
	//  	
	//  	return MaxSoFar;
	//  }
	public string SubArraySumWithNegValues(int[] a, int target){
		var SumIndex = new Dictionary<int,int>();
		SumIndex.Add(0,-1);
		int curSum = 0;
		for(int i=0; i<a.Length; i++){
			curSum += a[i];
			if(SumIndex.ContainsKey(curSum - target)){
				int index = SumIndex[curSum-target];
				return (index+1)+" "+i;
			}
			if(!SumIndex.ContainsKey(curSum))
				SumIndex.Add(curSum, i);
		}
		return string.Empty;
	}
	public static void Test(){
		int[] a = {6,4,5,7,9,1,2};
		int[] b = {1, 4, 20, 3, 10, 5};
		int[] c = {1, 4, 0, 0, 3, 10, 5};
		int[] d = { -3,1,2,4 };
		PairSumTarget pst = new PairSumTarget();
		foreach(var pair in pst.SumParis(a, 10))
			Console.WriteLine(pair);
		Console.WriteLine("Max sum "+pst.LargestPairSum(a));
		//  Console.WriteLine("Subset with sum "+pst.SubArraysWithSum_bruteforce(b, 33));
		//  Console.WriteLine("Subset with sum "+pst.SubArraysWithSum_bruteforce(c, 7));
		//  Console.WriteLine("Subset with sum "+pst.SubArraySum(b, 33));
		//  Console.WriteLine("Subset with sum "+pst.SubArraySum(c, 7));
		Console.WriteLine("Subset with sum "+pst.SubArraySumWithNegValues(d, 7));
	}
}