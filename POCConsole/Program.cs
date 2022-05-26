// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using POCConsole;
using POCConsole.Array;
using POCConsole.Inter;

Console.WriteLine("Init...");
//NullObjectPattern.ExecuteBad();
//NullObjectPattern.ExecuteRight();

//StaticTestsExec.Exec();

//await new AsyncTests().Exec();
//await new AsyncTests2().ExecTaskWhenAllExceptionsClass();

//var summary = BenchmarkRunner.Run<PerformanceTest>();
//Console.WriteLine(summary);

//NullsBreakPolymorphism.ExecuteRight();

//BinarySearch.Exec();

//TwoPointers.Exec();

//Subsets.Exec();

BFS.Exec();