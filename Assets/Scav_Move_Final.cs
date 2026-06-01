using JetBrains.Annotations;
using System.IO;
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

    public Rigidbody2D RigBod;
    public float Dis_Cheack1;

    public bool isLeft;
    public bool isBack;
    public bool isDefualt;
    public Animator Scav_Animator;

    public bool IsDialogueFinished; //Set in Dialogue6Real (in hide menu method)

    public QuestFinal quest;

    private float Speed = 5.0f;
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
       RigBod = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame

    void Update()
    {
        float HiHi = Vector3.Distance(transform.position, ScavPath1Fin.position);
        float HiHi2 = Vector3.Distance(transform.position , ScavPath2Fin.position);
        switch (ScavState)
        {
            case Scav_State.Scav_Trapped: Scav_Trapped();break;
            case Scav_State.Scav_Path1:Scav_P1_Move();break;
            case Scav_State.Scav_Path2:Scav_P2_Move(); break;
            case Scav_State.Scav_Rest:Scav_Rest_Shuttle(); break;
        }
        if (HiHi <= 3.0f)
        {
            ScavState = Scav_State.Scav_Path2;
        }
        if (HiHi2 <= 3.0f)
        {
            ScavState = Scav_State.Scav_Rest;
        }
           
        if (!Scav_Scrap_Heap.activeSelf)
        {
            TransitionCondition8.SetActive(true);
           //transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }

        if (IsDialogueFinished == true && ScavState == Scav_State.Scav_Trapped)
        {
            ScavState = Scav_State.Scav_Path1;
        }

        if(isLeft == true)
        {
            Scav_Animator.SetBool("isLeft", true);
        }
        else if (isLeft == false)
        {
            Scav_Animator.SetBool("isLeft", false);
        }

        if (isBack == true)
        {
            Scav_Animator.SetBool("isBack", true);
        }
        else if (isBack == false)
        {
            Scav_Animator.SetBool("isBack" , false);
        }
        if (isDefualt == true)
        {
            Scav_Animator.SetBool("isDefualt", true);
        }
      
 
    }
    public void Scav_Trapped()
    {
        transform.position = new Vector3(934.72f, -15.42f, 0.0f);
       // transform.eulerAngles = new Vector3(0,0, 12.809f);
    }
    public void Scav_P1_Move()
    {
        isLeft = true;
        isBack = false;
        Vector3 Dir_PathP1 = (ScavPath1Fin.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP1 * Speed);
        //transform.position = Vector3.MoveTowards(transform.position , ScavPath1Fin.position , Speed * Time.deltaTime);
        //transform.eulerAngles = new Vector3(0, 180f, 0);
        quest.QuestObjectives_Enum = QuestFinal.QuestObjective.O6;
    }
    public void Scav_P2_Move()
    {
      
        isBack = true;
        isLeft = false; 
        RigBod.linearVelocity = transform.position - ScavPath1Fin.position * Speed;
        Vector3 Dir_PathP2 = (ScavPath2Fin.position - transform.position).normalized;
        RigBod.linearVelocity = (Dir_PathP2 * Speed);
        //transform.position = Vector3.MoveTowards(transform.position, ScavPath2Fin.position, Speed * Time.deltaTime);
    }
    public void Scav_Rest_Shuttle()
    {
       // Scav_Animator.enabled = false;
        transform.position = new Vector3(701.42f, -80.57f, 0);
        isLeft = false;
        isBack = false;
        UIlinker7.SetActive(true);
        TransitionCondition9.SetActive(true);
        isDefualt = true;

    }
    



}