document.addEventListener("DOMContentLoaded", function () {
    // Brush Chart with Total Sales in Colones (50,000 to 450,000 range)

    var brushchartLine2Colors = getChartColorsArray("brushchart_line2");
    if (brushchartLine2Colors) {
        var options = {
            series: [{
                name: 'Total Sales',
                data: [
                    { x: new Date(2022, 0, 1), y: 85000 },
                    { x: new Date(2022, 1, 1), y: 95000 },
                    { x: new Date(2022, 2, 1), y: 120000 },
                    { x: new Date(2022, 3, 1), y: 150000 },
                    { x: new Date(2022, 4, 1), y: 170000 },
                    { x: new Date(2022, 5, 1), y: 200000 },
                    { x: new Date(2022, 6, 1), y: 230000 },
                    { x: new Date(2022, 7, 1), y: 250000 },
                    { x: new Date(2022, 8, 1), y: 270000 },
                    { x: new Date(2022, 9, 1), y: 300000 },
                    { x: new Date(2022, 10, 1), y: 330000 },
                    { x: new Date(2022, 11, 1), y: 350000 },
                    { x: new Date(2023, 0, 1), y: 80000 },
                    { x: new Date(2023, 1, 1), y: 110000 },
                    { x: new Date(2023, 2, 1), y: 130000 },
                    { x: new Date(2023, 3, 1), y: 160000 },
                    { x: new Date(2023, 4, 1), y: 190000 },
                    { x: new Date(2023, 5, 1), y: 100000 },
                    { x: new Date(2023, 6, 1), y: 140000 },
                    { x: new Date(2023, 7, 1), y: 170000 },
                    { x: new Date(2023, 8, 1), y: 200000 },
                    { x: new Date(2023, 9, 1), y: 230000 },
                    { x: new Date(2023, 10, 1), y: 260000 },
                    { x: new Date(2023, 11, 1), y: 290000 },
                    { x: new Date(2024, 0, 1), y: 100000 },
                    { x: new Date(2024, 1, 1), y: 130000 },
                    { x: new Date(2024, 2, 1), y: 160000 },
                    { x: new Date(2024, 3, 1), y: 190000 },
                    { x: new Date(2024, 4, 1), y: 250000 },
                    { x: new Date(2024, 5, 1), y: 320000 },
                    { x: new Date(2024, 6, 1), y: 380000 },
                    { x: new Date(2024, 7, 1), y: 310000 },
                    { x: new Date(2024, 8, 1), y: 250000 },
                    { x: new Date(2024, 9, 1), y: 280000 },
                    { x: new Date(2024, 10, 1), y: 250000 },
                    { x: new Date(2024, 11, 1), y: 220000 }
                ]
            }],
            chart: {
                id: 'chart2',
                type: 'line',
                height: 220,
                toolbar: {
                    autoSelected: 'pan',
                    show: false
                }
            },
            colors: brushchartLine2Colors,
            stroke: {
                width: 3
            },
            dataLabels: {
                enabled: false
            },
            fill: {
                opacity: 1,
            },
            markers: {
                size: 0
            },
            xaxis: {
                type: 'datetime'
            },
            yaxis: {
                min: 50000,
                max: 450000
            },
            tooltip: {
                y: {
                    formatter: function (value) {
                        return '₡' + value.toLocaleString('es-CR') + ' colones';
                    }
                }
            },
            legend: {
                show: true,
                position: 'top',
                horizontalAlign: 'right'
            }
        };

        var chart = new ApexCharts(document.querySelector("#brushchart_line2"), options);
        chart.render();
    }

    var brushchartLineColors = getChartColorsArray("brushchart_line");
    if (brushchartLineColors) {
        var optionsLine = {
            series: [{
                name: 'Total Sales',
                data: [
                    { x: new Date(2022, 0, 1), y: 85000 },
                    { x: new Date(2022, 1, 1), y: 95000 },
                    { x: new Date(2022, 2, 1), y: 120000 },
                    { x: new Date(2022, 3, 1), y: 150000 },
                    { x: new Date(2022, 4, 1), y: 170000 },
                    { x: new Date(2022, 5, 1), y: 200000 },
                    { x: new Date(2022, 6, 1), y: 230000 },
                    { x: new Date(2022, 7, 1), y: 250000 },
                    { x: new Date(2022, 8, 1), y: 270000 },
                    { x: new Date(2022, 9, 1), y: 300000 },
                    { x: new Date(2022, 10, 1), y: 330000 },
                    { x: new Date(2022, 11, 1), y: 350000 },
                    { x: new Date(2023, 0, 1), y: 80000 },
                    { x: new Date(2023, 1, 1), y: 110000 },
                    { x: new Date(2023, 2, 1), y: 130000 },
                    { x: new Date(2023, 3, 1), y: 160000 },
                    { x: new Date(2023, 4, 1), y: 190000 },
                    { x: new Date(2023, 5, 1), y: 100000 },
                    { x: new Date(2023, 6, 1), y: 140000 },
                    { x: new Date(2023, 7, 1), y: 170000 },
                    { x: new Date(2023, 8, 1), y: 200000 },
                    { x: new Date(2023, 9, 1), y: 230000 },
                    { x: new Date(2023, 10, 1), y: 260000 },
                    { x: new Date(2023, 11, 1), y: 290000 },
                    { x: new Date(2024, 0, 1), y: 100000 },
                    { x: new Date(2024, 1, 1), y: 130000 },
                    { x: new Date(2024, 2, 1), y: 160000 },
                    { x: new Date(2024, 3, 1), y: 190000 },
                    { x: new Date(2024, 4, 1), y: 250000 },
                    { x: new Date(2024, 5, 1), y: 320000 },
                    { x: new Date(2024, 6, 1), y: 380000 },
                    { x: new Date(2024, 7, 1), y: 310000 },
                    { x: new Date(2024, 8, 1), y: 250000 },
                    { x: new Date(2024, 9, 1), y: 280000 },
                    { x: new Date(2024, 10, 1), y: 250000 },
                    { x: new Date(2024, 11, 1), y: 220000 }
                ]
            }],
            chart: {
                id: 'chart1',
                height: 130,
                type: 'area',
                brush: {
                    target: 'chart2',
                    enabled: true
                },
                selection: {
                    enabled: true,
                    xaxis: {
                        min: new Date('19 Jun 2023').getTime(),
                        max: new Date('14 Aug 2023').getTime()
                    }
                },
            },
            colors: brushchartLineColors,
            fill: {
                type: 'gradient',
                gradient: {
                    opacityFrom: 0.91,
                    opacityTo: 0.1,
                }
            },
            xaxis: {
                type: 'datetime',
                tooltip: {
                    enabled: false
                }
            },
            yaxis: {
                min: 50000,
                max: 450000,
                tickAmount: 2,
                labels: {
                    formatter: function (value) {
                        return '₡' + value.toLocaleString('es-CR');
                    }
                }
            },
            tooltip: {
                y: {
                    formatter: function (value) {
                        return '₡' + value.toLocaleString('es-CR') + ' colones';
                    }
                }
            }
        };

        var chartLine = new ApexCharts(document.querySelector("#brushchart_line"), optionsLine);
        chartLine.render();
    }
});