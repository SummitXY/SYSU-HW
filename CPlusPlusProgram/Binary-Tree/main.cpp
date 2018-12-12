//
//  main.cpp
//  Binary_tree
//
//  Created by apple on 2017/10/24.
//  Copyright © 2017年 Quxy. All rights reserved.
//

#include <iostream>
#include <cctype>
using namespace std;
class Node{
public:
    int value;
    Node* lchild;
    Node* rchild;
    
    Node(int v){
        value=v;
        lchild=nullptr;
        rchild=nullptr;
    }
    Node(){
        value=0;
        lchild=rchild=nullptr;
    }
    
};

bool insert(Node* &node,int v){
    if (node==nullptr) {
        node=new Node(v);
    } else if(v<node->value){
        return insert(node->lchild, v);
    } else if(v>node->value){
        return insert(node->rchild, v);
    } else{
        return false;
    }
    return true;
}

void inorder(Node* node){
    if (node) {
        inorder(node->lchild);
        cout<<node->value<<" ";
        inorder(node->rchild);
    }
}

void interchange(Node* &node){
    if (node) {
        interchange(node->lchild);
        interchange(node->rchild);
        Node* temp=node->lchild;
        node->lchild=node->rchild;
        node->rchild=temp;
    }
    
}

bool find(Node* node,int v){
    if (node) {
        if (v<node->value) {
            return find(node->lchild, v);
        } else if(v>node->value){
            return find(node->rchild,v);
        } else{
            return true;
        }
    }
    return false;
}

void clear(Node* &node){
    if (node) {
        if (node->lchild) {
            clear(node->lchild);
        }
        
        if (node->rchild) {
            clear(node->rchild);
        }
        
        delete node;
        node=nullptr;
    }
    
    
}

bool remove(Node* &node, int v){
    if (node) {
        if (v<node->value) {
            return remove(node->lchild, v);
        } else if(v>node->value){
            return remove(node->rchild,v);
        } else{
            clear(node);
            return true;
        }
    }
    return false;
}

bool checkInputOrder(int& in,string s){
    for (int i=0; i<s.length(); i++) {
        if (i==0) {
            if (!(s[i]=='+' || s[i]=='-' || isdigit(s[i]))) {
                cout<<"Sorry, your input is illegal, please input again: "<<endl;
                return false;
            }
        } else {
            if (!isdigit(s[i])) {
                cout<<"Sorry, your input is illegal, please input again: "<<endl;
                return false;
            }
        }
    }
    
    in=atoi(s.c_str());
    return true;
}

int main(int argc, const char * argv[]) {
    Node* root;
    while (true) {
        cout<<"1) Insert node:"<<endl;
        cout<<"2) Interchange left and right subtrees:"<<endl;
        cout<<"3) Find whether value in tree:"<<endl;
        cout<<"4) Femove node:"<<endl;
        cout<<"5) Show tree in order:"<<endl;
        cout<<"0) Exit."<<endl;
        string tempStr;
        getline(cin,tempStr);
        int order;
        if (!checkInputOrder(order, tempStr)) {
            continue;
        }
        if (order<0 || order>5) {
            cout<<"The order should be in 0 to 5, please input again."<<endl;
            continue;
        }
        if (order==1) {
            cout<<"Input the node value:"<<endl;
            string tempStr;
            getline(cin,tempStr);
            int value;
            if (!checkInputOrder(value, tempStr)) {
                continue;
            }
            
            
            if (!insert(root, value)) {
                cout<<"Can't insert the same value."<<endl;
            }else{
                cout<<"Insert successful."<<endl;
            }
            
        } else if(order==2){
            interchange(root);
            cout<<"Interchange successful."<<endl;
        } else if(order==3){
            cout<<"Input the value you wanna check:"<<endl;
            cout<<"Input the node value:"<<endl;
            string tempStr;
            getline(cin,tempStr);
            int value;
            if (!checkInputOrder(value, tempStr)) {
                continue;
            }
            if (find(root,value)) {
                cout<<"Find it!"<<endl;
            } else{
                cout<<"Find no node."<<endl;
            }
        } else if(order==4){
            cout<<"Input the node you wanna remove:"<<endl;
            string tempStr;
            getline(cin,tempStr);
            int value;
            if (!checkInputOrder(value, tempStr)) {
                continue;
            }
            if (!remove(root,value)) {
                cout<<"wrong"<<endl;
            } else{
                cout<<"Remove successful."<<endl;
            }
        } else if(order==5){
            inorder(root);
            cout<<endl;
        } else {
            clear(root);
            return 0;
        }
    }
    
   
}


















