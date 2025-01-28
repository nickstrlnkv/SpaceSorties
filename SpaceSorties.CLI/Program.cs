using SpaceSorties.Core;

namespace SpaceSorties.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpaceSortiesTools spaceSortiesTools = new SpaceSortiesTools();

            spaceSortiesTools.PrintAvailableDrives();
        }
    }
}
