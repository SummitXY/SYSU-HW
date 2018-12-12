//
//  Queue.h
//  linkForStackQueue
//
//  Created by apple on 2017/9/19.
//  Copyright © 2017年 Quxy. All rights reserved.
//

#ifndef Queue_h
#define Queue_h
#define MAX_SIZE 10
//#include "Node.hpp"
//
//template <typename T>
//class Queue{
//public:
//    Queue();
//    bool empty();
//    void push(T value_);
//    T font();
//    void pop();
//    int size();
//    void clear();
//private:
//    Node<T> *_font;
//    Node<T> *_back;
//    int _size;
//};
//
//template <typename T>
//Queue<T>::Queue(){
//    _size=0;
//    _font=nullptr;
//    _back=nullptr;
//    
//}
//
//template <typename T>
//bool Queue<T>::empty(){
//    return _size==0;
//}
//
//template <typename T>
//void Queue<T>::push(T value_){
//    if (empty()) {
//        _font=_back=new Node<T>(value_,nullptr,nullptr);
//        _size++;
//    } else{
//        Node<T> *temp=new Node<T>(value_,nullptr,_back);
//        _back->_next=temp;
//        _back=temp;
//        temp=nullptr;
//        _size++;
//    }
//}
//
//template <typename T>
//T Queue<T>::font(){
//    return _font->_value;
//}
//
//template <typename T>
//void Queue<T>::pop(){
//    Node<T>* temp=_font;
//    _font=_font->_next;
//    delete temp;
//    temp=nullptr;
//    _size--;
//}
//
//template <typename T>
//int  Queue<T>::size(){
//    return _size;
//}
//
//template <typename T>
//void Queue<T>::clear(){
//    while (_font!=nullptr) {
//        Node<T>* temp=_font;
//        _font=_font->_next;
//        delete temp;
//        temp=nullptr;
//    }
//}

class Queue{
public:
    Queue(){
        for (int i=0; i<MAX_SIZE; i++) {
            _value[i]=0;
        }
        _font=_back=0;
    }
    
    void push(int value_){
        if (_back==MAX_SIZE-1) {
            _value[_back]=value_;
            _back=0;
            _size++;
        } else{
            _value[_back++]=value_;
            _size++;
        }
        
        
    }
    
    void pop(){
        if (_font==MAX_SIZE-1) {
            _font=0;
        } else{
            _font++;
        }
        _size--;
    }
    
    int size(){
        return _size;
    }
    
    int font(){
        return _value[_font];
    }
private:
    int _size;
    int _font;
    int _back;
    int _value[MAX_SIZE];
};
#endif /* Queue_h */









































