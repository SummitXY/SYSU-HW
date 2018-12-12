//
//  Stack.hpp
//  linkForStackQueue
//
//  Created by apple on 2017/9/19.
//  Copyright © 2017年 Quxy. All rights reserved.
//

#ifndef Stack_hpp
#define Stack_hpp

#include <stdio.h>
#include <string>
#include "Node.hpp"
using namespace std;
//class Error{
//public:
//    Error(string message_){
//        _message=message_;
//    }
//    string message(){
//        return _message;
//    }
//private:
//    string _message;
//};







template <typename T>
class Stack{
public:
    Stack();
    
    bool empty();
    void push(T value_);
    T top();
    void pop();
    int size();
    void clear();
private:
    Node<T> *_top;
    int _size;
};



//实现---------------------------------------------------------



template <typename T>
Stack<T>::Stack(){
    _size=0;
    _top=nullptr;
}

template <typename T>
bool Stack<T>::empty(){
    return _size==0;
}

template <typename T>
void Stack<T>::push(T value_){
    if (empty()) {
        _top=new Node<T>(value_,nullptr,nullptr);
        _size++;
    } else{
        Node<T> *temp=new Node<T>(value_,_top,nullptr);
        _top=temp;
        _size++;
    }
}

template <typename T>
int Stack<T>::size(){
    return _size;
}


template <typename T>
T Stack<T>::top(){
    
    return _top->value();
    
}

template <typename T>
void Stack<T>::pop(){
    Node<T> *temp=_top;
    _top=_top->_next;
    delete temp;
    temp=nullptr;
    _size--;
}

template <typename T>
void Stack<T>::clear(){
    while (_top!=nullptr) {
        
        Node<T>* temp=_top;
        _top=_top->_next;
        delete temp;
        
    }
    _size=0;
}








#endif /* Stack_hpp */
