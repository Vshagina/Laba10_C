using System;

class FirstClass
{
    public event EventHandler<string> MyEvent;
  
    public string Name { get; }

    public FirstClass(string name)
    {
        Name = name;
    }
 
    public void RaiseEvent()
    {
        MyEvent?.Invoke(this, Name);
    }
}

class SecondClass
{
 
    public void HandleEvent(object sender, string name)
    {
        Console.WriteLine($"Событие сгенерировано объектом : {name}");
    }
}

class Program
{
    static void Main(string[] args)
    {
  
        FirstClass first1 = new FirstClass("Первый объект");
        FirstClass first2 = new FirstClass("Второй объект");
        SecondClass second = new SecondClass();

        first1.MyEvent += second.HandleEvent;
        first2.MyEvent += second.HandleEvent;

        first1.RaiseEvent();
        first2.RaiseEvent();

    }
}
