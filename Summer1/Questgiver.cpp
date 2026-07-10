#include "Questgiver.h"
#include <fstream>
#include <iostream>
//The constructor for setting up the questgiver type NPC.
Questgiver::Questgiver(std::string n, std::string filename) {
	name = n;
	questCompletion = false;
	basis.open(filename);
	std::getline(basis, intro);
	std::getline(basis, questOffer);
	std::getline(basis, questComplete);
	std::getline(basis, outro);
	basis.close();
}
//Handles interactions with the questgiver NPC.
void Questgiver::Quest() {
	std::cout << intro << "\n";
	if (questCompletion == false) {
		std::cout << questOffer << "\n";
	}
	else {
		std::cout << questComplete << "\n";
	}
	std::cout << outro << "\n";
}
void Questgiver::CheckCompletion(bool check) {
	questCompletion = check;
}