// fetch('https://api.openweathermap.org/data/2.5/weather?q=Ternopil,ua&appid=eee4bc4ed0d380a1888c4ed04a4de600')
//     .then(function (resp) {return resp.json()})
//     .then(function(data){
//         console.log(data);
//         document.querySelector('.weather-city').textContent = data.name;
//         document.querySelector('.weather-temp').innerHTML = Math.round(data.main.temp - 273) + '&deg';
//         // document.querySelector('.weather-status').textContent = data.weather[0]['description'];
//         document.querySelector('.weather-icon').innerHTML = `<img src="https://openweathermap.org/img/wn/${data.weather[0]['icon']}@2x.png">`;
//     })
//     .catch(function(){

//     }); 


const weatherUrl = 'https://api.openweathermap.org/data/2.5/weather?q=Ternopil,ua&appid=eee4bc4ed0d380a1888c4ed04a4de600';
const apiUrl = 'https://v6.exchangerate-api.com/v6/36c05e2a791767781957a23f/latest/USD';

// Перший запит для погоди
fetch(weatherUrl)
    .then(response => response.json())
    .then((data) => {
        console.log(data);
        document.querySelector('.weather-city').textContent = data.name;
        document.querySelector('.weather-temp').innerHTML = Math.round(data.main.temp - 273) + '&deg';
        // document.querySelector('.weather-status').textContent = data.weather[0]['description'];
        document.querySelector('.weather-icon').innerHTML = `<img src="https://openweathermap.org/img/wn/${data.weather[0]['icon']}@2x.png">`;
    
    })
    .catch(error => {
        console.error();
    });

// Другий запит для обмінного курсу


// Function to fetch and render exchange rates
const fetchExchangeRates = () => {
    fetch(apiUrl)
    .then(response => response.json())
    .then(data => {
        // Отримання курсів валют
        const usdToUahRate = data.conversion_rates.UAH;
        const uahToEuroRate = data.conversion_rates.UAH / data.conversion_rates.EUR;

        // Виведення результатів на екран
        const usdToUahElement = document.getElementById('usdToUah');
        usdToUahElement.textContent = `$ ${usdToUahRate.toFixed(2)}`;

        const uahToEuroElement = document.getElementById('uahToEuro');
        uahToEuroElement.textContent = `€ ${uahToEuroRate.toFixed(2)}`;
    })
        .catch(error => {
            console.error(error);
        });
};

// Call the function on page load
fetchExchangeRates();

document.addEventListener('DOMContentLoaded', function () {
    var dateElement = document.getElementById('dateDisplay');
    var currentDate = new Date();
    var options = { weekday: 'short', month: 'long', day: 'numeric' };
    var dateString = currentDate.toLocaleDateString('uk-UA', options);

    dateElement.textContent = dateString;
});