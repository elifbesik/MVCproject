var createQuote = document.getElementById('createQuote');
var tweetButton = document.getElementById('tweetButton');
var textDiv = document.getElementById('text');
var yazarDiv = document.getElementById('yazar');

tweetButton.addEventListener('click', function () {
    var textDivValue = textDiv.innerHTML;
    var yazarDivValue = yazarDiv.innerHTML;
    window.open('https://twitter.com/intent/tweet?hashtags=Yaz%C4%B1l%C4%B1mPark&text= ${textDivVal} / Yazar: ${authorDivVal}');
});

function renderHtml(data, index) {
    textDiv.innerHTML = data[quote].text;
    yazarDiv.innerHTML = data[index].yazar;
}
