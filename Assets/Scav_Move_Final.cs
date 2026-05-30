using Unity.VisualScripting;
using UnityEngine;

public class Scav_Move_Final : MonoBehaviour
{
    public Transform ScavPath1Fin;
    public Transform ScavPath2Fin;

    //public Transform ScavRestingPoint;
    //public Transform Scav_Shuttle_Collision;

    public GameObject Scav_Scrap_Heap;

    public GameObject UIlinker7;
    public GameObject TransitionCondition9;
    public GameObject TransitionCondition8;

    public bool IsDialogueFinished; //Set in Dialogue6Real (in hide menu method)

    private float Speed = 10.0f;
    public enum Scav_State
    {
        Scav_Trapped,
        Scav_Rest,
        Scav_Path1,
        Scav_Path2
    }
    public Scav_State ScavState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       ScavState = Scav_State.Scav_Trapped;
    }

    // Update is called once per frame
    void Update()
    {
        switch (ScavState)
        {
            case Scav_State.Scav_Trapped: Scav_Trapped();break;
            case Scav_State.Scav_Path1:Scav_P1_Move();break;
            case Scav_State.Scav_Path2:Scav_P2_Move(); break;
            case Scav_State.Scav_Rest:Scav_Rest_Shuttle(); break;
        }

        if (Scav_Scrap_Heap == null)
        {
            TransitionCondition8.SetActive(true);
           transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }

        if (IsDialogueFinished == true)
        {
            ScavState = Scav_State.Scav_Path1;
        }
    }
    public void Scav_Trapped()
    {
        transform.position = new Vector3(934.72f, -15.42f, 0.0f);
        transform.eulerAngles = new Vector3(0,0, 12.809f);
    }
    public void Scav_P1_Move()
    {

        transform.position = Vector3.MoveTowards(transform.position , ScavPath1Fin.position , Speed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, 180);
    }
    public void Scav_P2_Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, ScavPath2Fin.position, Speed * Time.deltaTime);
    }
    public void Scav_Rest_Shuttle()
    {
        transform.position = new Vector3(701.42f, -80.57f, 0);
        UIlinker7.SetActive(true);
        TransitionCondition9.SetActive(true);
  
    }
    
    public void OnTriggerEnter2D(Collider2D  collider)
    {
        if (collider.gameObject.name == "ScavPath1Fin")
        {
            ScavState = Scav_State.Scav_Path1;
        }
        if (collider.gameObject.name == "ScavPath2Fin")
        {
            ScavState = Scav_State.Scav_Rest;
        }
    }


}