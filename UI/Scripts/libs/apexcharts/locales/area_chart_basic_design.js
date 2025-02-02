document.addEventListener("DOMContentLoaded", function () {
    var series = {
        "monthDataSeries1": {
            "sales": [
                30000, 50000, 45000, 60000, 90000, 120000, 150000, 110000, 80000, 95000, 85000, 75000, // 2022
                100000, 120000, 130000, 140000, 150000, 160000, 170000, 180000, 190000, 200000, 210000, 220000, // 2023
                230000, 240000, 250000, 260000, 270000, 280000, 290000, 300000, 310000, 320000, 330000, 340000  // 2024
            ]
        }
    };

    // Agrupar ventas por año
    const ventasPorAno = {
        2022: series.monthDataSeries1.sales.slice(0, 12),
        2023: series.monthDataSeries1.sales.slice(12, 24),
        2024: series.monthDataSeries1.sales.slice(24)
    };

    // Calcular promedio de ventas por año
    const promediosPorAno = {};
    Object.keys(ventasPorAno).forEach(ano => {
        const ventasAno = ventasPorAno[ano];
        const promedioAno = ventasAno.reduce((sum, venta) => sum + venta, 0) / ventasAno.length;
        promediosPorAno[ano] = promedioAno;
    });

    // Imprimir resultados
    console.log("Promedios de Ventas Anuales:");
    Object.entries(promediosPorAno).forEach(([ano, promedio]) => {
        console.log(`${ano}: ₡${promedio.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 })}`);
    });

    // Cálculo del promedio total
    const promedioTotal = Object.values(promediosPorAno).reduce((sum, promedio) => sum + promedio, 0) / Object.keys(promediosPorAno).length;
    console.log(`Promedio Total: ₡${promedioTotal.toLocaleString(undefined, { minimumFractionDigits: 2, maximumFractionDigits: 2 })}`);

    // Configuración del gráfico original (opcional)
    var options = {
        series: [{
            name: 'Productos',
            data: series.monthDataSeries1.sales
        }],
        chart: {
            height: 350,
            type: 'area'
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'smooth'
        },
        tooltip: {
            y: {
                formatter: function (value) {
                    return "₡" + value.toLocaleString();
                }
            }
        },
    };

    var chart = new ApexCharts(document.querySelector("#area_chart_basic"), options);
    chart.render();
});