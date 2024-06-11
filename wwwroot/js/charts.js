const raceLabels = ['Bhrain', 'China', 'Japan', 'Australia', 'Monaco', 'Belgium', 'Hungary', 'Great Britain', 'Azerbaijan', 'Abu Dhabi'];
const maxRaceResults = [25, 18, 15, 12, 17, 22, 20, 8, 18, 25];
const lewisRaceResults = [18, 25, 12, 15, 10, 20, 22, 25, 15, 18];

const ctx = document.getElementById('myChart').getContext('2d');
const myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: raceLabels,
        datasets: [{
            label: 'Max Verstappen',
            data: maxRaceResults,
            backgroundColor: 'rgba(0, 0, 139, 0.5)',
            borderColor: 'rgba(0, 0, 139, 1)',
            borderWidth: 1
        },
        {
            label: 'Lewis Hamilton',
            data: lewisRaceResults,
            backgroundColor: 'rgba(255, 0, 0, 0.5)',
            borderColor: 'rgba(255, 0, 0, 1)',
            borderWidth: 1
        }
        ]
    },
    options: {
        responsive: true,
        plugins: {
            legend: {
                position: 'bottom',
            },
            title: {
                display: true,
                text: 'Comparison between Max and Lewis points in last 10 races',
                font: {
                    size: 20
                }
            }
        }
    }
});


const constructorData = {
    labels: ['Ferrari', 'McLaren', 'Williams', 'Mercedes', 'Red Bull Racing', 'Lotus', 'Cooper', 'Renault', 'Brabham', 'Benetton'],
    datasets: [{
        label: 'Constructor Championships',
        data: [16, 12, 9, 7, 4, 4, 4, 2, 2, 1],
        backgroundColor: [
            'rgba(255, 99, 132, 0.5)',
            'rgba(54, 162, 235, 0.5)',
            'rgba(255, 206, 86, 0.5)',
            'rgba(75, 192, 192, 0.5)',
            'rgba(153, 102, 255, 0.5)',
            'rgba(255, 159, 64, 0.5)',
            'rgba(255, 99, 132, 0.5)',
            'rgba(54, 162, 235, 0.5)',
            'rgba(255, 206, 86, 0.5)',
            'rgba(75, 192, 192, 0.5)'
        ],
        borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)',
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)'
        ],
        borderWidth: 1
    }]
};

const constructorCtx = document.getElementById('constructorChart').getContext('2d');
const constructorChart = new Chart(constructorCtx, {
    type: 'pie',
    data: constructorData,
    options: {
        responsive: true,
        plugins: {
            legend: {
                position: 'bottom',
            },
            title: {
                display: true,
                text: 'Constructor Championships Won Since the Start of F1',
                font: {
                    size: 20
                }
            }
        }
    }
});


const raceLabels1 = ['Bahrain', 'China', 'Japan', 'Australia', 'Monaco', 'Belgium', 'Hungary', 'Great Britain', 'Azerbaijan', 'Abu Dhabi'];
const fastestLapTimes = [83.25, 79.78, 92.42, 82.16, 105.95, 77.71, 90.59, 120.38, 98.22, 88.11];


const ctx1 = document.getElementById('fastestLapChart').getContext('2d');
const fastestLapChart = new Chart(ctx1, {
    type: 'line',
    data: {
        labels: raceLabels1,
        datasets: [{
            label: 'Fastest Lap Time (seconds)',
            data: fastestLapTimes,
            fill: false,
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 2
        }]
    },
    options: {
        responsive: true,
        plugins: {
            legend: {
                position: 'bottom',
            },
            title: {
                display: true,
                text: 'Fastest Lap Times of Past Ten Races',
                font: {
                    size: 20
                }
            }
        },
        scales: {
            y: {
                beginAtZero: false,
                title: {
                    display: true,
                    text: 'Fastest Lap Time (seconds)',
                    font: {
                        size: 16
                    }
                }
            }
        }
    }
});