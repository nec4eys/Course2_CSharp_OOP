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

    static void Main(string[] args)
    {
        string standardInputPath = "..\\..\\..\\input.txt";
        string standardOutputPath = "..\\..\\..\\output.txt";

        if (args.Length == 0)
        {
            args = [standardInputPath, standardOutputPath];
        }

        try
        {
            if (string.IsNullOrEmpty(args[1]))
            {
                args[1] = standardOutputPath;
            }
        }
        catch (IndexOutOfRangeException)
        {
            args = [args[0], standardOutputPath];
        }

        StreamReader reader = null;
        StreamWriter writer = null;

        try
        {
            reader = new StreamReader(args[0]);
            writer = new StreamWriter(args[1]);

            int indentationSize = 0;

            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine(CreateMessageWithIndentation("<html>", indentationSize));
            indentationSize++;

            writer.WriteLine(CreateMessageWithIndentation("<head>", indentationSize));
            indentationSize++;

            writer.WriteLine(CreateMessageWithIndentation("<title>Таблица</title>", indentationSize));
            writer.WriteLine(CreateMessageWithIndentation("<meta charset=\"utf-8\">", indentationSize));

            --indentationSize;
            writer.WriteLine(CreateMessageWithIndentation("</head>", indentationSize));

            writer.WriteLine(CreateMessageWithIndentation("<body>", indentationSize));
            indentationSize++;

            writer.WriteLine(CreateMessageWithIndentation("<table border=\"1\">", indentationSize));
            indentationSize++;

            string currentLine;

            bool isNewRow = true;

            StringBuilder cell = new StringBuilder();

            while ((currentLine = reader.ReadLine()) != null)
            {
                if (isNewRow)
                {
                    writer.WriteLine(CreateMessageWithIndentation("<tr>", indentationSize));
                    indentationSize++;
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
                            writer.WriteLine(CreateMessageWithIndentation(cell.Insert(0, "<td>").Append("</td>").ToString(), indentationSize));

                            cell.Clear();
                            continue;
                        }
                    }

                    switch (currentChar)
                    {
                        case '<':
                            cell.Append("&lt;");
                            break;
                        case '>':
                            cell.Append("&gt;");
                            break;
                        case '&':
                            cell.Append("&amp;");
                            break;
                        default:
                            cell.Append(currentChar);
                            break;
                    }
                }

                if (!isNewRow)
                {
                    cell.Append("<br/>");
                }
                else
                {
                    writer.WriteLine(CreateMessageWithIndentation(cell.Insert(0, "<td>").Append("</td>").ToString(), indentationSize));

                    --indentationSize;
                    writer.WriteLine(CreateMessageWithIndentation("</tr>", indentationSize));

                    cell.Clear();
                }
            }

            --indentationSize;
            writer.WriteLine(CreateMessageWithIndentation("</table>", indentationSize));

            --indentationSize;
            writer.WriteLine(CreateMessageWithIndentation("</body>", indentationSize));

            --indentationSize;
            writer.WriteLine(CreateMessageWithIndentation("</html>", indentationSize));
        }
        catch (FileNotFoundException)
        {
            throw new ArgumentException("The specified path is invalid", nameof(args));
        }
        finally
        {
            if (reader is IDisposable)
            {
                reader.Dispose();
            }

            if (writer is IDisposable)
            {
                writer.Dispose();
            }
        }
    }
}
