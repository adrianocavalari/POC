// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using POCConsole;
using POCConsole.ArrayTests;
using POCConsole.Course.DSA;
using POCConsole.Course.MCI;
using POCConsole.GarbageCollector;
using POCConsole.Inter;
using POCConsole.Inter.BaseAlgo;
using POCConsole.Inter.BreadthFirstSearch;

Console.WriteLine("Init...");

#region BaseAlgo
NextPermutation.Exec();
#endregion

#region Algorithms
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

//BFSTest.Exec();

//AirportRoute.Exec();

//BFS.Exec();
//NullsBreakPolymorphism.ExecuteRight();

//var tree = new GFG().buildTree("10 5 18 2 9 15 19 N 4 8 N 1");

//Console.WriteLine(new SolutionBST().isBST(tree));

//new SolutionMergeSort().Exec();

//Dijkstra.Exec();
//TSP.Exec();
#endregion

#region Arrays
//var numbers = new POCConsole.Array.Array(3);

//numbers.Insert(10);
//numbers.Insert(20);
//numbers.Insert(30);
//numbers.Insert(40);

//numbers.RemoveAt(2);

//Console.WriteLine(numbers.IndexOf(40));


//numbers.Print();

//MissingBlock.Exec();
//MissingRolls.Exec();
//AliceAndBobApple.Exec();
#endregion

#region Course
#region MCI
//ContainsCommonItem.Exec();

//BubbleSort.Exec();
//SelectionSort.Exec();
//InsertionSort.Exec();
//MergeSort.Exec();
//QuickSort.Exec();

//FibonacciWithCache.Exec();

//Graph.Exec();

#endregion
#region DSA
//AvlTree.Exec();
//Heap.Exec();

#endregion
#endregion

#region Find in array
//TestCode.Exec();
#endregion

#region LinkedList
//ReverseLinkedList.Exec();
#endregion

#region Stack
//StackTests.Exec();
#endregion

#region Queue
//MyQueue.Exec();
#endregion

#region GarbageCollector
//GarbageCollectorCPF.Exec();
#endregion

#region SlidingWindow
//SlidingWindow.Exec();
#endregion


Console.Read();
