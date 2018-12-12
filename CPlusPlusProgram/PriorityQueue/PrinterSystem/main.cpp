////
//  main.cpp
//  PrinterSystem
//
//  Created by apple on 2017/9/19.
//  Copyright © 2017年 Quxy. All rights reserved.
//

#include <iostream>
#include <vector>
#include <utility>
#include <map>
#include <algorithm>

using namespace std;

bool more(){
    return true;
}
int main(int argc, const char * argv[]) {
    int N;cin>>N;
    while (N--) {
        int n,m;cin>>n>>m;
        vector<pair<int, int>> v;
        for (int i=0; i<n; i++) {
            int temp;cin>>temp;
            if (i==m) {
                v.push_back(pair<int, int>(temp,1));
            } else{
                v.push_back(pair<int, int>(temp,0));
            }
            
        }
        
        int sum=0;
        
        while (true) {
            int f=v[0].first;
            if (find_if(v.begin()+1, v.end(),[f](pair<int ,int>x){return f<x.first;} )!=v.end()) {
                v.push_back(v[0]);
                v.erase(v.begin());
                
            } else{
                if (v[0].second==1) {
                    sum++;
                    cout<<sum<<endl;
                    break;
                } else{
                    sum++;
                    v.erase(v.begin());
                }
            }
        }
        
    }
    return 0;
}


