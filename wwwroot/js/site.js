// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let currentSlide = 0;

function showSlide(slideIndex) {
    const slidesContainer = document.querySelector('.slides');
    const slidesCount = document.querySelectorAll('.slide').length;

    if (slideIndex >= slidesCount) {
        currentSlide = 0;
    } else if (slideIndex < 0) {
        currentSlide = slidesCount - 1;
    } else {
        currentSlide = slideIndex;
    }

    slidesContainer.style.transform = `translateX(-${currentSlide * 100}%)`;
    updateIndicators();
}

function nextSlide() {
    showSlide(currentSlide + 1);
}

function prevSlide() {
    showSlide(currentSlide - 1);
}

function updateIndicators() {
    const indicators = document.querySelectorAll('.indicator');
    indicators.forEach((indicator, index) => {
        if (index === currentSlide) {
            indicator.classList.add('active');
        } else {
            indicator.classList.remove('active');
        }
    });
}

document.addEventListener('DOMContentLoaded', function () {
    // Set up navigation buttons
    document.querySelector('.next').addEventListener('click', nextSlide);
    document.querySelector('.prev').addEventListener('click', prevSlide);

    // Auto-slide every 3 seconds
    setInterval(nextSlide, 3000);

    // Create indicators
    const indicatorsContainer = document.createElement('div');
    indicatorsContainer.classList.add('indicators');
    document.querySelector('.slider').appendChild(indicatorsContainer);

    // Add indicators for each slide
    const slidesCount = document.querySelectorAll('.slide').length;
    for (let i = 0; i < slidesCount; i++) {
        const indicator = document.createElement('div');
        indicator.classList.add('indicator');
        indicator.addEventListener('click', () => showSlide(i));
        indicatorsContainer.appendChild(indicator);
    }

    updateIndicators();
});

function editCSS(button) {
    const row = button.closest('tr');
    const teamNo = row.querySelector('td:nth-child(1)').innerText;
    const TeamName = row.querySelector('td:nth-child(2)').innerText;
    const headquarters = row.querySelector('td:nth-child(3)').innerText;
    const teamPrincipal = row.querySelector('td:nth-child(4)').innerText;
    const chassis = row.querySelector('td:nth-child(5)').innerText;
    const engine = row.querySelector('td:nth-child(6)').innerText;
    const drivers = row.querySelector('td:nth-child(7)').innerText;

    document.getElementById('team-no').value = teamNo;
    document.getElementById('team-name').value = TeamName;
    document.getElementById('headquarters').value = headquarters;
    document.getElementById('team-principal').value = teamPrincipal;
    document.getElementById('chassis').value = chassis;
    document.getElementById('engine').value = engine;
    document.getElementById('drivers').value = drivers;

    document.getElementById('edit-popup').classList.remove('hidden');
}

function closePopup() {
    document.getElementById('edit-popup').classList.add('hidden');
}

document.getElementById('edit-form').addEventListener('submit', function (event) {
    event.preventDefault();

    const formData = new FormData(event.target);

    closePopup();
});

function deletebutton(button) {
    const popup = document.getElementById('delete-confirmation-popup');
    const confirmDeleteButton = document.getElementById('confirm-delete');
    const cancelDeleteButton = document.getElementById('cancel-delete');
    const row = button.parentElement.parentElement;

    popup.classList.remove('hidden');

    confirmDeleteButton.onclick = function () {
        row.remove();
        popup.classList.add('hidden');
    };

    cancelDeleteButton.onclick = function () {
        popup.classList.add('hidden');
    };
}

function deletebutton(button) {
    // Get the delete confirmation popup and buttons
    const popup = document.getElementById('delete-confirmation-popup');
    const confirmDeleteButton = document.getElementById('confirm-delete');
    const cancelDeleteButton = document.getElementById('cancel-delete');

    // Get the table row (tr) element of the clicked button
    const row = button.parentElement.parentElement;

    // Show the delete confirmation popup
    popup.classList.remove('hidden');

    // Handle the "Delete" button click
    confirmDeleteButton.onclick = function () {
        // Delete the row
        row.remove();

        // Hide the popup
        popup.classList.add('hidden');
    };

    // Handle the "Cancel" button click
    cancelDeleteButton.onclick = function () {
        // Hide the popup
        popup.classList.add('hidden');
    };
}

// Function to edit driver details
function editDriver(button) {
    // Find the row of the clicked button
    const row = button.closest('tr');

    // Get the values from the row
    const driverId = row.querySelector('td:nth-child(1)').innerText;
    const driverName = row.querySelector('td:nth-child(2)').innerText;
    const TeamName = row.querySelector('td:nth-child(3)').innerText;
    const countryOfOrigin = row.querySelector('td:nth-child(4)').innerText;

    // Populate the popup form with the values
    document.getElementById('field1').value = driverId; // For driver ID
    document.getElementById('field2').value = driverName; // For driver name
    document.getElementById('field3').value = TeamName; // For TeamName
    document.getElementById('field4').value = countryOfOrigin; // For country of origin

    // Display the popup form
    document.getElementById('edit-popup').classList.remove('hidden');
}

// Function to close the popup form
function closePopup() {
    document.getElementById('edit-popup').classList.add('hidden');
}

// Handle form submission
document.getElementById('edit-form').addEventListener('submit', function (event) {
    event.preventDefault();

    // Get the form values
    const formData = new FormData(event.target);

    // Handle form submission (e.g., send data to a server or update the row directly)
    // Implement your form submission logic here

    // Close the popup form
    closePopup();
});

// Attach the function to the Edit buttons
document.querySelectorAll('.fancy-button').forEach(button => {
    button.addEventListener('click', function () {
        editDriver(this);
    });
});


// Sample data for F1 website
const raceLabels = ['Bhrain', 'China', 'Japan', 'Australia', 'Monaco', 'Belgium', 'Hungary', 'Great Britain', 'Azerbaijan', 'Abu Dhabi'];
const maxRaceResults = [25, 18, 15, 12, 17, 22, 20, 8, 18, 25]; // Sample points for Max
const lewisRaceResults = [18, 25, 12, 15, 10, 20, 22, 25, 15, 18]; // Sample points for Lewis

// Create a chart
const ctx = document.getElementById('myChart').getContext('2d');
const myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: raceLabels,
        datasets: [{
            label: 'Max Verstappen',
            data: maxRaceResults,
            backgroundColor: 'rgba(0, 0, 139, 0.5)', // Dark blue color for Max
            borderColor: 'rgba(0, 0, 139, 1)',
            borderWidth: 1
        },
        {
            label: 'Lewis Hamilton',
            data: lewisRaceResults,
            backgroundColor: 'rgba(255, 0, 0, 0.5)', // Red color for Lewis
            borderColor: 'rgba(255, 0, 0, 1)',
            borderWidth: 1
        }
        ]
    },
    //    options: {
    //      scales: {
    //        y: {
    //          beginAtZero: true
    //        },
    //        title: {
    //         display: true,
    //         text: 'Comparison between Max and Lewis'
    //       }
    //      }
    //    }
    options: {
        responsive: true,
        plugins: {
            legend: {
                position: 'bottom',
            },
            title: {
                display: true,
                text: 'Comparison between Max and Lewis',
                font: {
                    size: 20 // Specify the desired font size
                }
            }
        }
    }
});





// constructorChart.js

// Data representing the number of championships won by constructors since the start of F1
const constructorData = {
    labels: ['Ferrari', 'McLaren', 'Williams', 'Mercedes', 'Red Bull Racing', 'Lotus', 'Cooper', 'Renault', 'Brabham', 'Benetton'],
    datasets: [{
        label: 'Constructor Championships',
        data: [16, 12, 9, 7, 4, 4, 4, 2, 2, 1], // Sample data representing championships won by each constructor
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

// Create a pie chart for constructor championships
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
                    size: 20 // Specify the desired font size
                }
            }
        }
    }
});




// Sample data for F1 website
const raceLabels1 = ['Bhrain', 'China', 'Japan', 'Australia', 'Monaco', 'Belgium', 'Hungary', 'Great Britain', 'Azerbaijan', 'Abu Dhabi'];
const fastestLapTimes = [83.25, 79.78, 92.42, 82.16, 105.95, 77.71, 90.59, 120.38, 98.22, 88.11]; // Sample fastest lap times



// Create a line chart for fastest lap times
const ctx1 = document.getElementById('fastestLapChart').getContext('2d');
const fastestLapChart = new Chart(ctx1, {
    type: 'line',
    data: {
        labels: raceLabels1,
        datasets: [{
            label: 'Fastest Lap Time (seconds)',
            data: fastestLapTimes,
            fill: false,
            borderColor: 'rgba(75, 192, 192, 1)', // Aqua color for the line
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
                beginAtZero: false, // Start y-axis from the minimum value of the data
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


// deleteForm.js
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("deleteForm").addEventListener("submit", function (event) {
        if (document.querySelector('.fancy-delete-button').classList.contains('disabled')) {
            event.preventDefault();
        }
    });
});
