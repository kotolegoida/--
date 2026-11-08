using System;
using System.Collections.Generic;
using Main.Common;

namespace Main.Tasks.Level2
{
    // Вспомогательный класс для демонстрации оператора ?. (безопасный доступ)
    public class UserProfile
    {
        // Указываем string? чтобы избежать предупреждения CS8618 о незаполненном nullable-свойстве
        public string? Name { get; set; }
    }

    public class Task23_NullableTypes : ITask
    {
        public string Title => "Nullable-типы, ??, ?.";
        public string Description => "Демонстрация работы с nullable-типами, операторами ??, ?., а также свойствами HasValue и Value.";
        public string[] Requirements => new[]
        {
            "Метод int? FindValue(string key) — возвращает null, если ключа нет.",
            "Использовать ?? для значения по умолчанию.",
            "Использовать ?. для безопасного доступа к свойству объекта, который может быть null.",
            "Использовать HasValue / Value с проверкой.",
            "Продемонстрировать на примере с найденным и ненайденным ключом."
        };

        // Имитируем хранилище данных (словарь)
        private Dictionary<string, int> _storage = new Dictionary<string, int>
        {
            { "age", 25 },
            { "score", 100 }
        };

        public void Run()
        {
            // 1. Демонстрация метода FindValue и оператора ?? (значение по умолчанию)
            Console.WriteLine("--- 1. Поиск значений в словаре и оператор ?? ---");
            string existingKey = "age";
            string missingKey = "balance";

            int? foundVal = FindValue(existingKey);
            int? missingVal = FindValue(missingKey);

            // Используем ?? для подстановки значения по умолчанию, если результат null
            int resultExisting = foundVal ?? -1;
            int resultMissing = missingVal ?? -1;

            Console.WriteLine($"Ключ '{existingKey}': найден, значение = {resultExisting}");
            Console.WriteLine($"Ключ '{missingKey}': не найден, сработал '??' -> {resultMissing}");

            // 2. Демонстрация HasValue и Value с явной проверкой
            Console.WriteLine("\n--- 2. Использование HasValue и Value ---");
            if (foundVal.HasValue)
            {
                Console.WriteLine($"foundVal.HasValue истинно. Значение через .Value: {foundVal.Value}");
            }

            if (!missingVal.HasValue)
            {
                Console.WriteLine($"missingVal.HasValue ложно (значение равно null).");
            }

            // 3. Демонстрация оператора ?. (безопасный доступ к членам объекта)
            Console.WriteLine("\n--- 3. Безопасный доступ с помощью ?. ---");
            UserProfile userWithData = new UserProfile { Name = "Алексей" };
            UserProfile? userNull = null; // Явно указываем, что объект может быть null

            // Безопасное получение длины имени у существующего объекта
            int? length1 = userWithData?.Name?.Length;
            // Безопасное получение длины имени у null-объекта (вернет null вместо исключения NullReferenceException)
            int? length2 = userNull?.Name?.Length;

            Console.WriteLine($"Длина имени существующего пользователя: {length1 ?? 0}");
            Console.WriteLine($"Длина имени null-пользователя (безопасно): {(length2.HasValue ? length2.Value.ToString() : "null (нет объекта)")}");
        }

        // Метод, возвращающий nullable int (int?)
        private int? FindValue(string key)
        {
            if (_storage.ContainsKey(key))
            {
                return _storage[key];
            }
            return null; // Ключ отсутствует, возвращаем null
        }
    }
}