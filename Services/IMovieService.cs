using DefisStrategie.Models;
using System;
using System.Collections.Generic;

namespace DefisStrategie.Services
{
    public interface IMovieService
    {
        List<Films> GetAllFilms();

        List<Films> GetFilms(int id);

        List<Films> GetFilmsByAuthor(int authorId);

        Tuple<bool, string> CreateFilms(Films film);

        Tuple<bool, string> UpadateFilms(Films film);

        Tuple<bool, string> DeleteFilms(int id);
    }
}
