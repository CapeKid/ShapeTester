var evaluateRectangles = new function () {
    this.testOverlap = function testOverlap(rect1, rect2) {
        jQuery.post("/RectangleProcessor/TestOverlap",
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
                $("#isOverlap").text(data);
            });
    }

    this.testContain = function testContain(rect1, rect2) {
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
                $("#isContain").text(data);
            });
    }

    this.testAdjacent = function testAdjacent(rect1, rect2) {
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
                $("#isAdjacent").text(data);
            });
    }


    this.testAll = function testAll(rect1, rect2) {
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
            });
    }
}