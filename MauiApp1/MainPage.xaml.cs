using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public ObservableCollection<Item> Data { get; set; } = new();
	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private void Add_Item(object sender, EventArgs e)
	{
		Data.Add(new Item() { Name = "BlaBla"});
	}

	private void Add_SubItem(object sender, EventArgs e)
	{
		var item = (sender as Button).BindingContext as Item;
		item.SubItems.Add(new SubItem() { Comment = "BlubBlub" });
	}
}

public partial class Item : ObservableObject
{
	[ObservableProperty]
	string name;

	[ObservableProperty]
	ObservableCollection<SubItem> subItems = new();
}

public partial class SubItem : ObservableObject
{
	[ObservableProperty]
	string comment;
}