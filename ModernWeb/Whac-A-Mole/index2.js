window.onload = function () {
    var isStart = 0
    //click to start or end
    $('#start').click(function () {
        if (!isStart) {
            isStart = 1
            $('#score').val(0)
            $('#result').val('Playing..')
            var num = Math.floor(Math.random() * 16)
            $('.lattice').eq(num).addClass('appearHamster')
            //timer from 30s down
            timeDecrease = setInterval(function () {
                var time = parseInt($('#time').val())
                if (time == 0) {
                    isStart=0
                    $('.lattice').removeClass('appearHamster')
                    $('#result').val('Game Over')
                    $('#time').val(30)
                    clearInterval(timeDecrease)
                    alert('Score: ' + $('#score').val())
                    
                } else {
                    $('#time').val(--time)
                }

            }, 1000)
        } else{
            isStart=0
            $('.lattice').removeClass('appearHamster')
            $('#result').val('Game Over')
            clearInterval(timeDecrease)
            alert('Score: ' + $('#score').val())
             $('#time').val(30)
        }
    })

    //hit correct or hit wrong
    $('.lattice').hover(function () {

        $(this).css('cursor', 'pointer')

    }).click(function () {
        if ($(this).hasClass('appearHamster')) {
            $(this).removeClass('appearHamster')
            $score = $('#score')
            var score = $score.val()
            $score.val(++score)

            num = Math.floor(Math.random() * 16)
            Math.floor(Math.random() * 16)
            $('.lattice').eq(num).addClass('appearHamster')
        } else {
            $score = $('#score')
            var score = parseInt($score.val())
            $score.val(--score)
        }
    })
}