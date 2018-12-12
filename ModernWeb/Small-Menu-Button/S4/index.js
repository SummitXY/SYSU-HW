window.onload = function () {
    var activebars = 0
    var numbers = []
    var order=[0,1,2,3,4]
    order.sort((a,b)=>{
        return Math.random()>0.5?1:-1
    })
    var dict={
        '0':'A',
        '1':'B',
        '2':'C',
        '3':'D',
        '4':'E'
    }
    // var aa=order.map(function(a){
    //     return dict[a.toString()]
    // })
    //alert(aa)
    //alert(order)
    var clickFunc = function () {
        var that = this
        $(this).find('span').addClass('unread').text('...')
        $(this).siblings().unbind('click').css('opacity', '0.5')
        $(this).unbind('click').removeClass('able')
        activebars++
        $.get('http://127.0.0.1:8000', function (data) {
            $(that).find('span').text(data)
            numbers.push(parseInt(data))
            $(that).css('opacity', '0.5')
            $(that).parent().find('.able').bind('click', clickFunc).css('opacity', '1')
            if (activebars === 5) {
                $('#ansblock').bind('click', canShow).css('opacity', '1')
            }
        })
    }

    var auto=function($button){
        var $that = $button
        $button.find('span').addClass('unread').text('...')
        $button.siblings().unbind('click').css('opacity', '0.5')
        $button.unbind('click').removeClass('able')
        activebars++
        $.get('http://127.0.0.1:8000', function (data) {
            $that.find('span').text(data)
            numbers.push(parseInt(data))
            $that.css('opacity', '0.5')
            $that.parent().find('.able').bind('click', clickFunc).css('opacity', '1')
            if (activebars === 5) {
                $('#ansblock').bind('click', canShow).css('opacity', '1')
            }
            if(activebars<5){
                auto($('.button').eq(order.pop()))
            } else{
                $('#ansblock').trigger('click')
            }
            
        })
    }

    $('.apb').click(function(){
        $('#showorder').text(order.map((a)=>{
            return dict[a.toString()]
        }).reverse())
        auto($('.button').eq(order.pop()))
    })


    $('.button').bind('click', clickFunc)

    

    var canShow = function () {
        $(this).find('#answer').text(numbers.reduce(function (before, after) {
            return before + after
        })).css('opacity', '0.5')
    }


    

    $('#wrap').mouseout(function(){
        $('.button').css('opacity','1').bind('click',clickFunc).addClass('able')
        $('.button').find('span').text('').removeClass('unread')
        numbers=[]
        activebars=0
        order=[0,1,2,3,4]
        order.sort((a,b)=>{
            return Math.random()>0.5?1:-1
        })
        $('#showorder').text('')
        $('#ansblock').css('opacity','0.5').find('#answer').text('')
    })

    

}