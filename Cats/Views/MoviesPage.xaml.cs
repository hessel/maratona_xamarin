using Movies.ViewModels;
using Xamarin.Forms;

namespace Movies.Views
{
	public partial class MoviesPage : ContentPage
	{
		public MoviesPage()
		{
			InitializeComponent();
			BindingContext = new MoviesViewModel();
		}
	}
}
