using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Game Settings", fileName = "New Game settings", order = 40)]

public class GameSettings : ScriptableObject
{
    [SerializeField] private LevelSettings[] _levelsSettings;
    [SerializeField] private CellSet[] _possibleSets;

    public LevelSettings[] LevelsSettings => _levelsSettings;
    public CellSet[] PossibleSets => _possibleSets;
}
