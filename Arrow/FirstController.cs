using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {
    private  State state;
    public float power;
    private bool arrowState;
    private float time;
    private GameObject obj;
    public int goal;

    private void Awake()
    {
        SSDirector director = SSDirector.getInstance();
        director.setFPS(60);
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
    }

    public void addGoal(int num)
    {
        goal += num;
    }

    public void LoadResources()
    {
        GameObject ring5 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ring5"));
        GameObject ring4 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ring4"));
        GameObject ring3 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ring3"));
        GameObject ring2 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ring2"));
        GameObject ring1 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ring1"));
        GameObject wall = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/wall"));
        ring5.name = "ring5";
        ring4.name = "ring4";
        ring3.name = "ring3";
        ring2.name = "ring2";
        ring1.name = "ring1";
        wall.name = "wall";
        Debug.Log("Load resources success\n");
    }

    // Use this for initialization
    void Start () {
        state = State.START;
        time = 0F;
        arrowState = true;
        power = 0;
        goal = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (arrowState == false)
        {
            time += 1;
            if (time % 200 == 0)
            {
                time = 0;
                arrowState = true;
                GameObject.Destroy(obj);
                power = 0;
            }
        } else
        {
            Hit();
        }
	}

    public int getGoal()
    {
        return goal;
    }

    public bool getArrow()
    {
        return arrowState;
    }

    public float getPower()
    {
        return power;
    }

    public void Hit()
    {
        float speed = 1;
        if (arrowState)
        {
            if (Input.GetMouseButtonDown(0))
            {
                obj = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/attack"));
                obj.transform.position = new Vector3(0, 1, -9.5F);
                obj.name = "attack";
            }

            if (Input.GetKey(KeyCode.A))
            {
                obj.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                obj.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                obj.transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.W))
            {
                obj.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.J))
            {
                power = (power + 2) % 200;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                obj.GetComponent<Rigidbody>().isKinematic = false;
                obj.GetComponent<Rigidbody>().AddForce(Vector3.forward * power);
            } 

            if (Input.GetKeyUp(KeyCode.Space))
            {
                arrowState = false;
            }
        }

    }

    public void Destroy()
    {
        
    }
    public void Pause()
    {
        
    }

    public void Resume()
    {

    }

    public void GameOver()
    {

    }
}
