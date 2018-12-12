window.onload=function(){
    
    $('canvas').attr('width','500')
    $('canvas').attr('height','300')
    
    //use js to draw maze
    var C=document.getElementById('myCanvas')
    var cxt=C.getContext('2d')
    
    function reset(){
        cxt.fillStyle='#ccc'
        cxt.fillRect(0,0,500,300)
        
        cxt.fillStyle='white'
        cxt.fillRect(0,200,175,50)
        cxt.fillRect(325,200,175,50)
        cxt.fillRect(125,50,50,150)
        cxt.fillRect(325,50,50,150)
        cxt.fillRect(175,50,150,50)
        
        cxt.fillStyle='green'
        cxt.fillRect(0,200,50,50)
    
        cxt.fillStyle='blueviolet'
        cxt.fillRect(450,200,50,50)
    
        cxt.fillStyle='black'
        cxt.font='50px Georgia'
        cxt.fillText('S',10,245)
        cxt.fillText('E',460,245)
    }
    
    reset()
 
    var isStart=0
    var isCheat=0
    
    //judge if your mouse is in S block
    function isInS(x,y){
        return x>=300 && x<=350 && y>=200 && y<=250
    }
    
    //judge if your mouse is in E block
    function isInE(x,y){
        return x>=750 && x<=800 && y>=200 && y<=250
    }
    
    //judge if your mouse is in road
    function isInRoad(x,y){
        var inRoad1=(x>=300 && x<=425 && y>=200 && y<=250)
        var inRoad2=(x>=425 && x<=475 && y>=50 && y<=250)
        var inRoad3=(x>=475 && x<=625 && y>=50 && y<=100)
        var inRoad4=(x>=625 && x<=675 && y>=50 && y<=250)
        var inRoad5=(x>=675 && x<=800 && y>=200 && y<=250)
        return inRoad1 || inRoad2 || inRoad3 || inRoad4 || inRoad5
    }
    
    //judge if your mouse hits the wall
    function hitWall(x,y){
        if(x>=475 && x<=625 && y>=100 && y<=250){
            cxt.fillStyle='red'
            cxt.fillRect(175,100,150,150)
        }
        
        if(x>=300 && x<=425 && y>=50 && y<=200){
            cxt.fillStyle='red'
            cxt.fillRect(0,50,125,150)
        }
        
        if(x>=675 && x<=800 && y>=50 && y<=200){
            cxt.fillStyle='red'
            cxt.fillRect(375,50,125,150)
        }
        
        if(x>=425 && x<=675 && y>=0 && y<=50){
            cxt.fillStyle='red'
            cxt.fillRect(125,0,250,50)
        }
        
        if(x>=300 && x<=475 && y>=250 && y<=300){
            cxt.fillStyle='red'
            cxt.fillRect(0,250,175,50)
        }
        
        if(x>=625 && x<=800 && y>=250 && y<=300){
            cxt.fillStyle='red'
            cxt.fillRect(325,250,175,50)
        }
    }
    
    
    $('canvas').mousemove(function(e){
        var mx=e.pageX
        var my=e.pageY
        
        if(isInS(mx,my)){
            $('#result').text('')
            isStart=1
            //reset()
        }
        
        if(isStart){
            if(!isInRoad(mx,my)){
                isStart=0
                $('#result').text('You Lose')
                hitWall(mx,my) 
            }
            
            if(isInE(mx,my)){
                if(isCheat){
                    $('#result').text("Don't cheat,you should start from the 'S' and move to the 'E' inside the maze!")
                } else {
                    $('#result').text('You Win')
                }
                
                
                isStart=0
            }
        }
        
    })
    
    $('canvas').mouseleave(function(){
        reset()
        if(isStart){
            isCheat=1
        }
    })
    
}












