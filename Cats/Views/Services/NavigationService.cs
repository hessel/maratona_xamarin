using System.Threading.Tasks;
using Xamarin.Forms;
using Movies.ViewModels.Services;

namespace Movies.Views.Services
{
    public class NavigationService : INavigationService 
	{
		#region INavigationService implementation

		public async Task NavigateToDetail(Models.Movie selectedMovie)
		{
			await Application.Current.MainPage.Navigation.PushAsync (new DetailsPage(selectedMovie));
		}

		#endregion
	}
}
