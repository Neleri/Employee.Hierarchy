using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Employee.Hierarchy
{
    public class Employee
    {
        Dictionary<string, string> employees = new Dictionary<string, string>();
        Dictionary<string, int> employeesAndSalaries = new Dictionary<string, int>();
        Dictionary<string, List<string>> lists = new Dictionary<string, List<string>>();
        public Employee(string csv)
        {
            if (string.IsNullOrEmpty(csv))
                throw new ArgumentNullException(csv);

            using (var reader = new StreamReader(csv))
            {
                int ceoCounter = 0;
                HashSet<string> _managers = new HashSet<string>();
                HashSet<string> _employees = new HashSet<string>();

                while (!reader.EndOfStream)
                {

                    int output;
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    // Check for salary varied
                    if (!int.TryParse(values[2], out output)||output<0)
                    {
                        throw new InvalidCastException(values[2]);
                    }
                    if (!employeesAndSalaries.ContainsKey(values[0]))
                    {
                        employeesAndSalaries.Add(values[0], output);
                    }
                    // Check for more than one manager
                    if (employees.ContainsKey(values[1]))
                    {
                        if (employees[values[1]] == values[1])
                        {
                            throw new Exception();
                        }
                    }
                    // Check more than two CEO
                    if (values[1] == "" && ceoCounter > 1)
                    {
                        throw new Exception();
                    }
                    // Check for circular reference
                    if (employees.ContainsKey(values[1]))
                    {
                        if (employees[values[1]] == values[0])
                        {
                            throw new Exception();
                        }
                    }

                    if (values[0] != "")
                    {
                        _employees.Add(values[0]);

                    }
                    if (values[1] != "")
                    {
                        _managers.Add(values[1]);

                    }

                    employees.Add(values[0], values[1]);
                }
                //Check for Manager not an employee

                if (!_managers.IsSubsetOf(_employees))
                {
                    throw new Exception();
                }


            }

        }

        public long SalaryBudget(string manager)
        {
            long salary = 0;
            foreach (var item in employees)
            {
                if (item.Value != "")
                {
                    if (lists.ContainsKey(item.Value))
                    {
                        lists[item.Value].Add(item.Key);

                        continue;
                    }

                    lists.Add(item.Value, new List<string>());
                    lists[item.Value].Add(item.Key);
                }

            }

            if (lists.ContainsKey(manager))
            {
                var choice = lists[manager];

                foreach (var item in choice)
                {
                    salary += employeesAndSalaries[item];
                }

                salary += employeesAndSalaries[manager];
            }
            return salary;
        }

    }
}
