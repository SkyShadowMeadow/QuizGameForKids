using System.Collections.Generic;
using UnityEngine;

public class SetHandler : MonoBehaviour
{
    private Dictionary<string, Dictionary <string, Sprite>> _setsForAllLevels;
    
    public void AddNewSets(CellSet[] cellSets)
    {
        _setsForAllLevels = new Dictionary<string, Dictionary<string, Sprite>>();

        for (int i = 0; i < cellSets.Length; i++)
        {
            _setsForAllLevels.Add(cellSets[i].Name, TurnSetIntoDictionary(cellSets[i].Cells));
        }
    }
    private Dictionary<string, Sprite> TurnSetIntoDictionary(CellTemplate[] cells)
    {
        Dictionary<string, Sprite> setForCurrentType = new Dictionary<string, Sprite>();
        for (int i = 0; i < cells.Length; i++)
        {
            setForCurrentType.Add(cells[i].Identifier, cells[i].Representation);
        }
        return setForCurrentType;
    }

    public Dictionary<string, Sprite> GetCurrentSet(string nameOfSet) => _setsForAllLevels[nameOfSet];

    public List<string> GetPossibleNamesOfSets(int numberOfNeededCells)
    {
        List<string> namesOfPossibleSets = new List<string>();

        foreach (KeyValuePair<string, Dictionary<string, Sprite>> set in _setsForAllLevels)
        {
            Dictionary<string, Sprite> dict = _setsForAllLevels[set.Key];

            if (dict.Count >= numberOfNeededCells)
            {
                namesOfPossibleSets.Add(set.Key);
            }
        }
        return namesOfPossibleSets;
    }

    public void RemoveUsedPairs(string nameOfSet, Dictionary<string, Sprite> usedPairs)
    {
        Dictionary<string, Sprite> setToRemoveFrom = GetCurrentSet(nameOfSet);

        foreach (KeyValuePair<string, Sprite> usedPair in usedPairs)
        {
            setToRemoveFrom.Remove(usedPair.Key);
        }
        _setsForAllLevels[nameOfSet] = setToRemoveFrom;
    }
}
