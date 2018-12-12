
//注册页路由逻辑
var sha1=require('sha1')
var Promise=require('bluebird')
var express=require('express')
var router=express.Router()
var model=require('../database/mongo.js')
var check=require('../middleware/check.js')
router.get('/',check.checkLogin,function(req,res){
    res.render('regist',{
        title:'注册页'
    })
})

var hasNameAlready= function(user){
    return new Promise(function(resolve,reject){
        model.User.count({name:user.name},function(err,num){
            if(num==0){
                resolve()
            } else{
                reject('用户名')
            }
        })
    })
}

var hasIDAlready= function(user){
    return new Promise(function(resolve,reject){
        model.User.count({id:user.id},function(err,num){
            if(num==0){
                resolve()
            } else{
                reject('学号')
            }
        })
    })
}

var hasPhoneAlready= function(user){
    return new Promise(function(resolve,reject){
        model.User.count({phone:user.phone},function(err,num){
            if(num==0){
                resolve()
            } else{
                reject('电话')
            }
        })
    })
}

var hasMailAlready= function(user){
    return new Promise(function(resolve,reject){
        model.User.count({mail:user.mail},function(err,num){
            if(num==0){
                resolve()
            } else{
                reject('邮箱')
            }
        })
    })
}

var checkRegistValid=function(user,req,res){
    var test_name = /^[a-zA-Z][a-zA-Z0-9_]{5,17}$/
    var test_id = /^[1-9]\d{7}$/
    var test_phone = /^[1-9]\d{10}$/
    var test_mail = /^[a-zA-Z0-9]+\.?\w+\@\w+?\.+\w+$/
    var test_password=/^[0-9a-zA-Z_]{6,12}$/

    if (!test_name.test(user.name)) {
        req.flash('error','请输入正确的用户名<br>用户名6~18位英文字母、数字或下划线，必须以英文字母开头')
        return res.redirect('back')
    } else if (!test_id.test(user.id)) {
        req.flash('error','请输入正确的学号<br>学号8位数字，不能以0开头')
        return res.redirect('back')
    } else if (!test_phone.test(user.phone)) {
        req.flash('error','请输入正确的电话<br>电话11位数字，不能以0开头')
        return res.redirect('back')
    } else if (!test_mail.test(user.mail)) {
        req.flash('error','请输入正确的邮箱')
        return res.redirect('back')
    } else if(!test_password.test(user.password)) {
        req.flash('error','请输入正确的密码<br>密码为6~12位数字、大小写字母、中划线、下划线')
        return res.redirect('back')
    } else if(user.password!=user.repassword){
        req.flash('error','两次输入密码不同，请重新输入')
        return res.redirect('back')
    } else{
        Promise.all([
            hasNameAlready(user),
            hasIDAlready(user),
            hasPhoneAlready(user),
            hasMailAlready(user)
        ]).then(function(){
            delete user.repassword
            user.password=sha1(user.password)
            new model.User(user).save(function(){
                //console.log('new user signup:'+name)
                req.session.user=user
                res.redirect('/detail')
            })
        }).catch(function(message){
            req.flash('error',message+'已存在，请重新输入')
            res.redirect('back')
        })
        // delete user.repassword
        // user.password=sha1(user.password)
        // new model.User(user).save(function(){
        //     //console.log('new user signup:'+name)
        //     req.session.user=user
        //     res.redirect('/detail')
        // })
    }

}

router.post('/',function(req,res){
    var name=req.fields.name
    var id=req.fields.id
    var phone=req.fields.phone
    var mail=req.fields.mail
    var password=req.fields.password
    var repassword=req.fields.repassword

    var user={
        name:name,
        id:id,
        phone:phone,
        mail:mail,
        password:password,
        repassword:repassword
    }

    checkRegistValid(user,req,res)

})

module.exports=router