#pragma checksum "C:\Users\camilo.lozano\source\repos\Guestbook\Guestbook\Views\Shared\_Pagination.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "918a77fc2fd5c7b266cbe5867d6338b1e2f1d97d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Pagination), @"mvc.1.0.view", @"/Views/Shared/_Pagination.cshtml")]
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
#line 1 "C:\Users\camilo.lozano\source\repos\Guestbook\Guestbook\Views\_ViewImports.cshtml"
using Guestbook;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\camilo.lozano\source\repos\Guestbook\Guestbook\Views\_ViewImports.cshtml"
using Guestbook.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"918a77fc2fd5c7b266cbe5867d6338b1e2f1d97d", @"/Views/Shared/_Pagination.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe50703c499f42c7088a01c50ebe005444171dd2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Pagination : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Guestbook.Models.GuestBookViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col col-12 text-right\">\r\n");
#nullable restore
#line 5 "C:\Users\camilo.lozano\source\repos\Guestbook\Guestbook\Views\Shared\_Pagination.cshtml"
             foreach (var offset in Model.Pagination.Pages)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"btn btn-secondary\"");
            BeginWriteAttribute("href", " href=\"", 234, "\"", 272, 2);
            WriteAttributeValue("", 241, "/Guestbook/Index?offset=", 241, 24, true);
#nullable restore
#line 7 "C:\Users\camilo.lozano\source\repos\Guestbook\Guestbook\Views\Shared\_Pagination.cshtml"
WriteAttributeValue("", 265, offset, 265, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 7 "C:\Users\camilo.lozano\source\repos\Guestbook\Guestbook\Views\Shared\_Pagination.cshtml"
                                                                               Write(offset);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> \r\n");
#nullable restore
#line 8 "C:\Users\camilo.lozano\source\repos\Guestbook\Guestbook\Views\Shared\_Pagination.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Guestbook.Models.GuestBookViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
