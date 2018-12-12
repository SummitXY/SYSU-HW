#include<iostream>
#include<stack>
#include<iomanip>
using namespace std;

    
   
int main(){
    
    int n;
    
    cin>>n;
    
    for(int i=0;i<n;i++){
        
        string input;
        
        cin>>input;
        
        
        
        stack<double> mystack;
        
        double firstnum=0;
        
        double secondnum=0;
        
        double sum=0;
        
        for(int i=0;i<input.size();i++){
            
            if(input[i]=='+' || input[i]=='-' || input[i]=='*' || input[i]=='/'){
                
                firstnum = mystack.top();
                
                mystack.pop();
                
                secondnum = mystack.top();
                
                mystack.pop();
                
                if(input[i] == '+')
                    
                {
                    
                    sum = firstnum + secondnum;
                    
                    mystack.push(sum);
                    
                }
                
                if(input[i] == '-')
                    
                {
                    
                    sum = secondnum-firstnum;
                    
                    mystack.push(sum);
                    
                }
                
                if(input[i] == '*')
                    
                {
                    
                    sum = firstnum * secondnum;
                    
                    mystack.push(sum);
                    
                }
                
                if(input[i] == '/')
                    
                {
                    
                    sum = secondnum/firstnum;
                    
                    mystack.push(sum);
                    
                }
                
            }
            
            else{
                
                double a=input[i]-96;
                
                mystack.push(a);
                
            }
            
        }
        
        cout<<fixed<<setprecision(2)<<mystack.top()<<endl;
        
    } 
}










