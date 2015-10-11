var rectangleCanvas = new function ()
{
    //public Canvas object to use in all the functions.
    //Main canvas declaration 
    var canvas;
    var canvasContext;

    // Rectangle number one
    rect1 = {},
    rect1.Width = 0
    rect1.Height = 0
    //TODO: capitalize startX and startY
    rect1.startX = -1
    rect1.startY = -1
    rect1.Color = "#FF0000";
    
    // Rectangle number two
    rect2 = {},
    rect2.Width = 0
    rect2.Height = 0
    rect2.startX = -1
    rect2.startY = -1
    rect2.Color = "#0000FF";

    drag = false;

    //Create handlers for mouse events
    var downHandler;
    var upHandler;
    var moveHandler;

    //Initialize the Canvas and Mouse events for Canvas
    this.drawRectangleOne = function drawRectangleOne() {
        initializeCanvas();
        removeMouseListeners();
        addMouseListeners(rect1);
    
        return setInterval(function () { draw(rect1); }, 10);
    }

    this.drawRectangleTwo = function drawRectangleTwo() {
        initializeCanvas();
        removeMouseListeners();
        addMouseListeners(rect2);

        return setInterval(function () { draw(rect2); }, 10);
    }

    function initializeCanvas()
    {
        canvas = document.getElementById("canvas");
        canvasContext = canvas.getContext("2d");
    }

    //Add new listeners for the new rectangle to draw
    function addMouseListeners(rectangle) {
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

    //Remove listeners attached from the previous rectangle drawing
    function removeMouseListeners(downEvent, upEvent, moveEvent)
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

    //Mouse up event method
    function mouseUp(e, rectangle) {
        drag = false;
        evaluateRectangles.testAll(rect1, rect2);
    }

    //Mouse move event method
    function mouseMove(e, rectangle) {
        if (drag) {
            rectangle.Width = (e.pageX - canvas.offsetLeft) - rectangle.startX;
            rectangle.Height = (e.pageY - canvas.offsetTop) - rectangle.startY;
        
            draw(rectangle);
            canvasContext.clearRect(0, 0, canvas.width, canvas.height);
        }
    }

    //Draw the rectangle
    function draw(rectangle) {
        canvasContext.beginPath();
        canvasContext.strokeStyle = rectangle.Color

        canvasContext.rect(rectangle.startX, rectangle.startY, rectangle.Width, rectangle.Height);
        

        canvasContext.stroke();
    }
}