var sha1=require('sha1')
var express=require('express')
var router=express.Router()
var check=require('../middleware/check.js')
var model=require('../database/mongo.js')

router.get('/',check.checkLogin,function(req,res){
    res.render('signin',{
        title:'登陆页'
    })
})

router.post('/',function(req,res){
    var name=req.fields.name
    var password=req.fields.password
    console.log(name+' '+password)
    var where={
        name:name,
        password:sha1(password)
    }

    model.User.find(where,function(err,users){
        if(users.length>0){
            req.session.user=users[0]
            req.flash('success','登陆成功')
            res.redirect('/detail')
        } else{
            req.flash('error','用户名或密码错误')
            res.redirect('back')
        }
    })

})

module.exports=router