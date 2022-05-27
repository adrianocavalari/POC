// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using POCConsole;

Console.WriteLine("Init...");
//NullObjectPattern.ExecuteBad();
//NullObjectPattern.ExecuteRight();

//StaticTestsExec.Exec();

//await new AsyncTests().Exec();
//await new AsyncTests2().ExecTaskWhenAllExceptionsClass();

//var summary = BenchmarkRunner.Run<PerformanceTest>();
//Console.WriteLine(summary);

//NullsBreakPolymorphism.ExecuteRight();

//var tree = new GFG().buildTree("10 5 18 2 9 15 19 N 4 8 N 1");

//Console.WriteLine(new SolutionBST().isBST(tree));

new SolutionMergeSort().Exec();









Console.ReadLine();