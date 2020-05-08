using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1Scirpt : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPosition;
    private Vector3 endPosition = new Vector3(20,0,0);
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
        if (Input.GetKey(KeyCode.A))
            this.transform.position = Assets.SEuler.Parabola(Vector3.zero,Vector3.forward * 10f, 5f, Animation/5f);

    }
}
