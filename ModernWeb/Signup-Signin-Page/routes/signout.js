var express=require('express')
var router=express.Router()

router.get('/',function(req,res){
    req.session.user=null
    req.flash('success','登出成功')
    res.redirect('/signin')
})

module.exports=router