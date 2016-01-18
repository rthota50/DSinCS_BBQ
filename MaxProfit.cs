using System;
public class MaxProfit{
	public int Max(int[] a, int[] b){
		int p1=0, p2=1, l1=0, l2=1;
		if(a[p1]<a[p2]){p1 = 1; p2 = 0;}
		if(b[l1]>b[l2]){l1 = 1; l2=0;}
		
		for(int i=2; i<a.Length; i++){
			if(a[i]>a[p1]){
				p2 = p1; p1=i;
			} else if(a[i]>a[p2])
				p2=i;
		}
		Console.WriteLine("l1 "+l1);
		for(int i=2; i<b.Length; i++){
			if(b[i]<b[l1]){
				l2 = l1; l1=i;
			} else if(b[i]<b[l2])
				l2=i;
			Console.WriteLine("l1 "+l1);
		}
		Console.WriteLine(p1+" "+l1);
		if(p1 != l1) return a[p1]-b[l1];
		else 
			return Math.Max(a[p1]-b[l2],a[p2]-b[l1]);
		
	}
	public static void Test(){
		int[] a = {7,9, 11, 6};
		int[] b = {4,5, 1, 4};
		MaxProfit p = new MaxProfit();
		var res = p.Max(a,b);
		Console.WriteLine(res);
	}
}