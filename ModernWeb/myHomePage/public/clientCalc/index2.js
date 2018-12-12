//By QuXiangyu 15335124
//With Brackets in Mac
//In 2017.10.4 -
window.onload = function () {
    //----------------------------------------------------------------
    //js for web style
    $(function () {
        $("[data-toggle='tooltip']").tooltip();
    });
    var closePos = 0;
    $('#close').click(function () {
        $('#history-box').slideUp(0)
        if (closePos == 0) {
            $('#calc').slideToggle(1000)
            $('#close').siblings().fadeToggle(1000)
            setTimeout(function () {
                $('#close').animate({
                    left: '150px',
                    top: '200px'
                }, 1000)
                setTimeout(function () {
                    $('#close').removeClass('glyphicon-off')
                    $('#close').animate({
                        top: '+160px',
                        left: '+115px',
                        width: '100px',
                        height: '100px'
                    }, 500)
                }, 1000)
            }, 1000)

            closePos = 1;
        } else {
            $('#close').animate({
                top: '200px',
                left: '150px',
                width: '2rem',
                height: '2rem'
            }, 500)
            setTimeout(function () {
                $('#close').addClass('glyphicon-off')
                $('#close').animate({
                    left: '0',
                    top: '0'
                }, 1000)
                setTimeout(function () {
                    $('#calc').slideToggle(1000)
                    $('#close').siblings().fadeToggle(1000)
                }, 1000)
            }, 500)



            closePos = 0;
        }
    })

    //js for slidedown history box
    $('#history').click(function () {
        $('#history-box').slideToggle(1000)
    })

    $('#history-clear').click(function () {
        $('#history-box>li').remove()
    })


    //----------------------------------------------------------------
    //----------------------------------------------------------------
    //js for calculator program
    var storeStr = '';
    var hasDot = 0;
    var hasOp = false;
    var reBegin = false;
    var isBegin = true;
    var lastNum = 0.0;
    var newNum = 0.0;
    var op = {
            plus: 0,
            minus: 0,
            multiply: 0,
            divide: 0
        }
        //------------------------------------------------------
        //The method of solving javascript accuracy problem
        //From http://www.cnblogs.com/snandy/p/4943138.html
    function isInteger(obj) {
        return Math.floor(obj) === obj
    }

    function toInteger(floatNum) {
        var ret = {
            times: 1,
            num: 0
        }
        var isNegative = floatNum < 0
        if (isInteger(floatNum)) {
            ret.num = floatNum
            return ret
        }
        var strfi = floatNum + ''
        var dotPos = strfi.indexOf('.')
        var len = strfi.substr(dotPos + 1).length
        var times = Math.pow(10, len)
        var intNum = parseInt(Math.abs(floatNum) * times + 0.5, 10)
        ret.times = times
        if (isNegative) {
            intNum = -intNum
        }
        ret.num = intNum
        return ret
    }

    function operation(a, b, op) {
        var o1 = toInteger(a)
        var o2 = toInteger(b)
        var n1 = o1.num
        var n2 = o2.num
        var t1 = o1.times
        var t2 = o2.times
        var max = t1 > t2 ? t1 : t2
        var result = null
        switch (op) {
        case 'add':
            if (t1 === t2) { // 两个小数位数相同
                result = n1 + n2
            } else if (t1 > t2) { // o1 小数位 大于 o2
                result = n1 + n2 * (t1 / t2)
            } else { // o1 小数位 小于 o2
                result = n1 * (t2 / t1) + n2
            }
            return result / max
        case 'subtract':
            if (t1 === t2) {
                result = n1 - n2
            } else if (t1 > t2) {
                result = n1 - n2 * (t1 / t2)
            } else {
                result = n1 * (t2 / t1) - n2
            }
            return result / max
        case 'multiply':
            result = (n1 * n2) / (t1 * t2)
            return result
        case 'divide':
            result = (n1 / n2) * (t2 / t1)
            return result
        }
    }

    function add(a, b) {
        return operation(a, b, 'add')
    }

    function substract(a, b) {
        return operation(a, b, 'subtract')
    }

    function multiply(a, b) {
        return operation(a, b, 'multiply')
    }

    function divide(a, b) {
        return operation(a, b, 'divide')
    }

    //-------------------------------------------------------

    function beforeOutPut(num, inOp) {
        var numStr = num.toString()
        var pos = numStr.indexOf('329')
        var re = new RegExp('\\d+.329+\\d')
        var re2 = new RegExp('\\d+.3{15}\\d')
        var re3 = new RegExp('\\d+.\\d{5}0{11}\\d$')
        if (re.test(numStr)) {
            var outPutStr = numStr.substring(0, pos + 1) + '3'
            $('#output').text(outPutStr)
            $('#input').text(outPutStr + inOp)
            newNum = parseFloat(outPutStr)

        } else if (re2.test(numStr)) {
            var outPutStr = numStr.substring(0, numStr.length - 1)
            $('#output').text(outPutStr)
            $('#input').text(outPutStr + inOp)
            newNum = parseFloat(outPutStr)
        } else if (re3.test(numStr)) {
            var pos2 = numStr.indexOf('.')
            var outPutStr = numStr.substring(0, pos2 + 5)
            $('#output').text(outPutStr)
            $('#input').text(outPutStr + inOp)
            newNum = parseFloat(outPutStr)
        } else {
            $('#output').text(numStr)
            $('#input').text(numStr + inOp)

        }


    }

    $('#btn-per').click(function () {

    })

    $('.btn-num').click(function () {
        hasOp = false;
        if (reBegin) {
            newNum = lastNum = 0.0;
            $('#input').text(0)
            $('#output').text(0)
            reBegin = false;
            isBegin = true;
        }

        var nowInputStr = $('#input').text()
        var nowNumStr = $(this).text()
        if (nowInputStr == "0") {
            $('#input').text(nowNumStr)
        } else {
            $('#input').text(nowInputStr + nowNumStr)
        }

        //storeStr+=nowNumStr;

        var nowNum = parseFloat(nowNumStr);
        if (hasDot) {
            lastNum = parseFloat(lastNum + nowNum * Math.pow(10, (-1) * hasDot))
            hasDot++

        } else {
            lastNum = parseFloat(lastNum * 10 + nowNum);
        }


        if (isBegin || reBegin) {
            newNum = lastNum;

            var newNumStr = newNum.toString()
            var re = new RegExp('\\d+.329+\\d')
            var re2 = new RegExp('\\d+.3{15}\\d')
            var re3 = new RegExp('\\d+.\\d{5}0{11}\\d')
            if (re.test(newNumStr)) {
                var pos = newNumStr.indexOf('329')
                var outPutStr = newNumStr.substring(0, pos + 1) + '3'
                storeStr = outPutStr;

            } else if (re2.test(newNumStr)) {
                var outPutStr = newNumStr.substring(0, newNumStr.length - 1)
                storeStr = outPutStr;
            } else if (re3.test(newNumStr)) {
                var pos2 = newNumStr.indexOf('.')
                var outPutStr = newNumStr.substring(0, pos2 + 5)
                storeStr = outPutStr;
            } else {
                storeStr = newNumStr;

            }


        } else {
            var re = new RegExp('\\d+.329+\\d')
            var re2 = new RegExp('\\d+.3{15}\\d')
            var re3 = new RegExp('\\d+.\\d{5}0{11}\\d')
            if (re.test(nowNumStr)) {
                var pos = nowNumStr.indexOf('329')
                var outPutStr = nowNumStr.substring(0, pos + 1) + '3'
                storeStr += outPutStr;

            } else if (re2.test(nowNumStr)) {
                var outPutStr = nowNumStr.substring(0, nowNumStr.length - 1)
                storeStr += outPutStr;
            } else if (re3.test(nowNumStr)) {
                var pos2 = nowNumStr.indexOf('.')
                var outPutStr = nowNumStr.substring(0, pos2 + 5)
                storeStr += outPutStr;
            } else {
                storeStr += nowNumStr;

            }

        }


    })

    $('.btn-op').click(function () {
        if (hasOp == true) {
            var nowOp = $(this).text()
            for (x in op) {
                op[x] = 0;
            }
            switch (nowOp) {
            case "+":
                op.plus = 1;
                break;
            case "-":
                op.minus = 1;
                break;
            case "×":
                op.multiply = 1;
                break;
            case "÷":
                op.divide = 1;
                break;
            default:
                break;
            }
            var nowInputStr = $('#input').text()
            var strLen = nowInputStr.length;
            storeStr = storeStr.substring(0, strLen - 1) + nowOp
            $('#input').text(nowInputStr.substring(0, strLen - 1) + nowOp)
            return;
        }
        hasDot = 0;
        hasOp = true;
        isBegin = false;
        reBegin = false;
        var nowOp = $(this).text()
        storeStr += nowOp;
        if (op.plus == 1) {
            newNum = add(newNum, lastNum);
        } else if (op.minus == 1) {
            newNum = substract(newNum, lastNum);
        } else if (op.multiply == 1) {
            newNum = multiply(newNum, lastNum);
        } else if (op.divide == 1) {
            newNum = divide(newNum, lastNum);
        } else {
            newNum = add(newNum, 0.0);
        }
        lastNum = 0.0;

        beforeOutPut(newNum, nowOp)
        for (x in op) {
            op[x] = 0;
        }
        switch (nowOp) {
        case "+":
            op.plus = 1;
            break;
        case "-":
            op.minus = 1;
            break;
        case "×":
            op.multiply = 1;
            break;
        case "÷":
            op.divide = 1;
            break;
        default:
            break;
        }


    })

    $('expForm').submit(function () {
        $(this).submit()
        return false;
    })

    $('#btn-eq').click(function () {
        isBegin = false;
        reBegin = true;
        hasDot = 0;
        if (op.plus == 1) {
            //newNum += lastNum;
            //newNum = Math.formatFloat(newNum + lastNum, 1)
            newNum = add(newNum, lastNum);
        } else if (op.minus == 1) {
            newNum = substract(newNum, lastNum);
        } else if (op.multiply == 1) {
            newNum = multiply(newNum, lastNum);
        } else if (op.divide == 1) {
            newNum = divide(newNum, lastNum);
        } else {
            newNum = add(newNum, 0.0);
        }
        lastNum = 0.0;
        //        $('#output').text(newNum)
        //        $('#input').text(newNum)
        beforeOutPut(newNum, "")
        storeStr = storeStr + '=' + $('#output').text();
        $('#history-box').prepend('<li>' + storeStr + '</li>')
        storeStr = $('#output').text();
        for (x in op) {
            op[x] = 0;
        }


    })

    $('#btn-reZero').click(function () {
        reBegin = false;
        isBegin = true;
        newNum = 0.0;
        lastNum = 0.0;
        hasDot = 0;
        $('#input').text("0")
        $('#output').text("0")
    })

    $('#btn-dot').click(function () {
        if (hasDot == 0) {
            hasDot++;
            var nowInputStr = $('#input').text()
            $('#input').text(nowInputStr + ".")
        }


    })



}