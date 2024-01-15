using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
