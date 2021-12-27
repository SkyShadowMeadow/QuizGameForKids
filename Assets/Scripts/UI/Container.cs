using UnityEngine;
using UnityEngine.UI;
public class Container : MonoBehaviour
{
    private GridLayoutGroup _gridLayoutGroup;

    private void Awake()
    {
        _gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    public void SetContainerConfiguration(int cellSizeOneSide, int numberOfColumns)
    {
        Vector2 cellSize = Vector2.one * cellSizeOneSide;
        _gridLayoutGroup.cellSize = cellSize;
        _gridLayoutGroup.constraintCount = numberOfColumns;
    }

}
