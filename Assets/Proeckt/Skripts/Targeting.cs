using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    public Transform target;
    public float tr;
    public Animator anim;
    public static Targeting regit;
    void Awake()
    {
        if (regit == null)
        {
            regit = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        regit = null;
    }
    private void FixedUpdate()
    {
        if (target != null) 
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
        anim.SetFloat("TR", tr);
    }
}
