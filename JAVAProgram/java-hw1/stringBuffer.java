package stringBuffer;
import java.util.Scanner;
public class stringBuffer {
	public static void main(String[] args) {
		Scanner scan=new Scanner(System.in);
		String str=scan.nextLine();
		
		StringBuffer buf=new StringBuffer();
		buf.append(str);
		buf.reverse();
		System.out.println(buf.toString());
		
		
	}
}
