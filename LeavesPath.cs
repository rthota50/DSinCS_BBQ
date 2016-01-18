using System;
public class LeavesPath{
	public void Print(Node root){
		PreOrder(root,"");
	}
	private void PreOrder(Node root, string path){
		if(root == null){
			return;			
		}
		if(root.Left == null && root.Right == null)
			Console.WriteLine(path+"->"+root.Data); 
		PreOrder(root.Left, path+"->"+root.Data);
		PreOrder(root.Right, path+"->"+root.Data);
	}
	public static void Test(){
		Node root = new Node(1);
		root.Left = new Node(2);
		root.Right = new Node(3);
		root.Left.Left = new Node(4);
		root.Left.Right = new Node(5);
		root.Right.Left = new Node(6);
		root.Right.Right = new Node(7);
		var path = new LeavesPath();
		path.Print(root);
	}
	public class Node{
		public int Data { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }
		public Node(int data){this.Data = data; Left = null; Right = null;}
	}
}