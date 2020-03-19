using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContentManagement.Models;
using ContentManagement.DataAccess.ContentRepository;
using ContentManagement.DataAccess.Wrapper;
using ContentManagement.Domain.Entities;
using ContentManagement.Domain.ViewModels;

namespace ContentManagement.Controllers
{
    public class ContentController : Controller
    {
        public readonly IWrapper _uow;
        public ContentController(IWrapper uow)
        {
            _uow = uow;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Index()
        {
            return View(await _uow.ContentRepository.GetAll());
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _uow.ContentRepository.GetById(id));
        }



        [HttpGet("[action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContentViewModel  model)
        {
             await _uow.ContentRepository.Add(model);
            return RedirectToAction("Index");
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> Update(int id)
        {
            var content = await _uow.ContentRepository.GetById(id);
            return View(content);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContentViewModel model)
        {
             await _uow.ContentRepository.Update(model);
            return RedirectToAction("Index");
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            var content = await _uow.ContentRepository.GetById(id);
            return View(content);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _uow.ContentRepository.GetById(id);
            return RedirectToAction("Index");
        }


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
