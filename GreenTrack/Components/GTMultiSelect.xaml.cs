namespace GreenTrack.Components;

public partial class GTMultiSelect : ContentView
{
    #region Constructor
    public GTMultiSelect()
	{
		InitializeComponent();
	}
    #endregion
    #region Properties
    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<object>), typeof(GTMultiSelect), null);
    public IEnumerable<object> ItemsSource
    {
        get => (IEnumerable<object>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }
    #endregion
    #region Methods
    private void OnCollectionViewSelectionChanged(object sender, EventArgs e)
    {
        if (sender is BindableObject bindableObject)
        {
            var selectedItem = bindableObject.BindingContext;
            if (selectedItem != null)
            {
                // Supondo que você tenha uma lista de itens selecionados
                var selectedItems = new List<object>(ItemsSource);

                if (selectedItems.Contains(selectedItem))
                {
                    selectedItems.Remove(selectedItem);
                }
                else
                {
                    selectedItems.Add(selectedItem);
                }

                ItemsSource = selectedItems;
            }
        }
    }
    #endregion
}