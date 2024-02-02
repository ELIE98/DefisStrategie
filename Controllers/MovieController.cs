using DefisStrategie.Models;
using DefisStrategie.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace DefisStrategie.Controllers
{
  
    public class MovieController : ControllerBase
    {

        private MovieService _MovieSce;
        

        public MovieController(MovieService mSce)
        {
            _MovieSce = mSce;
        }

        // GET: MovieController
        public ActionResult Index()
        {
            var listeMovie = _MovieSce.GetAllFilms();
            return Ok(new { liste = listeMovie});
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            var listeMovie = _MovieSce.GetFilms(id);
            return Ok(new { liste = listeMovie });
        }

        public ActionResult GetFilmByAuthor(int AuthorId)
        {
            var listeMovie = _MovieSce.GetFilmsByAuthor(AuthorId);
            return Ok(new { liste = listeMovie });
        }

        // GET: MovieController/Create
        [HttpPost]
        public ActionResult Create(Films model)
        {
            if (ModelState.IsValid)
            {
                var data = _MovieSce.CreateFilms(model);
                if (data == null)
                    return Ok(new { success = data.Item1,message = "film crée  avec succès." });

                return Ok(new { success = false, message = "Une erreur est survenue lors de l'enregistrement." });
            }

            return Ok(new { success = false, message = "Une erreur est survenue lors de l'enregistrement." });
        }



        // GET: MovieController/Edit/5
        [HttpPost]
        public ActionResult Edit(Films model)
        {
            if (ModelState.IsValid)
            {
                var data = _MovieSce.UpadateFilms(model);
                if (data.Item1)
                    return Ok(new { success = data.Item1, message = "film modifie  avec succès." });

                return Ok(new { success = false, message = "Une erreur est survenue lors de l'enregistrement." });
            }

            return Ok(new { success = false, message = "Une erreur est survenue lors de l'enregistrement." });
        }


        // GET: MovieController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var data = _MovieSce.DeleteFilms(id);
            if (data.Item1)
                return Ok(new { success = data.Item1, message = "film supprimee  avec succès." });

            return Ok(new { success = false, message = "Une erreur est survenue lors de l'enregistrement." });
        }

    }
}
