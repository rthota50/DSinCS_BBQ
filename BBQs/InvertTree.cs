using System;
using System.Collections.Generic;
public class InvertTree{
	public InvertTree(Node root){
		this.root = root;
		//MirrorTree(root); //iterative solution
		//Invert(root); //recursive solution
		MirrorUsingStack(root); //iterative solution		
	}
	public void MirrorUsingStack(Node root){
		var s = new Stack<Node>();
		s.Push(root);
		while(s.Count != 0){
			var n = s.Pop();
			var temp = n.Left;
			n.Left = n.Right;
			n.Right = temp;
			if(n.Left != null) s.Push(n.Left);
			if(n.Right != null) s.Push(n.Right);
		}
	}
	private void MirrorTree(Node root){
		var f = new Queue<Node>();
		var s = new Queue<Node>();
		if(root!= null) f.Enqueue(root);
		if(root.Right != null) s.Enqueue(root.Right);
		if(root.Left != null) s.Enqueue(root.Left);
		while(s.Count != 0){
			var r = f.Dequeue();
			Console.WriteLine("Dealing with "+r.Data);
			bool right  = r.Right != null;
			bool left = r.Left != null;
			if(right){
				var c = s.Dequeue();
				QueueChildren(s, c, forward: false);
				f.Enqueue(c);
				Console.WriteLine("Assigning "+c.Data+" to left of "+r.Data);
				r.Left = c;	
			} 
			
			if(left){
				var c = s.Dequeue();
				QueueChildren(s, c, forward: false);
				f.Enqueue(c);
				Console.WriteLine("Assigning "+c.Data+" to right of "+r.Data);
				r.Right = c;
			} 
		}
	}
	private void QueueChildren(Queue<Node> q, Node item, bool forward){
		if(item != null){
			if(forward){
				if(item.Left != null) q.Enqueue(item.Left);
				if(item.Right != null) q.Enqueue(item.Right);
			} else {
				if(item.Right != null) q.Enqueue(item.Right);
				if(item.Left != null) q.Enqueue(item.Left);
			}
		}
	}
	public Node GetTree(){ return root; }
	private Node Invert(Node root){
		if(root == null) return null;
		Invert(root.Left);
		Invert(root.Right);
		Node temp = root.Right;
		root.Right = root.Left;
		root.Left = temp;
		return root;
	}
	private Node root;
	public static void Test(){
		Node root = new Node(1);
		root.Left = new Node(2);
		root.Right = new Node(3);
		root.Left.Left = new Node(4);
		root.Left.Right = new Node(5);
		root.Right.Left = new Node(6);
		root.Right.Right = new Node(7);
		root.Right.Left.Left = new Node(8);
		InvertTree it = new InvertTree(root);
		root = it.GetTree();
		Console.Write("\n3 == "+root.Left.Data);
		Console.Write("\n2 == "+root.Right.Data);
		Console.Write("\n7 == "+root.Left.Left.Data);
		Console.Write("\n8 == "+root.Left.Right.Right.Data);
	}
	public class Node{
		public int Data { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
		public Node(int data){this.Data = data; Left = null; Right = null;}
	}
}