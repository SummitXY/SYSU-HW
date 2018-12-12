//定义mongodb的模版
var mongoose=require('mongoose')
var config=require('config-lite')(__dirname)

mongoose.connect(config.mongodb)
var db=mongoose.connection
db.on('error',function(){
    console.error('mongodb connect fail')
})

exports.User=mongoose.model('User',{
    name:String,
    id:String,
    phone:String,
    mail:String,
    password:String
})
