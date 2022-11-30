using Credentials.Data;
using Credentials.Data.Interfaces;
using Credentials.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace AddressBook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKredencijaliRepository kredencijaliRepository;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, IKredencijaliRepository kredencijaliRepository, IMapper mapper)
        {
            _logger = logger;
            this.kredencijaliRepository = kredencijaliRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Kredencijali()
        {
            var dataResult = kredencijaliRepository.GetAll();

            List<KredencijaliModel> kredencijaliModel = mapper.Map<List<KredencijaliModel>>(dataResult);

            return View(kredencijaliModel);
        }

        #region Create

        [HttpGet]
        public IActionResult Create() => View(new KredencijaliModel());

        [HttpPost]
        public IActionResult Create(KredencijaliModel model)
        {
            try
            {
                kredencijaliRepository.Create(mapper.Map<Kredencijali>(model));

                return View(model);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        #endregion Create

        #region Delete

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            return View(mapper.Map<KredencijaliModel>(kredencijaliRepository.GetOne(Id)));
        }

        [HttpPost]
        public IActionResult Delete(KredencijaliModel model)
        {
            kredencijaliRepository.DeleteById(model.Id);

            return View("Index");
        }

        #endregion Delete

        #region Details

        /// <summary>
        /// Read one value from database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult Details(int Id)
        {
            return View(mapper.Map<KredencijaliModel>(kredencijaliRepository.GetOne(Id)));
        }

        #endregion Details

        #region Edit

        /// <summary>
        /// Edit data - get method: Home/Edit/{id?}
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(mapper.Map<KredencijaliModel>(kredencijaliRepository.GetOne(Id)));
        }

        /// <summary>
        /// Edit data - post method: Home/Edit/{model}
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(KredencijaliModel model)
        {
            kredencijaliRepository.Update(mapper.Map<Kredencijali>(model));

            return RedirectToAction("Details", "Home", new { Id = model.Id });
        }

        #endregion Edit

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}