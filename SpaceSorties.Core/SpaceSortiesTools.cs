namespace SpaceSorties.Core
{
    public class SpaceSortiesTools
    {
        private DriveInfo[] allDrives;
        public DriveInfo[] AllDrives
        {
            get
            {
                return allDrives;
            }
        }

        public SpaceSortiesTools()
        {
            allDrives = DriveInfo.GetDrives();
        }

        public void PrintAvailableDrives()
        {
            foreach (DriveInfo drive in allDrives)
            {
                Console.WriteLine($"Drive: {drive.Name}");
            }
        }

    }
}

