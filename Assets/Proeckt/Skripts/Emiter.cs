using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Emiter : MonoBehaviour
{
    public float interval = 5;
    public GameObject emit;
    public Transform point;
    float timer = 0;
    public void Emit()
    {
        GameObject g = Instantiate(emit);
        g.transform.position = transform.position;
        g.transform.rotation = transform.rotation;
        g.GetComponent<Mashin>().OnTarget(point);
    }
    private void FixedUpdate()
    {
        if (Time.time > timer)
        {
            Emit();
            timer = Time.time + interval;
        }
    }
}
