using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class InputPK : MonoBehaviour
{
    public GameObject joy;
    public static InputPK rid { get; set; }
    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        rid = null;
    }
    public void Kik() 
    {
        Player_Muwer.rid.Kik();
    }
    public void Kik2()
    {
        Player_Muwer.rid.Kik2();
    }

    public void MuweX(Vector2 m) 
    {
        if (Player_Muwer.rid) 
        {
            Player_Muwer.rid.muwe = new Vector3(m.x, 0, m.y);
        }
       
    }

    void Update()
    {
        if (YandexGame.EnvironmentData.isDesktop) 
        {
            joy.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Interface.rid.Sum(0, true, 0);
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                Interface.rid.Sum(4, true, 0.2f);
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Player_Muwer.rid.Kik2();
            }
            if (Player_Muwer.rid)
            {
                Player_Muwer.rid.muwe.z = Input.GetAxis("Vertical");
                Player_Muwer.rid.muwe.x = Input.GetAxis("Horizontal");
            }
        }
        
    }
}
