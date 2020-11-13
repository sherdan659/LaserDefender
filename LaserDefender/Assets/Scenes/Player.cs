using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float laserSpeed = 20f;
    [SerializeField] float laserDelay = 0.3f;

    [SerializeField] GameObject laserPrefab;

    Coroutine fireCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    /* In Unity there are two types of methods; built-in and user Defind
     * Built-in: there methods have their names already set up by unity compiler will know
     * when the call the method during game exceution. thus, we just need to provide the method defintion.
     * It is important to use the exact name for the built-in method defintion (proper spelling
     * + proper casting)
     * 
     * User Defined: These methods are inverted by the developer for proper organisation of code.
     */



    // Start is called before the first frame update
    void Start()
    {
        // print("The start method has been called.");  //method call
        SetUpMoveBoundaries();

        StartCoroutine(PrintAndWait());

    }

    // Update is called once per frame
    void Update()
    {
        //print(" The update method has been called");

        Move();
        Fire();
    }
    // Move is a User-Defined method and it will be used to control the player ships movment
    void Move()
    {
        /* Format for calling a method is:
         * Namespace/project.Class.MethodName()
         */

        //GetAxis returns a -ve or +ve value depending on which button on the keyboard the user presses
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        /* To access properties for THIS object the format is:
         * component.Name.properyName
         * 
         * To access properties for another object the format is:
         * object.component.propertyName 
         */

        //The current x popsition (for the player is changed) with the slight change of deltaX EVERY frame
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector3(newXpos, newYpos,  transform.position.z);

    }

    void SetUpMoveBoundaries()
    {
        float padding = 0.5f;


        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y + padding;
    }
    void Fire()
    {

        if (Input.GetButtonDown("Fire1"))// if(Input.GetButtonDown("Fire1") == true)
        {
           fireCoroutine = StartCoroutine(FireContinously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator PrintAndWait()
    {
        print("Message 1 sent!");

        yield return new WaitForSeconds(3f);

        print("Message 2 sent");

    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject laserClone = Instantiate(laserPrefab, transform.position, Quaternion.identity);

            laserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            
            yield return new WaitForSeconds(laserDelay);
        }
    }

}
