using System;
using System.IO;

class pokerConverter
{
    static void Main()
    {
        string filePath = "pokerhands.csv"; // You can use a full path too.

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string pokerHand in lines)
        {
            string[] values = pokerHand.Split(',');
            int[] suits = new int[5];
            int[] ranks = new int[5];
            for (int i = 0; i < 5; i++)
            {
                suits[i] = int.Parse(values[i * 2]);
                ranks[i] = int.Parse(values[i * 2 + 1]);
            }

            Array.Sort(ranks);

            int[] rankCount = new int[15];
            for (int i = 0; i < 5; i++)
                rankCount[ranks[i]]++;

            int pairs = 0;
            bool three = false;
            bool four = false;
            foreach (int count in rankCount)
            {
                if (count == 2) pairs++;
                if (count == 3) three = true;
                if (count == 4) four = true;
            }

            bool isFlush = suits[0] == suits[1] && suits[1] == suits[2] &&
                           suits[2] == suits[3] && suits[3] == suits[4];

            bool isStraight = true;
            for (int i = 0; i < 4; i++)
            {
                if (ranks[i + 1] != ranks[i] + 1)
                {
                    isStraight = false;
                    break;
                }
            }

            bool isRoyal = isFlush && isStraight && ranks[0] == 10;

            string handType = "";
            switch (true)
            {
                case true when isRoyal:
                    handType = "Royal Flush";
                    break;
                case true when isFlush && isStraight:
                    handType = "Straight Flush";
                    break;
                case true when four:
                    handType = "Four of a Kind";
                    break;
                case true when three && pairs == 1:
                    handType = "Full House";
                    break;
                case true when isFlush:
                    handType = "Flush";
                    break;
                case true when isStraight:
                    handType = "Straight";
                    break;
                case true when three:
                    handType = "Three of a Kind";
                    break;
                case true when pairs == 2:
                    handType = "Two Pair";
                    break;
                case true when pairs == 1:
                    handType = "One Pair";
                    break;
                default:
                    handType = "Null/High Card";
                    break;
            }

            Console.WriteLine($"Hand: {pokerHand} is a {handType}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
