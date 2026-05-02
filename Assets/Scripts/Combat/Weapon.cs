#if UNITY_EDITOR
using UnityEditor.Experimental.GraphView;
#endif
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Weapon: MonoBehaviour
{
    Rigidbody2D rb;








    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //registering position of mouse click on screen
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 direction = mousePos - transform.position;
            transform.right = direction;
        }
    }



}
