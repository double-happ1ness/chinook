#pragma checksum "D:\DOWNLOADS\STUDY\UNI\IS\PROJECTS\CourseworkTwo\CourseworkTwo\WebApp\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "453a703dd2a49f146e509557693754ec330dc5a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"453a703dd2a49f146e509557693754ec330dc5a2", @"/Pages/Index.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"jumbotron\">\r\n    <h1 class=\"display-3\">Welcome to Chinook!</h1>\r\n    <p class=\"lead\">We supply products to our customers.</p>\r\n    <hr />\r\n    <p>It\'s ");
#nullable restore
#line 33 "D:\DOWNLOADS\STUDY\UNI\IS\PROJECTS\CourseworkTwo\CourseworkTwo\WebApp\Pages\Index.cshtml"
       Write(Model.DayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("! Our customers include restaurants, hotels, and cruise lines.</p>\r\n    <p>\r\n        <a class=\"btn btn-primary\" href=\"albums\">Learn more about our albums</a>\r\n    </p>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 21 "D:\DOWNLOADS\STUDY\UNI\IS\PROJECTS\CourseworkTwo\CourseworkTwo\WebApp\Pages\Index.cshtml"
 
    public string DayName { get; set; }
    public void OnGet()
    {
        ViewData["Title"] = "Chinook Website";
        Model.DayName = DateTime.Now.ToString("dddd");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_Index> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Index> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Index>)PageContext?.ViewData;
        public Pages_Index Model => ViewData.Model;
    }
}
#pragma warning restore 1591
