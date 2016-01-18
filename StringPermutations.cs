using System;
using System.Collections.Generic;
public class StringPermutations{
	public bool AreStringPermutes(string a, string b){
		if(a.Length != b.Length) return false;
		var occurs = new Dictionary<char, int>();
		//can use array to count characters
		foreach(char c in a.ToCharArray()){
			if(occurs.ContainsKey(c))
				occurs[c]+=1;
			else occurs.Add(c,1);
		}
		foreach(char c in b.ToCharArray()){
			if(occurs.ContainsKey(c)){
				if(occurs[c] == 0) return false;
				occurs[c]-=1;
			}
			else return false;
		}
		return true;
	}
	public static void Test(){
		StringPermutations sp = new StringPermutations();
		var res = sp.AreStringPermutes("rajiv","vijark");
		Console.Write(res);
	}
}