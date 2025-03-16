document.addEventListener("DOMContentLoaded", function () {
    // Отримуємо дані моделі
    var result = @Html.Raw(Json.Serialize(Model));
    console.log(result);

    // Створення масивів для тагів і їх кількості
    var labels = result.userStats.tagStats.map(stat => stat.tag.Title);
    var data = result.userStats.tagStats.map(stat => stat.tagCount);
    var backgroundColors = result.userStats.tagStats.map(stat => stat.tag.ColorHash);

    // Дані для графіка
    const chartData = {
        labels: labels, // Теги
        datasets: [{
            label: 'Task Count by Tag',
            data: data, // Кількість задач
            backgroundColor: backgroundColors, // Кольори для кожного тега
            hoverOffset: 4
        }]
    };

    // Налаштування графіка
    const config = {
        type: 'doughnut', // Тип графіка
        data: chartData,
    };

    // Створення графіка
    const ctx = document.getElementById('myChart').getContext('2d');
    const myChart = new Chart(ctx, config);

    // Налаштування розмірів графіка
    myChart.canvas.style.width = '300px';
    myChart.canvas.style.height = '300px';
    myChart.resize();
});
