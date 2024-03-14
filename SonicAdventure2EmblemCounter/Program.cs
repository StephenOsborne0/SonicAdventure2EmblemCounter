namespace SonicAdventure2EmblemCounter
{
    public static class Program
    {
        private static MemoryHelper _memoryHelper;
        private static int _emblems;

        public static void Main(string[] args)
        {
            _memoryHelper = new MemoryHelper();

            try
            {
                while (true)
                {
                    int emblems = _memoryHelper.ReadInt(0x0174B032);

                    if (emblems != _emblems)
                    {
                        _emblems = emblems;
                        WriteToFile();
                    }
                    
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }

        private static void WriteToFile()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "emblems.txt");
            
            try
            {
                // Write the emblems count to a text file
                using (StreamWriter sw = new(filePath))
                {
                    sw.WriteLine($"Emblems: {_emblems}");
                }
                
                Console.WriteLine($"Emblems: {_emblems}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
}
