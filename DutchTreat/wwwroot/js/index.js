$(document).ready(function () {
    var x = 0;
    var s = "";

    console.log("Hello Aidas");


    var theForm = $("#theForm");
    theForm.hide();

    var theButton = $("#buyButton");
    theButton.on("click", function () { console.log("perku daiktus") });

    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("Tu paspaudei ant " + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function () {
        $popupForm.fadeToggle(1000);
    })





    //var theForm = document.getElementById("theForm");
    //theForm.hidden = true;

    //var theButton = document.getElementById("buyButton");
    //theButton.addEventListener("click", function () { console.log("perku daiktus") });

    //var productInfo = document.getElementsByClassName("product-props");
    //var listItems = productInfo.item[0].children;
});


