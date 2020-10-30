using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        //print(" The update method has been called");

        Move();
    }
    // Move is a User-Defined method and it will be used to control the player ships movment
    void Move()
    {
        /* Format for calling a method is:
         * Namespace/project.Class.MethodName()
         */

        //GetAxis returns a -ve or +ve value depending on which button on the keyboard the user presses
        var deltaX = Input.GetAxis("Horizontal");

        /* To access properties for THIS object the format is:
         * component.Name.properyName
         * 
         * To access properties for another object the format is:
         * object.component.propertyName 
         */

        //The current x popsition (for the player is changed) with the slight change of deltaX EVERY frame
        var newXpos = transform.position.x + deltaX;

        
        transform.position = new Vector3(newXpos, transform.position.y, transform.position.z);



    }
}
