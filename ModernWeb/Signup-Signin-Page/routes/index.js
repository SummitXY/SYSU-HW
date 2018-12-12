//路由控制页
var check=require('../middleware/check.js')
module.exports=function(app){
    //app.get('/',check.checkLogin,check.checkNotLogin)
    app.use('/',require('./main.js'))
    app.use('/regist',require('./regist.js'))
    app.use('/detail',require('./detail.js'))
    app.use('/signin',require('./signin.js'))
    app.use('/signout',require('./signout.js'))
}