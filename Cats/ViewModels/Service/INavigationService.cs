using System.Threading.Tasks;

namespace Movies.ViewModels.Services
{
	public interface INavigationService
	{
		Task NavigateToDetail(Models.Movie selectedMovie);
	}
}
