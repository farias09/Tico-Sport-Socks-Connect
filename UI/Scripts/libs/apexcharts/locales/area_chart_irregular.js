document.addEventListener("DOMContentLoaded", function () {
    var series = {
        "productData": {
            "Producto A": {
                "sales": [25, 30, 45, 55, 60, 80, 90, 100, 110, 125, 140, 150],
                "dates": [
                    "01 Jan 2024", "01 Feb 2024", "01 Mar 2024", "01 Apr 2024", "01 May 2024",
                    "01 Jun 2024", "01 Jul 2024", "01 Aug 2024", "01 Sep 2024", "01 Oct 2024",
                    "01 Nov 2024", "01 Dec 2024"
                ]
            },
            "Producto B": {
                "sales": [20, 40, 35, 55, 70, 10, 45, 50, 60, 75, 85, 90],
                "dates": [
                    "01 Jan 2024", "01 Feb 2024", "01 Mar 2024", "01 Apr 2024", "01 May 2024",
                    "01 Jun 2024", "01 Jul 2024", "01 Aug 2024", "01 Sep 2024", "01 Oct 2024",
                    "01 Nov 2024", "01 Dec 2024"
                ]
            },
            "Producto C": {
                "sales": [40, 60, 55, 65, 100, 140, 170, 130, 90, 105, 95, 85],
                "dates": [
                    "01 Jan 2024", "01 Feb 2024", "01 Mar 2024", "01 Apr 2024", "01 May 2024",
                    "01 Jun 2024", "01 Jul 2024", "01 Aug 2024", "01 Sep 2024", "01 Oct 2024",
                    "01 Nov 2024", "01 Dec 2024"
                ]
            }
        }
    };

    var options = {
        series: [
            {
                name: 'Producto A',
                data: series.productData["Producto A"].sales
            },
            {
                name: 'Producto B',
                data: series.productData["Producto B"].sales
            },
            {
                name: 'Producto C',
                data: series.productData["Producto C"].sales
            }
        ],
        chart: {
            height: 350,
            type: 'area',
            toolbar: {
                show: false
            }
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'smooth',
            width: 3
        },
        xaxis: {
            type: 'datetime',
            categories: series.productData["Producto A"].dates,
            labels: {
                style: {
                    colors: '#878a99',
                    fontSize: '12px',
                    fontFamily: 'inherit'
                }
            },
            axisBorder: {
                show: false
            },
            axisTicks: {
                show: false
            }
        },
        yaxis: {
            labels: {
                style: {
                    colors: '#878a99',
                    fontSize: '12px',
                    fontFamily: 'inherit'
                },
                formatter: function (value) {
                    return value.toLocaleString();
                }
            }
        },
        grid: {
            show: true,
            borderColor: '#f1f1f1',
            strokeDashArray: 5
        },
        fill: {
            type: 'gradient',
            gradient: {
                shadeIntensity: 1,
                inverseColors: false,
                opacityFrom: 0.4,
                opacityTo: 0.1,
                stops: [0, 90, 100]
            }
        },
        tooltip: {
            x: {
                format: 'dd/MM/yyyy'
            },
            theme: 'light',
            style: {
                fontSize: '12px',
                fontFamily: 'inherit'
            }
        },
        legend: {
            position: 'top',
            horizontalAlign: 'right'
        },
        colors: ['#3577f1', '#0ab39c', '#f06548']
    };

    var chart = new ApexCharts(document.querySelector("#area_chart_irregular"), options);
    chart.render();
});