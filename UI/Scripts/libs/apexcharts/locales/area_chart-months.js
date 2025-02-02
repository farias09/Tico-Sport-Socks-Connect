// Datos simulados para el gráfico
const githubdata = {
    series: [
        [new Date('2024-01-01').getTime(), 30],
        [new Date('2024-02-01').getTime(), 40],
        [new Date('2024-03-01').getTime(), 25],
        [new Date('2024-04-01').getTime(), 35],
        [new Date('2024-05-01').getTime(), 50],
        [new Date('2024-06-01').getTime(), 55],
        [new Date('2024-07-01').getTime(), 60],
        [new Date('2024-08-01').getTime(), 45],
        [new Date('2024-09-01').getTime(), 30],
        [new Date('2024-10-01').getTime(), 40],
        [new Date('2024-11-01').getTime(), 20],
        [new Date('2024-12-01').getTime(), 35]
    ]
};

// Función para renderizar gráficos
function renderCharts() {
    var areachartMonthsColors = getChartColorsArray("area_chart-months");
    if (areachartMonthsColors) {
        var options = {
            series: [{
                name: 'Ventas Mensuales',
                data: githubdata.series
            }],
            chart: {
                id: 'chartyear',
                type: 'area',
                height: 120,
                toolbar: { show: false },
                events: {
                    mounted: function (chart) {
                        updateCommits(chart);
                    },
                    updated: function (chart) {
                        updateCommits(chart);
                    }
                }
            },
            colors: areachartMonthsColors,
            stroke: { width: 0, curve: 'smooth' },
            dataLabels: { enabled: false },
            fill: { opacity: 1, type: 'solid' },
            yaxis: { show: false },
            xaxis: { type: 'datetime' }
        };
        var chart = new ApexCharts(document.querySelector("#area_chart-months"), options);
        chart.render();
    }

    var areachartyearsColors = getChartColorsArray("area_chart-years");
    if (areachartyearsColors) {
        var optionsYears = {
            series: [{
                name: 'Commits Anuales',
                data: githubdata.series
            }],
            chart: {
                height: 170,
                type: 'area',
                toolbar: { autoSelected: 'selection' },
                brush: { enabled: true, target: 'chartyear' },
                selection: {
                    enabled: true,
                    xaxis: {
                        min: new Date('2024-01-01').getTime(),
                        max: new Date('2024-12-31').getTime()
                    }
                }
            },
            colors: areachartyearsColors,
            dataLabels: { enabled: false },
            stroke: { width: 0, curve: 'smooth' },
            fill: { opacity: 1, type: 'solid' },
            legend: { position: 'top', horizontalAlign: 'left' },
            xaxis: { type: 'datetime' }
        };
        var chartYears = new ApexCharts(document.querySelector("#area_chart-years"), optionsYears);
        chartYears.render();
    }
}

// Función para actualizar commits
function updateCommits(chart) {
    var commitsEl = document.querySelector('.cmeta span.commits');
    var commits = chart.getSeriesTotalXRange(chart.w.globals.minX, chart.w.globals.maxX);
    commitsEl.innerHTML = commits;
}

// Función para obtener colores del gráfico
function getChartColorsArray(chartId) {
    // Implement this function to return the colors array based on the chartId
    return ['#1E90FF', '#32CD32', '#FFA500', '#FF6347', '#9370DB'];
}

// Llamar a la función para renderizar gráficos
renderCharts();