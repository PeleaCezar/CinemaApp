#pragma checksum "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d816d75663fbcf9865a4b23fad26d3306f2d02e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
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
#line 1 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\_ViewImports.cshtml"
using CinemaApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\_ViewImports.cshtml"
using CinemaApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d816d75663fbcf9865a4b23fad26d3306f2d02e1", @"/Views/Movies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8084176d599023adc56a4b10a115bd11b8f0b29", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CinemaApp.ViewModels.MovieGenreViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid jumbo-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-height: 100px;min-height: 430px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("movie image-cap"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" ml-auto btn btn-success mr-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "VerifyCinemaHallandDate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "RunningTime", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
 foreach (var movie in Model)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            WriteLiteral(" ");
#nullable restore
#line 7 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
         
        var photoPath = "~/Photo/" + (movie.Movie.PhotoPath ?? "noimage.jpg");
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"jumbotron\">");
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-xl-4 col-md-6 offset-md-3 offset-lg-0 text-center\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d816d75663fbcf9865a4b23fad26d3306f2d02e16382", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                                                                     WriteLiteral(photoPath);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 17 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <br class=\"d-lg-none\" /><br class=\"d-lg-none\" />\r\n        </div>\r\n        <div class=\"col\">\r\n            <h1 class=\"display-4\">");
#nullable restore
#line 21 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                             Write(movie.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            <hr class=\"my-4\">\r\n            <span>\r\n");
#nullable restore
#line 24 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                 if (movie.Description.Count() > 800)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a class=\"btn btn-primary btn-sm m-1\" role=\"button\" data-toggle=\"modal\" data-target=\"#description-modal\">Read more</a>\r\n");
#nullable restore
#line 28 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"

                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
               Write(movie.Description);

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                      
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </span>\r\n            <br /><br />\r\n\r\n            <p><strong>Director: </strong><a> Chritian Garcia </a></p>\r\n            <p>\r\n                <strong> Genres: </strong>\r\n");
#nullable restore
#line 40 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                 foreach (var genre in movie.GenreNames)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a class=\"badge badge-secondary\">");
#nullable restore
#line 42 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                                Write(genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 43 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </p>\r\n\r\n\r\n            <p><strong>Release Date: </strong>");
#nullable restore
#line 47 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                         Write(movie.ReleaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n            <p><strong>Runtime: </strong>");
#nullable restore
#line 49 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                    Write(movie.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

            <div class=""d-flex align-items-center mt-4"">
                <a class=""btn btn-primary mr-3"" href=""#"" role=""button"" data-toggle=""modal"" data-target=""#watch-modal"">Watch Thriler</a>

                <button class=""btn btn-info mr-3"" id=""bookingButton"" onclick=""onClickBooking()"">
                    <i class=""far fa-calendar-alt""></i>
                    <span class=""font-weight-medium""> Arată-mi programul</span>
                </button>

                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d816d75663fbcf9865a4b23fad26d3306f2d02e112386", async() => {
                WriteLiteral("Inapoi la filme");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 64 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
     foreach (var bookings in Model)
    {



#line default
#line hidden
#nullable disable
            WriteLiteral("            <div id=\"booking\" style=\"display:none\">\r\n                <div class=\"booking-inserted\">\r\n                    <p class=\"m-0 font-size-small\"></p>\r\n                    <div class=\"text-center\">\r\n                    </div>\r\n");
#nullable restore
#line 73 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                     if (bookings.AllBookings.Count != 0)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                         foreach (var booking in bookings.AllBookings)
                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d816d75663fbcf9865a4b23fad26d3306f2d02e114764", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 78 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                                                                                   WriteLiteral(bookings.MovieID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 78 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                                                                                                                           WriteLiteral(booking.StartDate);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["StartDate"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-StartDate", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["StartDate"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            <div class=""d-flex w-100"">
                                <div class=""appointment-container my-1 mr-1 booking-inserted"">
                                    <div class=""date text-center d-inline-flex justify-content-center flex-column border-positive p-1 border-no-shadow my-auto"">
                                        <div class=""font-weight-regular m-0"">");
#nullable restore
#line 82 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                                                        Write(booking.DayOfWeek);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                        <div class=\"font-weight-bold m-0\">");
#nullable restore
#line 83 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                                                     Write(booking.HourOfDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                        <div class=\"font-weight-regular m-0\">");
#nullable restore
#line 84 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                                                        Write(booking.DayOfMonth);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 84 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                                                                            Write(booking.MonthOfYear);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 88 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                         
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"text-center\">\r\n                            <span class=\"font-size text-danger\"> Nu este nicio programare disponibila pentru acest film.</span>\r\n                        </div>\r\n");
#nullable restore
#line 95 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    \r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 101 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
            WriteLiteral(@"    <div class=""modal fade"" id=""watch-modal"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog modal-lg modal-dialog-centered"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h2 class=""modal-title""> ");
#nullable restore
#line 111 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                        Write(movie.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""embed-responsive embed-responsive-16by9"">
                        <div class=""video"" id=""trailer"">
                            <script>
                              setTimeout(function () {
                                searchMovie('");
#nullable restore
#line 121 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                        Write(movie.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\')\r\n                                }, 500);\r\n                            </script>\r\n\r\n\r\n                        </div>\r\n                    </div>\r\n                    <br />\r\n                    <p>\r\n                        <strong>Descriere : </strong>");
#nullable restore
#line 130 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
                                                Write(movie.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 136 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Movies\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"




<style>
    .booking-inserted {
        display: flex;
        margin-left: 5px;
        position: relative;
        left: -10px;
    }
    
    .jumbotron {
        padding: 42px;
    }

    .jumbo-image {
        cursor: pointer;
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    }

    .badge-secondary {
        color: #fff !important;
    }

    /*booking inserted*/
    .font-size-small {
        font-size: .765rem !important
    }

    p {
        line-height: 1.4;
    }

    .date {
        width: 4rem;
        height: 4rem;
        border-radius: 100%;
        font-size: 0.8rem;
        line-height: 0.8rem;
        font-weight: 400 !important;
    }

    .border-positive {
        border: .1rem solid #58c314;
        /*box-shadow: 0 6px 20px 1px rgba(88,195,20,.43);*/
        background: #fefeff;
    }

    .border-no-shadow {
        box-shadow: none;
    }

    .font-weight-regular {
        font-weight");
            WriteLiteral(@": 400 !important;
    }
    .text-danger {
        color: #e91e63 !important;
        fill: #e91e63 !important;
    }
    .font-size {
        font-size: .865rem !important
    }
</style>



<script>
   function onClickBooking(){
       var myBooking = document.getElementById('booking');      
       var displaySetting = myBooking.style.display; // get the current value of myBooking display property
      // var myBookingButton = document.getElementById('bookingButton');
        // toggle the booking and the button text, depending on current state
       if (displaySetting == 'block') {
           myBooking.style.display = 'none';
          // myBookingButton.innerHTML = ""Arata-mi programul"";
       }
       else {
           myBooking.style.display = 'block';
          // myBookingButton.innerHTML = ""Ascunde programul"";
       } 
    }
</script>






















");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CinemaApp.ViewModels.MovieGenreViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
