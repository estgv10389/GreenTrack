using CommunityToolkit.Mvvm.Input;
using Maui.DataGrid;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Input;

namespace GreenTrack.Components;

public partial class GTTable : ContentView
{
    #region Constructor
    public GTTable()
	{
		InitializeComponent();
	}
    #endregion
    #region Properties
    public static readonly BindableProperty IsRefreshingProperty =
       BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(GTTable), false);
    public bool IsRefreshing
    {
        get => (bool)GetValue(IsRefreshingProperty);
        set => SetValue(IsRefreshingProperty, value);
    }

    public static readonly BindableProperty ClearCommandProperty =
              BindableProperty.Create(nameof(ClearCommand), typeof(ICommand), typeof(GTButton), null);
    public ICommand ClearCommand
    {
        get => (ICommand)GetValue(ClearCommandProperty);
        set => SetValue(ClearCommandProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty =
    BindableProperty.Create(
        propertyName: nameof(ItemsSource),
        returnType: typeof(IEnumerable),
        declaringType: typeof(DataGrid),
        defaultValue: null,
        propertyChanged: (b, o, n) =>
        {
            if (b is not DataGrid self)
            {
                return;
            }
        });

    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }
    #endregion

}