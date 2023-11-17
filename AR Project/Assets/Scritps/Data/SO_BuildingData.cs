using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "BuildingData")]
public class SO_BuildingData : ScriptableObject
{
    public string buildingName;
    public List<SO_MarkerData> markerDatas;
}