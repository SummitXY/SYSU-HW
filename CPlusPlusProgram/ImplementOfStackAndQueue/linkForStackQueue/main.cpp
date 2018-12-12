//
//  main.cpp
//  linkForStackQueue
//
//  Created by apple on 2017/9/19.
//  Copyright © 2017年 Quxy. All rights reserved.
//

#include <iostream>
#include <string>
#include "Stack.hpp"
#include "Queue.hpp"
using namespace std;
int main(int argc, const char * argv[]) {
    
    while (true) {
        cout<<"Input 1 to chose stack ,input 2 to chose queue and input 0 to quit:";
        string order;getline(cin,order);
        if (order=="1") {
            Stack<int> stack;
            while (true) {
                cout<<"order operation:"<<endl;
                cout<<"1     push some value."<<endl;
                cout<<"2     pop the top."<<endl;
                cout<<"3     return the top."<<endl;
                cout<<"4     return the size."<<endl;
                cout<<"5     clear the stack."<<endl;
                cout<<"0     exit."<<endl;
                int op;cin>>op;
                if (op==1) {
                    int value;cin>>value;
                    stack.push(value);
                    cout<<"push "<<value<<" successfully"<<endl;
                } else if(op==2){
                    stack.pop();
                    cout<<"pop successfully"<<endl;
                } else if(op==3){
                    cout<<"top value:"<<stack.top()<<endl;
                } else if(op==4){
                    cout<<"stack size:"<<stack.size()<<endl;
                } else if(op==5){
                    stack.clear();
                    cout<<"clear successfully"<<endl;
                } else if(op==0){
                    break;
                }
                cout<<"---------------------------"<<endl<<endl;

            }
            
        } else if(order=="2"){
            Queue queue;
            while (true) {
                cout<<"order operation:"<<endl;
                cout<<"1     push some value."<<endl;
                cout<<"2     pop the font."<<endl;
                cout<<"3     return the font."<<endl;
                cout<<"4     return the size."<<endl;
                cout<<"0     exit."<<endl;
                int op;cin>>op;
                if (op==1) {
                    int value;cin>>value;
                    if (queue.size()==MAX_SIZE) {
                        cout<<"Full, can not push!"<<endl;
                    } else{
                        queue.push(value);
                        cout<<"push "<<value<<" successfully"<<endl;
                    }
                    
                    
                } else if(op==2){
                    if (queue.size()==0) {
                        cout<<"Empty, can not pop!"<<endl;
                    } else{
                        queue.pop();
                        
                        cout<<"pop successfully"<<endl;

                    }
                } else if(op==3){
                    if (queue.size()==0) {
                        cout<<"Empty, can not return font!"<<endl;
                    } else{
                        cout<<"font value:"<<queue.font()<<endl;
                        
                    }
                    
                } else if(op==4){
                    cout<<"queue size:"<<queue.size()<<endl;
                } else if(op==0){
                    break;
                }
                cout<<"---------------------------"<<endl<<endl;

            }
            
        } else if(order=="0"){
            break;
        } else{
            cout<<"order wrong"<<endl;
            continue;
        }
    }
    
    return 0;
}
