using UnityEngine;
using System.Collections.Generic;
using static SetText;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 1)]
public class Data: ScriptableObject
{
    public List<Sprite> icons;
}
