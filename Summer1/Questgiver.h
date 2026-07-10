#pragma once
#include "NPC.h"
#include <fstream>
class Questgiver :
    public NPC
{
private:
    std::ifstream basis;
    std::string intro;
    std::string questOffer;
    std::string questComplete;
    std::string outro;
    bool questCompletion;
public:
    Questgiver(std::string n, std::string filename);
    void Quest();
    void CheckCompletion(bool check);
};

