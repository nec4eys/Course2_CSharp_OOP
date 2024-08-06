using System.Reflection.PortableExecutable;
using System.Text;

namespace CsvTask;

internal class Csv
{
    public static string CreateMessageWithIndentation(string message, int indentationSize = 0)
    {
        StringBuilder indentation = new StringBuilder();

        for (int i = 0; i < indentationSize; i++)
        {
            indentation.Append('\t');
        }

        return indentation.Append(message).ToString();
    }

    public static void ConvertCsvToHtml(string inputPath, string outputPath)
    {
        using StreamReader reader = new StreamReader(inputPath);
        using StreamWriter writer = new StreamWriter(outputPath);

        writer.WriteLine("<!DOCTYPE html>");
        writer.WriteLine(CreateMessageWithIndentation("<html>", 0));
        writer.WriteLine(CreateMessageWithIndentation("<head>", 1));
        writer.WriteLine(CreateMessageWithIndentation("<title>Таблица</title>", 2));
        writer.WriteLine(CreateMessageWithIndentation("<meta charset=\"utf-8\">", 2));
        writer.WriteLine(CreateMessageWithIndentation("</head>", 1));
        writer.WriteLine(CreateMessageWithIndentation("<body>", 1));
        writer.WriteLine(CreateMessageWithIndentation("<table border=\"1\">", 2));

        string? currentLine;

        bool isNewRow = true;

        while ((currentLine = reader.ReadLine()) != null)
        {
            if (isNewRow)
            {
                writer.WriteLine(CreateMessageWithIndentation("<tr>", 3));
                writer.Write(CreateMessageWithIndentation("<td>", 4));
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
                        writer.Write(CreateMessageWithIndentation("<td>", 4));

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
                writer.WriteLine(CreateMessageWithIndentation("</tr>", 3));
            }
        }

        writer.WriteLine(CreateMessageWithIndentation("</table>", 2));
        writer.WriteLine(CreateMessageWithIndentation("</body>", 1));
        writer.WriteLine(CreateMessageWithIndentation("</html>", 0));
    }

    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("В аргументах программы нужно указать два реальных пути к файлам");
            return;
        }

        try
        {
            ConvertCsvToHtml(args[0], args[1]);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("В аргументах программы нужно указать два реальных пути к файлам");
            return;
        }
    }
}
