using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bars : MonoBehaviour
{


    public Image Green;
    public Image Orange;

    int mEnergy; 
    int mHealth;
    float timesincelastupdate;
    float timebetweenupdate = 2f;

    public int Health
    {
        set
        {
            mHealth = Mathf.Clamp(value, 0, 100); //Make sure Health does not go out of range
            Green.rectTransform.localScale = new Vector2(1f, mHealth / 100.0f); //Scale top bar to reveal bottom one
        }
        get
        {
            return mHealth;
        }
    }


    public int Energy
    {
        set
        {
            mEnergy = Mathf.Clamp(value, 0, 100); //Make sure Health does not go out of range
            Orange.rectTransform.localScale = new Vector2(1f, mEnergy / 100.0f); //Scale top bar to reveal bottom one
        }
        get
        {
            return mEnergy;
        }
    }

    public void Start()
    {
        Health = 100; // change this to a very low number to test the gameover menu is working
        Energy = 100; //change this to a very low number to test the gameover menu is working

        if (Debug.isDebugBuild)
        { //Only do this for debug
            CheckIDELinks();  //Make sure all the stuff which is needed is linked
            
        }
    }

    public void Update()
    {

        // timer that reduces the health and energy
        timesincelastupdate += Time.deltaTime; // adding a second to timer
        if (timesincelastupdate > timebetweenupdate) // if timesincelastupdate is greater than timebetweenupdate do the following line of code
        {
          //Debug.Log("Trying to Reduce Health & Energy");
            Health -= 5; // keep reducing the healthbar
            Energy -= 5; // keep reducing the energybar

            timesincelastupdate = 0;


        }
        GameOver();

    }
    public void GameOver() {

        if (Health <= 0 && Energy <= 0) // if both Health and Energy are 0 0r less load GameOver
        {

            SceneManager.LoadScene("GameOver");
        }

        else {
            if (Health <= 0 || Energy <= 0) { // if either one of the bars are empty load GameOver
                SceneManager.LoadScene("GameOver");
            }
        }
    } 

     
    

    void CheckIDELinks()
    {
        Debug.Assert(Green != null, "Please link Green Bar");
    }
    
}








