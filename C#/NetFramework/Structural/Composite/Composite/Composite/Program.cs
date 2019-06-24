using System;
using System.Collections.Generic;

namespace Composite
{
    /// <summary>
    /// Composite pattern lets clients treat the individual objects in a uniform manner.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            // arrange Employees, Organization and add employees
            var developer = new Developer("Jeremy", 5000);
            var designer = new Designer("John", 3000);

            var organization = new Organization();
            organization.AddEmployee(developer);
            organization.AddEmployee(designer);

            Console.WriteLine($"Net salary of Employees in Organization is {organization.GetNetSalaries():C}");
        }
    }

    /// <summary>
    /// Here we have different employee types
    /// </summary>
    public interface IEmployee
    {
        float GetSalary();
        string GetRole();
        string GetName();
    }

    public class Developer : IEmployee
    {
        private readonly string name;
        private readonly float salary;

        public Developer(string name, float salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public float GetSalary()
        {
            return salary;
        }

        public string GetRole()
        {
            return GetType().Name;
        }

        public string GetName()
        {
            return name;
        }
    }

    class Designer : IEmployee
    {
        private readonly string name;
        private readonly float salary;

        public Designer(string name, float salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public float GetSalary()
        {
            return salary;
        }

        public string GetRole()
        {
            return GetType().Name;
        }

        public string GetName()
        {
            return name;
        }
    }

    /// <summary>
    /// Then we have an organization which consists of several different types of employees
    /// </summary>
    public class Organization
    {
        protected IList<IEmployee> Employees;

        public Organization()
        {
            Employees = new List<IEmployee>();
        }

        public void AddEmployee(IEmployee employee)
        {
            Employees.Add(employee);
        }

        public float GetNetSalaries()
        {
            float netSalary = 0;

            foreach (var employee in Employees)
            {
                netSalary += employee.GetSalary();
            }

            return netSalary;
        }
    }
}