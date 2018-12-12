window.onload=function(){
//    try{
//        var s=eval('jf+df')
//        
//    }catch(e){
//        alert('wrong')
//    }
    //----------------------------------------------------------------
    //js for web style
    $(function () {
        $("[data-toggle='tooltip']").tooltip();
    });
    var closePos = 0;
    $('#close').click(function () {
        $('#history-box').slideUp(0)
        $('#readme').hide()
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
                    $('#readme').show()
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
        $('.history-list').remove()
    })
    
    $('#user').click(function(){
        window.open('https://github.com/SummitXY')
    })
    
    $('#wrong').click(function(){
        var upStr= $('#upscreen').text()
        $('#upscreen').text(upStr+'$')
    })
    
    var isLight=true
    
    $('#eye').click(function(){
        if(isLight){
            $('body').css('backgroundColor','black')
            isLight=false
            $(this).removeClass('glyphicon-eye-open')
            $(this).addClass('glyphicon-eye-close')
        }else{
            $('body').css('backgroundColor','bisque')
            isLight=true
            $(this).removeClass('glyphicon-eye-close')
            $(this).addClass('glyphicon-eye-open')
        }
        
    })
    
    
    //----------------------------------------------------------------
    //----------------------------------------------------------------
    //js for calculator program
    var isBegin=true; 
    var hasDot=false;
    var hasLeftBracket=0;
    
    var equalOp=function(ch){
        return ch=='+' || ch=='-' || ch=='*' || ch=='/';
    }
    
    $('.btn-num').click(function(){
        var upStr=$('#upscreen').text()
        var len=upStr.length
        var lastChar=upStr.charAt(len-1)
        
        if(isBegin){
            $('#upscreen').text($(this).text())
            isBegin=false;
        } else{
            if(lastChar!=')'){
               var upStr=$('#upscreen').text()
                $('#upscreen').text(upStr+$(this).text())
            }
            
        }
        
    })
    
    $('.btn-op').click(function(){
        if(!isBegin){
            var upStr=$('#upscreen').text()
            var len=upStr.length
            var lastChar=upStr.charAt(len-1)
            //whether is number or ), use isNaN: false is number
            if(!isNaN(lastChar) || lastChar==')'){
                $('#upscreen').text(upStr+$(this).text())
                hasDot=false
            }
            //replace the operation
            if(equalOp(lastChar)){
                $('#upscreen').text(upStr.slice(0,len-1)+$(this).text())
                hasDot=false
            }
        }
    })
    
    $('#left-bracket').click(function(){
        var upStr=$('#upscreen').text()
        var len=upStr.length
        var lastChar=upStr.charAt(len-1)
        if(isBegin){
            $('#upscreen').text('(')
            isBegin=false
            hasLeftBracket++
        }
        if(equalOp(lastChar)){
            $('#upscreen').text(upStr+'(')
            hasLeftBracket++
        }
    })
    
    $('#right-bracket').click(function(){
        if(hasLeftBracket){
            var upStr=$('#upscreen').text()
            var len=upStr.length
            var lastChar=upStr.charAt(len-1)
            if(!isNaN(lastChar) || lastChar==')'){
                $('#upscreen').text(upStr+')')
                hasLeftBracket--
            }
            //lastchar must be number or ( or )
            
        }
    })
    
    $('#btn-dot').click(function(){
        var upStr=$('#upscreen').text()
        var len=upStr.length
        var lastChar=upStr.charAt(len-1)
        
        if(!isNaN(lastChar) && !hasDot){
            $('#upscreen').text(upStr+'.')
            hasDot=true
        }
    })
    
    var beforeOutPut =function(tempStr){
        var re1=/\d+.3{15}\d/
        var re2=/\d+.30{15}4/
        var re3=/\d+.29{14}/
        if(re1.test(tempStr)){
            var output=tempStr.slice(0,tempStr.length-1)
            return output
        }
        if(re2.test(tempStr)){
            return '0.3'
        }
        if(re3.test(tempStr)){
            var pos = tempStr.indexOf('.')
            return tempStr.substring(0, pos+1) + '3'
        }
        if(tempStr=='Infinity'){
            throw 'infinity'
            return 
        }
        return tempStr
    }
    
    $('#btn-eq').click(function(){
        var upStr=$('#upscreen').text()
        try{
            var answer=eval(upStr)
            var middleStr=beforeOutPut(answer.toString())
            $('#downscreen').text(middleStr)
            //upscreen to answer
            $('#upscreen').text(middleStr)
            var outPutStr=upStr+'='+middleStr
            $('#history-box').prepend('<li class="history-list">' +outPutStr+ '</li>')
        }catch(e){
            if(e=='infinity'){
               alert('The denominator can not be 0, please input correct expression.')
                isBegin=true; 
                hasDot=false;
                hasLeftBracket=0;
                $('#upscreen').text(0)
                $('#downscreen').text(0)
            } else{
                alert('Sorry,your expression is wrong, please input again.')
                isBegin=true; 
                hasDot=false;
                hasLeftBracket=0;
                $('#upscreen').text(0)
                $('#downscreen').text(0)
            }
            
        }
        
       
    })
    
    $('#btn-reZero').click(function(){
        isBegin=true; 
        hasDot=false;
        hasLeftBracket=0;
        $('#upscreen').text(0)
        $('#downscreen').text(0)
    })
    
    $('#btn-delete').click(function(){
        var upStr=$('#upscreen').text()
        //length>1 operate or to 0
        var len=upStr.length
        if(len>1){
           $('#upscreen').text(upStr.slice(0,len-1))
            
        } else{
            $('#upscreen').text(0)
            $('#downscreen').text(0)
            isBegin=true
            
        }
    })
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}