using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_.Net_Core_Fundamental.Models;
using System.Text;
using CsvHelper;
using System.IO;
using System.Collections;
using CsvHelper.Configuration;

namespace ASP_.Net_Core_Fundamental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static List<Person> membersTest = new List<Person>
        {
            new Person{
                FirstName = "Long",
                LastName = "Bao",
                Gender = "Male",
                DateOfBirth = new DateTime(1994,1,16),
                PhoneNumber="",
                BirthPlace = "Bac Ninh",
                IsGraduated  = true,
                Age = 18
            },
            new Person{
                FirstName = "Dat",
                LastName = "Dam Tuan",
                Gender = "Male",
                DateOfBirth = new DateTime(1996,7,14),
                PhoneNumber="",
                BirthPlace = "Ha noi",
                IsGraduated  = true,
                Age = 23
            },
            new Person{
                FirstName = "Hung",
                LastName = "Ngo Quoc",
                Gender = "Male",
                DateOfBirth = new DateTime(1991,3,7),
                PhoneNumber="",
                BirthPlace = "Hai Phong",
                IsGraduated  = false,
                Age = 28
            },
            new Person{
                FirstName = "Van",
                LastName = "Nguyen Cong",
                Gender = "Male",
                DateOfBirth = new DateTime(1998,4,5),
                PhoneNumber="",
                BirthPlace = "Ha Noi",
                IsGraduated  = false,
                Age = 24
            },
            new Person{
                FirstName = "Trang",
                LastName = "Nguyen Huyen",
                Gender = "Female",
                DateOfBirth = new DateTime(2002,7,14),
                PhoneNumber="",
                BirthPlace = "Hai Duong",
                IsGraduated  = false,
                Age = 25
            },
            new Person{
                FirstName = "Ky",
                LastName = "Nguyen Khac",
                Gender = "Male",
                DateOfBirth = new DateTime(1999,11,12),
                PhoneNumber="",
                BirthPlace = "Ha Noi",
                IsGraduated  = false,
                Age = 26
            },
            new Person{
                FirstName = "Phuoc",
                LastName = "Hoang",
                Gender = "Male",
                DateOfBirth = new DateTime(2000,11,25),
                PhoneNumber="",
                BirthPlace = "Hai Phong",
                IsGraduated  = true,
                Age = 27
            },
            new Person{
                FirstName = "Hung",
                LastName = "Bui",
                Gender = "Male",
                DateOfBirth = new DateTime(1983,11,13),
                PhoneNumber="",
                BirthPlace = "Ha Noi",
                IsGraduated  = true,
                Age = 18
            }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ExportFile()
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true)))
                {
                    using (var cw = new CsvWriter(sw, cc))
                    {
                        cw.WriteRecords(membersTest);
                    }// The stream gets flushed here.
                    return File(ms.ToArray(), "text/csv", $"export_{DateTime.Now}.csv");
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
