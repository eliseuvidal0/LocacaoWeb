﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoWeb.DAL;
using LocacaoWeb.Models;
using LocacaoWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoWeb.Controllers
{
    [Authorize]
    public class VeiculoController : Controller
    {
        private readonly VeiculoDAO _veiculoDAO;

        public VeiculoController(VeiculoDAO veiculoDAO) => _veiculoDAO = veiculoDAO;
        public IActionResult Index()
        {
            return View(_veiculoDAO.Listar());
        }
        public IActionResult Cadastrar() => View();
        public IActionResult teste() => View();
        [HttpPost]
        public IActionResult Cadastrar(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                if (Validacao.ValidarPlaca(veiculo.placa)) {
                    if (_veiculoDAO.Cadastrar(veiculo))
                    {
                        return RedirectToAction("Index", "Veiculo");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Já existe veiculo cadastrado nessa PLACA!");
                    }
                    
                } else
                {

                    ModelState.AddModelError("", "PLACA INVÁLIDA!");
                }
            }

             ModelState.AddModelError("", "**Preencha todos os campos!**");

            return View(veiculo);
        }

        public IActionResult Remover(int id)
        {
            Veiculo v = _veiculoDAO.BuscarPorId(id);

            if(v.locado == false)
            {
                _veiculoDAO.Remover(id);
                return RedirectToAction("Index", "Veiculo");
            }

            ModelState.AddModelError("", "**Veículo está locado**");
            return RedirectToAction("Index", "Veiculo");
        }

        public IActionResult Editar(int id)
        {
            return View(_veiculoDAO.BuscarPorId(id));
        }
        [HttpPost]
        public IActionResult Editar(Veiculo veiculo)
        {
            _veiculoDAO.Editar(veiculo);

            return RedirectToAction("Index", "Veiculo");
        }
    }
}
