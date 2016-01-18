using System;
public class OverlapLL{
	public OverlapLL(Node ahead, Node bhead){
		var first = ahead; 
		var second = bhead;
		this.Overlap = false;
		int s =0;
		while(first != null){ s++; first = first.Next;}
		while(second != null){ s--; second = second.Next; }
		Node larger, small;
		if(s>=0) {
			whichNode = 0;
			larger = ahead; small = bhead;
		} else {
			whichNode = 1;
			s *= -1; s++;
			small = bhead; larger = ahead;
		}
		pos = s;
		Console.WriteLine(s);
		while(s-->0) larger = larger.Next;
		while(larger != null && small != null){
			pos++;
			if(larger == small)
			{ Overlap = true; break; }
			larger = larger.Next; small = small.Next;
		}
	}
	public int OverlapAt(){
		return Overlap ? pos : -1;
	}
	public int WhichNode(){ return whichNode; }
	public bool Overlap{get; private set;}
	private int pos, whichNode;
	public static void Test(){
		Node ahead = new Node(1);
		ahead.Next = new Node(2);
		ahead.Next.Next = new Node(3);
		ahead.Next.Next.Next = new Node(4);
		ahead.Next.Next.Next.Next = new Node(5);
		ahead.Next.Next.Next.Next.Next = new Node(6);
		Node bhead = new Node(11);
		bhead.Next = ahead.Next.Next;
		OverlapLL ol = new OverlapLL(bhead, ahead);
		if(ol.Overlap)
			Console.Write("\nOverlap at pos "+ol.OverlapAt()+" of the "+ol.whichNode+"th give nodes");
	}
	public class Node{
		public int Data { get; set; }
		public Node Next { get; set; }
		public Node(int data){this.Data = data; Next = null;}
	}
}