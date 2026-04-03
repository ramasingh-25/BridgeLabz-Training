using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

class Serialization
{
    public class Employee
    {
        public int id;
        public string name;
        public string dept;
        public double sal;   
    }

    static void Main()
    {
        List<Employee> list = new List<Employee>()
        {
            new Employee{ id=1, name="Amit", dept="IT", sal=45000 },
            new Employee{ id=2, name="Neha", dept="HR", sal=40000 }
        };

        string path = "emp.json";

        File.WriteAllText(path, JsonSerializer.Serialize(list));

        var data = JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText(path));

        foreach (var e in data)
            Console.WriteLine(e.id + " " + e.name + " " + e.dept + " " + e.sal);
    }
}

