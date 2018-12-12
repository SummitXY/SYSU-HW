var express=require('express')
var router=express.Router()
var check=require('../middleware/check.js')

router.get('/',check.checkNotLogin,function(req,res){
    if(req.session.user.name==req.query.username){
        req.flash('success','欢迎回来')
    } else{
        req.flash('error','只能够访问自己的数据')
    }
    res.redirect('/detail')
    
})

module.exports=router