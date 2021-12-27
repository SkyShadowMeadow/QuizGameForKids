using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Cells/Create cell", fileName = "New cell", order = 40)]
public class CellTemplate : ScriptableObject
{
    [SerializeField] private string _identifier;
    [SerializeField] private Sprite _representation;

    public Sprite Representation => _representation;
    public string Identifier => _identifier;
}
