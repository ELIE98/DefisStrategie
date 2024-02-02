using DefisStrategie.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DefisStrategie.Services
{
    public class MovieService : IMovieService
    {
        private moviesContext moviesContext { get; }
        public MovieService(moviesContext ctx)
        {
            moviesContext = ctx;
        }

      

        public List<Films> GetAllFilms()
        {
            List<Films> films = new List<Films>();
            try
            {
                return films = moviesContext.Films.Where(x => (bool)x.EstActif).ToList();
            }
            catch
            {
                return films;
            }
        }

        public List<Films> GetFilms(int id)
        {
            List<Films> films = new List<Films>();
            try
            {
                return films = moviesContext.Films.Where(x => x.Id== id && (bool)x.EstActif).ToList();
            }
            catch
            {
                return films;
            }
        }

        public Tuple<bool, string> CreateFilms(Films film)
        {
            try
            {
                moviesContext.Entry(film).State = EntityState.Added;
                moviesContext.SaveChanges();
                return new Tuple<bool, string>(true, "creation du film effectuée avec succès.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, "Une erreur est survenue lors de l'opération.");
            }
        }

        public Tuple<bool, string> UpadateFilms(Films film)
        {
            try
            {
                moviesContext.Entry(film).State = EntityState.Modified;
                moviesContext.SaveChanges();
                return new Tuple<bool, string>(true, "Modification du film effectuée avec succès.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, "Une erreur est survenue lors de l'opération.");
            }
        }

        public Tuple<bool, string> DeleteFilms(int id)
        {
            try
            {
                var films = moviesContext.Films.Where((x) => x.Id== id).FirstOrDefault();
                if (films != null)
                    films.EstActif = false;

                moviesContext.Entry(films).State = EntityState.Modified;
                moviesContext.SaveChanges();
                return new Tuple<bool, string>(true, "Suppression du film effectuée avec succès.");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, "Une erreur est survenue lors de l'opération.");
            }
        }

        public List<Films> GetFilmsByAuthor(int authorId)
        {
            List<Films> films = new List<Films>();
            try
            {
                return films = moviesContext.Films.Where(x => x.AuteurId == authorId && (bool)x.EstActif).ToList();
            }
            catch
            {
                return films;
            }
        }
    }
}
