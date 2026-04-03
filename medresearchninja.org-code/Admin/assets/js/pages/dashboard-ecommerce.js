var products = [];
var MonthSale = [];
var MonthInitiated = [];
var DayMonthNYear = [];
var PayStatus = [];
var totalSales = 0;
var url = 'dashboard.aspx/MDashBoardChart';

$.ajax({
    type: 'POST',
    url: url,
    data: "{}",
    contentType: 'application/json; charset=utf-8',
    dataType: "json",
    async: false,
    success: function (data) {
        products = data.d;
        MonthSale = data.d.MonthSale;
        MonthInitiated = data.d.MonthInitiated;
        DayMonthNYear = data.d.DayMonthNYear;
        PayStatus = data.d.PayStatus;
        $(".MtotalSales").attr("data-target", data.d.TotalOrder || 0);
        $(".MtotalSales").html(data.d.TotalOrder.toLocaleString());
        $(".MconfirmedSale").attr("data-target", data.d.TotalPaid || 0);
        $(".MconfirmedSale").html(data.d.TotalPaid.toLocaleString());
        $(".MinitiatedSale").attr("data-target", data.d.TotalInitiated || 0);
        $(".MinitiatedSale").html(data.d.TotalInitiated.toLocaleString());
        $(".MconvRatio").attr("data-target", data.d.ConvPercent.toFixed(2));
        $(".MconvRatio").html(data.d.ConvPercent.toFixed(2));
    }
});


var options,
    options2,
    chart,
    worldemapmarkers,
    overlay,
    chartDonutBasicColors =
        (((options = {
            series: [
                //{ name: "Orders", type: "area", data: [34, 65, 46, 68, 49, 61, 42, 44, 78, 52, 63, 67] },
                { name: "Completed Sale", type: "area", data: MonthSale /*[89.25, 98.58, 68.74, 108.87, 77.54, 84.03, 51.24, 28.57, 92.57, 42.36, 88.51, 36.57]*/ },
                { name: "Initiated Sale", type: "area", data: MonthInitiated /*[8, 12, 7, 17, 21, 11, 5, 9, 7, 29, 12, 35]*/ },
            ],
            chart: {
                height: 370,
                type: "line",
                toolbar: { show: !1 }
            },
            stroke: { curve: "straight", dashArray: [0, 0, 8], width: [2, 0, 2.2] },
            fill: { opacity: [0.1, 0.2/*, 1*/] },
            markers: { size: [0, 0, 0], strokeWidth: 2, hover: { size: 4 } },
            xaxis: {
                categories: DayMonthNYear /*["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]*/,
                axisTicks: { show: !1 },
                axisBorder: { show: !1 }
            },
            grid: {
                show: !0, xaxis:
                {
                    lines: { show: !0 }
                },
                yaxis:
                {
                    lines:
                    {
                        show: !1
                    }
                },
                padding:
                {
                    top: 0,
                    right: -2,
                    bottom: 15,
                    left: 10
                }
            },
            legend: {
                show: !0,
                horizontalAlign: "center",
                offsetX: 0,
                offsetY: -5,
                markers: { width: 9, height: 9, radius: 6 },
                itemMargin: { horizontal: 10, vertical: 0 }
            },
            plotOptions: {
                bar:
                    { columnWidth: "30%", barHeight: "70%" }
            },
            colors: ['#45CB85', /*'#4b38b3',*/ '#f06548'],
            tooltip: {
                shared: !0,
                y: [
                ],
            },
        }),
            (chart = new ApexCharts(document.querySelector("#Mcustomer_impression_charts"), options)).render())
        )


$(document).ready(function () {
    $(".MfilterRev").click(function () {
        $("#Mcustomer_impression_charts").empty();
        $(".MfilterRev").removeClass("selected");
        $(this).addClass("selected");

        var fValue = $(this).attr("data-val");
        $.ajax({
            type: 'POST',
            url: "dashboard.aspx/MFilterDashBoardChart",
            data: "{fValue:'" + fValue + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (data) {
                products = data.d;
                MonthSale = data.d.MonthSale;
                MonthInitiated = data.d.MonthInitiated;
                DayMonthNYear = data.d.DayMonthNYear;

                $(".MtotalSales").attr("data-target", data.d.TotalOrder||0);
                $(".MtotalSales").html(data.d.TotalOrder.toLocaleString());
                $(".MconfirmedSale").attr("data-target", data.d.TotalPaid || 0);
                $(".MconfirmedSale").html(data.d.TotalPaid.toLocaleString());
                $(".MinitiatedSale").attr("data-target", data.d.TotalInitiated || 0);
                $(".MinitiatedSale").html(data.d.TotalInitiated.toLocaleString());
                $(".MconvRatio").attr("data-target", data.d.ConvPercent.toFixed(2));
                $(".MconvRatio").html(data.d.ConvPercent.toFixed(2));

                var options1,
                    chart1
                chartDonutBasicColors1 =
                    (((options1 = {
                        series: [
                            //{ name: "Orders", type: "area", data: [34, 65, 46, 68, 49, 61, 42, 44, 78, 52, 63, 67] },
                            { name: "Completed Sale", type: "area", data: MonthSale /*[89.25, 98.58, 68.74, 108.87, 77.54, 84.03, 51.24, 28.57, 92.57, 42.36, 88.51, 36.57]*/ },
                            { name: "Initiated Sale", type: "area", data: MonthInitiated /*[8, 12, 7, 17, 21, 11, 5, 9, 7, 29, 12, 35]*/ },
                        ],
                        chart: {
                            height: 370,
                            type: "line",
                            toolbar: { show: !1 }
                        },
                        stroke: { curve: "straight", dashArray: [0, 0, 8], width: [2, 0, 2.2] },
                        fill: { opacity: [0.1, 0.2/*, 1*/] },
                        markers: { size: [0, 0, 0], strokeWidth: 2, hover: { size: 4 } },
                        xaxis: {
                            categories: DayMonthNYear /*["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]*/,
                            axisTicks: { show: !1 },
                            axisBorder: { show: !1 }
                        },
                        grid: {
                            show: !0, xaxis:
                            {
                                lines: { show: !0 }
                            },
                            yaxis:
                            {
                                lines:
                                {
                                    show: !1
                                }
                            },
                            padding:
                            {
                                top: 0,
                                right: -2,
                                bottom: 15,
                                left: 10
                            }
                        },
                        legend: {
                            show: !0,
                            horizontalAlign: "center",
                            offsetX: 0,
                            offsetY: -5,
                            markers: { width: 9, height: 9, radius: 6 },
                            itemMargin: { horizontal: 10, vertical: 0 }
                        },
                        plotOptions: {
                            bar:
                                { columnWidth: "30%", barHeight: "70%" }
                        },
                        colors: ['#45CB85', /*'#4b38b3',*/ '#f06548'],
                        tooltip: {
                            shared: !0,
                            y: [],
                        },
                    }),
                        (chart1 = new ApexCharts(document.querySelector("#Mcustomer_impression_charts"), options1)).render())
                    )
            }
        });
    });
});

 
