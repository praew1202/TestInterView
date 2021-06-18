using API.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API
{
    public class IndexModel2 : PageModel
    {
        public IMyDependency MyDependency { get; }
        public IndexModel2(IMyDependency myDependency)
        {
            MyDependency = myDependency;

        }
    }
}