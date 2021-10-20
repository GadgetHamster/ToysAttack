using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour {

  public enum DrawMode {noiseMap, colorMap, mesh};
  public DrawMode drawMode;

  public int mapWidth;
  public int mapHeight;
  public float noiseScale;

  public int octaves;
  [Range(0,1)]
  public float persistance;
  public float lacunarity;

  public int seed;
  public Vector2 offset;

  public float meshHeightMultiplier;
  public AnimationCurve meshHeightCurve;

  public bool autoUpdate;

  public terrainType[] regions;

  public void GenerateMap() {
    float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

    Color[] colorMap = new Color[mapWidth * mapHeight];
    for (int y = 0; y < mapHeight; y++){
      for(int x = 0; x < mapWidth; x++){
        float currentHeight = noiseMap [x, y];
        for(int i = 0; i < regions.Length; i++){
          if (currentHeight <= regions[i].height){
            colorMap [y * mapWidth + x] = regions [i].Color;
             break;
          }
        }
      }
    }
    mapDisplay display = FindObjectOfType<mapDisplay> ();
    if(drawMode == DrawMode.noiseMap){
      display.DrawTexture (textureGenerator.textureFromHeightMap(noiseMap));
    } else if(drawMode == DrawMode.colorMap){
      display.DrawTexture (textureGenerator.textureFromColorMap(colorMap, mapWidth, mapHeight));
    } else if(drawMode == DrawMode.mesh){
      display.drawMesh(meshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve), textureGenerator.textureFromColorMap(colorMap, mapWidth, mapHeight));
    }
  }
  void OnValidate() {
    if (mapWidth < 1) {
      mapWidth = 1;
    }
    if (mapHeight < 1) {
      mapHeight = 1;
    }
    if (lacunarity < 1) {
      lacunarity = 1;
    }
    if (octaves < 0) {
      mapHeight = 0;
    }
  }
}
[System.Serializable]
public struct terrainType {
  public string name;
  public float height;
  public Color Color;

}
