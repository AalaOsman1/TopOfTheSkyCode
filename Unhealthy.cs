using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unhealthy : MonoBehaviour
{

    private GameObject player;
    private Bars bars; // a class variable type to access the bars and change them
    private Vector2 rotate = new Vector2(0f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // this is finding a GameObject called "Player"
        // the player variable is linked to the Player game object 
        bars = player.GetComponent<Bars>();// getting access to the bars script
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotate); //rotating whatever this script is attached to
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // trigger detection
    {
        if (collision.gameObject.CompareTag("Player"))// if whatever collides with whatever this script is attached to has the Player tag
        {
            // do the following things
           
            reducingHealth(); // this functions are called when the trigger happens 
            addingEnergy();
            Destroy(gameObject);// when the player touchess destory the object this script is attached to
        }
    }

    public void addingEnergy() {// if the player collides with the unhealthy food add energy

        int change = Mathf.RoundToInt(Random.Range(0.0f, 10.0f)); // change variable will hold a value of either 0 to 10.
        Debug.Log("Energy bar before: " + bars.Energy);// printing the value before the change happens to the console
        Debug.Log("Changing bar energy by " + change); // printing the amount been added
        bars.Energy += change;// here the value of Energy and add change to it
        Debug.Log("Energy after: " + bars.Energy); // printing the change

    }

    public void reducingHealth() // when the player touches with the unhealthy object reduce the health
    {

        int change = Mathf.RoundToInt(Random.Range(0.0f, 10.0f));
        Debug.Log("Health bar before: " + bars.Health);
        Debug.Log("Changing health by " + change);
        bars.Health -= change;
        Debug.Log("Health after: " + bars.Health);

    }
}
