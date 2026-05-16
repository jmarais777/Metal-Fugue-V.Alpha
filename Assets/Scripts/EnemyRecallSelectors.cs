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

    public Transform RecallStart;
    public Transform RecallP1;

    public float X = 0;
    float Z = 0;
    float Y = 0;

 
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
        else if (option != RecallLayout.Defualt)
        {
            Is_Defualt = false;
        }

        //LinearVerticle
        if (option == RecallLayout.LinearVerticle)
        {
            Is_LinVert = true;

            if (Is_LinVert == true)
            {
                Recall_Layout_LinearVerticle();
            }
        }

        else if (option != RecallLayout.LinearVerticle)
        {
            Is_LinVert = false;
        }

        //LinearHoroznontal
        if (option == RecallLayout.LinearHoroznontal)
        {
            Is_LinHoroz = true;

            if (Is_LinHoroz == true)
            {
                Recall_Layout_LinearHorozontal();
            }
        }

        else if (option != RecallLayout.LinearHoroznontal)
        {
            Is_LinHoroz = false;
        }

        //CustomDiagonal1
        if (option == RecallLayout.CustomDiagonal1)
        {
            Is_CusDiag1 = true;
            if (Is_CusDiag1 == true)
            {
                Recall_Layout_CustomDiag1();
            }
        }
        else if (option != RecallLayout.CustomDiagonal1)
        { 
            Is_CusDiag1 = false;
        }

        //CustomDiagonal2
        if (option == RecallLayout.CustomDiagonal2)
        {
            Is_CusDiag2 = true;

            if (Is_CusDiag2 == true)
            {
                Recall_Layout_CustomDiag2();
            }
        }
        else if (option != RecallLayout.CustomDiagonal2)
            { Is_CusDiag2 = false; }


    }

    public void OnTriggerEnter2D(Collider2D collider)
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


        RecallStart.localPosition = new Vector3(18.74814f, 9.504487f, Z);
        RecallP1.localPosition = new Vector3(22.49776f , -1.900897f ,Z);
      

    }


    public void Recall_Layout_LinearVerticle()
    {
        RecallStart.localPosition = new Vector3(-9.7f, 8.08f, Z);
        RecallP1.localPosition = new Vector3(8.4f, 16.23f, Z);
    
    }

    public void Recall_Layout_LinearHorozontal()
    {
        RecallStart.localPosition = new Vector3(16.1f, -4.3f, Z);
        RecallP1.localPosition = new Vector3(39.6f, 1.8f, Z);

    }
    public void Recall_Layout_CustomDiag1()
    {
        RecallStart.localPosition = new Vector3(-13.5f, -5.05f, Z);
        RecallP1.localPosition = new Vector3(-19.8f, -17.7f, Z);
      
    }

    public void Recall_Layout_CustomDiag2()
    {
        RecallStart.localPosition = new Vector3(17f, -1.5f, Z);
        RecallP1.localPosition = new Vector3(25.1f, -16f, Z);
    }
    public void Recall_Unset()
    {
        RecallStart.localPosition = new Vector3(X, Y, Z);
        RecallP1.localPosition = new Vector3(X, Y, Z);
    }


}
