namespace LambdasTask;

public class Person
{
    private string _name;

    private int _age;

    public string Name => _name;

    public int Age => _age;

    public Person(string name, int age)
    {
        _name = name; 
        _age = age;
    }
}
