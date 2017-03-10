using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmHelpers;

namespace Movies.Models
{
	public class Repository
	{
		//To use consume data from web api
		//public async Task<ObservableRangeCollection<Cat>> GetCats()
		//{
		//	ObservableRangeCollection<Cat> Movies;
		//	var URLWebAPI = "http://demos.ticapacitacion.com/cats";
		//	using (var Client = new System.Net.Http.HttpClient())
		//	{
		//		var JSON = await Client.GetStringAsync(URLWebAPI);
		//		Movies = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableRangeCollection<Cat>>(JSON);
		//	}
		//	return Movies;
		//}

		public async Task<IEnumerable<Movie>> GetMovies()
		{
			var service = new Services.AzureService<Movie>();
			var items = await service.GetTable();
			return items;
		}
	}
}
