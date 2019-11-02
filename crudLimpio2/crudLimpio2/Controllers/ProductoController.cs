using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crudLimpio2.Models;

namespace crudLimpio2.Controllers
{
    public class ProductoController : Controller
    {
        #region Index(default)
        // GET: Producto
        public ActionResult Index()
        {
            List<ProductoViewModel> lista;
            using (BDPruebaEntities ObjBDPrueba = new BDPruebaEntities())
            {
                lista = (from varTabla in ObjBDPrueba.Producto.Where(o => o.Prod_estatus == 1)
                         select new ProductoViewModel
                         {
                             Producto_id = varTabla.Producto_id,
                             Prod_nombre = varTabla.Prod_nombre,
                             Prod_descripción = varTabla.Prod_descripción,
                             Prod_cantidad = varTabla.Prod_cantidad
                         }).ToList();
            };
            return View(lista);
        }
        #endregion

        #region Nuevo Registro
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ProductoViewModel Producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BDPruebaEntities ObjBDPrueba = new BDPruebaEntities())
                    {
                        var objProducto = new Producto();
                        objProducto.Producto_id = Producto.Producto_id;
                        objProducto.Prod_nombre = Producto.Prod_nombre;
                        objProducto.Prod_descripción = Producto.Prod_descripción;
                        objProducto.Prod_cantidad = Producto.Prod_cantidad;
                        objProducto.Prod_estatus = 1;
                        objProducto.Prod_fechaRegistro = DateTime.Now;
                        objProducto.Prod_fechaActualizacion = DateTime.Now;

                        ObjBDPrueba.Producto.Add(objProducto);
                        ObjBDPrueba.SaveChanges();
                    }
                    //Valido
                    return Redirect("/Producto/Index");
                }
                //No Valido
                return View(Producto);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region Modificar Registro
        /// <summary>
        /// Metódo que sirve para obtener los datos a partir del ID y poder cargar información
        /// en la pantalla de vista de EDITAR
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Editar(int id)
        {
            ProductoViewModel objProductoViewModel = new ProductoViewModel();
            using (BDPruebaEntities ObjBDPrueba = new BDPruebaEntities())
            {
                var objProducto = ObjBDPrueba.Producto.Find(id);
                objProductoViewModel.Prod_nombre = objProducto.Prod_nombre;
                objProductoViewModel.Prod_descripción = objProducto.Prod_descripción;
                objProductoViewModel.Prod_cantidad = objProducto.Prod_cantidad;
                objProductoViewModel.Prod_fechaActualizacion = DateTime.Now;
                objProductoViewModel.Producto_id = objProducto.Producto_id;
            }
            return View(objProductoViewModel);
        }

        /// <summary>
        /// Método que recibe la entidad Producto con los datos modificados
        /// Modifica los datos del producto en base de datos.
        /// </summary>
        /// <param name="Producto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(ProductoViewModel Producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BDPruebaEntities ObjBDPrueba = new BDPruebaEntities())
                    {
                        var objProducto = ObjBDPrueba.Producto.Find(Producto.Producto_id);
                        objProducto.Prod_nombre = Producto.Prod_nombre;
                        objProducto.Prod_descripción = Producto.Prod_descripción;
                        objProducto.Prod_cantidad = Producto.Prod_cantidad;
                        objProducto.Prod_fechaActualizacion = DateTime.Now;

                        ObjBDPrueba.Entry(objProducto).State = System.Data.Entity.EntityState.Modified;
                        ObjBDPrueba.SaveChanges();
                    }
                    //Valido
                    return Redirect("/Producto/Index");
                }
                //No Valido
                return View(Producto);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Eliminar
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            try
            {
                using (BDPruebaEntities ObjBDPrueba = new BDPruebaEntities())
                {
                    var objProducto = ObjBDPrueba.Producto.Find(id);
                    objProducto.Prod_estatus = 0;
                    objProducto.Prod_fechaActualizacion = DateTime.Now;
                    ObjBDPrueba.Entry(objProducto).State = System.Data.Entity.EntityState.Modified;
                    ObjBDPrueba.SaveChanges();
                }
                return Redirect("/Producto/Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}