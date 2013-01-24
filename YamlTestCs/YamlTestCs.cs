using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Yaml.Serialization;

namespace YamlTestCs
{
	public class Company
	{
		public string Name { get; set; }
		internal List<Employee> _Employees;
		public Employee[] Employees
		{
			get { return _Employees.ToArray(); }
			set { _Employees = new List<Employee>(value); }
		}
		internal List<Group> _Groups;
		public Group[] Groups
		{
			get { return _Groups.ToArray(); }
			set { _Groups = new List<Group>(value); }
		}
		public Company()
		{
			_Employees = new List<Employee>();
			_Groups = new List<Group>();
		}
		public Company(string name0) : this()
		{
			Name = name0;
		}
	}
	public class Group
	{
		public string Name { get; set; }
		internal List<Employee> _Employees;
		public Employee[] Employees
		{
			get { return _Employees.ToArray(); }
			set { _Employees = new List<Employee>(value); }
		}
		public Group()
		{
			_Employees = new List<Employee>();
		}
		public Group(string name0) : this()
		{
			Name = name0;
		}
	}
	public class Employee
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public Employee() { }
		public Employee(string name0, int age0)
		{
			Name = name0;
			Age = age0;
		}
	}
	class YamlTestCs
	{
		static void Main(string[] args)
		{
			//SerializeSample("../test.yml");
			DeserializeSample("../test.yml");
		}
		static void SerializeSample(string fnam)
		{
			var co = new Company("Googol");
			co._Employees.Add(new Employee("A", 30));
			co._Groups.Add(new Group("G"));
			co._Groups[0]._Employees.Add(co.Employees[0]);
			var ys = new YamlSerializer();
			ys.SerializeToFile(fnam, co);
		}
		static void DeserializeSample(string fnam)
		{
			var ys = new YamlSerializer();
			var co = (Company)ys.DeserializeFromFile(fnam, typeof(Company))[0];
			co.Employees[0].Age = 24;
			Console.WriteLine(co.Groups[0].Employees[0].Age);
		}
	}
}
