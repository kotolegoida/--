using System;
using Main.Common;

namespace Main.Tasks.Level2
{
    public enum NotificationType
    {
        Email,
        Sms,
        Push
    }

    public interface INotification
    {
        void Send(string message);
    }

    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[Email] Отправка электронной почты: \"{message}\"");
        }
    }
    public class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[SMS] Отправка текстового сообщения: \"{message}\"");
        }
    }

    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[Push] Отправка пуш-уведомления на устройство: \"{message}\"");
        }
    }

    public static class NotificationFactory
    {
        public static INotification Create(NotificationType type)
        {
            return type switch
            {
                NotificationType.Email => new EmailNotification(),
                NotificationType.Sms => new SmsNotification(),
                NotificationType.Push => new PushNotification(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Неизвестный тип уведомления")
            };
        }
    }
    public class Task29_NotificationFactory : ITask
    {
        public string Title => "Паттерн «Фабрика» (уведомления)";
        public string Description => "Реализация порождающего паттерна проектирования «Фабрика» для создания различных типов уведомлений.";
        public string[] Requirements => new[]
        {
            "Интерфейс INotification с методом Send(string message).",
            "Реализации: EmailNotification, SmsNotification, PushNotification.",
            "NotificationFactory.Create(NotificationType type) — возвращает нужную реализацию.",
            "enum NotificationType { Email, Sms, Push }.",
            "Продемонстрировать создание и отправку через фабрику."
        };
        public void Run()
        {
            Console.WriteLine("--- Демонстрация паттерна «Фабрика» ---\n");
            INotification emailNotif = NotificationFactory.Create(NotificationType.Email);
            emailNotif.Send("Здравствуйте! Ваш заказ успешно оформлен.");
            INotification smsNotif = NotificationFactory.Create(NotificationType.Sms);
            smsNotif.Send("Ваш код подтверждения: 7392.");
            INotification pushNotif = NotificationFactory.Create(NotificationType.Push);
            pushNotif.Send("У вас новое сообщение от друга.");
        }
    }
}