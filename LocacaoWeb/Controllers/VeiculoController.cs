﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoWeb.Controllers
{
    public class VeiculoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
