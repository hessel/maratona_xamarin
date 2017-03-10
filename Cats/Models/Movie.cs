using System;
using Microsoft.WindowsAzure.MobileServices;

namespace Movies.Models
{
    [DataTable("Movies")]
    public class Movie
    {
        public String Id { get; set; }
        public String Film { get; set; }
        public String Genre { get; set; }
        public String Year { get; set; }
        [Version]
        public string AzureVersion { get; set; }
    }
}
