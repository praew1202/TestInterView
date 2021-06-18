using API.service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API
{
    public class IndexModel :PageModel
    {
        private readonly MyDependency _myDependency = new MyDependency();
        public void OnGet(){
            _myDependency.WriteMessage("hello");
        }
    }
}