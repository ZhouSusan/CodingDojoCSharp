#pragma checksum "C:\Users\szhou\c#\c#_.Net_Core\Crudelicious\Views\Home\ViewDish.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51644e7e4e259e128382b9970dc4c58780f1adbe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewDish), @"mvc.1.0.view", @"/Views/Home/ViewDish.cshtml")]
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
#nullable restore
#line 1 "C:\Users\szhou\c#\c#_.Net_Core\Crudelicious\Views\_ViewImports.cshtml"
using Crudelicious;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\szhou\c#\c#_.Net_Core\Crudelicious\Views\_ViewImports.cshtml"
using Crudelicious.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\szhou\c#\c#_.Net_Core\Crudelicious\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51644e7e4e259e128382b9970dc4c58780f1adbe", @"/Views/Home/ViewDish.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57463720301c40e017233f1c7d6c0aaeeeb8621f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewDish : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dish>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<a href=\"/\">Home</a>\r\n<h1>");
#nullable restore
#line 4 "C:\Users\szhou\c#\c#_.Net_Core\Crudelicious\Views\Home\ViewDish.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h3>");
#nullable restore
#line 5 "C:\Users\szhou\c#\c#_.Net_Core\Crudelicious\Views\Home\ViewDish.cshtml"
Write(Model.Chef);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<hr>\r\n\r\n<p>");
#nullable restore
#line 8 "C:\Users\szhou\c#\c#_.Net_Core\Crudelicious\Views\Home\ViewDish.cshtml"
Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Calories: ");
#nullable restore
#line 9 "C:\Users\szhou\c#\c#_.Net_Core\Crudelicious\Views\Home\ViewDish.cshtml"
        Write(Model.Calories);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Tastiness: ");
#nullable restore
#line 10 "C:\Users\szhou\c#\c#_.Net_Core\Crudelicious\Views\Home\ViewDish.cshtml"
         Write(Model.Tastiness);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n<a");
            BeginWriteAttribute("href", " href=\"", 190, "\"", 218, 2);
            WriteAttributeValue("", 197, "/delete/", 197, 8, true);
#nullable restore
#line 12 "C:\Users\szhou\c#\c#_.Net_Core\Crudelicious\Views\Home\ViewDish.cshtml"
WriteAttributeValue("", 205, Model.DishId, 205, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Delete</a>\r\n<a");
            BeginWriteAttribute("href", " href=\"", 257, "\"", 283, 2);
            WriteAttributeValue("", 264, "/edit/", 264, 6, true);
#nullable restore
#line 13 "C:\Users\szhou\c#\c#_.Net_Core\Crudelicious\Views\Home\ViewDish.cshtml"
WriteAttributeValue("", 270, Model.DishId, 270, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">Edit</a>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dish> Html { get; private set; }
    }
}
#pragma warning restore 1591