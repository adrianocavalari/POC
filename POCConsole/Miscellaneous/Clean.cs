using System.Collections;

public class CleanExe
{
    public static void Exec()
    {
        var a = new Test("Worked");
        var b = new Test("Worked");
        a.SomeParam("Worked 2");

        a.SomeParam2("Worked 3");
    }
}

//public class Test : IComparable<Test>
//{
//    public string Name { get; set; }

//    public int CompareTo(Test? other)
//    {
//        if (other != null)
//            return this.Name.CompareTo(other.Name);

//        return -1;
//    }
//}


public abstract class TestBase
{
    public TestBase(string SomeParam)
    {

    }

    public abstract string SomeParam(string SomeParam);

    public string SomeParam2(string SomeParam)
    {
        return SomeParam;
    }
}

public class Test : TestBase
{
    public string SomeProp { get; set; }

    static Test()
    {

    }

    public Test(string SomeParam)
        : base("")
    {
        SomeProp = "";
    }

    public override string SomeParam(string SomeParam)
    {
        return SomeParam2(SomeParam);
    }
}

public static class Esta
{
    static Esta()
    {
    }

    public static void Estaaaaa()
    {
    }
}

public class List2 : List<string>
{

}

public class Enumerable2 : IList<string>
{
    public string this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(string item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(string item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(string[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<string> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public int IndexOf(string item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, string item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(string item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}