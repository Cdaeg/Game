#pragma once
#include "NPC.h"
#include <fstream>
class Shopkeeper :
    public NPC
{
private:
    std::ifstream basis;
    std::string items[10];
    int index;
    std::string intro;
    std::string offer;
    std::string thanks;
    std::string outro;
public:
    Shopkeeper(std::string n, std::string filename);
    void Shop();
};

