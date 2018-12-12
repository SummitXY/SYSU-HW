var express=require('express')
var config=require('config-lite')(__dirname)
var path=require('path')
var formidable=require('express-formidable')
var session=require('express-session')
var MongoStore=require('connect-mongo')(session)
var flash=require('connect-flash')
var routes=require('./routes')

var app=express()
//express基本配置
app.set('views',path.join(__dirname,config.views))
app.set('view engine',config['view engine'])//不太喜欢jade的反人类缩进
app.listen(config.port)

//挂载静态目录
app.use(express.static(path.join(__dirname,'public')))

//配置session
app.use(session({
    store:new MongoStore({
        url:config.mongodb
    }),
    cookie:{
        maxAge:config.session.maxAge
    },
    saveUninitialized:false,
    resave:true,
    name:config.session.key,
    secret:config.session.secret
}))
app.use(flash())


//处理post提交中间件
app.use(formidable())

app.use(function(req,res,next){
    res.locals.user=req.session.user
    res.locals.success=req.flash('success').toString()
    res.locals.error=req.flash('error').toString()
    next()
})
//挂载路由
routes(app)

