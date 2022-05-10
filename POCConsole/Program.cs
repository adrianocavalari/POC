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

NullsBreakPolymorphism.ExecuteRight();