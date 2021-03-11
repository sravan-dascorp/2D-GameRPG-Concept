using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transportation : MonoBehaviour
{
    // Start is called before the first frame update
    public enum VechicleType {car,boat,horse,railkart, }
    public VechicleType vechicletype;
    public bool createpositiongameobjects;
    public Transform starting_position;
    public Transform ending_position;
    public Transform landing_position;
    public float speed;

    public bool  use_animator;
    Animator animator;
   
    //check this if you want the vechicle to start it movement from the current position its placed,.
    [SerializeField] private bool start_from_current_position;

    public Transform Player;
    public Transform Vechicle;


    private bool finishedmove;
    private bool finshedlanding;

    public bool movement_execute;
    public Booltrigger Booltriggerscript;

    public Transform saddle;
   // private void Start()
   // {
   //  if (createpositiongameobjects)
     //   {
     //       GameObject starting_positiongameobject = new GameObject("starting_position");
     //       GameObject ending_positiongameobject = new GameObject("ending_position");
    //        starting_positiongameobject.transform.SetParent(this.gameObject.transform);
    //        ending_positiongameobject.transform.SetParent(this.gameObject.transform);
    //
    //        starting_position = starting_positiongameobject.transform;
    //        ending_position = ending_positiongameobject.transform;
    //    }
   // }
    //[ExecuteInEditMode]
    private void Update()
    {
        bool tembbool = Booltriggerscript.execute;

        /*if (createpositiongameobjects)
        {
            GameObject starting_positiongameobject = new GameObject("starting_position");
            GameObject ending_positiongameobject = new GameObject("ending_position");

            starting_position = starting_positiongameobject.transform;
            ending_position = ending_positiongameobject.transform;
        }*/
        if ( tembbool)
        {
            move_Vechicle();
        }
        
    }


    void  move_Vechicle()
    {
        if (!finishedmove)
        {
            if (use_animator)
            {
                Vechicle.GetComponent<Animator>().enabled = true;
            }
            Player.transform.GetComponent<SpriteRenderer>().enabled = true;
            Player.position = Vechicle.position;
            if(vechicletype == VechicleType.horse) Player.position = saddle.position;

            Player.transform.SetParent(Vechicle);
            if (!start_from_current_position)
            {
                Vechicle.position = starting_position.position;
            }
            Vechicle.position = Vector2.MoveTowards(Vechicle.position, ending_position.position, speed * Time.deltaTime);
            if (Vechicle.position == ending_position.position) { finishedmove = true; }
            
        }

        if (finishedmove)
        {
            Vechicle.GetComponent<Animator>().enabled = false;
            Invoke("exitVechicle",1.5f);
        }
        
        
            


    }



    void exitVechicle()
    {
        if (!finshedlanding)
        {
            Player.transform.parent = null;
            Player.position = landing_position.position;
            Player.transform.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.SetActive(false);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
           
        
    }


}
