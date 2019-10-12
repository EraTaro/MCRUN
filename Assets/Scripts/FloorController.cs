using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public enum State
    {
        IDLE,
        MOVE
    }

    private GameObject obj;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private State state = State.IDLE;

    // Start is called before the first frame update
    void Start()
    {
        obj = Instantiate((GameObject)Resources.Load("Floor"), new Vector3(transform.position.x, transform.position.y, transform.position.z - ((GameObject)Resources.Load("Floor")).GetComponent<Renderer>().bounds.extents.z), Quaternion.identity);
        obj.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.transform.position.z <= transform.position.z - obj.GetComponent<Renderer>().bounds.extents.z)
        {
            obj = Instantiate((GameObject)Resources.Load("Floor"), new Vector3(transform.position.x, transform.position.y, obj.transform.position.z + obj.GetComponent<Renderer>().bounds.size.z - speed * Time.deltaTime), Quaternion.identity);
            obj.transform.parent = transform;
        }
    }

    public float getSpeed()
    {
        return speed;
    }

    public State getState()
    {
        return state;
    }
}
