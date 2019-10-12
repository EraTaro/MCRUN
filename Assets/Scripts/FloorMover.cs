using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMover : MonoBehaviour
{
    [SerializeField] float speed =10.0f ;
    private float initPositionZ = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initPositionZ = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.GetComponent<FloorController>().getState().Equals(FloorController.State.IDLE))
        {
            return;
        }

        Debug.Log("world position is " + transform.position);
        Debug.Log("local position is " + transform.localPosition);
        float speed = transform.root.gameObject.GetComponent<FloorController>().getSpeed();
        this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);

        if (transform.localPosition.z < initPositionZ - GetComponent<Renderer>().bounds.size.z * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
