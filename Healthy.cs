using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthy : MonoBehaviour // this script is only for healthy food
{
    
    

    private GameObject player;
    private Bars bars;
    private Vector2 rotate = new Vector2(0f, 1f); // rotate the object 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // the game object variable called player find the game tag called player the game object needs to be called Player
        bars = player.GetComponent<Bars>(); // getting access to the Bars script
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotate); // rotate whatever object this script is attached to using the value that is assigned on the global variable
    }
    private void OnTriggerEnter2D(Collider2D collision) // a collision detector function
    {
        if (collision.gameObject.CompareTag("Player")) // if whatever collided with this object has the tag player do the following things
        {
            
         
            
            reducingEnergy();
            addingHealth();
            Destroy(gameObject);// destory the game object this script is attached to
        }
    }


    public void reducingEnergy()
    {
        // Random.Range will contain a float number of 0 to 10 and it will be converted to int from float and stored in change because the values of the Health is a int(Bars class)
        int change = Mathf.RoundToInt(Random.Range(0.0f, 10.0f)); 
       Debug.Log("Energy bar before: " + bars.Energy);// testing the value before it changes and prints to console
        Debug.Log("Changing bar energy by " + change); //testing the value after it changes and prints to console
        bars.Energy -= change;// whatever the value on change - from energy
        Debug.Log("Energy after: " + bars.Energy);

    }

    public void addingHealth()
    {

        int change = Mathf.RoundToInt(Random.Range(0.0f, 10.0f));
        Debug.Log("Health bar before: " + bars.Health);
        Debug.Log("Changing bar health by " + change);
        bars.Health += change;
        Debug.Log("Health after: " + bars.Health);

    }

}
