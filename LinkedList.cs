using System;
public class LinkedList{
	public Node Reverse(Node head){
		if(head == null) return null;
		Node prev = null;
		while(head.Next != null){
			Node next = head.Next;
			head.Next = prev;
			prev = head;
			head = next;
		}
		head.Next = prev;
		return head;
	}
	public Node MergeSort(Node head){
		if(head == null || head.Next == null)
			return head;
		//Console.WriteLine("recurring "+head.Data);
		var mid = Mid(head);
		//Console.WriteLine("mid "+mid.Data);
		var nhead = mid.Next;
		mid.Next = null;
		return Merge(MergeSort(head), MergeSort(nhead));
	}
	public Node Merge(Node headA, Node headB){
		Node head = new Node(-1);
		Node temp = head;
		while(headA != null && headB != null){
			//Console.WriteLine("headA "+headA.Data+" headB "+headB.Data);
			if(headA.Data < headB.Data){
				head.Next = headA;
				head = head.Next;
				headA = headA.Next;
				head.Next = null;
			} else {
				head.Next = headB;
				head = head.Next;
				headB = headB.Next;
				head.Next = null;
			}
		}
		if(headA != null){
			head.Next = headA;
		}
		if(headB != null){
			head.Next = headB;
		}
		return temp.Next;;
	}
	public Node Mid(Node head){
		Node s=head,f=head;
		while(f!=null && f.Next != null && f.Next.Next != null){
			s = s.Next;
			f = f.Next.Next;
		}
		return s;
	}
	
	public static void Test(){
		Node head = new Node(21);
		head.Next = new Node(12);
		head.Next.Next = new Node(31);
		head.Next.Next.Next = new Node(14);
		head.Next.Next.Next.Next = new Node(5);
		head.Next.Next.Next.Next.Next = new Node(5);
		//head.Next.Next.Next.Next.Next = new Node(5);
		LinkedList ll = new LinkedList();
		//  //testing Mid
		//  Console.WriteLine(ll.Mid(head).Data+" == 31");
		//  Console.WriteLine("\nEnd merge");		
		//  //end testing Mid
		//  //tesing Merge
		//  Node t = new Node(1); t.Next = new Node(3); t.Next.Next = new Node(5);
		//  Node s = new Node(2); s.Next = new Node(4); s.Next.Next = new Node(6);
		//  var r = ll.Merge(t,s);
		//  while(r != null){
		//  	Console.Write(r.Data + " "); r = r.Next; }
		//  //end testing Merge
		//  Node temp = head;
		//  while(temp!=null){
		//  	Console.Write(temp.Data+" "); temp = temp.Next;}
		//  Console.Write("\n");
		//  head = ll.Reverse(head);
		//  while(head!=null){
		//  	Console.Write(head.Data+" "); 
		//  	head = head.Next;
		//  }
		
		var temp = ll.MergeSort(head);
		while(temp!=null){
			Console.Write(temp.Data+" "); temp = temp.Next;} 
	}
	public class Node{
		public Node Next { get; set; }
		public int Data { get; set; }
		public Node(int data){this.Data = data; Next = null;}
	}
}