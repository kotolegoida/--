using System;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class Temperature
    {
        private double _celsius;

        public double Celsius
        {
            get => _celsius;
            set
            {
                if (value < -273.15)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), 
                        value, 
                        "Температура не может быть ниже абсолютного нуля (-273.15 °C)."
                    );
                }
                _celsius = value;
            }
        }

        public double Fahrenheit => (_celsius * 9.0 / 5.0) + 32.0;

        public Temperature(double initialCelsius)
        {
            Celsius = initialCelsius;
        }

        public override string ToString()
        {
            return $"{Celsius:F2} °C ({Fahrenheit:F2} °F)";
        }
    }

    public class Task32_TemperatureValidation : ITask
    {
        public string Title => "Свойства с валидацией (Temperature)";
        public string Description => "Реализация класса Temperature с проверкой корректности данных в аксессоре set и вычисляемым свойством для Фаренгейта.";
        public string[] Requirements => new[]
        {
            "Свойство Celsius с проверкой в set: не ниже −273.15.",
            "При некорректном значении — бросать ArgumentOutOfRangeException.",
            "Вычисляемое свойство Fahrenheit (только get).",
            "Продемонстрировать корректное и некорректное присваивание."
        };

        public void Run()
        {
            Console.WriteLine("--- 1. Демонстрация корректного присваивания ---");
            try
            {
                Temperature temp = new Temperature(25.0);
                Console.WriteLine($"Установлена температура: {temp}");

                temp.Celsius = -40.0;
                Console.WriteLine($"Новая температура: {temp}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\n--- 2. Демонстрация некорректного присваивания (ниже абсолютного нуля) ---");
            try
            {
                Temperature temp = new Temperature(0.0);
                Console.WriteLine($"Исходная температура: {temp}");

                Console.WriteLine("Попытка установить значение -300 °C...");
                temp.Celsius = -300.0;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"[Перехвачено исключение]: {ex.ParamName} = {ex.ActualValue}");
                Console.WriteLine($"Сообщение: {ex.Message}");
            }
        }
    }
}