using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private LevelSettings[] _levels;
    private int _currentLevelNumber;
    private LevelSettings _currentLevelSettings;

    public int GetCurrentLevel() => _currentLevelNumber;
    public LevelSettings GetCurrentLevelSettings() => _currentLevelSettings;

    public void SetAllLevels(LevelSettings[] levels)
    {
        _levels = levels;
        _levels = _levels.OrderBy(x => x.LevelNumber).ToArray();
        _currentLevelNumber = 0;
        _currentLevelSettings = _levels[_currentLevelNumber];
    }

    public bool CheckIsLastLevel()
    {
        if (_currentLevelNumber >= _levels.Length - 1) return true;
        else return false;
    }
    public void SetNextLevel()
    {
        _currentLevelNumber++;
        _currentLevelSettings = _levels[_currentLevelNumber];
    }
}
