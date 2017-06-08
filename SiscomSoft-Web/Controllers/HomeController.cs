using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiscomSoft.Comun;
using SiscomSoft.Models;
using SiscomSoft.Controller;
using SiscomSoft_Web.ViewModel;

namespace SiscomSoft_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Categorias()
        {
            List<Categoria> dato = CategoriaViewModel.Listar();
            ViewBag.dato = dato;
            return View();
        }
        public ActionResult Catalogo()
        {
            List<Catalogo> cat = CatalogoViewModel.Listar();
            ViewBag.dato = cat;
            return View();
        }
        public ActionResult ActualizarCatalogo(int id)
        {
            ViewBag.id = CatalogoViewModel.BuscarporID(id);
            return View();
        }
        public ActionResult VerificarCatalogo(CatalogosViewModel Datos)
        {
            CatalogoViewModel.Actualizar(Datos);
            return View();
        }
        public ActionResult ActualizarCat(CatalogosViewModel Datos)
        {
            CatalogoViewModel.Actualizar(Datos);
            return View();
        }
        public ActionResult BorrarCatalogo(int id)
        {
            ViewBag.Dato = CatalogoViewModel.BuscarporID(id);
            return View();
        }

        public ActionResult EliminarCatalogo(int txtId)
        {
            CatalogoViewModel.Borrar(txtId);
            return View();
        }
        public ActionResult AgregarCatalogo()
        {
            return View();
        }

        public ActionResult GuardarCatalogo(CatalogosViewModel Dato)
        {
            CatalogoViewModel.Guardar(Dato);
            return View();
        }
        //---------------------------------------------------------------
        public ActionResult Clientes()
        {
            List<Cliente> cat = ClienteViewModel.Listar();
            ViewBag.dato = cat;
            return View();
        }
        public ActionResult ActualizarCliente(int id)
        {
            ViewBag.id = ClienteViewModel.BuscarporID(id);
            return View();
        }
        public ActionResult VerificarCliente(ClientesViewModel Datos)
        {
            ClienteViewModel.Actualizar(Datos);
            return View();
        }
        public ActionResult ActualizarCliente(ClientesViewModel Datos)
        {
            ClienteViewModel.Actualizar(Datos);
            return View();
        }
        public ActionResult BorrarCliente(int id)
        {
            ViewBag.Dato = ClienteViewModel.BuscarporID(id);
            return View();
        }

        public ActionResult EliminarCliente(int txtId)
        {
            ClienteViewModel.Borrar(txtId);
            return View();
        }
        public ActionResult AgregarCliente()
        {
            return View();
        }

        public ActionResult GuardarCliente(CatalogosViewModel Dato)
        {
            ClienteViewModel.Guardar(Dato);
            return View();
        }
        //---------------------------------------------------------------
        public ActionResult Actualizar(CategoriaViwModel Datos)
        {
            CategoriaViewModel.Actualizar(Datos);
            return View();
        }
        public ActionResult Borrar(int id)
        {
            ViewBag.Dato = CategoriaViewModel.BuscarporID(id);
            return View();
        }

        public ActionResult Borrar2(int txtId)
        {
            CategoriaViewModel.Borrar(txtId);
            return View();
        }
        public ActionResult frmNuevo()
        {
            return View();
        }

        public ActionResult Guardar(CategoriaViwModel Dato)
        {
            CategoriaViewModel.Guardar(Dato);
            return View();
        }
    }
}