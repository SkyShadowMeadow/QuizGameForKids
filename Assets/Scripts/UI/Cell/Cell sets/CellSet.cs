using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cells/Create cell set", fileName = "New set", order = 40)]
public class CellSet : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private CellTemplate[] _cells;

    public CellTemplate[] Cells => _cells;
    public string Name => _name;
}
