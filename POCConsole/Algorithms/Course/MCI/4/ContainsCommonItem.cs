using Shouldly;

namespace POCConsole.Inter
{

    public class ContainsCommonItem
    {
        public static void Exec()
        {
			ExistsIn(
				new[] { "a", "b", "c", "x" }, 
				new[] { "z", "y", "i" }).Dump().ShouldBe(false);

			ExistsIn(
				new[] { "a", "b", "c", "x" },
				new[] { "z", "y", "x" }).Dump().ShouldBe(true);

			ExistsIn(
				new[] { "a", "b", "c", "a", "x" },
				new[] { "z", "y", "x" }).Dump().ShouldBe(true);
		}

		private static bool ExistsIn(string[] array1, string[] array2)
		{
			var hash = new HashSet<string>();

			foreach (var item1 in array1)
			{
				hash.Add(item1);
			}


			foreach (var item2 in array2)
			{
				if (hash.Contains(item2))
					return true;
			}

			return false;
		}

		//private static bool ExistsIn(string[] array1, string[] array2)
		//{
		//	foreach (var item1 in array1)
		//	{
		//		foreach (var item2 in array2)
		//		{
		//			if (item1 == item2)
		//				return true;
		//		}
		//	}

		//	return false;
		//}
	}
}
