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
        speed = 5.8f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x<=-3){
            speed*=-1;
            transform.position = new Vector3(-2.99f, -2.2f, 0 );
        }
        if(transform.position.x>=3){
            speed*=-1;
            transform.position = new Vector3(2.99f, -2.2f, 0 );
        }
        transform.Translate(new Vector3(speed*Time.deltaTime, 0, 0 ));
    }
}
