#pragma checksum "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a346544348a2c8d9ccacfd9efcd9129c78c0e11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Seats_ListOfSeats), @"mvc.1.0.view", @"/Views/Seats/ListOfSeats.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a346544348a2c8d9ccacfd9efcd9129c78c0e11", @"/Views/Seats/ListOfSeats.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8084176d599023adc56a4b10a115bd11b8f0b29", @"/Views/_ViewImports.cshtml")]
    public class Views_Seats_ListOfSeats : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CinemaApp.ViewModels.CinemaHall>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a346544348a2c8d9ccacfd9efcd9129c78c0e113213", async() => {
                WriteLiteral("\r\n\r\n    <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js\"></script>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a346544348a2c8d9ccacfd9efcd9129c78c0e114293", async() => {
                WriteLiteral("\r\n    <h1 class=\"title\"> Rezerva loc :</h1>\r\n\r\n    <div class=\"theatre\">\r\n\r\n        <div class=\"cinema-seats left\">\r\n");
#nullable restore
#line 15 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
             foreach (var leftHall in Model.LeftHall)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div");
                BeginWriteAttribute("class", " class=", 372, "", 416, 1);
#nullable restore
#line 17 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
WriteAttributeValue("", 379, $"cinema-row row-{leftHall.RowNr}", 379, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 18 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                     foreach (var seats in leftHall.Seats)
                    {
                        if (@seats.Status == "Liber")
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"seat\">\r\n                                <div class=\"text-center\" data-id=\"");
#nullable restore
#line 23 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                                                             Write(seats.SeatNr);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">");
#nullable restore
#line 23 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                                                                            Write(seats.SeatNr);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n");
#nullable restore
#line 25 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                        }
                        else if (seats.Status == "Rezervat")
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"seat active\" style=\"pointer-events: none\">\r\n                                <div class=\"text-center\" data-id=\"");
#nullable restore
#line 29 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                                                             Write(seats.SeatNr);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"><span>(R)</span></div>\r\n                            </div>\r\n");
#nullable restore
#line 31 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </div>\r\n");
#nullable restore
#line 34 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n\r\n\r\n        <div class=\"cinema-seats right\">\r\n");
#nullable restore
#line 39 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
             foreach (var rightHall in Model.RightHall)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div");
                BeginWriteAttribute("class", " class=", 1354, "", 1399, 1);
#nullable restore
#line 41 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
WriteAttributeValue("", 1361, $"cinema-row row-{rightHall.RowNr}", 1361, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 42 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                     foreach (var seats in rightHall.Seats)
                    {

                        if (@seats.Status == "Liber")
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"seat\">\r\n                                <div class=\"text-center\" data-id=\"");
#nullable restore
#line 48 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                                                             Write(seats.SeatNr);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">");
#nullable restore
#line 48 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                                                                            Write(seats.SeatNr);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            </div>\r\n");
#nullable restore
#line 50 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                        }
                        else if (seats.Status == "Rezervat")
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"seat active\" style=\"pointer-events: none\">\r\n                                <div class=\"text-center\" data-id=\"");
#nullable restore
#line 54 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                                                             Write(seats.SeatNr);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"><span>(R)</span></div>\r\n                            </div>\r\n");
#nullable restore
#line 56 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                        }

                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </div>\r\n");
#nullable restore
#line 60 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        </div>


    </div>
    <div class=""screen text-center"">SCREEN</div>

    <!-- Modal Confirmation-->
    <div class=""modal fade"" id=""modalConfirm"" tabindex=""-1"" role=""dialog"" aria-labelledby=""modalConfirmTitle"" aria-hidden=""true"">

        <div class=""modal-dialog modal-dialog-centered "" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title""> Confirmare rezervare</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>

                <div class=""modal-body"">
                    <div class=""p-2"">
                        <div class=""form-row"">
                            <div class=""col-md-6"">
                                <div class=""mb-4"">
                                    <h6 for=""movieDisplay"">Numele filmului</h6>
         ");
                WriteLiteral(@"                           <input disabled class=""form-control"" id=""movieDisplay"" style=""text-align:center;border: 1px solid #888;"">
                                </div>
                            </div>
                            <div class=""col-md-6"">
                                <div class=""mb-4"">
                                    <h6 for=""dateDisplay"">Data filmului</h6>
                                    <input disabled class=""form-control"" id=""dateDisplay"" style=""text-align:center;border: 1px solid #888;"">
                                </div>
                            </div>
                            

                        </div>
                        <div class=""form-row"">
                            <div class=""col-md-6"">
                                <div class=""mb-4"">
                                    <h6 for=""seatsDisplay"">Scaune</h6>
                                    <textarea disabled class=""form-control"" id=""seatsDisplay"" style=""text-align:center;border:");
                WriteLiteral(@" 1px solid #888; resize:none;""></textarea>
                                </div>
                                </div>
                                <div class=""col-md-6"">
                                    <div class=""mb-4"">
                                        <h6 for=""cinemaDisplay"">Sala</h6>
                                        <input disabled class=""form-control"" id=""cinemaDisplay"" style=""text-align:center;border: 1px solid #888;"">
                                    </div>
                                </div>
                            </div>
                        <div class=""form-row"">
                            <div class=""col-md-6"">
                                <div class=""mb-4"">
                                    <h6 for=""ticketDisplay"">Numar Bilete</h6>
                                    <input disabled class=""form-control"" id=""ticketDisplay"" style=""text-align:center;border: 1px solid #888; "">
                                </div>
                            <");
                WriteLiteral(@"/div>
                            <div class=""col-md-6"">
                                <div class=""mb-4"">
                                    <h6 for=""totalDisplay"">Cost</h6>
                                    <input disabled class=""form-control"" id=""totalDisplay"" style=""text-align:center;border: 1px solid #888;"">
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class=""modal-footer justify-content-between"">
                    <button type=""button"" class=""btn btn-light text-left"">Inapoi</button>
                    <div class=""text-right"">
                        <button type=""button"" class=""btn btn-primary btnSave"" id=""confirm-button"" data-dismiss=""modal"">Confirma</button>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class=""reserve"">
        <div class="" card-body reservation"">
            <p> <s");
                WriteLiteral("trong> Film :</strong> <span id=\"name\">");
#nullable restore
#line 141 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                                                    Write(Model.MovieName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> </p>\r\n            <p> <strong> Data : </strong> <span id=\"date\">");
#nullable restore
#line 142 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                                                     Write(Model.Date);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></p>\r\n            <p> <strong> Sala de Cinema : </strong> <span id=\"cinema\">");
#nullable restore
#line 143 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                                                                 Write(Model.CinemaNo);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span></p>

            <p>
                <strong> Legenda : </strong>
                <div class=""row"">
                    <div class=""oneSeat""><span class=""descriptionSeat""> Liber</span></div>
                    <div class=""secondSeat active""> <span class=""descriptionSeat""> Selectat</span></div>
                    <div class=""thirdSeat active""> <span class=""descriptionSeat""> Rezervat </span></div>
                </div>

            </p>

            <p> <strong> Scaun : </strong> </p>

            <ul id=""selected-seats""></ul>
            <p><strong> Locuri rezervate : </strong> <span id=""counter"">0</span></p>
            <p><strong>Total : </strong><span id=""total"">0</span> RON</p>
            <div class=""confirm-form"">
                <button class=""btn-light btnReserved"" data-id=""");
#nullable restore
#line 161 "C:\Users\Cezar\source\repos\CinemaApp\CinemaApp\Views\Seats\ListOfSeats.cshtml"
                                                          Write(Model.MovieID);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">Confirmare</button>\r\n            </div>\r\n\r\n\r\n\r\n        </div>\r\n        <div style=\"clear:both\"></div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"





<style>
    /* Seat legend -----------------*/
    .row {
        margin-top:30px;
    }
    /*--first seat --*/
    .oneSeat {
        margin-left:15px;
        width: 30px;
        height: 40px;
        border-radius: 7px;
        background: linear-gradient(to top, #761818, #761818, #761818, #761818, #761818, #B54041, #F3686A);
        margin-bottom: 5px;
        margin-top: -15px;
        box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
    }
    .descriptionSeat {
      position:relative; left:50px; bottom:-5px;
    }
    /*---second Seat*/
    .secondSeat {
        margin-left:75px;
        width: 30px;
        height: 40px;
        border-radius: 7px;
        background: linear-gradient(to top, #761818, #761818, #761818, #761818, #761818, #B54041, #F3686A);
        margin-bottom: 5px;
        margin-top: -15px;
        box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
    }
    .secondSeat.active:before {
        content: '';
        position: absolute;
        width: 30px;
 ");
            WriteLiteral(@"       height: 40px;
        background: rgba(255, 255, 255, 0.6);
        border-radius: 7px;
        box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
    }
    /*---Third Seat*/
    .thirdSeat {
        margin-left: 100px;
        width: 30px;
        height: 40px;
        border-radius: 7px;
        background: linear-gradient(to top, #761818, #761818, #761818, #761818, #761818, #B54041, #F3686A);
        margin-bottom: 5px;
        margin-top: -15px;
        box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
    }

        .thirdSeat.active:before {
            content: '(R)';
            text-align: center;
            position: absolute;
            width: 30px;
            height: 40px;
            background: rgba(255, 255, 255, 0.6);
            border-radius: 7px;
            box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
            color: #f1c6c7;
        }
        /*end seats*/
    .screen {
        position: absolute;
        bottom: 0;
        width: 50%;
        background: #f8f9fa;
   ");
            WriteLiteral(@"     border-color: #f8f9fa;
        color: #212529 !important;
        margin-bottom: 237px;
        box-shadow: 0 0 3px rgba(0, 0, 0, 0.5);
        margin-left: 15px;
        margin-right: 15px;
        border-radius: 5px;
    }



    /* Reservation panel -----------------*/
    .reservation {
        background: #c6cace;
        float: right;
        position: relative;
        width: 320px;
        height: 450px;
    }

        .reservation p {
            line-height: 26px;
            font-size: 17.5px;
            margin-bottom: 1.5rem;
            margin-top: revert;
        }

    #selected-seats {
        max-height: 100px;
        width: 120px;
        background: #f7f7f7;
        font-size: 15px;
        font-weight: bold;
        text-align: center;
        overflow-y: auto;
        padding-left: 0.5px;
    }


    /*---finish */
    body {
        background: #c6cace;
        color: #687078 !important;
    }

    .theatre {
        display: flex;
  ");
            WriteLiteral(@"      position: absolute;
        top: 40%;
        left: 40%;
        transform: translate(-50%, -50%);
    }

    .cinema-seats {
        display: flex;
    }

        .cinema-seats .seat {
            cursor: pointer;
        }

            .cinema-seats .seat:hover:before {
                content: '';
                position: absolute;
                top: 0;
                width: 100%;
                height: 100%;
                background: rgba(0, 0, 0, 0.5);
                border-radius: 7px;
            }

            .cinema-seats .seat.active:before {
                content: '';
                position: absolute;
                top: 0;
                width: 100%;
                height: 100%;
                background: rgba(255, 255, 255, 0.6);
                border-radius: 7px;
            }

    .left .cinema-row {
        transform: skew(-15deg);
        margin: 0 6px;
    }

    .left .seat {
        width: 35px;
        height: 50px;
       ");
            WriteLiteral(@" border-radius: 7px;
        background: linear-gradient(to top, #761818, #761818, #761818, #761818, #761818, #B54041, #F3686A);
        margin-bottom: 10px;
        transform: skew(20deg);
        margin-top: -32px;
        box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
    }



    .right {
        margin-left: 70px;
    }

        .right .cinema-row {
            transform: skew(7deg);
            margin: 0 6px;
        }

        .right .seat {
            width: 35px;
            height: 50px;
            border-radius: 7px;
            background: linear-gradient(to top, #761818, #761818, #761818, #761818, #761818, #B54041, #F3686A);
            margin-bottom: 10px;
            transform: skew(-8deg);
            margin-top: -32px;
            box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
        }




    .text-center {
        color: #F3686A;
    }

    .title {
        color: #2517174f;
    }

    /* modal*/
    .p-2 {
        padding: .75rem !important;
        white-s");
            WriteLiteral(@"pace: normal;
    }


.modal-dialog {
    max-width: 540px;
    margin: 1.75rem auto;
}
    .form-row > .col, .form-row > [class*=col-] {
         padding-right: 15px; 
         padding-left: 15px; 
    }
    .form-control:disabled, .form-control[readonly] {
        background-color: #e3e5e7;
        opacity: 1;
    }
</style>


<script>
    $(document).ready(function () {
        $("".confirm-form *"").prop(""disabled"", true);
        let count = 0;
        

        $('.cinema-seats .seat').on('click', function (e) {
            e.preventDefault();

            var seatNr = $(this).children('div').data('id');
            var $cart = $('#selected-seats');

            var price = 20;
            $total = $('#total');

            if (!$(this).hasClass('active')) {
                $('<div>Scaunul ' + (seatNr) + '</div>')
                    .attr('id', 'seat-item-' + seatNr)
                    .data('id', seatNr)
                    .appendTo($cart);
                $(this");
            WriteLiteral(@").toggleClass('active');
                var theStatus = 'selected'
                $("".confirm-form *"").prop(""disabled"", false);
                count++;
                $('#counter').empty().append(count);
                $total.text(recalculateTotal(count, price));

            }


            else if (theStatus = 'selected' && $(this).hasClass('active')) {
                $('#seat-item-' + seatNr).remove();
                $(this).removeClass('active');
                count--;
                if (count == 0) {
                    $("".confirm-form *"").prop(""disabled"", true);
                }
                $('#counter').empty().append(count);
                $total.text(recalculateTotal(count, price));
            }

            else {
                return ""unavailable"";
            }
        });
    });


    function recalculateTotal(count, price) {
        var total = 0;
        for (var i = 1; i <= count; i++) {
            total += price;
        }
        return ");
            WriteLiteral(@"total;
    }




    $('button.btnReserved').on('click', function (e) {

        e.preventDefault();
        var movieID = $(this).closest('button').data('id');
        $('#modalConfirm').data('id', movieID).modal('show');
    
        var name = document.getElementById(""name"").innerText;
        $(""#movieDisplay"").val(name);
        var date = document.getElementById(""date"").innerText;
        $(""#dateDisplay"").val(date);
        var noOfTicket = document.getElementById(""counter"").innerText;
        $(""#ticketDisplay"").val(noOfTicket);
        var price = document.getElementById(""total"").innerText;
        $(""#totalDisplay"").val(price);
        var cinema = document.getElementById(""cinema"").innerText;
        $(""#cinemaDisplay"").val(cinema);
        var seatReserved = document.getElementById(""selected-seats"").innerText;
        $(""#seatsDisplay"").val(seatReserved);
        debugger;
        

    })

    $(""#confirm-button"").on(""click"", function () {
        var movieID = $('#mo");
            WriteLiteral(@"dalConfirm').data('id');
        var date = $(""#dateDisplay"").val();
        var cinema = $(""#cinemaDisplay"").val();
        var seatReserved = $(""#seatsDisplay"").val();


        var reservation = {};
        reservation.movieDate = date;
        var stringWithoutSpaces =seatReserved.replace(/\s/g, ''); // delete  wrong spaces from my string
        var seat = stringWithoutSpaces.match(/\d+/g); // get a numbers from seat and move them in the array
        reservation.seatReserved = seat;
        reservation.movieID = movieID;
        reservation.cinema = cinema;
        var reservation = JSON.stringify(reservation);
        $.ajax({
            type: 'POST',
            data: { jsonResult: reservation },
            url: '/Seats/CreateReservation',
            dataType: ""text"",
            success: function (data) {
                window.location.reload();
            }
        });

    });


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CinemaApp.ViewModels.CinemaHall> Html { get; private set; }
    }
}
#pragma warning restore 1591
