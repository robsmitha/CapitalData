using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CapitalData.Models;
using Microsoft.AspNetCore.Mvc;
using ProPublicaSDK;

namespace CapitalData.Controllers
{
    public class StatementsController : BaseController
    {
        public StatementsController(IMapper mapper, ProPublica proPublica) : base(mapper, proPublica) { }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List()
        {
            var statements = _proPublica.Statements.GetRecentStatements();
            return PartialView("_List", _mapper.Map<List<StatementViewModel>>(statements));
        }
        public async Task<IActionResult> Search(string term)
        {
            var statements = _proPublica.Statements.SearchStatements(term);
            return PartialView("_List", _mapper.Map<List<StatementViewModel>>(statements));
        }
    }
}