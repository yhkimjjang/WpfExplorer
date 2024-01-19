using Jamesnet.Wpf.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Support.Local.Helpers;

public class FileService
{
    private readonly DirectoryManager _directoryManager;

    public FileService(DirectoryManager directoryManager)
    {
        _directoryManager = directoryManager;
    }

    public List<FolderInfo> GenerateRootNodes()
    {
        List<FolderInfo> roots = new List<FolderInfo>
        {
            CreateFolderInfo(1, "Download", IconType.ArrowDownBox, _directoryManager.DownloadDirectory),
            CreateFolderInfo(1, "Document", IconType.TextBox, _directoryManager.DocumentsDirectory),
            CreateFolderInfo(1, "Picture", IconType.Image, _directoryManager.PicturesDirectory),
        };

        foreach(DriveInfo driveInfo in DriveInfo.GetDrives())
        {
            var name = $"{driveInfo.VolumeLabel} ({driveInfo.RootDirectory.FullName.Replace("\\", "")})";
            roots.Add(CreateFolderInfo(1, name, IconType.MicrosoftWindows, driveInfo.Name));
        }

        return roots;
    }

    private FolderInfo CreateFolderInfo(int depth, string name, IconType iconType, string fullPath)
    {
        return new FolderInfo
        {
            Depth = depth,
            Name = name,
            IconType = iconType,
            FullPath = fullPath,
            Children = new()
        };
    }

    public void RefreshSubDirectories(FolderInfo parent)
    {
        var newChildren = FetchSubDirectories(parent);

        var oldChildrenDict = parent.Children.ToDictionary(c => c.FullPath);
        var newChildrenDict = newChildren.ToDictionary(c => c.FullPath);

        var added = newChildren.Where(c => !oldChildrenDict.ContainsKey(c.FullPath)).ToList();
        var removed = parent.Children.Where(c => newChildrenDict.ContainsKey(c.FullPath)).ToList();

        parent.Children.AddRange(added);
        foreach(var child in removed)
        {
            parent.Children.Remove(child);
        }
    }

    private static List<FolderInfo> FetchSubDirectories(FolderInfo parent)
    {
        var children = new List<FolderInfo>();
        try
        {
            var subDirs = Directory.GetDirectories(parent.FullPath);
            foreach (var subDir in subDirs)
            {
                children.Add(new FolderInfo
                {
                    Depth = parent.Depth + 1,
                    FullPath = subDir,
                    Name = Path.GetFileName(subDir),
                    IconType = IconType.Folder,
                    Children = new()
                });
            }
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return children;
    }
}
