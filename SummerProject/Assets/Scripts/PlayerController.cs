using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBullet))]
public class PlayerController : MonoBehaviour {

    private PlayerBullet bulletScript;

    /*   Vector3 forwardForce = new Vector3(0, 0, 1);

       Vector3 sidewayForce = new Vector3(1,0,0);

       private void FixedUpdate()
       {

           if (Input.GetKey("d"))
           {
               transform.position += sidewayForce * Time.deltaTime;
           }
           if (Input.GetKey("a"))
           {
               transform.position += -sidewayForce * Time.deltaTime;
           }
           if (Input.GetKey("w"))
           {
               transform.position += forwardForce * Time.deltaTime;
           }
           if (Input.GetKey("s"))
           {
               transform.position += -forwardForce * Time.deltaTime;
           }
       }
    */
    void Start()
    {
        bulletScript = GetComponent<PlayerBullet>();  
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletScript.Shoot();
        }
    }

}
