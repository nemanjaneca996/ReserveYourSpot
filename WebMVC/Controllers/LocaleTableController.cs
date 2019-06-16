using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.LocaleCommands;
using Application.Commands.LocaleTableCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class LocaleTableController : Controller
    {
        private readonly IGetLocaleTablesCommand _getAllCommand;
        private readonly IGetLocaleTableWitIdsCommand _getWithIdCommand;
        private readonly IGetLocaleTableCommand _getOneCommand;
        private readonly IAddLocaleTableCommand _addCommand;
        private readonly IEditLocaleTableCommand _editCommand;
        private readonly IDeleteLocaleTableCommand _deleteCommand;
        private readonly IGetLocalesCommand _getLocales;


        public LocaleTableController(IGetLocaleTablesCommand getAllCommand, IGetLocaleTableWitIdsCommand getWithIdCommand, IGetLocaleTableCommand getOneCommand, IAddLocaleTableCommand addCommand, IEditLocaleTableCommand editCommand, IDeleteLocaleTableCommand deleteCommand, IGetLocalesCommand getLocales)
        {
            _getAllCommand = getAllCommand;
            _getWithIdCommand = getWithIdCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
            _getLocales = getLocales;
        }

        // GET: LocaleTable
        public ActionResult Index(LocaleTableQuery query)
        {
            return View(_getAllCommand.Execute(query));
        }

        // GET: LocaleTable/Details/5
        public ActionResult Details(int id)
        {
            return View(_getOneCommand.Execute(id));
        }

        // GET: LocaleTable/Create
        public ActionResult Create()
        {
            ViewBag.Locales = _getLocales.Execute(new LocaleQuery()).Data;
            return View();
        }

        // POST: LocaleTable/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocaleTableDto dto)
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
                TempData["error"] = e.Message;
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
            }
            return View();
        }

        // GET: LocaleTable/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Locales = _getLocales.Execute(new LocaleQuery()).Data;
            return View(_getWithIdCommand.Execute(id));
        }

        // POST: LocaleTable/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocaleTableDto dto)
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

        // GET: LocaleTable/Delete/5
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