using System;
using System.Diagnostics;
using System.Text;
using Main.Common;

namespace Main.Tasks.Level2
{
    public class Task17_StringPerformance : ITask
    {
        public string Title => "StringBuilder vs конкатенация";
        public string Description => "Сравнение производительности сборки строки через оператор '+' и StringBuilder.";
        public string[] Requirements => new[]
        {
            "Собрать строку из 10 000 (или 100 000) чисел двумя способами.",
            "Замерить время каждого через Stopwatch.",
            "Вывести оба времени и разницу.",
            "Объяснить в комментарии, почему StringBuilder быстрее."
        };

        public void Run()
        {
            int iterations = 20000;
            Stopwatch sw = Stopwatch.StartNew();
            string concatResult = "";
            for (int i = 0; i < iterations; i++)
            {
                concatResult += i;
            }
            sw.Stop();
            long concatTime = sw.ElapsedMilliseconds;
            sw.Restart();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                sb.Append(i);
            }
            string sbResult = sb.ToString();
            sw.Stop();
            long sbTime = sw.ElapsedMilliseconds;
            Console.WriteLine($"Количество итераций: {iterations}");
            Console.WriteLine($"Время через оператор '+': {concatTime} мс");
            Console.WriteLine($"Время через StringBuilder: {sbTime} мс");
            if (sbTime > 0)
            {
                Console.WriteLine($"Разница в скорости: StringBuilder быстрее примерно в {(double)concatTime / sbTime:F1} раз(а).");
            }
            else
            {
                Console.WriteLine("StringBuilder выполнил операцию настолько быстро, что время составило 0 мс.");
            }
        }
    }
}