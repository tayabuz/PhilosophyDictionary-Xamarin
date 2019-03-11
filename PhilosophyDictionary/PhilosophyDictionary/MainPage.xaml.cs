using System;
using Xamarin.Forms;

namespace Philosophy
{
    public partial class MainPage
    {
        WorkWithPDictionary textParser = WorkWithPDictionary.getInstance();
        public MainPage()
        {
            InitializeComponent();
            DictionaryListView.ItemsSource = textParser.DictionaryPhilosophy;
        }

        private void DictionaryListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new TermPage(e.Item));
        }

        private void SearchBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            DictionaryListView.ItemsSource = textParser.FindTerm(searchBar.Text);
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(searchBar.Text))
            {
                DictionaryListView.ItemsSource = textParser.DictionaryPhilosophy;
            }
        }
    }
}
