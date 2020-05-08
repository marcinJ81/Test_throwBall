using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Euler : MonoBehaviour
{
    private Vector3 startPosition;
    protected float Animation;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Animation += Time.deltaTime;
        Animation = Animation % 5f;
        if(Input.GetKey(KeyCode.A))
        this.transform.Translate(SEuler.Parabola(Vector3.zero, new Vector3(0, 0, 1) * 10f, 5f, Animation));
    }
}
