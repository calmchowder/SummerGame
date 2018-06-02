using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerBullet))]
public class PlayerController : MonoBehaviour {

    public float movementSpeed = 3.0f;
    private PlayerBullet bulletScript;
    private Player player;
    private Plane plane;
    private Ray ray;
    private Dash dash;


    void Start()
    {
        dash = GetComponent<Dash>();
        player = GetComponent<Player>();
        bulletScript = GetComponent<PlayerBullet>();
        plane = new Plane(Vector3.up, Vector3.zero);
    }

    void Update()
    {

        //rotate player around mouse 
        float distance;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

        //Player Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float x = transform.position.x + moveHorizontal * movementSpeed * Time.deltaTime;
        float z = transform.position.z + moveVertical * movementSpeed * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, z);


        //Player actions 
        if (Input.GetMouseButtonDown(0) && bulletScript.CanStartAbility()) 
        {
            bulletScript.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dash.CanStartAbility())
        {
            dash.StartAbility();
        }
        if(dash.abilityOn) dash.UpdateMovement();
    }
}
