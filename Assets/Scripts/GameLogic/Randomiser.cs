using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Randomiser
{
    private System.Random _random = new System.Random();

    public Dictionary<string, Sprite> GetRandomPairs(Dictionary<string, Sprite> possiblePairsForCurrentLevel, int numberOfPairs)
    {
        Dictionary<string, Sprite> chosenPairs = new Dictionary<string, Sprite>();

        for (int i = 0; i < numberOfPairs; i++)
        {
            string key = GetRandomKey(possiblePairsForCurrentLevel);
            chosenPairs.Add(key, possiblePairsForCurrentLevel[key]);
            possiblePairsForCurrentLevel.Remove(key);
        }
        return chosenPairs;
    }

    public string GetRandomKey(Dictionary<string, Sprite> possiblePairsForCurrentLevel)
    {
        ICollection<string> keys = possiblePairsForCurrentLevel.Keys;
        string key = keys.ElementAt(_random.Next(0, keys.Count));
        return key;
    }

    public string GetRandomSetName(List<string> possibleNames)
    {
        int randomNumber = _random.Next(0, possibleNames.Count);
        return possibleNames[randomNumber];
    }
}
