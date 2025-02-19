using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace GreenTrack.Components;

public partial class GTButton : ContentView
{
    #region Constructor
    public GTButton()
	{
        InitializeComponent();
        this.BindingContextChanged += (s, e) =>
        {
            if (BindingContext != null)
            {
               BindingContext = this.BindingContext;
            }
        };
    }
    #endregion

    #region Properties
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(GTInput), string.Empty);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty BackgoundColorProperty =
        BindableProperty.Create(nameof(BgColor), typeof(Color), typeof(GTInput), null);
    public Color BgColor
    {
        get => (Color)GetValue(BackgoundColorProperty);
        set => SetValue(BackgoundColorProperty, value);
    }

    #endregion

    public static readonly BindableProperty ExternalCommandProperty =
               BindableProperty.Create(nameof(ExternalCommand), typeof(ICommand), typeof(GTButton), null);

    public ICommand ExternalCommand
    {
        get => (ICommand)GetValue(ExternalCommandProperty);
        set => SetValue(ExternalCommandProperty, value);
    }

    public static readonly BindableProperty GTAutomationIdProperty = BindableProperty.Create(
         nameof(GTAutomationId),
         typeof(string),
         typeof(GTInput),
         string.Empty
    );
    public string GTAutomationId
    {
        get => (string)GetValue(GTAutomationIdProperty);
        set => SetValue(GTAutomationIdProperty, value);
    }
}