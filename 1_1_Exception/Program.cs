namespace _1_1_Exception
{
    class MyExceptionClass : Exception
    {
        public DateTime Time { get; set; } = DateTime.Now;

        public MyExceptionClass() { }
        public MyExceptionClass(string? message) : base(message) { }
        public MyExceptionClass(string? message, Exception? innerException) : base(message, innerException) { }
    }

    internal class Program
    {
        public static int GetInt32FromConsole()
        {
            try
            {
                return int.Parse(Console.ReadLine()!);
            }
            catch (FormatException ex)
            {
                throw new MyExceptionClass("Рядок містить недопустимі символи (потрібні лише цифри 0-9)", ex);
            }
            catch (OverflowException ex)
            {
                throw new MyExceptionClass("Число виходить за межі діапазону int", ex);
            }
        }

        static long CalculateExpression(string expression)
        {
            string[] parts = expression.Split('*');
            long result = 1;

            foreach (string part in parts)
            {
                int number = int.Parse(part);
                result = result * number;

                if (result > int.MaxValue || result < int.MinValue)
                {
                    throw new OverflowException("Результат виходить за межі діапазону int");
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region Task 1
            Console.WriteLine("Введіть набір цифр 0-9 : ");
            int number = 0;
            try
            {
                number = GetInt32FromConsole();
                Console.WriteLine($"Число = {number}");
            }
            catch (MyExceptionClass ex)
            {
                Console.WriteLine("Перехоплено власне виключення !");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Time);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Кінець завдання 1");
            }
            #endregion

            Console.WriteLine();

            #region Task 2
            Console.WriteLine("Введіть вираз (наприклад, 3*2*1*4) : ");
            try
            {
                string expression = Console.ReadLine()!;
                long res = CalculateExpression(expression);
                Console.WriteLine($"Результат = {res}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Неправильний формат виразу");
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Переповнення");
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Порожнє введення");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Кінець завдання 2");
            }

            #endregion
        }
    }
}