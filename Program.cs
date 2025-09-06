using System;

class Calculator
{
    private double memory = 0;
    private double currentValue = 0;
    
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        calculator.Run();
    }
    
    public void Run()
    {
        Console.WriteLine("Операции: +, -, *, /, %, sqr (квадрат), sqrt (корень), rec (1/x)");
        Console.WriteLine("Память: m+, m-, mr, mc");
        Console.WriteLine("Введите 'exit' для выхода");
        
        while (true)
        {
            Console.Write("\nВведите команду: ");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "exit")
                break;
                
            ProcessInput(input);
        }
    }
    
    private void ProcessInput(string input)
    {
        string[] parts = input.Split(' ');
        
        switch (parts[0].ToLower())
        {
            case "m+":
                memory += currentValue;
                memory = Math.Round(memory, 5);
                Console.WriteLine($"Память: {memory:F5}");
                break;
                
            case "m-":
                memory -= currentValue;
                memory = Math.Round(memory, 5);
                Console.WriteLine($"Память: {memory:F5}");
                break;
                
            case "mr":
                currentValue = memory;
                Console.WriteLine($"Восстановлено: {currentValue:F5}");
                break;
                
            case "mc":
                memory = 0;
                Console.WriteLine("Память очищена");
                break;
                
            case "sqrt":
                double sqrtNumber;
                if (parts.Length > 1)
                    sqrtNumber = double.Parse(parts[1]);
                else
                    sqrtNumber = currentValue;
                
                if (sqrtNumber < 0)
                {
                    Console.WriteLine("Ошибка: нельзя извлечь корень из отрицательного числа");
                    break;
                }
                
                currentValue = Math.Sqrt(sqrtNumber);
                currentValue = Math.Round(currentValue, 5);
                Console.WriteLine($"Результат: {currentValue:F5}");
                break;
                
            case "rec":
                double recNumber;
                if (parts.Length > 1)
                    recNumber = double.Parse(parts[1]);
                else
                    recNumber = currentValue;
                
                if (recNumber == 0)
                {
                    Console.WriteLine("Ошибка: деление на ноль невозможно");
                    break;
                }
                
                currentValue = 1 / recNumber;
                currentValue = Math.Round(currentValue, 5);
                Console.WriteLine($"Результат: {currentValue:F5}");
                break;
                
            case "sqr":
                double sqrNumber;
                if (parts.Length > 1)
                    sqrNumber = double.Parse(parts[1]);
                else
                    sqrNumber = currentValue;
                
                currentValue = sqrNumber * sqrNumber;
                currentValue = Math.Round(currentValue, 5);
                Console.WriteLine($"Результат: {currentValue:F5}");
                break;
                
            default:
                if (parts.Length >= 3)
                {
                    double num1 = double.Parse(parts[0]);
                    string op = parts[1];
                    double num2 = double.Parse(parts[2]);
                    
                    if ((op == "/" || op == "%") && num2 == 0)
                    {
                        Console.WriteLine("Ошибка: деление на ноль невозможно");
                        break;
                    }
                    
                    currentValue = op switch
                    {
                        "+" => num1 + num2,
                        "-" => num1 - num2,
                        "*" => num1 * num2,
                        "/" => num1 / num2,
                        "%" => num1 % num2,
                        _ => currentValue
                    };
                    
                    currentValue = Math.Round(currentValue, 5);
                    Console.WriteLine($"Результат: {currentValue:F5}");
                }
                break;
        }
    }
}