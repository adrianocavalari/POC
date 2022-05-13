namespace POCConsole
{
    internal class NullsBreakPolymorphism
    {
        public static void ExecuteBad()
        {
            var employees = GetEmployees();

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1}: {2} days", employee.FirstName,
            employee.LastName, employee.DateTerminatedInDays());
            }
            Console.ReadLine();
        }

        public static void ExecuteRight()
        {
            var employees = GetEmployees();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToDisplayString());
            }

            Console.ReadLine();
        }

        private static List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee()
            {
                FirstName = "Steve",
                LastName = "Smith",
                DateHired = new DateTime(2014, 6, 1)
            });
            employees.Add(new Employee()
            {
                FirstName = "John",
                LastName = "Doe",
                DateHired = new DateTime(2015, 6, 1),
                DateTerminated = new DateTime(2015, 7, 1)
            });
#pragma warning disable CS8604 // Possible null reference argument.
            employees.Add(GetEmployee());
#pragma warning restore CS8604 // Possible null reference argument.
            return employees;
        }

        private static Employee? GetEmployee()
        {
            return null;
        }
    }

    public class Employee
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime? DateTerminated { get; set; }

        public int DateTerminatedInDays(DateTime? currentDate = null)
        {
            DateTime endDate = currentDate ?? DateTime.Now;
            if (DateTerminated.HasValue)
            {
                endDate = DateTerminated.Value;
            }
            return (endDate - DateHired).Days;
        }
    }

    public static class EmployeeExtensions
    {
        public static string ToDisplayString(this Employee employee)
        {
            if (employee != null)
            {
                return string.Format("{0} {1}: {2} days", employee.FirstName,
            employee.LastName, employee.DateTerminatedInDays());
            }
            return "Unknown employee";
        }
    }
}
