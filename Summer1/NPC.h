#pragma once
#include <string>

class NPC
{
private:
protected:
	std::string name;
public:
	NPC();
	NPC(std::string n);
	void Talk();
};

