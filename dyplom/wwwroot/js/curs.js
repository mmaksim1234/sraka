fetch('https://api.monobank.ua/bank/currency')
    .then(function(resp) {return resp.json()})
    .then(function(data){
        console.log(data);
        document.querySelector('.usd').textContent = [].buy;
    });
 