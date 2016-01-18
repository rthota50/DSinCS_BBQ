using System;
public class ArrayProd
{
	public int[] BuildProdArray(int[] a)
	{
		int N = a.Length;
		var left = new int[N];
		var right = new int[N];
		var prod = new int[N];
		
		left[0]=1;
		for(int i=1; i<N; i++)
			left[i] = left[i-1]*a[i-1];			
		right[N-1]=1;
		for(int i=N-2; i>=0; i--)
			right[i] = right[i+1] * a[i+1];
		for(int i=0; i<N; i++)
		{
			prod[i] = left[i]*right[i];
		}
		return prod;
	}
	public int[] BuildProdArray2(int[] a)
	{
		int N = a.Length;
		
		var prod = new int[N];
		//for(int i=0; i<N; i++)
			prod[0] = 1;
		for(int i=1; i<N; i++)
			prod[i] = prod[i-1]*a[i-1];
		int temp = a[N-1];
		
		for(int i=N-2; i>=0; i--){
			prod[i] = prod[i] * temp;
			temp = temp*a[i];
		}
		return prod;
	}
	public static void Test()
	{
		int[] a = {1,2,3,4,5};
		ArrayProd ap = new ArrayProd();
		var start = (long)Environment.TickCount;
		var prod = ap.BuildProdArray(a);
		Console.WriteLine("Elapased : "+((long)Environment.TickCount - start));
		for(int i=0; i<prod.Length; i++)	
			Console.Write(prod[i]+" ");
	}
}