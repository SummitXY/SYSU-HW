//
//  main.cpp
//  experiment4
//
//  Created by apple on 2017/10/18.
//  Copyright © 2017年 Quxy. All rights reserved.
//

#include <iostream>
#include <cctype>
using namespace std;

const int seqMaxSize=10;
int seqSize=0;

void exchange(char& v1,char& v2);
void seqInsert(char c[],char v,int p);
void seqDelete(char c[],int p);

class Node{
public:
    Node(){
        value=0;
        next=nullptr;
    }
    Node(char v){
        value=v;
        next=nullptr;
    }
    char value;
    Node* next;
};
class LinkStorage{
public:
    LinkStorage(){
        linksize=0;
        head=nullptr;
    }
    ~LinkStorage();
    void linkInsert(char v,int p);
    void linkDelete(int p);
    void show();
    int linksize;
private:
    
    Node* head;
};

bool checkInputOrder(int& in,string s){
    if (s.length()>1 || !isdigit(s[0])) {
        cout<<"Sorry, the input should be number."<<endl;
        cout<<"Try again."<<endl;
        return false;
    }
    
    in=atoi(s.c_str());
    return true;
}

bool checkCharValue(char& ch,string s){
    if (s.length()>1) {
        cout<<"Sorry, the input should be only one char."<<endl;
        cout<<"Try again."<<endl;
        return false;
    }
    ch=s[0];
    return true;
}

int main(int argc, const char * argv[]) {
    while (true) {
        cout<<"1) the Sequential Storage"<<endl;
        cout<<"2) the Linked Storage"<<endl;
        cout<<"0) exit"<<endl;
        //int order;cin>>order;
        int order;
        string tempOrder;getline(cin,tempOrder);
        if (!checkInputOrder(order, tempOrder)) {
            continue;
        }
        if (order<0 || order>2) {
            cout<<"Sorry, the order should be 1 2 or 0."<<endl;
            cout<<"Try again."<<endl;
        }
        if (order==1) {
            seqSize=0;
            char c[10]={};
            while (true) {
                cout<<"1) insert item"<<endl;
                cout<<"2) delete item"<<endl;
                cout<<"3) show"<<endl;
                cout<<"0) exit"<<endl;
                int order;
                string tempOrder;getline(cin,tempOrder);
                if (!checkInputOrder(order, tempOrder)) {
                    continue;
                }
                if (order<0 || order>3) {
                    cout<<"Sorry, the order should be 1 2 3 or 0."<<endl;
                    cout<<"Try again."<<endl;
                }
                if (order==1) {
                    if (seqSize==seqMaxSize) {
                        cout<<"Sorry,the storage is full,you cannot insert."<<endl;
                        continue;
                    }
                    cout<<"Input the insert position: ";
                    //int pos;cin>>pos;
                    int pos;
                    string tempOrder;getline(cin,tempOrder);
                    if (!checkInputOrder(pos, tempOrder)) {
                        continue;
                    }
                    if (pos>seqSize || pos<0) {
                        cout<<"Sorry,the insert position should be between 0 to "<<seqSize<<",inclusive"<<endl;
                        cout<<"Try again"<<endl;
                        continue;
                    }
                    cout<<"Input the insert value: ";
                    //char value;cin>>value;
                    char value;
                    string tempValue;getline(cin,tempValue);
                    if (!checkCharValue(value, tempValue)) {
                        continue;
                    }
                    seqInsert(c, value, pos);
                    seqSize++;
                    cout<<"Insert success"<<endl;
                } else if(order==2){
                    if (seqSize ==0) {
                        cout<<"Sorry,the storage is empty, you cannot delete."<<endl;
                        continue;
                    }
                    cout<<"Input the delete pos: ";
                    int pos;
                    string tempOrder;getline(cin,tempOrder);
                    if (!checkInputOrder(pos, tempOrder)) {
                        continue;
                    }
                    if (pos<0 || pos>=seqSize) {
                        cout<<"Sorry,the delete position should be between 0 to "<<seqSize-1<<",inclusive"<<endl;
                        cout<<"Try again"<<endl;
                        continue;
                    }
                    seqDelete(c, pos);
                    seqSize--;
                    cout<<"Delete success"<<endl;
                } else if(order==3){
                    for(auto x:c){
                        cout<<x<<" ";
                    }
                    cout<<endl;
                } else {
                    break;
                }
            }
            
        } else if(order==2){
            LinkStorage client;
            while (true) {
                cout<<"1) insert item"<<endl;
                cout<<"2) delete item"<<endl;
                cout<<"3) show"<<endl;
                cout<<"0) exit"<<endl;
                int order;
                string tempOrder;getline(cin,tempOrder);
                if (!checkInputOrder(order, tempOrder)) {
                    continue;
                }
                if (order<0 || order>3) {
                    cout<<"Sorry, the order should be 1 2 3 or 0."<<endl;
                    cout<<"Try again."<<endl;
                }
                if (order==1) {
                    cout<<"Input the insert position: ";
                    int pos;
                    string tempOrder;getline(cin,tempOrder);
                    if (!checkInputOrder(pos, tempOrder)) {
                        continue;
                    }
                    if (pos<0 || pos>client.linksize) {
                        cout<<"Sorry,the insert position should be between 0 to "<<client.linksize<<",inclusive"<<endl;
                        cout<<"Try again"<<endl;
                        continue;
                    }
                    cout<<"Input the insert value: ";
                    char value;
                    string tempValue;getline(cin,tempValue);
                    if (!checkCharValue(value, tempValue)) {
                        continue;
                    }
                    client.linkInsert(value, pos);
                    cout<<"Insert OK."<<endl;
                } else if(order==2){
                    cout<<"Input the delete position: ";
                    int pos;
                    string tempOrder;getline(cin,tempOrder);
                    if (!checkInputOrder(pos, tempOrder)) {
                        continue;
                    }
                    if (pos<0 || pos>=client.linksize) {
                        cout<<"Sorry,the delete position should be between 0 to "<<client.linksize-1<<",inclusive"<<endl;
                        cout<<"Try again"<<endl;
                        continue;
                    }
                    client.linkDelete(pos);
                    cout<<"Delete OK."<<endl;
                } else{
                    client.show();
                }
                
            }
            
            
            
        } else if(order==0){
            return 0;
        } else {
            continue;
        }

    }
}

void exchange(char& v1,char& v2){
    char temp=v1;
    v1=v2;
    v2=temp;
}

void seqInsert(char c[],char v,int p){
    char temp=v;
    for (int i=p; i<seqMaxSize; i++) {
        exchange(temp, c[i]);
    }
}

void seqDelete(char c[],int p){
    for (int i=p; i<seqMaxSize-1; i++) {
        c[i]=c[i+1];
    }
}

void LinkStorage::linkInsert(char v, int p){
    Node* insertBefore=head;
    Node* insertNode=new Node(v);
    
    if (p==0) {
        insertNode->next=head;
        head=insertNode;
    } else{
        for (int i=1; i<p; i++) {
            insertBefore=insertBefore->next;
        }
        insertNode->next=insertBefore->next;
        insertBefore->next=insertNode;
    }
    
    linksize++;
    
}

void LinkStorage::linkDelete(int p){
    Node* deleteBefore=head;
    
    if (p==0) {
        head=head->next;
        delete deleteBefore;
        deleteBefore=nullptr;
    } else{
        for (int i=1; i<p; i++) {
            deleteBefore=deleteBefore->next;
        }
        Node* deleteNode=deleteBefore->next;
        deleteBefore->next=deleteNode->next;
        delete deleteNode;
        deleteNode=nullptr;
    }
    
    linksize--;
    
}
void LinkStorage::show(){
    Node* now=head;
    while (now!=nullptr) {
        cout<<now->value<<" ";
        now=now->next;
    }
    cout<<endl;
}

LinkStorage::~LinkStorage(){
    Node* now=nullptr;
    while (true) {
        now=head;
        if (now==nullptr) {
            break;
        } else{
            head=head->next;
            delete now;
            now=nullptr;
        }
    }
}

























