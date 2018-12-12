exports.checkLogin=function(req,res,next){
    if(req.session.user){
        return res.redirect('/detail')
    } 
    next()
}

exports.checkNotLogin=function(req,res,next){
    if(!req.session.user){
        req.flash('error','你好，请登录')
        return res.redirect('/signin')
    } 
    next()
}