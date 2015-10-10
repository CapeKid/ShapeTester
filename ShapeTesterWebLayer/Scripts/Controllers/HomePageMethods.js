function TestOverlap(rect1, rect2) {
    jQuery.post("/RectangleProcessor/TestOverlap",
        {
            rect1 : {
                X: rect1.startX,
                Y: rect1.startY,
                Height: rect1.Height,
                Width: rect1.Width
            },
            
            rect2: {
                X: rect2.startX,
                Y: rect2.startY,
                Height: rect2.Height,
                Width: rect2.Width
            },
        }
        , function (data) {
            alert(data);
    });
}

function TestContain(rect1, rect2) {
    jQuery.post("/RectangleProcessor/TestContain",
        {
            rect1: {
                X: rect1.startX,
                Y: rect1.startY,
                Height: rect1.Height,
                Width: rect1.Width
            },

            rect2: {
                X: rect2.startX,
                Y: rect2.startY,
                Height: rect2.Height,
                Width: rect2.Width
            },
        }
        , function (data) {
            alert(data);
        });
}

function TestAdjacent(rect1, rect2) {
    jQuery.post("/RectangleProcessor/TestAdjacent",
        {
            rect1: {
                X: rect1.startX,
                Y: rect1.startY,
                Height: rect1.Height,
                Width: rect1.Width
            },

            rect2: {
                X: rect2.startX,
                Y: rect2.startY,
                Height: rect2.Height,
                Width: rect2.Width
            },
        }
        , function (data) {
            alert(data);
        });
}

function TestAll(rect1, rect2) {
    jQuery.post("/RectangleProcessor/TestAll",
        {
            rect1: {
                X: rect1.startX,
                Y: rect1.startY,
                Height: rect1.Height,
                Width: rect1.Width
            },

            rect2: {
                X: rect2.startX,
                Y: rect2.startY,
                Height: rect2.Height,
                Width: rect2.Width
            },
        }
        , function (data) {

            alert(data);
        });
}