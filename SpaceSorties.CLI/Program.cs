﻿using SpaceSorties.Core;

namespace SpaceSorties.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpaceSorties.Core.Folder folder = new Folder("Name", 55559);
            Console.WriteLine(folder.Name);
            Console.WriteLine(folder.Size);

        }

        static void Trash()
        {
            /*
            Tools spaceSortiesTools = new Tools();

            spaceSortiesTools.PrintAvailableDrives();

            DriveInfo[] driveinfo = spaceSortiesTools.AllDrives;

            Console.WriteLine(driveinfo[0].Name);
            foreach (string folder in Directory.GetDirectories(driveinfo[0].Name))
            {
                Console.WriteLine(folder);
            }

            long result = spaceSortiesTools.GetDirectorySize(driveinfo[0].Name);
            result = driveinfo[0].TotalSize;
            Console.WriteLine($"Directory: {driveinfo[0].Name} {Tools.FormatSize(result)}");
            */

            Tools spaceSortiesTools = new Tools();
            spaceSortiesTools.PrintAvailableDrives();
            DriveInfo[] driveinfo = spaceSortiesTools.AllDrives;
            DriveInfo diskE = driveinfo[2];
            Console.WriteLine(diskE.Name);
            Console.WriteLine(Tools.FormatSize(Tools.GetDiskSize(diskE.Name)));
            Console.WriteLine(Tools.FormatSize(Tools.GetDirectorySizeNoEnumerate(diskE.Name)));
        }
    }
}
