﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    public class ModalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}