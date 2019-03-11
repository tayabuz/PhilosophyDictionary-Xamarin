using Xamarin.Forms.Xaml;

namespace Philosophy
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TermPage
    {
		public TermPage (object e)
		{
			InitializeComponent();
            LabelKey.BindingContext = CastHelper.CastToKeyValuePairFromObject(e);
            LabelValue.BindingContext = CastHelper.CastToKeyValuePairFromObject(e);
        }
    }
}
