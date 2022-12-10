// See https://aka.ms/new-console-template for more information
using System.IO;

Console.WriteLine("Choose your drive -->");
DriveInfo[] driveInfo = DriveInfo.GetDrives();
List<DriveInfo> listDriveInfo = driveInfo.ToList();
listDriveInfo.ForEach(d => Console.Write($"{d.Name}, "));
Console.WriteLine();

Console.Write("-->");
string driveName = Console.ReadLine();
Console.WriteLine(driveName);


//listDriveInfo.ForEach(d => d.Equals(DriveName) ? exist = true : exist = false);
static bool Exist(List<DriveInfo> listDriveInfo, string driveName)
{
    bool b = false;
    foreach (var d in listDriveInfo)
    {
        if (d.RootDirectory.Name.Equals(driveName))
        {
            b = true;
        }
    }
    return b;
}

bool exist = Exist(listDriveInfo, driveName);
if (!exist)
{
    Console.WriteLine("error!!! this drive is not exist");
}

DriveInfo drive = new(driveName);

ShowFilesinDrive(driveName);

static void ShowFilesinDrive(string driveName)
{
    var dir = new DirectoryInfo(driveName);

    if (!dir.Exists)
        throw new DirectoryNotFoundException($"Source drive not found: {dir.FullName}");

    DirectoryInfo[] dirs = dir.GetDirectories();

    foreach (FileInfo file in dir.GetFiles())
    {
        Console.WriteLine($"File Name: {file.Name}, Length: {file.Length}.");
    }

    foreach (DirectoryInfo d in dirs)
    {
        Console.WriteLine($"Directory: {d.Name} -->");
        ShowFilesinDrive(d.FullName);
    }

}

Console.WriteLine("Choose a file extension -->");
string fileExt = Console.ReadLine();

static void ShowFilesExtension(string driveName,string fileExt)
{
    var dir = new DirectoryInfo(driveName);

    if (!dir.Exists)
        throw new DirectoryNotFoundException($"Source drive not found: {dir.FullName}");

    DirectoryInfo[] dirs = dir.GetDirectories();

    foreach (FileInfo file in dir.GetFiles())
    {
        if(file.Extension== fileExt)
            Console.WriteLine($"File Name: {file.Name}.");
    }


    foreach (DirectoryInfo d in dirs)
    {
        //Console.WriteLine($"Directory: {d.Name} -->");
        ShowFilesExtension(d.FullName, fileExt);
    }

}

ShowFilesExtension(driveName, fileExt);
