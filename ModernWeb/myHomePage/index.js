var express = require('express')
var app=express()

app.use(express.static('public'))
app.use('/calculator',express.static('public/clientCalc'))
app.use('/maze',express.static('public/Mouse_Maze'))
app.use('/whac_a_mole',express.static('public/WhacAMole'))
app.use('/img',express.static('source'))
app.listen(3000)

console.log('port at '+3000)