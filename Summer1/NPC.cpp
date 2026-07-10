#include "NPC.h"
#include <string>
#include <iostream>
NPC::NPC() {
	name = "test";
}
NPC::NPC(std::string n) {
	name = n;
}
void NPC::Talk() {
	std::cout << "'Greetings, traveler. My name is " << name << ".'\n";
	std::string response;
	std::cin >> response;
	if (response == "leave" || response == "bye") {
		std::cout << "You walked away...\n";
	}
	if (response == "hello" || response == "hi") {
		std::cout << "'I am merely a demo NPC, so I have no more dialogue.'\n";
	}
	else {
		std::cout << "not a valid command.\n";
	}
}