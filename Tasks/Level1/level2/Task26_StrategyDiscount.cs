using System;
using Main.Common;

namespace Main.Tasks.Level2
{
    public interface IDiscountStrategy
    {
        decimal Apply(decimal price);
    }
    public class NoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price)
        {
            return price;
        }
    }
    public class VipDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price)
        {
            return price * 0.9m;
        }
    }
    public class PromoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price)
        {
            return price * 0.8m;
        }
    }
    public class PriceCalculator
    {
        private readonly IDiscountStrategy _discountStrategy;

        public PriceCalculator(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public decimal CalculatePrice(decimal basePrice)
        {
            return _discountStrategy.Apply(basePrice);
        }
    }

    public class Task26_StrategyDiscount : ITask
    {
        public string Title => "Паттерн «Стратегия» (скидки)";
        public string Description => "Реализация калькулятора скидок с использованием паттерна проектирования «Стратегия».";
        public string[] Requirements => new[]
        {
            "Интерфейс IDiscountStrategy с методом Apply(decimal price).",
            "Реализации: NoDiscount, VipDiscount (10%), PromoDiscount (20%).",
            "Класс PriceCalculator, принимающий стратегию в конструкторе.",
            "Продемонстрировать расчёт цены с каждой стратегией."
        };

        public void Run()
        {
            decimal initialPrice = 1000m;
            Console.WriteLine($"Исходная цена товара: {initialPrice:F2} руб.\n");
            PriceCalculator normalCalc = new PriceCalculator(new NoDiscount());
            decimal price1 = normalCalc.CalculatePrice(initialPrice);
            Console.WriteLine($"1. Без скидки (NoDiscount): {price1:F2} руб.");
            PriceCalculator vipCalc = new PriceCalculator(new VipDiscount());
            decimal price2 = vipCalc.CalculatePrice(initialPrice);
            Console.WriteLine($"2. VIP-скидка 10% (VipDiscount): {price2:F2} руб.");
            PriceCalculator promoCalc = new PriceCalculator(new PromoDiscount());
            decimal price3 = promoCalc.CalculatePrice(initialPrice);
            Console.WriteLine($"3. Промо-скидка 20% (PromoDiscount): {price3:F2} руб.");
        }
    }
}