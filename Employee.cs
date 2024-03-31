namespace DZ_8
{
    class Employee(string name, int salary)
    {
        public string Name { get; set; } = name;
        public int Salary { get; set; } = salary;
        public Employee Left { get; set; }
        public Employee Right { get; set; }

    }
}