using System;
using System.Collections.Generic;
public class RefineryLocator{
	public RefineryLocator(IEnumerable<Refinery> refs){
		this.refs = refs;
	}
	public IEnumerable<Refinery> RefsIn(int xa, int ya, int xb, int yb){
		var inRect = new List<Refinery>();
		foreach(var re in this.refs){
			if(re.X > xa && re.Y > ya && re.X < xb && re.Y < yb){
				inRect.Add(re);				
			}
		}
		return inRect;
	}
	public Refinery NearestRef(int x, int y){
		Refinery nearest = null;
		double dist = double.MaxValue;
		foreach(var re in this.refs){
			double d = Math.Sqrt(Math.Pow(re.X-x,2.0)+Math.Pow(re.Y-y,2.0));
			if(d < dist) {
				dist = d;
				nearest = re;
			}
		}
		return nearest;
	}
	private IEnumerable<Refinery> refs;
	public static void Test(){
		var list = new List<Refinery>();
		list.Add(new Refinery("r1",12,9));
		list.Add(new Refinery("r2",33,19));
		list.Add(new Refinery("r3",84,88));
		list.Add(new Refinery("r4",12,15));
		list.Add(new Refinery("r5",20,25));
		list.Add(new Refinery("r6",10,1));
		list.Add(new Refinery("r7",3,5));
		
		RefineryLocator rl = new RefineryLocator(list);
		var result = rl.RefsIn(11,6,19,16);
		foreach(var re in result)
			Console.WriteLine(re);
		var nearest = rl.NearestRef(11,6);
		Console.WriteLine(nearest);
	}
	public class Refinery{
		public string Name { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public Refinery(string name, int x, int y){this.Name = name; this.X = x; this.Y = y;}
		public override string ToString(){
			return this.Name+" "+this.X+" "+this.Y;
		}
	}
	
}