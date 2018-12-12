//
//  Node.h
//  linkForStackQueue
//
//  Created by apple on 2017/9/19.
//  Copyright © 2017年 Quxy. All rights reserved.
//

#ifndef Node_h
#define Node_h

template <typename T>
class Node{
public:
    Node(T value_,Node* next_,Node* prev_);
    T value(){
        return _value;
    }
    //private:
    T _value;
    Node *_next;
    Node *_prev;
};

template <typename T>
Node<T>::Node(T value_,Node* next_,Node* prev_){
    _value=value_;
    _next=next_;
    _prev=prev_;
}
#endif /* Node_h */
