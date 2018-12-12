package server

import (
	"args"
	"fmt"
	"io"
	"log"
	"net/http"
)

func makeMux() *http.ServeMux {
	m := http.NewServeMux()
	m.HandleFunc("/", func(w http.ResponseWriter, req *http.Request) {
		w.Write([]byte("hello world\n"))
	})
	return m
}

var mux *http.ServeMux

// 获取URL
func Get() *http.ServeMux {
	if mux == nil {
		mux = makeMux()
	}
	return mux
}


func getLoggerFromWriter(writer io.Writer) *log.Logger {
	return log.New(writer, "http", log.LstdFlags)
}

// 启动服务器
func Serve(args *args.Args) {
	server := http.Server{
		Addr:     fmt.Sprintf("%s:%d", args.Host, args.Port),
		Handler:  Get(),
		ErrorLog: getLoggerFromWriter(args.Log),
	}
	fmt.Fprintf(args.Log, "Hello Quxy , the server listening at %s:%d\n", args.Host, args.Port)
	server.ListenAndServe()
}
