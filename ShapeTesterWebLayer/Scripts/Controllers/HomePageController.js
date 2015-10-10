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



//TODO: Pass object instead of use array
//TODO: Use razor, not JS file
//TODO: Proper namespacing of javascript

//public Canvas object to use in all the functions.
//Main canvas declaration 
var canvas;
var ctx;

// Rectangle number one
rect1 = {},
rect1.Width = 0
rect1.Height = 0

// Rectangle number two
rect2 = {},
rect2.Width = 0
rect2.Height = 0

rectangles = [rect1, rect2]


drag = false;


//Initialize the Canvas and Mouse events for Canvas
function DrawRectangleOne() {
    canvas = document.getElementById("canvas");
    ctx = canvas.getContext("2d");
    
    //RemoveMouseListeners(mouseDown2, mouseUp2, mouseMove2);
    AddMouseListeners(mouseDown, mouseUp, mouseMove, 0);
    
    return setInterval(function () { draw(0); }, 10);
}

function DrawRectangleTwo() {
    canvas = document.getElementById("canvas");
    ctx = canvas.getContext("2d");
    
    RemoveMouseListeners(mouseDown, mouseUp, mouseMove);
    AddMouseListeners(mouseDown2, mouseUp2, mouseMove2);

    return setInterval(draw2, 10);
}


function AddMouseListeners(downEvent, upEvent, moveEvent, rectangleNumber) {
    canvas.addEventListener('mousedown', function (e) { downEvent(e, rectangleNumber); }, false);
    canvas.addEventListener('mouseup', function (e) { upEvent(e, rectangleNumber); }, false);
    canvas.addEventListener('mousemove', function (e) { moveEvent(e, rectangleNumber); }, false);
}

function RemoveMouseListeners(downEvent, upEvent, moveEvent)
{
    canvas.removeEventListener('mousedown', downEvent, false);
    canvas.removeEventListener('mouseup', upEvent, false);
    canvas.removeEventListener('mousemove', moveEvent, false);
}


//Mouse down event method
function mouseDown(e, rectangleNumber) {
    rectangles[rectangleNumber].Width = 0;
    rectangles[rectangleNumber].Height = 0;
    rectangles[rectangleNumber].startX = e.pageX - canvas.offsetLeft;
    rectangles[rectangleNumber].startY = e.pageY - canvas.offsetTop;
    
    drag = true;
}
//Mouse UP event Method
function mouseUp(e, rectangle) {
    drag = false;
}

//mouse Move Event method
function mouseMove(e, rectangleNumber) {

    if (drag) {
        
        rectangles[rectangleNumber].Width = (e.pageX - canvas.offsetLeft) - rectangles[rectangleNumber].startX;
        //console.log(rectangles[rectangleNumber].Width);
        rectangles[rectangleNumber].Height = (e.pageY - canvas.offsetTop) - rectangles[rectangleNumber].startY;
        
        draw(rectangleNumber);
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    }
}


//Draw all Shaps,Text and add images 
function draw(rectangleNumber) {
    //alert("!");
    ctx.beginPath();
    ctx.fillStyle = "#FF0000";
    ctx.rect(rectangles[rectangleNumber].startX, rectangles[rectangleNumber].startY, rectangles[rectangleNumber].Width, rectangles[rectangleNumber].Height);

    ctx.fill();
}



//Mouse down event method
function mouseDown2(e) {
    rect2.Width = 0;
    rect2.Height = 0;
    rect2.startX = e.pageX - this.offsetLeft;
    rect2.startY = e.pageY - this.offsetTop;

    drag = true;
}
//Mouse UP event Method
function mouseUp2() {
    drag = false;
}

//mouse Move Event method
function mouseMove2(e) {
    if (drag) {
        rect2.Width = (e.pageX - this.offsetLeft) - rect2.startX;
        rect2.Height = (e.pageY - this.offsetTop) - rect2.startY;

        draw2();
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    }
}


//Draw all Shaps,Text and add images 
function draw2() {
    ctx.beginPath();
    ctx.fillStyle = "#0000FF";
    ctx.rect(rect2.startX, rect2.startY, rect2.Width, rect2.Height);

    ctx.fill();
}





//save as image file 
function SaveRectangle() { 
    jQuery.post("/Home/RectOne", { X: rect1.startX, Y: rect1.startY, Height: rect1.Height, Width: rect1.Width }, function (data) {
    });
}