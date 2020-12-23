using MentoringProgram.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MentoringProgram.Controllers
{
    public class GamesController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<GameViewModel> { new GameViewModel { Id = 1, Description = "Free to play MOBA", Developer = "Valve", Publisher = "Steam Corporation", Name = "Dota 2", ReleaseDate = new DateTime(2011, 06, 01) } });
        }

        // GET: GamesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GamesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GamesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GamesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GamesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GamesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GamesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
