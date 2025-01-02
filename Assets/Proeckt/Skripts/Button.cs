using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int index;
    public bool cursor;
    public float scale;

    public void Onclick()
    {
        Interface.rid.Sum(index, cursor, scale);
    }
}
