using System;
using homework_7;

class Program
{
    public static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
    }

    static string ReverseString(string inputStroka)
    {
        return new string(inputStroka.Reverse().ToArray());
    }
    
    static void CheckIfFormattable(object input)
    {
        if (input is IFormattable)
        {
            Console.WriteLine($"{input} реализует IFormattable (проверяется с помощью 'is').");
        }
        else
        {
            Console.WriteLine($"{input} не реализует IFormattable (проверяется с помощью 'is').");
        }
        
        IFormattable formattable = input as IFormattable;
        if (formattable != null)
        {
            Console.WriteLine($"{input} реализует IFormattable (проверяется с помощью 'as').");
        }
        else
        {
            Console.WriteLine($"{input} не реализует IFormattable (проверяется с помощью 'as').");
        }
    }

    public static void SearchMail(ref string s)
    {
        int separatorIndex = s.IndexOf('#');
        if (separatorIndex != -1)
        {
            s = s[(separatorIndex + 1)..].Trim();
        }
        else
        {
            s = string.Empty;
        }
    }
    
    static void Task1()
    {
        // В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить
        // метод, который переводит деньги с одного счета на другой. У метода два параметра: ссылка
        // на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
        Console.WriteLine("Упражнение 8.1");
        BankAccount account1 = new BankAccount(100000, AccountType.Current);
        BankAccount account2 = new BankAccount(200000, AccountType.Current);
        account1.TransferTo(account2, 100);
        Console.WriteLine($"Баланс счета {account1.AccountNumber}: {account1.Balance}");
        Console.WriteLine($"Баланс счета {account2.AccountNumber}: {account2.Balance}");
    }

    static void Task2()
    {
        // Реализовать метод, который в качестве входного параметра принимает
        // строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
        // Протестировать метод.
        Console.WriteLine("Упражнен 8.2");
        string inputStroka = Console.ReadLine();
        string reversed = ReverseString(inputStroka);
        Console.WriteLine($"Обратная строка: {reversed}");
    }

    static void Task3()
    {
        // Написать программу, которая спрашивает у пользователя имя файла. Если
        // такого файла не существует, то программа выдает пользователю сообщение и заканчивает
        // работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
        // буквами.
        Console.WriteLine("Упражнение 8.3");
        Console.WriteLine("Введите имя исходного файла");
        string inputFileName = Console.ReadLine();
        string inputFilePath = $"../../../txtFiles/{inputFileName}";
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Файла с таким именем не существует");
            return;
        }

        Console.WriteLine("Введите меня выходного файла");
        string outputFileName = Console.ReadLine();
        string outputFilePath = $"../../../txtFiles/{outputFileName}";
        if (!File.Exists(outputFilePath))
        {
            Console.WriteLine("Файла с таким именем не существует");
            return;
        }

        try
        {
            string lines = File.ReadAllText(inputFilePath);
            string upper = lines.ToUpper();
            File.WriteAllText(outputFilePath, upper);
            Console.WriteLine(
                $"Содержимое файла {inputFileName} успешно записано в {outputFileName} заглавными буквами.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Произошла ошибка: {e.Message}");
        }
    }
    
    static void Task4()
    {
        // Реализовать метод, который проверяет реализует ли входной параметр
        // метода интерфейс System.IFormattable. Использовать оператор is и as. (Интерфейс
        // IFormattable обеспечивает функциональные возможности форматирования значения объекта
        // в строковое представление.)
        Console.WriteLine("Упражнение 8.4");
        int number = 8642;
        string text = "I love my friends";
        DateTime date = DateTime.Now;
            
        CheckIfFormattable(number);
        CheckIfFormattable(text);
        CheckIfFormattable(date);
    }

    static void Task5()
    {
        // Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail
        // адрес. Разделителем между ФИО и адресом электронной почты является символ #:
        // Иванов Иван Иванович # iviviv@mail.ru
        // Петров Петр Петрович # petr@mail.ru
        // Сформировать новый файл, содержащий список адресов электронной почты.
        // Предусмотреть метод, выделяющий из строки адрес почты. Методу в
        // качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:
        // public void SearchMail (ref string s).
        Console.WriteLine("Домашняя работа 8.1");
        Console.WriteLine("Введите имя входного файла:");
        string inputFileName = Console.ReadLine();
        string inputFilePath = $"../../../ex5/{inputFileName}";
            
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Ошибка: файл '{inputFileName}' не найден.");
            return;
        }

        Console.WriteLine("Введите имя выходного файла:");
        string outputFileName = Console.ReadLine();
        string outputFilePath = $"../../../ex5/{outputFileName}";
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Ошибка: файл '{outputFileName}' не найден.");
            return;
        }
            

        try
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (string line in lines)
                {
                    string email = line;
                    SearchMail(ref email);
                    
                    writer.WriteLine(email);
                }
            }

            Console.WriteLine($"Список адресов электронной почты успешно сохранён в файл '{outputFileName}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    static void Task6()
    {
        // Список песен. В методе Main создать список из четырех песен. В
        // цикле вывести информацию о каждой песне. Сравнить между собой первую и вторую
        // песню в списке. Песня представляет собой класс с методами для заполнения каждого из
        // полей, методом вывода данных о песне на печать, методом, который сравнивает между
        // собой два объекта:
        Console.WriteLine("Домашнее задание 8.2");
        List<Song> songs = new List<Song>
        {
            new Song { Name = "Песня о свободе", Author = "ДДТ" },
            new Song { Name = "Я хочу быть с тобой", Author = "Наутилус Помпилус" },
            new Song { Name = "Без тебя", Author = "7Б" },
            new Song { Name = "Я тебя люблю", Author = "Где Фантом?" }
        };
        for (int i = 1; i < songs.Count; i++)
        {
            songs[i].Prev = songs[i-1];
        }
        
        Console.WriteLine("Список песен:");
        foreach (var song in songs)
        {
            Console.WriteLine(song.Title());
        }
        
        Console.WriteLine("\nСравнение первой и второй песни:");
        if (songs[0].Equals(songs[1]))
        {
            Console.WriteLine("Песни одинаковые.");
        }
        else
        {
            Console.WriteLine("Песни разные.");
        }
    }
    
}