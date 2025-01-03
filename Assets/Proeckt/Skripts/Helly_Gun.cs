using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helly_Gun : MonoBehaviour
{
    public GameObject bomb;
    public GameObject[] bombs;
    int num;

    public void Shut() 
    {
        if (num < bombs.Length) 
        {
            Instantiate(bomb, bombs[num].transform.position, bombs[num].transform.rotation);
            bombs[num].SetActive(false);
            num += 1;
        }
        
    }
}
