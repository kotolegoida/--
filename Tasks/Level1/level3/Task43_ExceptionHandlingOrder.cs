using System;
using Main.Common;

namespace Main.Tasks.Level3
{
    public class Task43_ExceptionHandlingOrder : ITask
    {
        public string Title => "Множественные типы исключений и порядок catch";
        public string Description => "Демонстрация правильной иерархии catch-блоков, кастомных исключений и блока finally.";
        public string[] Requirements => new[]
        {
            "Создать метод, способный выбрасывать FormatException, DivideByZeroException и кастомное исключение.",
            "Настроить несколько catch-блоков в правильном порядке (от узких к общим).",
            "Продемонстрировать все сценарии исключений.",
            "Добавить блок finally с гарантированным выводом сообщения и объяснить важность порядка catch."
        };

        public void Run()
        {
            TestScenario("123");   
            TestScenario("abc");   
            TestScenario("0");     
            TestScenario("-5");    

            Console.WriteLine("\nРезультат:");
            Console.WriteLine("Порядок catch критически важен: более специализированные исключения (например, FormatException) должны идти раньше общих (Exception). Иначе общий catch перехватит всё первым, и компилятор выдаст ошибку недостижимого кода.");
        }

        private void TestScenario(string input)
        {
            Console.WriteLine($"\n--- Запуск сценария с входным значением: \"{input}\" ---");

            try
            {
                ProcessInput(input);
                Console.WriteLine("Операция выполнена успешно без ошибок.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[Перехвачено FormatException]: Неверный формат данных. Детали: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"[Перехвачено DivideByZeroException]: Попытка деления на ноль. Детали: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[Перехвачено Custom/InvalidOperationException]: Бизнес-ошибка. Детали: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Перехвачено общие Exception]: Непредвиденная ошибка. Детали: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("[Блок finally]: Ресурсы освобождены, шаг завершен.");
            }
        }

        private void ProcessInput(string input)
        {
            if (input == "abc")
            {
                throw new FormatException("Строка не может быть преобразована в число.");
            }

            int number = int.Parse(input);

            if (number < 0)
            {
                throw new InvalidOperationException("Отрицательные значения запрещены бизнес-логикой.");
            }

            int result = 100 / number;
            Console.WriteLine($"Результат деления 100 на {number} равен {result}.");
        }
    }
}