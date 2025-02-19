namespace GreenTrack.Components;

public partial class GTDatePicker : ContentView
{
    #region Constructor
    public GTDatePicker()
	{
		InitializeComponent();
	}
    #endregion

    #region Properties
    public static readonly BindableProperty SelectedDateProperty =
       BindableProperty.Create(nameof(SelectedDate), typeof(DateTime), typeof(DatePicker), null);

    public DateTime SelectedDate
    {
        get => (DateTime)GetValue(SelectedDateProperty);
        set => SetValue(SelectedDateProperty, value);
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