package PI;
import java.util.Scanner;
public class PI {
	public static void main(String[] args) {
		
		Scanner scan=new Scanner(System.in);
		int N=scan.nextInt();
		float sum=0;
		for(int i=1;i<=N;i++){
			sum+=((float)Math.pow(-1, i+1)/(float)(2*i-1));
		}
		System.out.println(sum*4);
	}
}
