namespace POCConsole
{
    internal static class NullObjectPattern
    {
        static List<Customer> customers = new List<Customer> {
            new Customer
            {
                FirstName = "AAA",
                LastName = "BBBB"
            }
            };

        public static void ExecuteBad()
        {
            customers.Add(GetCustomer());

            var employees = GetCustomers();

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1}", employee.FirstName,
            employee.LastName);
            }
            Console.ReadLine();
        }

        public static void ExecuteRight()
        {
            customers.Add(GetCustomer());

            var employees = GetCustomers();

            foreach (var employee in employees)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                GetByFirstName(employee.FirstName);
#pragma warning restore CS8604 // Possible null reference argument.
            }

            Console.ReadLine();
        }


        private static List<Customer> GetCustomers()
        {
            return customers ?? new List<Customer>();
        }

        public static Customer GetByFirstName(string firstName)
        {
            var customer = customers.FirstOrDefault(c => c.FirstName == firstName);
            if (customer == null) { return Customer.NotFound; }

            return customer;
        }

        private static Customer GetCustomer()
        {
            return Customer.NotFound;
        }
    }

    public class Customer
    {
        public static Customer NotFound = new Customer() { FirstName = String.Empty, LastName = String.Empty };
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
