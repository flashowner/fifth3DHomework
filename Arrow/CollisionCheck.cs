using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour {
    public ISceneController currentSceneController;

    // Use this for initialization
    void Start () {
        SSDirector director = SSDirector.getInstance();
        currentSceneController = director.currentSceneController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        
        if (collision.gameObject.name == "ring5")
        {
            currentSceneController.addGoal(5);
        } else if (collision.gameObject.name == "ring4")
        {
            currentSceneController.addGoal(4);
        } else if (collision.gameObject.name == "ring3")
        {
            currentSceneController.addGoal(3);
        } else if (collision.gameObject.name == "ring2")
        {
            currentSceneController.addGoal(2);
        } else if (collision.gameObject.name == "ring1")
        {
            currentSceneController.addGoal(1);
        }
    }
}
