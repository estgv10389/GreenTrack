namespace GreenTrack.Components;

public partial class GTEditor : ContentView
{
    #region Constructor
    public GTEditor()
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