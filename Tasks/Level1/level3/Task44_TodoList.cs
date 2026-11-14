using System;
using System.Collections.Generic;
using System.Linq;
using Main.Common;
using Main.Tasks.Level3.Todo;

namespace Main.Tasks.Level3
{
    public class Task44_TodoList : ITask
    {
        public string Title => "Мини-проект «Todo List» (JSON)";
        public string Description => "Консольное приложение для управления списком задач с сохранением в JSON (CRUD).";
        public string[] Requirements => new[]
        {
            "Классы TaskItem (Id, Title, IsDone) и TaskRepository (загрузка/сохранение в tasks.json).",
            "CRUD-операции: добавление, просмотр, отметка о выполнении, удаление.",
            "Интерактивное подменю для управления задачами.",
            "Обработка ошибок ввода и отсутствующего файла."
        };
        private readonly TaskRepository _repository = new();

        public void Run()
        {
            List<TaskItem> tasks = _repository.LoadTasks();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== МИНИ-ПРОЕКТ: TODO LIST ===");
                Console.WriteLine("1. Посмотреть все задачи");
                Console.WriteLine("2. Добавить новую задачу");
                Console.WriteLine("3. Отметить задачу как выполненную");
                Console.WriteLine("4. Удалить задачу");
                Console.WriteLine("5. Выйти из Todo List");
                Console.Write("\nВыберите действие: ");

                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    ShowTasks(tasks);
                }
                else if (choice == "2")
                {
                    AddTask(tasks);
                }
                else if (choice == "3")
                {
                    CompleteTask(tasks);
                }
                else if (choice == "4")
                {
                    DeleteTask(tasks);
                }
                else if (choice == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nНеверный выбор. Нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
        }

        private void ShowTasks(List<TaskItem> tasks)
        {
            Console.Clear();
            Console.WriteLine("--- Список задач ---");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    string status = task.IsDone ? "[X]" : "[ ]";
                    Console.WriteLine($"{task.Id}. {status} {task.Title}");
                }
            }
            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }

        private void AddTask(List<TaskItem> tasks)
        {
            Console.Clear();
            Console.WriteLine("--- Добавление задачи ---");
            Console.Write("Введите текст задачи: ");
            string? title = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(title))
            {
                int newId = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
                tasks.Add(new TaskItem { Id = newId, Title = title.Trim(), IsDone = false });
                _repository.SaveTasks(tasks);
                Console.WriteLine("Задача успешно добавлена и сохранена!");
            }
            else
            {
                Console.WriteLine("Название задачи не может быть пустым.");
            }

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }

        private void CompleteTask(List<TaskItem> tasks)
        {
            Console.Clear();
            Console.WriteLine("--- Отметка о выполнении ---");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Нет доступных задач.");
                Console.ReadKey();
                return;
            }

            foreach (var task in tasks)
            {
                string status = task.IsDone ? "[X]" : "[ ]";
                Console.WriteLine($"{task.Id}. {status} {task.Title}");
            }

            Console.Write("\nВведите ID задачи для отметки как выполненной: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = tasks.FirstOrDefault(t => t.Id == id);
                if (task != null)
                {
                    task.IsDone = true;
                    _repository.SaveTasks(tasks);
                    Console.WriteLine("Задача отмечена как выполненная!");
                }
                else
                {
                    Console.WriteLine("Задача с таким ID не найдена.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID.");
            }

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }

        private void DeleteTask(List<TaskItem> tasks)
        {
            Console.Clear();
            Console.WriteLine("--- Удаление задачи ---");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Нет доступных задач.");
                Console.ReadKey();
                return;
            }

            foreach (var task in tasks)
            {
                string status = task.IsDone ? "[X]" : "[ ]";
                Console.WriteLine($"{task.Id}. {status} {task.Title}");
            }

            Console.Write("\nВведите ID задачи для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = tasks.FirstOrDefault(t => t.Id == id);
                if (task != null)
                {
                    tasks.Remove(task);
                    _repository.SaveTasks(tasks);
                    Console.WriteLine("Задача успешно удалена!");
                }
                else
                {
                    Console.WriteLine("Задача с таким ID не найдена.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID.");
            }

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}