using Unity.Burst.Intrinsics;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UIElements;

public class slideranimation : MonoBehaviour
{
    public bool moving;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // moving=true; 
        // if(moving) {
        //     moving=false;
        //     for(int i=0; i<100; i++){
        //         transform.Translate(new Vector3(1f*Time.deltaTime, 0, 0 ));
        //     }
        //     for(int i=0; i<100; i++){
        //         transform.Translate(new Vector3(-1f*Time.deltaTime, 0, 0 ));
        //     }
        // }
        speed = 0.005f*100*Time.deltaTime;
        transform.position = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.y<=-5){
            speed*=-1;
            transform.localPosition = new Vector3(0f, -4.99f, 0 );
        }
        if(transform.localPosition.y>=5){
            speed*=-1;
            transform.localPosition = new Vector3(0f, 4.99f, 0 );
        }
        transform.Translate(new Vector3(speed, 0, 0 ));
    }
}
