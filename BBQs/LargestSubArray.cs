using System;
using System.Collections.Generic;
public class LargestSubArray{
	public string Find_BF(int[] a){
		int sum, str=0, end=0, max=0; 
		int n = a.Length;
		for(int i=0; i<n; i++){
			sum = (a[i]==0)?-1:1;
			for(int j=i+1; j<n; j++){
				sum += (a[j]==0)?-1:1;
				if(sum==0 && j-i+1>max){
					max = j-i+1;
					str = i; end = j;
				}
			}
		}
		return str+" "+end;
	}
	public string Find(int[] a){
		int n = a.Length;
		int st=0, max=int.MinValue;
		a[0] = (a[0]==0) ? -1 : 1;
		for(int i=1; i<n; i++){
			a[i] = (a[i]==0?-1:1)+a[i-1];
			Console.Write(a[i]+" ");
		}
		Dictionary<int,int> map = new Dictionary<int,int>();
		for(int i=0; i<n; i++){
			if(!map.ContainsKey(a[i]))
				map[a[i]] = i;
			else {
				if(i-map[a[i]]>max){
					st = map[a[i]]+1;
					max = i-map[a[i]];
				}
			} 
		}
		return st+" "+(st+max-1);
	}
	public static void Test(){
		int[] a = {1, 0, 1, 1, 1, 0, 0};
		var res = new LargestSubArray();
		Console.WriteLine(res.Find_BF(a));
		Console.WriteLine(res.Find(a));
	}
}