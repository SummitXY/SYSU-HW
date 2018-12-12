package main

//导入核心包
import (
	"args"
	"server"
)

func main() {
	a := args.Get()
	server.Serve(a)
}
