using System;
using System.Collections.Generic;
public class Smallest{
	public int SmallestIndex(int[] A){
		int N = A.Length;
		int f=0;
		for(int i=1; i<N; i++){
			if(A[i]<A[f])
				f = i;
		}
		return f;
	}
	public IEnumerable<int> TwoSmallestIndex(int[] A){
		int N = A.Length;
		var res = new List<int>();
		int f=0,s=1;
		if(A[f] > A[s]){
			f = 1; s = 0;
		}
		for(int i=2; i<N; i++){
			if(A[i]<A[f]){
				s = f; f = i; 
			} else if(A[i]<A[s]){
				s = i;
			}
		}
		res.Add(f); res.Add(s);
		return res;
	}
	public IEnumerable<int> KSE_Bubble(int[] A, int K){ 
		//bubble sort k times
		int N = A.Length;
		for(int i=0; i<K; i++){
			for(int j=N-1; j>0; j--){
				int temp;
				if(A[j-1]>A[j]){
					temp = A[j];
					A[j]=A[j-1];
					A[j-1] = temp;				
				}
			}
		}
		for(int i=0; i<K; i++)
			yield return A[i];
	}
	public IEnumerable<int> KSE_Selection(int[] A, int K){
		int N = A.Length;
		for(int i=0; i<K; i++){
			int pos = i;
			for(int j=i+1; j<N; j++){
				if(A[pos]>A[j]) pos = j;
			}
			if(pos != i) {
				int temp = A[pos];
				A[i] = A[pos];
				A[pos] = temp;
			}
		}
		for(int i=0; i<K; i++)
			yield return A[i];
	}
	public IEnumerable<int> KSE_Sorting_Quick(int[] A, int K){
		//quick sort
		// find a pivot and move smaller before and larger to later
		
		QSort(A);
		
		for(int i=0; i<K; i++)
			yield return A[i];
	}
	internal void QSort(int[] A){
		QSort(A, 0, A.Length-1);
	}
	private void QSort(int[] A, int lo, int hi) {
		if(hi<=lo) return;
		int p = Partition(A, lo, hi);
		QSort(A, lo, p-1);
		QSort(A, p+1, hi);
	}
	private int Partition(int[] A, int lo, int hi){
		int v = A[lo]; // 3 1 2 4 5 6
		int i=lo, j=hi+1;
		while(true){
			while(A[++i]<v)
				if(i==hi) break;
			while(A[--j]>v)
				if(j==lo) break;
			if(i>=j) break;
			Swap(A, i, j);
		}
		Swap(A, lo, j);
		return j;
	}
	private void Swap(int[] a, int i, int j){
		int temp = a[i]; a[i] = a[j]; a[j] = temp;
	}
	public IEnumerable<int> KSE_MaxHeap(int[] A, int K){
		var pq = new MaxPQ(A);
				
		for(int i=0; i<K; i++)
			yield return pq.DelMax();
	}
	public IEnumerable<int> KSE_MinHeap(int[] A, int K){
		var heap = new int[K];
		for(int i=0; i<heap.Length; i++)
			heap[i] = A[i];
		var pq = new MinPQ(heap);
		for(int i=K; i<A.Length; i++)
			pq.InsertAtTop(A[i]);
		foreach(var i in pq.PQ())
			yield return i;
	}
	public static void Test(){
		int[] a = { 23, 12, 9, 30, 2, 1, 50};
		Smallest s = new Smallest();
		//  Out(s.SmallestIndex(a));
		//  Out("\n");
		//  foreach(var i in s.TwoSmallestIndex(a))
		//  	Out(i+" ");
		//  Out("\n");
		//  foreach(var i in s.KSE_Bubble(a,3))
		//  	Out(i+" ");
		//  Out("\n");
		//  foreach(var i in s.KSE_Selection(a,3))
		//  	Out(i+" ");
		
		//  Out("\n");
		//  foreach(var i in s.KSE_Sorting_Quick(a,3))
		//  	Out(i+" ");
		//MaxPQ.Test();
		//  foreach(var i in s.KSE_MaxHeap(a, 3))
		//  	Out(i+" ");
		//MinPQ.Test();
		foreach(var i in s.KSE_MinHeap(a,3))
			Out(i+" ");
	}
	private static void OutL(object o){
		Console.WriteLine(o);
	}
	private static void Out(object o){
		Console.Write(o);
	}
	public class MinPQ{
		public MinPQ(int[] a){
			N = a.Length;
			pq = new int[N+1];
			for(int i=0; i<N; i++)
				pq[i+1] = a[i];
			for(int k=N/2; k>0; k--)
				Sink(k);
		}
		public void InsertAtTop(int v){
			pq[1] = v;
			Sink(1);
		}
		public int Peek(){return pq[1]; }
		private void Sink(int k){
			while(2*k <= N ){
				int j = 2*k; 
				if(j<N && pq[j]>pq[j+1]) j++;
				if(pq[k]<pq[j]) break;
				Swap(k,j);
				k = j;
			}
		}
		private void Swim(int k){
			while(k>0 && pq[k]<pq[k/2]){
				Swap(k, k/2); k = k/2;
			}
		}
		private void Swap(int i, int j){
			int temp = pq[i];
			pq[i] = pq[j];
			pq[j] = temp;
		}
		public IEnumerable<int> PQ(){ return pq; }
		public static void Test(){
			var a = new int[] { 23, 12, 9, 30, 2, 1, 50 };
			MinPQ pq = new MinPQ(a);
			foreach(var i in pq.PQ()){
				Out(i+" ");
			}
		}
		private int[] pq;
		private int N;
	}
	public class MaxPQ {
		public MaxPQ(int[] H){
			N = H.Length;
			pq = new int[N+1]; //note pq is 1 larger than that needed capacity
			for(int i=0; i<N; i++)
				pq[i+1] = H[i];
			for(int k=N/2; k>0; k--)
				Sink(k);	
		}
		public bool IsEmpty() { return N == 0; }
		internal int DelMax(){
			int max = pq[1];
			Swap(1, N--);
			Sink(1);
			return max;			
		}
		private void Sink(int k){
			while(2*k <= N){
				int j = 2*k;
				if(j<N && pq[j]<pq[j+1]) j++;
				if(pq[j] < pq[k]) break;
				Swap(j,k);
				k=j;
			}
		}
		private void Swim(int k){
			while(k>1 && pq[k/2]<pq[k]){
				Swap(k, k/2);
				k = k/2;
			}
		}
		
		private void Swap(int i, int j){
			int temp = pq[i];
			pq[i] = pq[j];
			pq[j] = temp;
		}
		public int[] pq;
		private int N; 
		
		public static void Test(){
			int[] a = { 23, 12, 9, 30, 2, 1, 50 };
			var mpq = new MaxPQ(a);
			for(int i=1; i<mpq.pq.Length; i++)
				Out(mpq.pq[i]+" ");
		}
	}
}