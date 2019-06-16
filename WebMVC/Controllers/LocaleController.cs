using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CityCommands;
using Application.Commands.LocaleCommands;
using Application.Commands.LocaleTypeCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class LocaleController : Controller
    {
        private readonly IAddLocaleCommand _addCommand;
        private readonly IGetLocaleCommand _getOneCommand;
        private readonly IGetLocaleWithIdsCommand _getOneWithIdsCommand;
        private readonly IGetLocalesCommand _getAllCommand;
        private readonly IEditLocaleCommand _editCommand;
        private readonly IDeleteLocaleCommand _deleteCommand;
        private readonly IGetCitiesCommand _getCitiesCommand;
        private readonly IGetLocaleTypesCommand _getLocaleTypesCommand;

        public LocaleController(IAddLocaleCommand addCommand, IGetLocaleCommand getOneCommand, IGetLocaleWithIdsCommand getOneWithIdsCommand, IGetLocalesCommand getAllCommand, IEditLocaleCommand editCommand, IDeleteLocaleCommand deleteCommand, IGetCitiesCommand getCitiesCommand, IGetLocaleTypesCommand getLocaleTypesCommand)
        {
            _addCommand = addCommand;
            _getOneCommand = getOneCommand;
            _getOneWithIdsCommand = getOneWithIdsCommand;
            _getAllCommand = getAllCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
            _getCitiesCommand = getCitiesCommand;
            _getLocaleTypesCommand = getLocaleTypesCommand;
        }


        // GET: Locale
        public ActionResult Index(LocaleQuery query)
        {
            return View(_getAllCommand.Execute(query));
        }

        // GET: Locale/Details/5
        public ActionResult Details(int id)
        {
            return View(_getOneCommand.Execute(id));
        }

        // GET: Locale/Create
        public ActionResult Create()
        {
            ViewBag.Cities = _getCitiesCommand.Execute(new CityQuery()).Data;
            ViewBag.LocaleTypes = _getLocaleTypesCommand.Execute(new LocaleTypeQuery()).Data;
            return View();
        }

        // POST: Locale/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocaleDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Inaccurate create object";
                RedirectToAction(nameof(Create));
            }
            try
            {
                _addCommand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                TempData["error"]=e.Message;
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
            }
            return View();
        }

        // GET: Locale/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Cities = _getCitiesCommand.Execute(new CityQuery()).Data;
            ViewBag.LocaleTypes = _getLocaleTypesCommand.Execute(new LocaleTypeQuery()).Data;
            return View(_getOneWithIdsCommand.Execute(id));
        }

        // POST: Locale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocaleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            dto.Id = id; 
            try
            {
                _editCommand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
                return View(dto);
            }
        }

        // POST: Locale/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}