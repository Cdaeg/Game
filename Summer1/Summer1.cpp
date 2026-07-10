#include <iostream>
#include "NPC.h"
#include "Questgiver.h"
#include "Shopkeeper.h"
int main()
{
    Questgiver old = Questgiver("Ezekiel", "Old_Man.txt");
    Shopkeeper potion = Shopkeeper("Sandy", "Potionmaker.txt");
    Shopkeeper librarian = Shopkeeper("Zachariah", "Librarian.txt");
    std::cout << "You are in a bazaar, filled with people going about their business.\nThe various stalls offer foods both local and exotic, trinkets from far-off lands, and mystical artifacts of many different kinds\n";
    std::cout << "Three specific figures stand out from the crowd: a travelling booklender, a potion seller surrounded by vials, and an old man standing by the wall, seeming troubled by something.\n";
    std::string response;
    std::cin >> response;
    bool oldCheck;
    while (response != "close") {
        if (response == "move" || response == "exit") {
            std::cout << "You step out of the bazaar, into the street outside.\n";
            if (oldCheck == false) {
                std::cout << "You see a wooden cane lying on the ground.\nYou pick up the cane, so you can give it to the old man when you next see him.\n";
                oldCheck = true;
            }
            std::cout << "Still having business within, you head back inside.\n";
        }
        else {
            if (response == "library") {
                librarian.Shop();
            }
            if (response == "potion" || response == "potionseller") {
                potion.Shop();
            }
            if (response == "old man") {
                old.CheckCompletion(oldCheck);
                old.Quest();
            }
        }
        std::cin >> response;
    }
}