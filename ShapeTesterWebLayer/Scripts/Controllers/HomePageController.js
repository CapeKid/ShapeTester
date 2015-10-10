//TODO: Pass object instead of use array
//TODO: Proper namespacing of javascript

//public Canvas object to use in all the functions.
//Main canvas declaration 
var canvas;
var ctx;

// Rectangle number one
rect1 = {},
rect1.Width = 0
rect1.Height = 0
rect1.Color = "#FF0000";

// Rectangle number two
rect2 = {},
rect2.Width = 0
rect2.Height = 0
rect2.Color = "#0000FF";

drag = false;

//Create handlers for mouse events
var downHandler;
var upHandler;
var moveHandler;

//Initialize the Canvas and Mouse events for Canvas
function DrawRectangleOne() {
    InitializeCanvas();
    RemoveMouseListeners();
    AddMouseListeners(rect1);
    
    return setInterval(function () { draw(rect1); }, 10);
}

function DrawRectangleTwo() {
    InitializeCanvas();
    RemoveMouseListeners();
    AddMouseListeners(rect2);

    return setInterval(function () { draw(rect2); }, 10);
}


function InitializeCanvas()
{
    canvas = document.getElementById("canvas");
    ctx = canvas.getContext("2d");
}

function AddMouseListeners(rectangle) {
    downHandler = function (e) {
        mouseDown(e, rectangle);
    };
    upHandler = function (e) {
        mouseUp(e, rectangle);
    };

    moveHandler = function (e) {
        mouseMove(e, rectangle);
    };
    
    canvas.addEventListener('mousedown', downHandler, false);
    canvas.addEventListener('mouseup', upHandler, false);
    canvas.addEventListener('mousemove', moveHandler, false);
}

function RemoveMouseListeners(downEvent, upEvent, moveEvent)
{
    canvas.removeEventListener('mousedown', downHandler, false);
    canvas.removeEventListener('mouseup', upHandler, false);
    canvas.removeEventListener('mousemove', moveHandler, false);
}


//Mouse down event method
function mouseDown(e, rectangle) {
    
    rectangle.Width = 0;
    rectangle.Height = 0;
    rectangle.startX = e.pageX - canvas.offsetLeft;
    rectangle.startY = e.pageY - canvas.offsetTop;
    
    drag = true;
}
//Mouse UP event Method
function mouseUp(e, rectangle) {
    drag = false;
}

//mouse Move Event method
function mouseMove(e, rectangle) {

    if (drag) {
        rectangle.Width = (e.pageX - canvas.offsetLeft) - rectangle.startX;
        rectangle.Height = (e.pageY - canvas.offsetTop) - rectangle.startY;
        
        draw(rectangle);
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    }
}


//Draw all Shaps,Text and add images 
function draw(rectangle) {
    ctx.beginPath();
    ctx.fillStyle = rectangle.Color
    ctx.rect(rectangle.startX, rectangle.startY, rectangle.Width, rectangle.Height);
    ctx.fill();
}