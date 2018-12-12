module.exports={
    port:8000,
    mongodb:'mongodb://localhost:27017/hw10',
    session:{
        maxAge:6000000,//session保存在数据库的时间
        key:'hw10',//session保存在cookie字段中的名称
        secret:'hw10'
    },
    'view engine':'ejs',//大爱ejs模版引擎
    views:'/views'//视图目录
}