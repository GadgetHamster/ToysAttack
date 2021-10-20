using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour {
  public float randomness;
  public float randomnessTest;

  Mesh mesh;

  Vector3[] vertices;
  int[] triangles;

  public int xSize = 20;
  public int zSize = 20;

  void Start () {
    randomness = Random.Range(0f, 1500f);
    randomnessTest = Random.Range(0f, 100f);

    mesh = new Mesh();
    GetComponent<MeshFilter>().mesh = mesh;

    CreateShape();
    UpdateMesh();
    GetComponent<MeshCollider>().sharedMesh = mesh;
  }

  void CreateShape()
  {
    vertices = new Vector3[(xSize + 1) * (zSize + 1)];

    for (int i = 0, z = 0; z <= zSize; z++)
    {
      for (int x = 0; x <= xSize; x++)
      {
        float y = Mathf.PerlinNoise(x * 3f + randomness, z  * 3f + randomness) * 3f;
        vertices[i] = new Vector3(x - xSize/2, y, z - zSize/2);
        i++;
      }
    }

    triangles = new int[xSize * zSize * 6];

    int vert = 0;
    int tris = 0;
    for(int z = 0; z < zSize; z++)
    {
      for (int x = 0; x < xSize; x++)
      {
        triangles[tris + 0] = vert + 0;
        triangles[tris + 1] = vert + xSize + 1;
        triangles[tris + 2] = vert + 1;
        triangles[tris + 3] = vert + 1;
        triangles[tris + 4] = vert + xSize + 1;
        triangles[tris + 5] = vert + xSize + 2;

        vert++;
        tris += 6;
      }
      vert++;
    }
  }

  void UpdateMesh()
  {
    mesh.Clear();
    mesh.vertices = vertices;
    mesh.triangles = triangles;
    mesh.RecalculateNormals();
  }

  private void OnDrawGizmos()
  {
    if (vertices == null)
      return;
    for (int i = 0; i < vertices.Length; i++)
    {
      Gizmos.DrawSphere(vertices[i], .1f);
    }
  }
}
