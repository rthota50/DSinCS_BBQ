using System;
public class RepeatedNum{
	public int Find(int[] a){
		
		for(int i=0; i<a.Length; i++){
			if(a[Math.Abs(a[i])]>0){
				a[Math.Abs(a[i])] *= -1;
			} else {
				return Math.Abs(a[i]);
			}
		}
		return -1;
	}
	public static void Test(){
		int[] a = {1,2,3,4,4,5,6,7};
		RepeatedNum rn = new RepeatedNum();
		Console.WriteLine(rn.Find(a));
	}
}