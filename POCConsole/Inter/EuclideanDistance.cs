using System.Collections;
using System.Collections.Generic;

namespace POCConsole.Inter
{
    //https://hackernoon.com/the-ultimate-strategy-to-preparing-for-the-coding-interview-yxts3zbg
    //TODO - NOT WORKING

    public class EuclideanDistance
    {
        public static void Exec()
        {
            Point[] points = new Point[] { new Point(1, 3), new Point(3, 4), new Point(2, -1) };

            var result = FindClosestPoints(points, 2);

            Console.WriteLine("Here are the k points closest the origin: ");
            //foreach (var p in result)
            //{
            //    Console.WriteLine("[" + p.x + " , " + p.y + "] ");
            //}
        }

        public static PriorityQueue<Point, Point> FindClosestPoints(Point[] points, int k)
        {
            var maxHeap = new PriorityQueue<Point, Point>(Comparer<Point>.Create((p1, p2) => p2.DistFromOrigin() - p1.DistFromOrigin()));

            // put first 'k' points in the max heap
            for (int i = 0; i < k; i++)
                maxHeap.Enqueue(points[i], points[k]);

            // go through the remaining points of the input array, if a point is closer to 
            // the origin than the top point of the max-heap, remove the top point from 
            // heap and add the point from the input array
            for (int i = k; i < points.Length; i++)
            {
                if (points[i].DistFromOrigin() < maxHeap.Peek().DistFromOrigin())
                {
                    maxHeap.Dequeue();
                    maxHeap.Enqueue(points[i], points[k]);
                }
            }

            // the heap has 'k' points closest to the origin, return them in a list
            return maxHeap;
        }
    }

    public class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int DistFromOrigin()
        {
            // ignoring sqrt
            return (x * x) + (y * y);
        }
    }
}
