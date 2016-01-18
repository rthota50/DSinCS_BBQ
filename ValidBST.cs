using System;
public class BST{
	public bool Valdiate(Node root){
		prev = null;
		return InOrder(root);
	}
	private bool InOrder(Node root){
		if(root == null) return true;
		//Console.WriteLine(root.Data);
		if(!InOrder(root.Left)) return false;
		if(prev != null){
			//Console.WriteLine("cur "+root.Data+" prev "+prev.Data);
			if(root.Data <= prev.Data)
				return false;
			}
		prev = root;
		//Console.WriteLine("cur "+root.Data+" prev "+prev.Data);
		if(!InOrder(root.Right)) return false;
		return true;
	}
	private static Node prev = null;
	public static void Test(){
		var root1 = new Node(1);
		root1.Left = new Node(2);
		root1.Right = new Node(3);
		root1.Left.Left = new Node(4);
		root1.Left.Right = new Node(5);
		root1.Right.Left = new Node(6);
		root1.Right.Right = new Node(7);
		var bst = new BST();
		var root2 = new Node(8);
		root2.Left = new Node(5);
		root2.Right = new Node(11);
		root2.Left.Left = new Node(4);
		root2.Left.Right = new Node(6);
		root2.Right.Left = new Node(10);
		root2.Right.Right = new Node(13);
		Console.WriteLine(bst.Valdiate(root1));
		Console.WriteLine(bst.Valdiate(root2));
	}
	public class Node{
		public int Data { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
		public Node(int data){this.Data = data; Left = null; Right = null;}
	}
}