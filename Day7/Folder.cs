namespace Day7;

public class Folder
{
    public string? Name { get; set; }
    public int Size { get; set; } = 0;
    public Folder CurrentFolder { get; set; }
    public List<Folder> SubFolders { get; set; }
    public Folder Parent { get; set; }

    public Folder(string name, Folder parent)
    {
        Name = name;
        Parent = parent;
        SubFolders = new List<Folder>();
    }

    public void SetCurrentFolder(Folder folder)
    {
        CurrentFolder = folder;
    }
    
    public Folder MoveOneUp()
    {
        if (Parent != null)
            CurrentFolder = Parent;

        return CurrentFolder;
    }

    public void MoveToTopLevel()
    {
        while (Parent != null)
            MoveOneUp();
    }

    public void AddFolder(string name, Folder folder)
    {
        SubFolders.Add(new Folder(name, folder));
    }
}