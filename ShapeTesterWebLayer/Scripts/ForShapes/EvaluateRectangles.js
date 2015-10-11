var evaluateRectangles = new function () {
    this.testOverlap = function testOverlap(rect1, rect2) {
        jQuery.post("/RectangleProcessor/TestOverlap",
            {
                rect1: {
                    StartX: rect1.StartX,
                    StartY: rect1.StartY,
                    Height: rect1.Height,
                    Width: rect1.Width
                },

                rect2: {
                    StartX: rect2.StartX,
                    StartY: rect2.StartY,
                    Height: rect2.Height,
                    Width: rect2.Width
                },
            }
            , function (data) {
                $("#isOverlap").text(data);
            });
    }

    this.testContain = function testContain(rect1, rect2) {
        jQuery.post("/RectangleProcessor/TestContain",
            {
                rect1: {
                    StartX: rect1.StartX,
                    StartY: rect1.StartY,
                    Height: rect1.Height,
                    Width: rect1.Width
                },

                rect2: {
                    StartX: rect2.StartX,
                    StartY: rect2.StartY,
                    Height: rect2.Height,
                    Width: rect2.Width
                },
            }
            , function (data) {
                $("#isContain").text(data);
            });
    }

    this.testAdjacent = function testAdjacent(rect1, rect2) {
        jQuery.post("/RectangleProcessor/TestAdjacent",
            {
                rect1: {
                    StartX: rect1.StartX,
                    StartY: rect1.StartY,
                    Height: rect1.Height,
                    Width: rect1.Width
                },

                rect2: {
                    StartX: rect2.StartX,
                    StartY: rect2.StartY,
                    Height: rect2.Height,
                    Width: rect2.Width
                },
            }
            , function (data) {
                $("#isAdjacent").text(data);
            });
    }
    


    this.testAll = function testAll(rect1, rect2) {
        jQuery.post("/RectangleProcessor/TestAll",
            {
                rect1: {
                    StartX: rect1.StartX,
                    StartY: rect1.StartY,
                    Height: rect1.Height,
                    Width: rect1.Width
                },

                rect2: {
                    StartX: rect2.StartX,
                    StartY: rect2.StartY,
                    Height: rect2.Height,
                    Width: rect2.Width
                },
            }
            , function (data) {
                $("#isOverlap").text(data.isOverlap);
                $("#isContain").text(data.isContain);
                $("#isAdjacent").text(data.isAdjacent);
            });
    }
}