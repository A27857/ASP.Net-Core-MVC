using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_.Net_Core_Fundamental.Models;
using System.Text.Json;

namespace ASP_.Net_Core_Fundamental.Controllers
{
    public class RookiesController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public RookiesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        static List<Person> members = new List<Person>
        {
            new Person{
                FirstName = "Long",
                LastName = "Bao",
                Gender = "Male",
                DateOfBirth = new DateTime(1994,1,16),
                PhoneNumber="",
                BirthPlace = "Bac Ninh",
                IsGraduated  = false,
                Age = 27
            },
            new Person{
                FirstName = "Dat",
                LastName = "Dam Tuan",
                Gender = "Male",
                DateOfBirth = new DateTime(1996,7,14),
                PhoneNumber="",
                BirthPlace = "Ha noi",
                IsGraduated  = true,
                Age = 25
            },
            new Person{
                FirstName = "Hung",
                LastName = "Ngo Quoc",
                Gender = "Male",
                DateOfBirth = new DateTime(1991,3,7),
                PhoneNumber="",
                BirthPlace = "Hai Phong",
                IsGraduated  = false,
                Age = 30
            },
            new Person{
                FirstName = "Van",
                LastName = "Nguyen Cong",
                Gender = "Male",
                DateOfBirth = new DateTime(1998,4,5),
                PhoneNumber="",
                BirthPlace = "Ha Noi",
                IsGraduated  = true,
                Age = 23
            },
            new Person{
                FirstName = "Trang",
                LastName = "Nguyen Huyen",
                Gender = "Female",
                DateOfBirth = new DateTime(2002,7,14),
                PhoneNumber="",
                BirthPlace = "Hai Duong",
                IsGraduated  = false,
                Age = 19
            },
            new Person{
                FirstName = "Ky",
                LastName = "Nguyen Khac",
                Gender = "Male",
                DateOfBirth = new DateTime(1999,11,12),
                PhoneNumber="",
                BirthPlace = "Ha Noi",
                IsGraduated  = false,
                Age = 22
            },
            new Person{
                FirstName = "Phuoc",
                LastName = "Hoang",
                Gender = "Male",
                DateOfBirth = new DateTime(2000,11,25),
                PhoneNumber="",
                BirthPlace = "Hai Phong",
                IsGraduated  = false,
                Age = 21
            },
            new Person{
                FirstName = "Hung",
                LastName = "Bui",
                Gender = "Male",
                DateOfBirth = new DateTime(1983,11,13),
                PhoneNumber="",
                BirthPlace = "Ha Noi",
                IsGraduated  = true,
                Age = 38
            }
        };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GetFullNames()
        {
            var names = members.Select(mb => $"{mb.LastName} {mb.FirstName}").ToList();
            return View("ViewGetFullNamePerson", names);
            // return Json(names);
        }
        public IActionResult GetPersonByGender()
        {
            var student = members.Where(s => s.Gender == "Male").ToList();
            return View("ViewGetPersonByGender", student);
            // var json = JsonSerializer.Serialize(names);
            // return Content(json);
        }
        public IActionResult GetOldestPerson()
        {
            var biggest = members.Max(st => st.Age);
            System.Console.WriteLine(biggest);
            var oldest = members.Where(st => st.Age == biggest).ToList();
            var oldestTemp = oldest.FirstOrDefault();
            return View("ViewGetOldestPerson", oldestTemp);
        }
        public IActionResult GetPersonEqualsYear(int year)
        {
            var equal = members.Where(s => s.DateOfBirth.Year == year).ToList();
            return View("ViewGetPersonEqualsYear", equal);
        }
         public IActionResult GetPersonGreaterThanYear(int year)
        {
            var greater = members.Where(s => s.DateOfBirth.Year > year).ToList();
            return View("ViewGetPersonGreaterThanYear", greater);
        }
         public IActionResult GetPersonLessThanYear(int year)
        {
            var less = members.Where(s => s.DateOfBirth.Year < year).ToList();
            return View("ViewGetPersonLessThanYear", less);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}