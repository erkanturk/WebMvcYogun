using _11_AutoMapper.Dto;
using _11_AutoMapper.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _11_AutoMapper.Controllers
{
    public class UserController(IMapper mapper) : Controller
    {
        public IActionResult Index()
        {
            var user = new User()
            {
                Id= 1,
                FirstName="Erkan",
                LastName="Türk",
                Email="erkanturk@gmail.com"
            };
            //DTo Dışarıya ekrana gelecek sadeleştirilmiş nesne 
            //Entity her alanı gösterilmez bazı alanlar birleştirilir(FirstName+LastName = FullName gibi)
            var userDto = mapper.Map<UserDto>(user);
            return View(userDto);
        }

        public IActionResult Index2()
        {
            var user = new User()
            {
                Id= 1,
                FirstName="Erkan",
                LastName="Türk",
                Email="erkanturk@gmail.com"
            };
            //DTo Dışarıya ekrana gelecek sadeleştirilmiş nesne 
            //Entity her alanı gösterilmez bazı alanlar birleştirilir(FirstName+LastName = FullName gibi)
           
            return View(user);
        }
    }
}
