﻿using CommunityToolkit.Mvvm.ComponentModel;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools.Command;
using MFAWPF.Data;
using MFAWPF.Helper;
using MFAWPF.ViewModels.Tool;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace MFAWPF.ViewModels.UI;

public partial class RootViewModel : ViewModel
{
    [ObservableProperty] private bool _idle = true;

    [ObservableProperty] private bool _notLock = true;

    [ObservableProperty] private bool _isRunning;

    public void SetIdle(bool value)
    {
        Idle = value;
    }
    [ObservableProperty] private bool _enableEdit = MFAConfiguration.GetConfiguration("EnableEdit", false);

    partial void OnEnableEditChanged(bool value)
    {
        MFAConfiguration.SetConfiguration("EnableEdit", value);
    }


    [ObservableProperty] private bool _isAdb = true;

    [ObservableProperty] private bool _isConnected;

    [ObservableProperty] private bool _isUpdating;

    [ObservableProperty] private bool _isVisible = true;

    public void SetConnected(bool isConnected)
    {
        IsConnected = isConnected;
    }

    public void SetUpdating(bool isUpdating)
    {
        IsUpdating = isUpdating;
    }

    partial void OnIsVisibleChanged(bool value)
    {
        if (value)
        {
            Application.Current.MainWindow?.Show();
        }
        else
        {
            Application.Current.MainWindow?.Hide();
        }
    }



    [ObservableProperty] private string? _resourceName;

    [ObservableProperty] private bool _isResourceNameVisible;

    [ObservableProperty] private string? _resourceVersion;

    [ObservableProperty] private bool _isResourceVersionVisible;

    [ObservableProperty] private string? _customTitle;

    [ObservableProperty] private bool _isCustomTitleVisible;

    [ObservableProperty] private bool _isDefaultTitleVisible = true;

    [ObservableProperty] private bool _isVersionVisible = true;

    public void ShowResourceName(string name)
    {
        ResourceName = name;
        IsResourceNameVisible = true;
    }

    public void ShowResourceVersion(string version)
    {
        ResourceVersion = version;
        IsResourceVersionVisible = true;
    }

    public void ShowCustomTitle(string title)
    {
        CustomTitle = title;
        IsCustomTitleVisible = true;
        IsDefaultTitleVisible = false;
        IsVersionVisible = false;
        IsResourceNameVisible = false;
        IsResourceVersionVisible = false;
    }
}
