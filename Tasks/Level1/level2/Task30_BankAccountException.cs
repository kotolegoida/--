using System;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class InsufficientFundsException : Exception
    {
        public decimal CurrentBalance { get; }
        public decimal RequestedAmount { get; }

        public InsufficientFundsException(decimal currentBalance, decimal requestedAmount)
            : base($"Недостаточно средств на счете. Баланс: {currentBalance:F2}, запрошено: {requestedAmount:F2}")
        {
            CurrentBalance = currentBalance;
            RequestedAmount = requestedAmount;
        }
    }

    public class BankAccount
    {
        private decimal _balance;

        public decimal Balance => _balance;

        public BankAccount(decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentException("Начальный баланс не может быть отрицательным.", nameof(initialBalance));
            }
            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма пополнения должна быть больше нуля.", nameof(amount));
            }
            _balance += amount;
            Console.WriteLine($"[Депозит] Успешно зачислено: {amount:F2} руб. Текущий баланс: {_balance:F2} руб.");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма снятия должна быть больше нуля.", nameof(amount));
            }

            if (amount > _balance)
            {
                throw new InsufficientFundsException(_balance, amount);
            }

            _balance -= amount;
            Console.WriteLine($"[Снятие] Успешно списано: {amount:F2} руб. Текущий баланс: {_balance:F2} руб.");
        }
    }

    public class Task30_BankAccountException : ITask
    {
        public string Title => "BankAccount + свой Exception";
        public string Description => "Реализация банковского счета с инкапсулированным балансом и генерацией собственного исключения InsufficientFundsException.";
        public string[] Requirements => new[]
        {
            "Класс BankAccount с приватным балансом.",
            "Методы Deposit(decimal), Withdraw(decimal).",
            "Свой класс InsufficientFundsException : Exception.",
            "Withdraw бросает исключение, если сумма больше баланса.",
            "Продемонстрировать: успешное снятие и попытку снять больше баланса (с try/catch)."
        };

        public void Run()
        {
            Console.WriteLine("--- Создаем банковский счет с балансом 5000 руб. ---");
            BankAccount account = new BankAccount(5000m);
            Console.WriteLine("\n1. Тест успешных операций:");
            account.Deposit(1500m);
            try
            {
                account.Withdraw(2000m);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.WriteLine("\n2. Тест попытки снятия суммы, превышающей баланс:");
            decimal tooMuch = 10000m;
            try
            {
                Console.WriteLine($"Попытка снять {tooMuch:F2} руб...");
                account.Withdraw(tooMuch);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"[Перехвачено InsufficientFundsException]: {ex.Message}");
                Console.WriteLine($"Баланс остался неизменным и не ушел в минус: {account.Balance:F2} руб.");
            }
        }
    }
}