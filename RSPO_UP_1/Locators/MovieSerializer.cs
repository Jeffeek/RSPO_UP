using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using RSPO_UP_1.Models;

namespace RSPO_UP_1.Locators
{
    public class MovieSerializer
    {
        public bool WriteMovies(List<Movie> moviesList)
        {
            if (!File.Exists(FileSettings.Path))
            {
                using (var fs = new FileStream(FileSettings.Path, FileMode.Create)) { }
                return false;
            }
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Movie>));
            File.WriteAllText(FileSettings.Path, String.Empty);
            using (var fs = new FileStream(FileSettings.Path, FileMode.Append))
            { 
                serializer.WriteObject(fs, moviesList);
                return true;
            }
        }
    }
}
