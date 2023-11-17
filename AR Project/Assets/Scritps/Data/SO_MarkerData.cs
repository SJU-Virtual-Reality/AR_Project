using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "MarkerData")]
public class SO_MarkerData : ScriptableObject
{
    public string markerName;
    public List<SO_GameData> gameDatas;
}