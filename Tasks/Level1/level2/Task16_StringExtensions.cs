using System;

namespace Main.Tasks.Level2
{
    public static class StringExtensions
    {
        /// <summary>
        /// Проверяет, является ли строка палиндромом (без использования LINQ).
        /// </summary>
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str)) return true;

            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                if (char.ToLower(str[left]) != char.ToLower(str[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        /// <summary>
        /// Подсчитывает количество слов в строке (без использования LINQ).
        /// </summary>
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;

            int count = 0;
            bool inWord = false;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsWhiteSpace(str[i]))
                {
                    inWord = false;
                }
                else if (!inWord)
                {
                    inWord = true;
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Возвращает перевернутую строку (без использования LINQ).
        /// </summary>
        public static string ReverseString(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            char[] chars = str.ToCharArray();
            int left = 0;
            int right = chars.Length - 1;

            while (left < right)
            {
                char temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;
                left++;
                right--;
            }

            return new string(chars);
        }
    }
}