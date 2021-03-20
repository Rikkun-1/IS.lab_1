using System;
using System.Linq;
using System.Collections.Generic;

namespace IS_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                char[] russianAlfabet = Enumerable.Range('А', 'Я' - 'А' + 1)
                                                  .Select(Convert.ToChar)
                                                  .Concat("Ё .,")
                                                  .ToArray();

                Console.WriteLine("Введите ключевое слово: ");
                char[] keyword = Console.ReadLine()
                                        .ToUpper()
                                        .Distinct()
                                        .ToArray();

                char[] cipherAlfabet = new char[36];

                keyword.CopyTo(cipherAlfabet, 0);

                russianAlfabet.Except(keyword)
                              .ToArray()
                              .CopyTo(cipherAlfabet, keyword.Length);

                Console.WriteLine("Введите текст: ");
                char[] text = Console.ReadLine()
                                     .ToUpper()
                                     .ToArray();

                char[] encripted = text.Select(c => Array.IndexOf(cipherAlfabet, c))
                                       .Select(index => index + 6 < cipherAlfabet.Length
                                                        ? cipherAlfabet[index + 6]
                                                        : cipherAlfabet[index - 30])
                                       .ToArray();

                char[] decripted = encripted.Select(c => Array.IndexOf(cipherAlfabet, c))
                                            .Select(index => index - 6 >= 0
                                                             ? cipherAlfabet[index - 6]
                                                             : cipherAlfabet[index + 30])
                                            .ToArray();

                Console.Write("Русский алфавит    : ");
                Console.WriteLine(russianAlfabet);
                Console.Write("Ключевое слово     : ");
                Console.WriteLine(keyword);
                Console.Write("Алфавит шифра      : ");
                Console.WriteLine(cipherAlfabet);
                Console.Write("Текст              : ");
                Console.WriteLine(text);
                Console.Write("Зашифрованный текст: ");
                Console.WriteLine(encripted);
                Console.Write("Расшифрованый текст: ");
                Console.WriteLine(decripted);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("Доступны лишь русские буквы без цифр");
            }
        }
    }
}