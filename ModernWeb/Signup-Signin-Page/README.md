# homework10 源代码注释

15335124 曲翔宇 软工5班

`config/default.js` 为程序基本配置文件，在`index.js`中引用`config-lite`包的作用便是使`config`对象包含有程序的基本配置

`database/mongo.js`连接`mongodb`数据库，并定义`Schema`，操作`mongodb`数据库的包我选择的是`mongoose`

`public`目录存储静态资源，主要是我写的css文件

`routes`目录为路由目录，其中`index`为路由控制文件，`regist` `signin` `signout` `detail` `main` 分别实现注册、登陆、登出、详情、主页的路由逻辑

`views`为视图目录

`middleware`存有路由中间件

UI设计采用`bootstrap`

加密使用`sha1`包

express的session控制使用的是`express-session`

将session存储在mongodb使用的是`connect-mongo`

使用`express-formidable`代替`body-parser`处理post请求

一次性通知功能由`connect-flash`实现

