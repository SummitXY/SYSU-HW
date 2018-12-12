package args

import (
	"flag"
	"fmt"
	"io"
	"os"
)

// 定义传入服务器的参数
type Args struct {
	Host string
	Port uint
	Log  io.WriteCloser
}

var args *Args

// 获取命令行传入的参数
func Get() *Args {
	if args == nil {
		args = parseArgs()
	}
	return args
}

func getLogWriter(file string) io.WriteCloser {
	if file == "stdout" || file == "" {
		return os.Stdout
	}
	f, err := os.OpenFile(file, os.O_WRONLY|os.O_CREATE|os.O_APPEND, 0744)
	if err != nil {
		fmt.Fprintln(os.Stderr, err.Error())
		os.Exit(1)
	}
	return f
}

// 处理参数
func parseArgs() *Args {
	port := flag.Uint("port", 8080, "server port")
	host := flag.String("host", "localhost", "server host")
	logfile := flag.String("log", "stdout", "log file")
	flag.Parse()
	return &Args{
		Host: *host,
		Port: *port,
		Log:  getLogWriter(*logfile),
	}
}
