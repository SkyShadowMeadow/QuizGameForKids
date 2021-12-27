using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Level Settings", fileName = "New level settings", order = 40)]
public class LevelSettings : ScriptableObject
{
    [Header("Data of the conteiner for cells")]

    [SerializeField] private int _levelNumber;
    [SerializeField] private int _numberOfColums;
    [SerializeField] private int _numberOfRows;
    [SerializeField] private int _cellSize = 150;

    public int LevelNumber => _levelNumber;
    public int NumberOfColums => _numberOfColums;
    public int NumberOfRows => _numberOfRows;
    public int CellSize => _cellSize;
}
