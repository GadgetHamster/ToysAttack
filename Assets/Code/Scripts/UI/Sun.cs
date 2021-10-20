using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
  public float DayNightSpeed = 10f;
  public float LightIntensity = 1f;
  Light myLight;


    // Start is called before the first frame update
    void Start()
    {
      myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
      if (this.transform.position.y > 0f){
      myLight.intensity = LightIntensity;
      transform.RotateAround(Vector3.zero, Vector3.right,  DayNightSpeed * Time.deltaTime);
      transform.LookAt(Vector3.zero);
    }
    else{
       myLight.intensity = 0f;
       transform.RotateAround(Vector3.zero, Vector3.right,  DayNightSpeed * Time.deltaTime);
       transform.LookAt(Vector3.zero);
    }

    }
}
