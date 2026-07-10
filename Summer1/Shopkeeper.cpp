#include "Shopkeeper.h"
#include <fstream>
#include <iostream>
//Constructor for the shopkeeper NPC type.
Shopkeeper::Shopkeeper(std::string n, std::string filename) {
	name = n;
	basis.open(filename);
	index = 0;
	bool contin = true;
	//Takes the shopkeeper's items and puts them into a list, until the point in the file where dialogue begins.
	while (contin) {
		std::getline(basis, items[index]);
		if (items[index] == "---") {
			contin = false;
		}
		else {
			index++;
		}
	}
	//Handles the shopkeeper's dialogue.
	std::getline(basis, intro);
	std::getline(basis, offer);
	std::getline(basis, thanks);
	std::getline(basis, outro);
	basis.close();
}
//Handles interactions between the player and shopkeeper.
void Shopkeeper::Shop() {
	std::string response;
	std::cout << intro << "\n";
	std::cin >> response;
	while (response != "leave") {
		std::cout << offer << "\n";
		for (int i = 0; i < index; i++) {
			std::cout << items[i] << "\n";
		}
		std::cin >> response;
		if (std::stoi(response) < index) {
			std::cout << thanks << "\n";
		}
	}
	std::cout << outro << "\n";
}