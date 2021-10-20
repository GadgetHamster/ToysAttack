using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
  public Material skyboxMat;

  public float DayNightSpeed = 10f;
  public float SunLightIntensity = 1f;
  public float MoonLightIntensity = 1f;
  Light Sun;
  Light Moon;
//  HorizonWithSunSkyboxInspector sunController;
    // Start is called before the first frame update
    void Start()
    {
      skyboxMat = RenderSettings.skybox;
    }

    // Update is called once per frame
    void Update()
    {
      var raz = skyboxMat.GetFloat("_SunAzimuth") * Mathf.Deg2Rad;
      skyboxMat.SetFloat("_SunAltitude", Time.time * 10f % 360);
      var ral = skyboxMat.GetFloat("_SunAltitude") * Mathf.Deg2Rad;


      var upVector = new Vector4 (
        Mathf.Cos (ral) * Mathf.Sin (raz),
        Mathf.Sin (ral),
        Mathf.Cos (ral) * Mathf.Cos (raz),
        0.0f
      );

      skyboxMat.SetVector("_SunVector", upVector);
      RenderSettings.skybox = skyboxMat;


    }
}
