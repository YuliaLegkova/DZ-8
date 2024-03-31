    using System;

namespace DZ_8
{
    class Program
    {
        static Employee Insert(Employee root, string name, int salary)
        {
            if (root == null)
            {
                root = new Employee(name, salary);
            }
            else if (salary < root.Salary)
            {
                root.Left = Insert(root.Left, name, salary);
            }
            else
            {
                root.Right = Insert(root.Right, name, salary);
            }
            return root;
        }
        static void InOrderTraversal(Employee root)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left);
                Console.WriteLine($"{root.Name} - {root.Salary}");
                InOrderTraversal(root.Right);
            }
        }

        static string Search(Employee root, int salary)
        {
            while (root != null)
            {
                if (salary == root.Salary)
                {
                    return root.Name;
                }
                else if (salary < root.Salary)
                {
                    root = root.Left;
                }
                else
                {
                    root = root.Right;
                }
            }
            return "такой сотрудник не найден";
        }

        static void Main(string[] args)
        {
            Employee root = null;
            string inputName;
            int inputSalary;

            do
            {
                Console.WriteLine("Введите имя сотрудника:");
                inputName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputName))
                {
                    break;
                }

                Console.WriteLine("Введите зарплату:");
                int.TryParse(Console.ReadLine(), out inputSalary);
                root = Insert(root, inputName, inputSalary);
            }
            while (!string.IsNullOrWhiteSpace(inputName));

            Console.WriteLine("\nСотрудники в порядке возрастания зарплат:");
            InOrderTraversal(root);

            string? choice = null;
            do
            {
                Console.WriteLine("\nВведите зарплату сотрудника для поиска:");
                int searchSalary;

                while (!int.TryParse(Console.ReadLine(), out searchSalary))
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число:");
                }

                string employeeName = Search(root, searchSalary);
                Console.WriteLine(employeeName);

                Console.WriteLine("Введите 1 для повторного поиска или 0 для завершения:");

                choice = Console.ReadLine();
                while (choice != "1" && choice != "0")
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите 1 или 0:");
                    choice = Console.ReadLine();
                }
            }
            while (choice == "1");
        }
    }
}

