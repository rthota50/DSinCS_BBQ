using System.Collections.Generic;
using System;
public class Siblings{
	public void AttachSiblings(Node root){
		var q = new Queue<Node>();
		if(root != null) q.Enqueue(root);
		q.Enqueue(null);
		Node sibl = null;
		while(q.Count != 0){
			var n = q.Dequeue();
			if(n!= null){
				n.Prev = sibl;
				sibl = n;
				if(n.Left != null)	q.Enqueue(n.Left);
				if(n.Right != null) q.Enqueue(n.Right);
			} else {
				if(q.Count != 0)
					q.Enqueue(null);
				sibl = null;
			}
		}
	}
	public static void Test(){
		Node root = new Node(1);
		root.Left = new Node(2);
		root.Right = new Node(3);
		root.Left.Left = new Node(4);
		root.Left.Right = new Node(5);
		root.Right.Left = new Node(6);
		root.Right.Right = new Node(7);
		Siblings sb = new Siblings();
		sb.AttachSiblings(root);
		Console.Write(root.Right.Right.Prev.Data+" == 6");
		Console.Write("\n"+root.Right.Left.Prev.Data+" == 5");
		Console.Write("\n"+(root.Left.Left.Prev==null?"null":"exists")+" == null");
	}
	public class Node{
		public int Data { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
		public Node Prev {get; set;}
		public Node(int data){ this.Data = data; Left = null; Right = null; Prev = null;}
	}
}