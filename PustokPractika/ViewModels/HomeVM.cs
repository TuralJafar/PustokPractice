using Microsoft.AspNetCore.Mvc;
using PustokPractika.DAL;
using PustokPractika.Models;

namespace PustokPractika.ViewModels
{
    public class HomeVM
    {

        public List<Slide>slides { get; set; }
    }
}
