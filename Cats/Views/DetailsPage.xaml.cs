using System;
using Movies.Models;
using Xamarin.Forms;

namespace Movies.Views
{
	public partial class DetailsPage : ContentPage
	{
		Movie selectedMovie;
		public DetailsPage(Movie selectedMovie)
		{
			InitializeComponent();
			this.selectedMovie = selectedMovie;
			BindingContext = this.selectedMovie;
			//ButtonWebSite.Clicked += ButtonWebSite_Clicked;
		}

		void ButtonWebSite_Clicked(object sender, EventArgs e)
		{
			
		}
	}
}
