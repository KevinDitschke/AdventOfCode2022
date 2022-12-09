namespace Day7;

public class Folder
{
    public string Name { get; set; }
    public long Size { get; set; }
    public Dictionary<string, Folder> Subfolders { get; set; }
    public Folder Parent { get; set; }
    public Folder CurrentFolder { get; set; }

    public Folder(string name, long size, Folder parent = null)
    {
        Name = name;
        Size = size;
        Parent = parent;
        Subfolders = new Dictionary<string, Folder>();
        CurrentFolder = this;
    }

    public Folder GetParent()
    {
        return Parent;
    }

    public Folder GetSubfolder(string name)
    {
        if (Subfolders.ContainsKey(name))
        {
            return Subfolders[name];
        }
        return null;
    }

    public void MoveUp()
    {
        if (CurrentFolder.Parent != null)
        {
            CurrentFolder = CurrentFolder.Parent;
        }
    }

    public void MoveDown(string name)
    {
        if (CurrentFolder.Subfolders.ContainsKey(name))
        {
            CurrentFolder = CurrentFolder.Subfolders[name];
        }
    }

    public long GetTotalSize()
    {
        return GetTotalSize(this, 0);
    }

    private long GetTotalSize(Folder folder, long sum)
    {
        sum += folder.Size;
        foreach (var subfolder in folder.Subfolders.Values)
        {
            sum = GetTotalSize(subfolder, sum);
        }
        return sum;
    }
}