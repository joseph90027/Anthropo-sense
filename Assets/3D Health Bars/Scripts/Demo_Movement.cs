using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_Movement : MonoBehaviour
{

    Vector3 movement;
    Vector3 aiming;
    Rigidbody rb;
    int floorMask;
    public float speed = 6f;


    public float nspeed;
    Vector3 lastPosition = Vector3.zero;

    public GameObject child;

    bool targeting;

    //Don't look to much into this script I made it a long time ago!

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
    }
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            targeting = !targeting;
        }
    }
    void FixedUpdate()
    {
        float rh2 = Input.GetAxisRaw("Horizontal");
        float rv2 = Input.GetAxisRaw("Vertical");


        KeyboardTurn(rh2, rv2);
        KeyboardMove(rh2, rv2);

        nspeed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        GetComponentInChildren<Animator>().SetFloat("Speed", nspeed);
    }

    void KeyboardMove(float rh2, float rv2)

    {
        // Set the movement vector based on the axis input.
        movement.Set(rh2, 0f, rv2);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        Vector3 playerToMouse = (transform.position + movement) - transform.position;

        if (!targeting && playerToMouse != Vector3.zero)
        {
            // Cursor.visible = false;
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(Quaternion.Lerp(transform.rotation, newRotatation, Time.deltaTime * 15f));
        }


        if (movement.magnitude > .05f)
        {
            //moving = true;
        }

        if (movement.magnitude == 0)
        {
            //moving = false;
        }
    }

    void KeyboardTurn(float rh2, float rv2)
    {


        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;


        if (Physics.Raycast(camRay, out floorHit, Mathf.Infinity, floorMask))
        {

            Vector3 playerToMouse = floorHit.point - transform.position;
            //    if (playerToMouse.magnitude > 2 )
            //   {
            if (targeting)
            {
                //  Cursor.visible = true;
                child.transform.LookAt(floorHit.point);
            }

            //   }

            if (playerToMouse.magnitude < 2 && playerToMouse != Vector3.zero)
            {


            }


            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            //  Vector3 playerToMouse = floorHit.point - transform.position;
            if (playerToMouse.magnitude > 2)
            {

            }
            if (playerToMouse.magnitude < 2)
            {

            }


        }

    }

    IEnumerator Rolling()
    {

        //  isRolling = true;
        //  playerRigidbody.useGravity = false;
        yield return new WaitForSeconds(.18f);
        //   isRolling = false;
        yield return new WaitForSeconds(.2f);
        //  playerRigidbody.useGravity = true;
    }
}
