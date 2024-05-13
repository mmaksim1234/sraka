let weather = document.querySelector('.weather-city .weather-temp .weather-status .weather-icon');
// fetch('https://api.openweathermap.org/data/2.5/weather?q=Ternopil,ua&appid=eee4bc4ed0d380a1888c4ed04a4de600')
//     .then(function (resp) {return resp.json()})
//     .then(function(data){
//         console.log(data);
//         document.querySelector('.weather-city').textContent = data.name;
//         document.querySelector('.weather-temp').innerHTML = Math.round(data.main.temp - 273) + '&deg';
//         document.querySelector('.weather-status').textContent = data.weather[0]['description'];
//         document.querySelector('.weather-icon').innerHTML = `<img src="https://openweathermap.org/img/wn/${data.weather[0]['icon']}@2x.png">`;
//     })
//     .catch(function(){

//     }); 