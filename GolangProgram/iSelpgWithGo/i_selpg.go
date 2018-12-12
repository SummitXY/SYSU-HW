package main

//导入库
import (
	"bufio"
	"flag"
	"fmt"
	"io"
	"os"
	"os/exec"
)

//参数结构体
type selpgargs struct {
	start_page  int
	end_page    int
	page_len    int
	form_deli   bool
	input_file  string
	destination string
}

var params selpgargs

//帮助信息-h
func usage() {
	fmt.Printf("Usage : selpg -s Number -e Number [options] [filename]\n\n")
	fmt.Printf("Arguments and Options:\n")
	fmt.Printf("-s Numbert\t: 从<Number>页尾开始打印，即<Number+1>页头开始打印\n")
	fmt.Printf("-e Numbert\t: 到<Number>页尾结束打印\n")
	fmt.Printf("-l Number\t: 每页有<Number>行，默认为72行\n")
	fmt.Printf("-f\t\t: 每页之间是否用\\f作为分隔，默认为否\n")
	fmt.Printf("[filename]\t: 要打印的文件名，例如doc.txt,如果未有显示文件名则会接收命令行输入，并以control+d作为结束标志\n\n")
}

//参数默认值
func params_init(args *selpgargs) {
	flag.Usage = usage
	flag.IntVar(&args.start_page, "s", -1, "开始页")
	flag.IntVar(&args.end_page, "e", -1, "结束页")
	flag.IntVar(&args.page_len, "l", 10, "每页行数")
	flag.BoolVar(&args.form_deli, "f", false, "页是否以\\f分隔")
	flag.StringVar(&args.destination, "d", "", "确定打印机")
	flag.Parse()
}

func check_params(args *selpgargs) {
	//必须输入前两个参数
	if args.start_page == -1 || args.end_page == -1 {
		fmt.Fprintf(os.Stderr, "Error: 必须输入前两个参数\n\n")
		//输出帮助信息
		flag.Usage()
		os.Exit(1)
	}

	//第一个参数必须为 -s <Number>
	if os.Args[1][0] != '-' || os.Args[1][1] != 's' {
		fmt.Fprintf(os.Stderr, "Error: 第一个参数必须为 -s <Number>\n\n")
		//输出帮助信息
		flag.Usage()
		os.Exit(1)
	}


	temp_idx := 2
	if len(os.Args[1]) == 2 {
		temp_idx = 3
	}

	//第二个参数必须为 -e <Number>
	if os.Args[temp_idx][0] != '-' || os.Args[temp_idx][1] != 'e' {
		fmt.Fprintf(os.Stderr, "Error: 第二个参数必须为 -e <Number>\n\n")
		//输出帮助信息
		flag.Usage()
		os.Exit(1)
	}

	//页数必须为非负数
	if args.start_page > args.end_page || args.start_page < 0 ||
		args.end_page < 0 {
		fmt.Fprintln(os.Stderr, "Error: 页数必须为非负数且尾页必须大于等于首页\n\n")
		//输出帮助信息
		flag.Usage()
		os.Exit(1)
	}
}

//确定输出目标
func cmd_print(args *selpgargs, line string, stdin io.WriteCloser) {
	//写文件
	if args.destination != "" {
		stdin.Write([]byte(line + "\n"))
	} else {
		//命令行输出
		fmt.Println(line)
	}
}

//按需打印
func i_print(args *selpgargs) {
	var stdin io.WriteCloser
	var err error
	var order *exec.Cmd

	if args.destination != "" {
		order = exec.Command("cat", "-n")
		stdin, err = order.StdinPipe()
		if err != nil {
			fmt.Println(err)
		}
	} else {
		stdin = nil
	}

	if flag.NArg() > 0 {
		args.input_file = flag.Arg(0)
		output, err := os.Open(args.input_file)
		if err != nil {
			fmt.Println(err)
			os.Exit(1)
		}
		reader := bufio.NewReader(output)
		if args.form_deli {
			for pageNum := 0; pageNum <= args.end_page; pageNum++ {
				line, err := reader.ReadString('\f')
				if err != io.EOF && err != nil {
					fmt.Println(err)
					os.Exit(1)
				}
				if err == io.EOF {
					break
				}
				cmd_print(args, string(line), stdin)
			}
		} else {
			count := 0
			for {
				line, _, err := reader.ReadLine()
				if err != io.EOF && err != nil {
					fmt.Println(err)
					os.Exit(1)
				}
				if err == io.EOF {
					break
				}
				if count/args.page_len >= args.start_page {
					if count/args.page_len > args.end_page {
						break
					} else {
						cmd_print(args, string(line), stdin)
					}
				}
				count++
			}

		}
	} else {
		scanner := bufio.NewScanner(os.Stdin)
		count := 0
		target := ""
		for scanner.Scan() {
			line := scanner.Text()
			line += "\n"
			if count/args.page_len >= args.start_page {
				if count/args.page_len <= args.end_page {
					target += line
				}
			}
			count++
		}
		cmd_print(args, string(target), stdin)
	}

	if args.destination != "" {
		stdin.Close()
		order.Stdout = os.Stdout
		order.Run()
	}
}

func main() {
	params_init(&params)
	check_params(&params)
	i_print(&params)
}
