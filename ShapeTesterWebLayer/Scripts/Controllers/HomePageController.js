//var HomePageController = function ($scope) {
//    $scope.models = {
//        numberOne: 1,
//        numberTwo: 2
//};
//}

//// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
//HomePageController.$inject = ['$scope'];


//var app = angular.module("myApp", []);
//app.controller("homePageController", function ($scope) {

//    var self = this;
//    self.numberOne = "John";
//    self.numberTwo = "Doe";
//});



//public Canvas object to use in all the functions.
//Main canvas declaration 
var canvas;
var ctx;
var x = 75;
var y = 50;
//Width and Height of the canvas
var WIDTH = 1024;
var HEIGHT = 740;



// Rectangle array
rect = {},
//drag= false default to test for the draging
drag = false;
// Array to store all the old Shapes drawing details
var rectStartXArray = new Array();
var rectStartYArray = new Array();
var rectWArray = new Array();
var rectHArray = new Array();
var rectColor = new Array();
var Text_ARR = new Array();

//to add the Image
var imageObj = new Image();
//Initialize the Canvas and Mouse events for Canvas
function DrawRectangleOne() {
    canvas = document.getElementById("canvas");
    x = 5;
    y = 5;
    ctx = canvas.getContext("2d");
    canvas.addEventListener('mousedown', mouseDown, false);
    canvas.addEventListener('mouseup', mouseUp, false);
    canvas.addEventListener('mousemove', mouseMove, false);
    
    return setInterval(draw, 10);
}






//Mouse down event method
function mouseDown(e) {
    rect.startX = e.pageX - this.offsetLeft;
    rect.startY = e.pageY - this.offsetTop;
    
    drag = true;
}
//Mouse UP event Method
function mouseUp() {
    rectStartXArray[rectStartXArray.length] = rect.startX;
    rectStartYArray[rectStartYArray.length] = rect.startY;
    rectWArray[rectWArray.length] = rect.w;
    rectHArray[rectHArray.length] = rect.h;
    
    rectColor[rectColor.length] = "#444444";

    drag = false;
}

//mouse Move Event method
function mouseMove(e) {
    if (drag) {
        rect.w = (e.pageX - this.offsetLeft) - rect.startX;
        rect.h = (e.pageY - this.offsetTop) - rect.startY;
        
                
        draw();
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    }
}





//Draw all Shaps,Text and add images 
function draw() {
    ctx.beginPath();
    ctx.fillStyle = "#444444";
    ctx.rect(rect.startX, rect.startY, rect.w, rect.h);
            
    ctx.fill();
}



//save as image file 
function SaveRectangle() { 
    
    // generate the image data 
    var image_new = document.getelementbyid("canvas").todataurl("image/png"); 
    image_new = image_new.replace('data:image/png;base64,', '');
    $.ajax({
        type: 'post',
        url: 'HomeController/saveimage',
        data: '{ "imagedata" : "' + image_new + '" }',
        contenttype: 'application/json; charset=utf-8',
        datatype: 'json',
        success: function (msg) {
            alert('image saved to your root folder !');
        }
    });   
}

