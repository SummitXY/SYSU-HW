window.onload = function () {
    var activebars = 0
    var numbers = []
    var clickFunc = function () {
        var that = this
        $(this).find('span').addClass('unread').text('...')
        $(this).siblings().unbind('click').css('opacity', '0.5')
        $(this).unbind('click').removeClass('able')
        $.get('http://127.0.0.1:8000/', function (data) {
            activebars++
            $(that).find('span').text(data)
            numbers.push(parseInt(data))
            $(that).css('opacity', '0.5')
            $(that).parent().find('.able').bind('click', clickFunc).css('opacity', '1')
            
            if (activebars === 5) {
                $('#ansblock').bind('click', canShow).css('opacity', '1')
            }
        })
    }

    $('.button').bind('click', clickFunc)

    var canShow = function () {
        
        $(this).find('#answer').text(numbers.reduce(function (before, after) {
            return before + after
        })).css('opacity', '0.5')
    }

    $('#wrap').mouseout(function(){
        $('.button').unbind('click').removeClass('able')
        $('.button').css('opacity','1').bind('click',clickFunc).addClass('able')
        $('.button').find('span').text('').removeClass('unread')
        numbers=[]
        activebars=0
        $('#ansblock').unbind('click').css('opacity','0.5').find('#answer').text('')
        
    })

    

}