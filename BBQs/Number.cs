using System;
public class Number{
	public int Reverse(int n){
		int s = 0;
		while(n>0){
			s = s*10 + n%10;
			n /= 10;
		}
		return s;	
	}
	public static void Test(){
		int n = 13451;
		Number nu = new Number();
		Console.WriteLine(nu.Reverse(n));
	}
}