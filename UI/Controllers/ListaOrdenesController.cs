﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ListaOrdenesController : Controller
    {
        // GET: ListaOrdenesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ListaOrdenesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListaOrdenesController/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
