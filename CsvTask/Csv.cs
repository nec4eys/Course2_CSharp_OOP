namespace CsvTask
{
    internal class Csv
    {
        public static string CreateIndentation(int count)
        {
            string indentation = "";

            for (int i = 0; i < count; i++)
            {
                indentation += "\t";
            }

            return indentation;
        }

        static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader(args[0]);
            using StreamWriter writer = new StreamWriter(args[1]);

            int indentationCount = 0;

            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine(CreateIndentation(indentationCount++) + "<html>");

            writer.WriteLine(CreateIndentation(indentationCount++) + "<head>");
            writer.WriteLine(CreateIndentation(indentationCount) + "<title>" + "Таблица" + "</title>");
            writer.WriteLine(CreateIndentation(indentationCount) + "<meta charset=\"utf-8\">");
            writer.WriteLine(CreateIndentation(--indentationCount) + "</head>");

            writer.WriteLine(CreateIndentation(indentationCount++) + "<body>");
            writer.WriteLine(CreateIndentation(indentationCount++) + "<table>");

            string currentLine;

            bool isNewRow = true;

            string lineCell = "";

            while ((currentLine = reader.ReadLine()) != null)
            {
                if (isNewRow)
                {
                    writer.WriteLine(CreateIndentation(indentationCount++) + "<tr>");
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
                        else
                        {
                            i++;
                        }
                    }

                    if (currentChar == ',')
                    {
                        if (isNewRow)
                        {
                            writer.WriteLine(CreateIndentation(indentationCount) + "<td>" + lineCell + "</td>");
                            lineCell = "";
                            continue;
                        }
                    }

                    switch (currentChar)
                    {
                        case '<':
                            lineCell += "&lt";
                            break;
                        case '>':
                            lineCell += "&gt";
                            break;
                        case '&':
                            lineCell += "&amp";
                            break;
                        default:
                            lineCell += currentChar;
                            break;
                    }
                }

                if (!isNewRow)
                {
                    lineCell += "<br/>";
                }
                else
                {
                    writer.WriteLine(CreateIndentation(indentationCount) + "<td>" + lineCell + "</td>");
                    writer.WriteLine(CreateIndentation(--indentationCount) + "</tr>");
                    lineCell = "";
                }
            }

            writer.WriteLine(CreateIndentation(--indentationCount) + "</table>");
            writer.WriteLine(CreateIndentation(--indentationCount) + "</body>");
            writer.WriteLine(CreateIndentation(--indentationCount) + "</html>");
        }
    }
}
