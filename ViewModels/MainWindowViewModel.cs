using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MammaMiaDev.Templates;

namespace MammaMiaDev.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private bool _isPaneOpen = true;
    [ObservableProperty] private ViewModelBase? _currentPage = new HomePageViewModel();
    [ObservableProperty] private ListItemTemplate? _selectedListItem;

    public ObservableCollection<ListItemTemplate> Items { get; } 
        = [
            new ListItemTemplate(typeof(HomePageViewModel), "HomeRegular"),
            new ListItemTemplate(typeof(ButtonPageViewModel), "CursorHoverRegular"),
            new ListItemTemplate(typeof(GridPageViewModel), "GridRegular"),
            new ListItemTemplate(typeof(ImagePageViewModel), "ImageRegular"),
            new ListItemTemplate(typeof(DragAndDropPageViewModel), "DragRegular")
          ];


    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null)
        {
            return;
        }

        var instance = Activator.CreateInstance(value.ModelType);
        if (instance is null)
        {
            return;
        }

        CurrentPage = (ViewModelBase)instance;
    }


    [RelayCommand]
    private void TriggerPane()
        => IsPaneOpen = !IsPaneOpen;
}
