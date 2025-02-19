using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui;

namespace GreenTrack.Components;

public partial class GTInput : ContentView
{
    #region Constructor
    public GTInput()
	{
        InitializeComponent();
	}
    #endregion

    #region Properties
    public static readonly BindableProperty PlaceholderProperty =
       BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(GTInput), string.Empty);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(GTInput), string.Empty, BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty IsPasswordProperty =
        BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(GTInput), false);

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }
   
    public static readonly BindableProperty ValidationMessageProperty =
            BindableProperty.Create(
                nameof(ValidationMessage),
                typeof(string),
                typeof(GTInput),
                string.Empty);

    public string ValidationMessage
    {
        get => (string)GetValue(ValidationMessageProperty);
        set => SetValue(ValidationMessageProperty, value);
    }

    public static readonly BindableProperty HasValidationErrorProperty =
        BindableProperty.Create(
            nameof(HasValidationError),
            typeof(bool),
            typeof(GTInput),
            false);

    public bool HasValidationError
    {
        get => (bool)GetValue(HasValidationErrorProperty);
        set => SetValue(HasValidationErrorProperty, value);
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
    #endregion





}