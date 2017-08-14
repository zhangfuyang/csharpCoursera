using System;
using System.Threading;
using System.Threading.Tasks;

class TestParallelInvoke
{
	public delegate void func();
	static void Main(string[] args)
	{
		//Action[] actions = { new Action(DoSometing), new Action(DoSometing) };
		func[] method = {DoSometing, DoSometing};
		Parallel.Invoke( method );
		Console.WriteLine("主函数所在线程"+Thread.CurrentThread.ManagedThreadId);
		Console.ReadKey();
	}
	static void DoSometing(){
		Console.WriteLine("函数所在线程"+Thread.CurrentThread.ManagedThreadId);
		Thread.Sleep(2000);
		Console.WriteLine("haha" + Thread.CurrentThread.ManagedThreadId);
	}

}