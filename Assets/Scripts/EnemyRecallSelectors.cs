using Unity.VisualScripting;
using UnityEngine;

public class EnemyRecallSelectors : MonoBehaviour
{
    public enum  RecallLayout
    {
        Defualt,
        LinearHoroznontal,
        LinearVerticle,
        CustomDiagonal1,
        CustomDiagonal2,

    }
    public RecallLayout option = RecallLayout.Defualt;

    public bool Is_Defualt = false;
    public bool Is_LinVert = false;
    public bool Is_LinHoroz= false;

    public bool Is_CusDiag1 = false;
    public bool Is_CusDiag2 = false;

    public EnemyMovementRev EnemyMoveRev;

    public float X = 0;
    float Z = 0;
    float Y = 0;

    public void Start()
    {
     
      
        
    }
 
    public void Update()
    {
        //Defualt 
        if (option == RecallLayout.Defualt)
        {
            Is_Defualt = true;
            if (Is_Defualt == true)
            {
                Recall_Layout_Defualt();
            }
        }
        else
        {
            Is_Defualt = false;
        }

        //LinearVerticle
        if (option == RecallLayout.LinearVerticle)
            Is_LinVert = true;
        if (Is_LinVert == true)
        {
            Recall_Layout_LinearVerticle();
        }
        else { Is_LinVert = false; }

        //LinearHoroznontal
        if (option == RecallLayout.LinearHoroznontal)
            Is_LinHoroz = true;
        if (Is_LinHoroz == true)
        {
            Recall_Layout_LinearHorozontal();
        }
        else { Is_LinHoroz = false; }
    
        //CustomDiagonal1
        if (option == RecallLayout.CustomDiagonal1)
            Is_CusDiag1 = true;
        if (Is_CusDiag1 == true)
        {
            Recall_Layout_CustomDiag1();
        }
        else
        { Is_CusDiag1 = false; }

        //CustomDiagonal2
        if (option == RecallLayout.CustomDiagonal2)
            Is_CusDiag2 = true;
        if (Is_CusDiag2 == true)
        {
            Recall_Layout_CustomDiag2();
        }
        else { Is_CusDiag2 = false; }


    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        //CustomDiagonal2 
        if (collider.gameObject.CompareTag("Recall_Layout_Custom_Diag2"))
        {
            Debug.Log("Recall_Layout_Custom_Diag2 is active");
            option = RecallLayout.CustomDiagonal2;
        }

        //CustomDiagonal1
        if (collider.gameObject.CompareTag("Recall_Layout_Custom_Diag1"))
        {
            Debug.Log("Recall_Layout_Custom_Diag1 is active");
            option = RecallLayout.CustomDiagonal1;
        }
  

    //LinearHoroznontal
            if (collider.gameObject.CompareTag("RecallLayout_Linear_Horozontal"))
        {
            Debug.Log("RecallLayout_Linear_Horozontal is active");
            option = RecallLayout.LinearHoroznontal;
        }
    //LinearVerticle
        if (collider.gameObject.CompareTag("RecallLayout_Linear_Verticle"))
        {
            Debug.Log("RecallLayout_Linear_Verticle is active");
            option = RecallLayout.LinearVerticle;
        }


        //Defualt 
        if (collider.gameObject.CompareTag("RecallLayout_Defualt"))
        {
            Debug.Log("RecallLayoutDefualte is active");
            option = RecallLayout.Defualt;
        }

      
    }
    public void Recall_Layout_Defualt()
    {


        EnemyMoveRev.recallStart.localPosition = new Vector3(18.74814f, 9.504487f, Z);
        EnemyMoveRev.recallP1.localPosition = new Vector3(22.49776f , -1.900897f ,Z);
        EnemyMoveRev.recallP2.localPosition = new Vector3(12.49876f, -10.45494f , Z);

    }
    
    public void Recall_Layout_LinearVerticle()
    {
        EnemyMoveRev.recallStart.localPosition = new Vector3(-0.4396276f, 4.348204f, Z);
        EnemyMoveRev.recallP1.localPosition = new Vector3(1.52f , 11.9209f , Z);
        EnemyMoveRev.recallP2.localPosition = new Vector3(11.7895f , 1.440449f , Z);
    }

    public void Recall_Layout_LinearHorozontal()
    {
        EnemyMoveRev.recallStart.localPosition = new Vector3(16.68801f, -1.35449f , Z);
        EnemyMoveRev.recallP1.localPosition = new Vector3(27.76739f , 4.317301f, Z);
        EnemyMoveRev.recallP2.localPosition = new Vector3(8.039876f , 7.143144f, Z);

    }
    public void Recall_Layout_CustomDiag1()
    {
        EnemyMoveRev.recallStart.localPosition = new Vector3(-12.0592f, -4.205841f, Z);
        EnemyMoveRev.recallP1.localPosition = new Vector3(-17.22821f, -9.939423f, Z);
        EnemyMoveRev.recallP2.localPosition = new Vector3(-28.20658f, -10.91538f, Z);
    }

    public void Recall_Layout_CustomDiag2()
    {
        EnemyMoveRev.recallStart.localPosition = new Vector3(11.68844f, -3.255395f, Z);
        EnemyMoveRev.recallP1.localPosition = new Vector3(16.51844f, -10.88988f, Z);
        EnemyMoveRev.recallP2.localPosition = new Vector3(31.78745f, -11.86584f, Z);

    }
    public void Recall_Unset()
    {
        EnemyMoveRev.recallStart.localPosition = new Vector3(X, Y, Z);
        EnemyMoveRev.recallP1.localPosition = new Vector3(X, Y, Z);
        EnemyMoveRev.recallP2.localPosition = new Vector3(X, Y, Z);
    }


}
