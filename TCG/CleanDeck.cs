using System;
using System.Collections.Generic;

namespace TCG
{
    public class CleanDeck : ICardManager
    {
        private Dictionary<char, int> nameValues = new Dictionary<char, int>()
                                                       {
                                                           {'Q',10},
                                                           {'J',20},
                                                           {'K',30},
                                                           {'A',40},
                                                           {'2',50},
                                                           {'3',60}
                                                       };
        public Dictionary<char, int> symbolValues = new Dictionary<char, int>()
                                                        {
                                                            {'D',100},
                                                            {'S',200},
                                                            {'H',300},
                                                            {'C',400}
                                                        };

        public Dictionary<char, char> ManilhaMapping = new Dictionary<char, char>()
                                                          {
                                                           {'Q','J'},
                                                           {'J','K'},
                                                           {'K','A'},
                                                           {'A','2'},
                                                           {'2','3'},
                                                           {'3','Q'}
                                                          };

        public int GetCardValue(Card selectedCard, Card turnedCard)
        {
            if (!nameValues.ContainsKey(selectedCard.Name) || !symbolValues.ContainsKey(selectedCard.Symbol))
                throw new TrucoException("The card does not exist.");

            return IsManilha(selectedCard, turnedCard) ? symbolValues[selectedCard.Symbol] : nameValues[selectedCard.Name];
        }

        private bool IsManilha(Card selectedCard, Card turnedCard)
        {
            return (turnedCard != null) && (ManilhaMapping[turnedCard.Name] == selectedCard.Name);
        }
    }
}