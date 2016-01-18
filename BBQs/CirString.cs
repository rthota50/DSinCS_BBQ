using System;
public class CirString{
	public bool AreCircular(string a, string b){
		if(a.Length != b.Length) return false;
		string temp = a+a;
		if(!temp.Contains(b)) return false;
		temp = b+b;
		if(!temp.Contains(a)) return false;
		return true;
	}
	public static void Test(){
		string a = "vraji";
		string b = "rajiv";
		CirString cs = new CirString();
		Console.Write(cs.AreCircular(a,b));
	}
}