using System;

class Program
{
    static void Main()
    {
        string pokerHand = "1,1,1,13,2,4,2,3,1,12";

        string[] values = pokerHand.Split(',');
        //values = {"1", "13", etc}

        string[] pokerSets = new string[5];

        for(int i = 0; i < 5; i++)
        {
            int suitNumber = int.Parse(values[i * 2]);
            int rankNumber = int.Parse(values[i * 2 + 1]);

            string suitName = "";
            string rankName = "";

            switch(suitNumber)
            {
                case 1:
                    suitName = "Spades";
                    break;
                case 2:
                    suitName = "Hearts";
                    break;
                case 3:
                    suitName = "Clubs";
                    break;
                default:
                    suitName = "Diamonds";
                    break;
            }
            //csv file
            switch(rankNumber)
            {
                case 1:
                    rankName = "Ace";
                    break;
                case 2:
                    rankName = "Two";
                    break;
                case 3:
                    rankName = "Three";
                    break;
                case 4:
                    rankName = "Four";
                    break;
                case 5:
                    rankName = "Five";
                    break;
                case 6:
                    rankName = "Six";
                    break;  
                case 7:
                    rankName = "Seven";
                    break;
                case 8:
                    rankName = "Eight";
                    break;
                case 9:
                    rankName = "Nine";
                    break;
                case 10:
                    rankName = "Ten";
                    break;  
                case 11:
                    rankName = "Jack";
                    break;
                case 12:
                    rankName = "Queen";
                    break;
                default:
                    rankName = "King";
                    break;
            }
            pokerSets[i] = $"Card {i + 1}: Suit: {suitName}, Rank: {rankName}";
        }

        foreach(string card in pokerSets)
        {
            Console.WriteLine(card);
        }
    }
}
