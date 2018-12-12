//By QuXiangyu 15335124
//In 17.09.27
#include <iostream>
#include <vector>
#include <array>
#include <string>
#include <cctype>
#include <cstdlib>
using namespace std;
int sum = 0;
vector<int> answer;
vector<int> container;
int T, n;

bool check(int& tt ){
    string temp;
    getline(cin,temp);
    for (int i=0; i<temp.length(); i++) {
        if (!isdigit(temp[i])) {
            return false;
        }
    }
    tt=atoi(temp.c_str());
    return true;
}

void filter(int res, int pos);
int main() {
    while (true) {
        cout<<"Please input the bag capicity(input 0 to exit):"<<endl;
        if (!check(T)) {
            cout<<"Sorry, your input wrong,plese input again:"<<endl;
            continue;
        }
        //cin >>T;
        cout<<"Please input the item number:"<<endl;
        if (!check(n)) {
            cout<<"Sorry, your input wrong,plese input again:"<<endl;
            continue;
        }
        //cin>>n;
        cout<<"Please input each item weight:"<<endl;
        for (int i = 0; i < n; i++) {
            int temp;cin>>temp;
            container.push_back(temp);
            
        }
        getchar();
        filter(T, 0);
        cout<<"There are "<<sum<<" solutions for this problem."<<endl;
        sum=0;
    }
    
    
}

void filter(int res, int pos) {
    if (res == 0){
        return;
    }
    if (pos == n){
        return;
    }
    filter(res, pos+1);
    if (res < container[pos]) return;
    answer.push_back(container[pos]);
    if (res == container[pos]) {
        sum++;
        auto it=answer.begin();
        for (it ; it != answer.end(); it++) {
            cout << *it << " ";
        }
        cout << endl;
    }
    filter(res-container[pos], pos+1);
    answer.pop_back();
}















