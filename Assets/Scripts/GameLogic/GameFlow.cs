using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private UIHandler _handlerUI;
    [SerializeField] private SetHandler _setHandler;

    private Randomiser _iconRandomiser = new Randomiser();
    private int _currentLevelNumber;
    private LevelSettings _currentLevelSettings;
    private int _numberOfCells;
    private Dictionary<string, Sprite> _currentSet;
    private string _currentObjectNameToFind;
    private string _currentSetName;
    private float _loadTime = 2f;
    private float _delayToDestroyTime = 1.0f;
    private bool _isTheFirstStart = true;

    private void Start()
    {
        StartGame();
        _isTheFirstStart = false;
    }
    public void StartGame()
    {
        if (!_isTheFirstStart) StartCoroutine(DestroyGameWithDelay(_loadTime));
        else StartFirstLevel();
    }

    private void StartFirstLevel()
    {
        _levelManager.SetAllLevels(_gameSettings.LevelsSettings);
        _setHandler.AddNewSets(_gameSettings.PossibleSets);
        _handlerUI.DeactivateFinishScreen();
        StartLevel();
    }

    private void StartLevel()
    {
        SetCurrentLevelSettings();
        CreateLevel();
    }

    public void SetCurrentLevelSettings()
    {
        _currentLevelNumber = _levelManager.GetCurrentLevel();
        _currentLevelSettings = _levelManager.GetCurrentLevelSettings();
        _numberOfCells = GetHowManyCells();
        _currentSetName = _iconRandomiser.GetRandomSetName(_setHandler.GetPossibleNamesOfSets(_numberOfCells));
        _currentSet = _iconRandomiser.GetRandomPairs(_setHandler.GetCurrentSet(_currentSetName), _numberOfCells);
        _currentObjectNameToFind = _iconRandomiser.GetRandomKey(_currentSet);
    }
    private void CreateLevel()
    {
        _handlerUI.SpawnLevel(_currentLevelNumber, _currentLevelSettings.CellSize,
                                 _currentLevelSettings.NumberOfColums, _currentLevelSettings.NumberOfRows,
                                 _currentSet, _currentObjectNameToFind);
    }

    public void ProcessFinishLevel()
    {
        _setHandler.RemoveUsedPairs(_currentSetName, _currentSet);
        StartCoroutine(DestroyLevelWithDelay(_delayToDestroyTime)); 
    }
    IEnumerator DestroyLevelWithDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        if (!_levelManager.CheckIsLastLevel())
        {
            _handlerUI.DestroyLevel();
            _levelManager.SetNextLevel();
            StartLevel();
        }
        else FinishGame();
    }

    private void FinishGame() => _handlerUI.ActivateFinishScreen();
    
    IEnumerator DestroyGameWithDelay(float loadTime)
    {
        _handlerUI.DeactivateFinishScreen();
        _handlerUI.DestroyLevel();
        _handlerUI.ActivateLoadScreen(loadTime);
        yield return new WaitForSeconds(loadTime);

        _handlerUI.DeactivateLoadScreen();
        StartFirstLevel();
    }

    private int GetHowManyCells() => _currentLevelSettings.NumberOfColums * _currentLevelSettings.NumberOfRows;
}
