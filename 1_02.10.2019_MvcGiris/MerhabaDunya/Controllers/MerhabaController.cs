using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MerhabaDunya.Models;

namespace MerhabaDunya.Controllers
{
    public class MerhabaController : Controller
    {
        public string Index()
        {
            return "Merhaba Dünya";
        }

        public string Selam()
        {
            return "Selam";
        }
    }
}
