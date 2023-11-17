using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "GameData")]
public class SO_GameData : ScriptableObject
{
    public string gameName;
    public GameObject gamePrefab;
}