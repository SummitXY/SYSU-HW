package hello_world;
import java.util.Scanner;
public class hello_world {
	public static void main(String[] args) {
		Scanner scan=new Scanner(System.in);
		
		int N=scan.nextInt();
		for(int i=1;i<=N;i++){
			for(int j=7;j>=1;j--){
				if(j>i){
					System.out.print("  ");
				} else{
					System.out.print(j+" ");
				}
			}
			
			for(int j=2;j<=7;j++){
				if(j>i){
					System.out.print("  ");
				} else{
					System.out.print(j+" ");
				}
			}
			
			System.out.println("");
		}
		
		
	}
}
