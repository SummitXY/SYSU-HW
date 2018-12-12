package Calculator;
import java.util.Scanner;
public class Calculator{
	public static void main(String[] args) {
		boolean isGoon=false;
		double goOnNum=0;
		double res=0;
		Scanner input=new Scanner(System.in);
		while(true) {
			if (isGoon) {
				System.out.println("Chose the operation and input the number:");
				System.out.println("--------------------------------------------");
				System.out.println("Num: 1  2  3  4  5    6    7   8    9    10   11");
				System.out.println("Op:  +  -  ×  ÷  %  x^2  x^y  √x   y√x  lgx  lnx");
				int op=input.nextInt();
				if (op==1) {
					System.out.println("Input the second number:");
					double num2=input.nextDouble();
					res=goOnNum+num2;
					System.out.println("The answer is "+res);
				} else if (op==2) {
					System.out.println("Input the second number:");
					double num2=input.nextDouble();
					 res=goOnNum-num2;
					System.out.println("The answer is "+res);
				} else if (op==3) {
					System.out.println("Input the second number:");
					double num2=input.nextDouble();
					res=goOnNum*num2;
					System.out.println("The answer is "+res);
				} else if (op==4) {
					System.out.println("Input the second number:");
					double num2=input.nextDouble();
					res=goOnNum/num2;
					System.out.println("The answer is "+res);
				} else if (op==5) {
					System.out.println("Input the second number:");
					double num2=input.nextDouble();
					res=goOnNum%num2;
					System.out.println("The answer is "+res);
				}else if (op==6) {
					res=goOnNum*goOnNum;
					System.out.println("The answer is "+res);
				} else if (op==7) {
					System.out.println("Input the power:");
					double power=input.nextDouble();
					res=Math.pow(goOnNum, power);
					System.out.println("The answer is "+res);
				}  else if (op==8) {
					res=Math.sqrt(goOnNum);
					System.out.println("The answer is "+res);
				} else if (op==9) {
					System.out.println("Input the power:");
					double power=input.nextDouble();
					res=Math.pow(goOnNum, 1d/power);
					System.out.println("The answer is "+res);
				}else if (op==10) {
					res=Math.log10(goOnNum);
					System.out.println("The answer is "+res);
				} else if (op==11) {
					res=Math.log(goOnNum);
					System.out.println("The answer is "+res);
				} 
				
				System.out.println("chose the operation and input the number:");
				System.out.println("--------------------------------------------");
				System.out.println("Exit: 0");
				System.out.println("ReZero: 1");
				System.out.println("Go-on: 2" );
				op=input.nextInt();
				if(op==0) {
					System.exit(0);
				} else if (op==1) {
					isGoon=false;
					continue;
				} else if (op==2) {
					isGoon=true;
					goOnNum=res;
					continue;
				}
				
			}
			
			
			System.out.println("Input the first number:");
			double num1=input.nextDouble();
			System.out.println("Chose the operation and input the number:");
			System.out.println("--------------------------------------------");
			System.out.println("Num: 1  2  3  4  5    6    7   8    9    10  11");
			System.out.println("Op:  +  -  ×  ÷  %  x^2  x^y  √x  y√x  lgx  lnx");
			int op=input.nextInt();
			if (op==1) {
				System.out.println("Input the second number:");
				double num2=input.nextDouble();
				res=num1+num2;
				System.out.println("The answer is "+res);
			} else if (op==2) {
				System.out.println("Input the second number:");
				double num2=input.nextDouble();
				 res=num1-num2;
				System.out.println("The answer is "+res);
			} else if (op==3) {
				System.out.println("Input the second number:");
				double num2=input.nextDouble();
				res=num1*num2;
				System.out.println("The answer is "+res);
			} else if (op==4) {
				System.out.println("Input the second number:");
				double num2=input.nextDouble();
				res=num1/num2;
				System.out.println("The answer is "+res);
			} else if (op==5) {
				System.out.println("Input the second number:");
				double num2=input.nextDouble();
				res=num1%num2;
				System.out.println("The answer is "+res);
			}else if (op==6) {
				res=num1*num1;
				System.out.println("The answer is "+res);
			} else if (op==7) {
				System.out.println("Input the power:");
				double power=input.nextDouble();
				res=Math.pow(num1, power);
				System.out.println("The answer is "+res);
			}  else if (op==8) {
				res=Math.sqrt(num1);
				System.out.println("The answer is "+res);
			} else if (op==9) {
				System.out.println("Input the power:");
				double power=input.nextDouble();
				res=Math.pow(num1, 1d/power);
				System.out.println("The answer is "+res);
			}else if (op==10) {
				res=Math.log10(num1);
				System.out.println("The answer is "+res);
			} else if (op==11) {
				res=Math.log(num1);
				System.out.println("The answer is "+res);
			} 
			
			System.out.println("chose the operation and input the number:");
			System.out.println("--------------------------------------------");
			System.out.println("Exit: 0");
			System.out.println("ReZero: 1");
			System.out.println("Go-on: 2" );
			op=input.nextInt();
			if(op==0) {
				System.exit(0);
			} else if (op==1) {
				isGoon=false;
				continue;
			} else if (op==2) {
				isGoon=true;
				goOnNum=res;
				continue;
			}
			
			
		}
		
		
	}
}












