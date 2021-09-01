using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public Camera cam;
    public PlayerStats ps;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.MovePosition(rb.position);
        speed = ps.MoveSpeed;
        //PutColliders();
        movement.x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //movement.y = Input.GetAxisRaw("Vertical");
        movement.x = -6;
        movement.y = cam.ScreenToWorldPoint(Input.mousePosition).y;
    }
    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.position = Vector2.MoveTowards(rb.position, movement, speed * Time.fixedDeltaTime);
    }
   /* private void PutColliders()
    {
        GameObject left = new GameObject("LeftCollider", typeof(BoxCollider2D));
        GameObject right = new GameObject("RightCollider", typeof(BoxCollider2D));
        GameObject top = new GameObject("TopCollider", typeof(BoxCollider2D));
        GameObject bottom = new GameObject("BottomCollider", typeof(BoxCollider2D));

        left.transform.SetParent(transform);
        right.transform.SetParent(transform);
        top.transform.SetParent(transform);
        bottom.transform.SetParent(transform);

        Vector2 leftBottomCorner = cam.ViewportToWorldPoint(Vector3.zero);
        Vector2 rightTopCorner = cam.ViewportToWorldPoint(Vector3.one);

        Debug.LogWarning(leftBottomCorner);
        Debug.Log(rightTopCorner);

        left.transform.position = new Vector2(
            leftBottomCorner.x - 0.5f,
            cam.transform.position.y
            );
        right.transform.position = new Vector2(
            rightTopCorner.x + 0.5f,
            cam.transform.position.y
            );
        top.transform.position = new Vector2(
            cam.transform.position.x,
            rightTopCorner.y + 0.5f
            );
        bottom.transform.position = new Vector2(
            cam.transform.position.x,
            leftBottomCorner.y - 0.5f
            );

        left.transform.localScale = new Vector3(1, Mathf.Abs(rightTopCorner.y - leftBottomCorner.y));
        right.transform.localScale = new Vector3(1, Mathf.Abs(rightTopCorner.y - leftBottomCorner.y));
        top.transform.localScale = new Vector3(Mathf.Abs(rightTopCorner.x - leftBottomCorner.x), 1);
        bottom.transform.localScale = new Vector3(Mathf.Abs(rightTopCorner.x - leftBottomCorner.x), 1);
    }*/
}
