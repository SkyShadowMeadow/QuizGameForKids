using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Container _cellContainer;
    [SerializeField] private Cell _cellTemplate;
    [SerializeField] private QuizText _quizText;
    [SerializeField] private FinishScreen _finishScreen;
    [SerializeField] private LoadScreen _loadScreen;
    [SerializeField] private GameFlow _gameFlow;

    private List<Cell> cells = new List<Cell>();
    private int _levelNumber;
    private Container _container;
    private QuizText _quiz;

    public void SpawnLevel(int levelNumber,int cellSizeOneSide, int numberOfColumns, int numberOfRows, Dictionary<string, Sprite> pairsToShow, string currentObjectNameToFind)
    {
        _levelNumber = levelNumber;
        CreateContainer(cellSizeOneSide, numberOfColumns);
        FillContainer(levelNumber, pairsToShow, currentObjectNameToFind);
        ShowQuiz(currentObjectNameToFind);
    }

    private void CreateContainer(int cellSizeOneSide, int numberOfColumns)
    {
        _container = Instantiate(_cellContainer, transform);
        _container.SetContainerConfiguration(cellSizeOneSide, numberOfColumns);
    }

    private void FillContainer(int levelNumber, Dictionary<string, Sprite> pairsToShow, string rightAnswer)
    {
        foreach (KeyValuePair<string, Sprite> pairToShow in pairsToShow)
        {
            string name = pairToShow.Key;
            Sprite representation = pairToShow.Value;

            Cell cell = Instantiate(_cellTemplate, _container.transform);
            cell.SetCellConfiguration(name, representation);
            cell.SetRightAnswer(rightAnswer);
            cell.GetRightAnswer += NotifyFinishLevel;
            cells.Add(cell);

            if (IsTheFirstLevel()) cell.BounceAppearance();
        }
    }
    private void ShowQuiz(string currentObjectNameToFind)
    {
        _quiz = Instantiate(_quizText, transform);
        _quiz.SetWhatToFind(currentObjectNameToFind);

        if (IsTheFirstLevel()) _quiz.FadeIn();
    }
    public void ActivateFinishScreen()
    {
        _finishScreen.gameObject.SetActive(true);
        _finishScreen.Appear();
    }
    public void ActivateLoadScreen(float loadTime) => _loadScreen.ActivateLoading(loadTime);
    
    public void DeactivateFinishScreen() => _finishScreen.gameObject.SetActive(false);
    
    public void DeactivateLoadScreen() => _loadScreen.DisactivateLoading();

    private bool IsTheFirstLevel() => _levelNumber == 0;

    private void NotifyFinishLevel(Cell cell)
    {
        _gameFlow.ProcessFinishLevel();
        cell.GetRightAnswer -= NotifyFinishLevel;
    }

    public void DestroyLevel()
    {
        Destroy(_container.gameObject);
        Destroy(_quiz.gameObject);
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i] != null) Destroy(cells[i].gameObject);
        }
    }

}
