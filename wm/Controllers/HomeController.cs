using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using wm.Lib;

namespace wm.Controllers
{
    public class HomeController : Controller
    {
        private const string ws_address = "http://desafioonline.wm.com.br/api/OnlineChallenge";

        public IActionResult Index()
        {
            List<Models.Anuncio> cars = new List<Models.Anuncio>();
            BD.Repo.Anuncio repo = new BD.Repo.Anuncio();
            cars = repo.Consultar();

            return View(cars);
        }


        [Route("/Edit/{id?}")]
        public IActionResult Car(int id)
        {
            Models.Anuncio anuncio = new Models.Anuncio();
            if (id != 0)
            {
                anuncio = new BD.Repo.Anuncio().Consultar(id);
                anuncio.modelos = GetModels(anuncio.marca);
                anuncio.versoes = GetVersions(anuncio.modelo);
            }

            anuncio.marcas = GetMakes();
            return View(anuncio);
        }


        public List<Models.Ws> GetMakes()
        {
            try
            {
                return Util.GetJsonAndDeserialize<List<Models.Ws>>(string.Concat(ws_address, "/Make"), "GET", "application/json");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Models.Ws> GetModels(string makeId)
        {
            try
            {
                return Util.GetJsonAndDeserialize<List<Models.Ws>>(string.Concat(ws_address, "/Model?MakeID=", makeId), "GET", "application/json");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public JsonResult GetModelsJs(int makeId)
        {
            try
            {
                if (makeId != 0)
                {
                    return Json(GetModels(makeId.ToString()));
                }
                else
                {
                    return Json("");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Models.Ws> GetVersions(string modelId)
        {
            try
            {

                return Util.GetJsonAndDeserialize<List<Models.Ws>>(string.Concat(ws_address, "/Version?ModelID=", modelId), "GET", "application/json");

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public JsonResult GetVersionsJs(int modelId)
        {
            try
            {
                if (modelId != 0)
                {
                    return Json(GetVersions(modelId.ToString()));
                }
                else
                {
                    return Json("");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public List<Models.Anuncio> GetVehicles(int page)
        //{
        //    try
        //    {
        //        return Util.GetJsonAndDeserialize<List<Car>>(string.Concat(address, "/Vehicles?Page=", page.ToString()), "GET", "application/json");
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        [HttpPost]
        [Route("/Edit")]
        public void Edit(Models.Anuncio car)
        {
            BD.Repo.Anuncio repo = new BD.Repo.Anuncio();
            if (car.ID == 0)
            {
                repo.Incluir(car);
            }
            else
            {
                repo.Atualizar(car);
            }
        }
        [HttpPost]
        public bool Del(int id)
        {
            try
            {
                Models.Anuncio car = new Models.Anuncio();
                BD.Repo.Anuncio repo = new BD.Repo.Anuncio();
                car = repo.Consultar(id);

                repo.Remover(car);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
