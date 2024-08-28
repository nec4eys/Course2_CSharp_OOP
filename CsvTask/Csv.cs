using System.Text;

namespace CsvTask;

internal class Csv
{
    public static string CreateMessageWithIndentation(string message, int indentationSize)
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < indentationSize; i++)
        {
            stringBuilder.Append('\t');
        }

        return stringBuilder.Append(message).ToString();
    }

    public static void ConvertCsvToHtml(string inputPath, string outputPath)
    {
        using StreamReader reader = new StreamReader(inputPath);
        using StreamWriter writer = new StreamWriter(outputPath);

        writer.WriteLine("<!DOCTYPE html>");
        writer.WriteLine(CreateMessageWithIndentation("<html>", 0));
        writer.WriteLine(CreateMessageWithIndentation("<head>", 0));
        writer.WriteLine(CreateMessageWithIndentation("<title>Таблица</title>", 1));
        writer.WriteLine(CreateMessageWithIndentation("<meta charset=\"utf-8\">", 1));
        writer.WriteLine(CreateMessageWithIndentation("</head>", 0));
        writer.WriteLine(CreateMessageWithIndentation("<body>", 0));
        writer.WriteLine(CreateMessageWithIndentation("<table border=\"1\">", 1));

        string? currentLine;

        bool isNewRow = true;

        while ((currentLine = reader.ReadLine()) != null)
        {
            if (isNewRow)
            {
                writer.WriteLine(CreateMessageWithIndentation("<tr>", 2));
                writer.Write(CreateMessageWithIndentation("<td>", 3));
            }

            for (int i = 0; i < currentLine.Length; i++)
            {
                char currentChar = currentLine[i];

                if (currentChar == '"')
                {
                    if (isNewRow || i + 1 >= currentLine.Length || currentLine[i + 1] != '"')
                    {
                        isNewRow = !isNewRow;
                        continue;
                    }

                    i++;
                }

                if (currentChar == ',')
                {
                    if (isNewRow)
                    {
                        writer.WriteLine("</td>");
                        writer.Write(CreateMessageWithIndentation("<td>", 3));

                        continue;
                    }
                }

                switch (currentChar)
                {
                    case '<':
                        writer.Write("&lt;");
                        break;
                    case '>':
                        writer.Write("&gt;");
                        break;
                    case '&':
                        writer.Write("&amp;");
                        break;
                    default:
                        writer.Write(currentChar);
                        break;
                }
            }

            if (!isNewRow)
            {
                writer.Write("<br/>");
            }
            else
            {
                writer.WriteLine("</td>");
                writer.WriteLine(CreateMessageWithIndentation("</tr>", 2));
            }
        }

        writer.WriteLine(CreateMessageWithIndentation("</table>", 1));
        writer.WriteLine(CreateMessageWithIndentation("</body>", 0));
        writer.WriteLine(CreateMessageWithIndentation("</html>", 0));
    }

    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("В аргументах программы нужно указать два реальных пути к файлам. Первым путь файла для чтения, Вторым путь файла для записи");
            return;
        }
        
        try
        {
            ConvertCsvToHtml(args[0], args[1]);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Случилась непредвиденная ошибка! " + e.Message);
        }
    }
}
