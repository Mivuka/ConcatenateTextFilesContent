using System.Text;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter directory");
        string filesDirectory = Console.ReadLine();

        var txtFilesPaths = Directory.EnumerateFiles(filesDirectory, "*.txt");

        var sb = new StringBuilder();

        foreach (var txtFilePath in txtFilesPaths)
        {
            var text = File.ReadAllTextAsync(txtFilePath, CancellationToken.None).Result;
            sb.Append(text + "\n");
        }

        File.WriteAllTextAsync($"{filesDirectory}//Summary (total files counted {txtFilesPaths.Count()}).txt", 
            sb.ToString(), 
            Encoding.Unicode,
            CancellationToken.None);
    }
}