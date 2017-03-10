using System;
using System.Threading.Tasks;
using Movies.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace Movies.ViewModels
{
	public class MoviesViewModel : ObservableObject
	{
		readonly Services.INavigationService navigationService;

		readonly Services.IMessageService messageService;

		public Command GetMoviesCommand { get; }

		public ObservableRangeCollection<Movie> Movies { get; set; }

        Movie selectedMovie;
		public Movie SelectedCat
		{
			get { return selectedMovie; }
			set
			{
				if (SetProperty(ref selectedMovie, value))
				{
					ShowDetail();
				};
			}
		}

		bool isBusy;
		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				if (SetProperty(ref isBusy, value))
				{
                    GetMoviesCommand.ChangeCanExecute();
				};
			}
		}

		public MoviesViewModel()
		{
			Movies = new ObservableRangeCollection<Movie>();

            GetMoviesCommand = new Command(async () => await GetMovies(), () => !IsBusy);

			navigationService = DependencyService.Get<Services.INavigationService>();

			messageService = DependencyService.Get<Services.IMessageService>();
		}

		async Task ShowDetail()
		{
			if (selectedMovie != null)
			{
				await navigationService.NavigateToDetail(selectedMovie);
				SelectedCat = null;
			}
		}

		async Task GetMovies()
		{
			if (!IsBusy)
			{
				Exception Error = null;
				try
				{
					IsBusy = true;
					var repository = new Repository();
					var items = await repository.GetMovies();
					Movies.Clear();
					Movies.AddRange(items);
				}
				catch (Exception ex)
				{
					Error = ex;
				}
				finally
				{
					if (Error != null)
					{
						await messageService.ShowOkAsync("Error!", Error.Message);
					}
					IsBusy = false;
				}
			}
			return;
		}
	}
}
