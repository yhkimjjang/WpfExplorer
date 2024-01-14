using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;

namespace WpfExplorer.Support.Local.Models;

public partial class FileInofBasecs : ObservableObject
{
    [ObservableProperty]
    private bool _isDenied;

    public string Name { get; set; }
    public int Depth { get; set; }
    public string FullPath { get; set; }
    public long Length { get; set; }
    public IconType IconType { get; set; }
}
