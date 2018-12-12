var express=require('express')
var router=express.Router()
var check=require('../middleware/check.js')

router.get('/',check.checkNotLogin,function(req,res){
    res.render('detail',{
        user:req.session.user,
        title:'详情页'
    })
})

module.exports=router