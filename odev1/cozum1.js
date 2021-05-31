// görev 1
var basliklar1= $("h2");
var ul1 = document.querySelector("#gorev1").querySelector("ul");
var a =0;
$("#gorev1 > button").click(function(){
for (var i=0;i<3;i++)
{
    var li1=document.createElement("li");
    li1.innerText= basliklar1[i].innerText;
    ul1.appendChild(li1);
}});

// görev 2
var tagLength2 = document.querySelector("article").querySelectorAll("h2").length;
var input2 = document.querySelector("#gorev2").querySelector("input");
$("#gorev2 > button").click(function(){
input2.value=tagLength2;
});

// görev 3
var baslik3 = document.querySelector("h1").innerHTML;
var input3 = document.querySelector("#gorev3").querySelector("input");
$("#gorev3 > button").click(function(){
input3.value=baslik3; 
});

// görev 4
var paragraflar4 = $("p");
var basliklar4  = document.querySelector("article").querySelectorAll("h2"); 
$("#gorev4 > button").click(function(){
for(var i=0; i<paragraflar4.length; i++)
{
    var sayi4= paragraflar4[i].innerHTML.split('').length;
    basliklar4[i].innerHTML += " (" + sayi4 + " karakter" + ")";
}});

// görev 5
var basliklar5= document.querySelector("article").querySelectorAll("h2");
$("#gorev5 > button").click(function(){
$("h1").css("color","red");
for (var i=0;i<=basliklar5.length;i+=2)
{
 basliklar5[i].style.color="blue";
}
for (var i=1;i<basliklar5.length;i+=2)
{
    basliklar5[i].style.color = "orange";
}});

// görev 6
 var icerik6 = $("div > p:first, h2:first");
  $("#gorev6 > button").click(function() {
     icerik6.fadeOut("slow");
  });


// görev 7
var basliklar7 = $("article").find("h2:contains('can')");
var ul7 = document.querySelector("#gorev7").querySelector("ul");
$("#gorev7 > button").click(function(){
for(var i=0;i<basliklar7.length;i++)
{
    var li7=document.createElement("li");
    li7.innerText= basliklar7[i].innerText;
    ul7.appendChild(li7);
}});

// görev 8
$("#gorev8 > button").click(function(){
$("h1").after("<p id=ajax>");
$("#ajax").load("lorem.html");
$("h1").after("<h2>Lorem</h2>");
});

// görev 9
var input9 = document.querySelector("#gorev9").querySelector("input");
$("h2,h1").mouseenter(function()
{
    input9.value= $(this).text();
}); 

// görev 10           
$("#gorev10 > button").click(function(){
    var img = $('<img src="check.png" style="height:100px; width:100px; position:fixed; bottom:0px; right:0px;" />');
    $('body').prepend(img);
});


