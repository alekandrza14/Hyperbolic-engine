using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created based on this post/comments by 907games here https://www.reddit.com/r/Unity3D/comments/f18rfu/skinned_mesh_collider_first_implementation_still/

public class SkinnedMeshCollider : MonoBehaviour
{
    public Transform Target;
    public float TargetDistanceThreshold;
    public bool Activate;
    public SkinnedMeshRenderer SourceSkinnedMeshRenderer;
    Transform _transform;
    Transform _SourceMeshTransform;
    public SkinnedMeshRenderer OutputSkinnedMeshRenderer;
    public MeshCollider MeshCollider;
    Vector3[] OriginalVerts;
    List<Vector3> ActiveVerts = new List<Vector3>();
    List<int> triangleList = new List<int>();
    List<int> modifiedTriangleList = new List<int>();


    private void Awake()
    {
        _transform = transform;
        _SourceMeshTransform = SourceSkinnedMeshRenderer.transform;
        OriginalVerts = SourceSkinnedMeshRenderer.sharedMesh.vertices;
        triangleList = new List<int>(SourceSkinnedMeshRenderer.sharedMesh.triangles.Length);

    }

    private void LateUpdate()
    {
        if (Activate)
        {
            CreateBakedMeshForCollider();
        }
    }


    void CreateBakedMeshForCollider()
    {

        Mesh SourceMesh = new Mesh();
        SourceMesh.RecalculateBounds();
        SourceMesh.GetVertices(ActiveVerts);
        SourceMesh.GetTriangles(triangleList, 0);

        modifiedTriangleList.Clear();

        for (int index = 0; index < triangleList.Count; index += 3)
        {
            bool canAddTriangle = false;
            var Tri0 = triangleList[index];
            var Tri1 = triangleList[index + 1];
            var Tri2 = triangleList[index + 2];

            if (WithinRange(_SourceMeshTransform.TransformPoint(ActiveVerts[Tri0]), Target.position, TargetDistanceThreshold) == true)
            {
                canAddTriangle = true;
            }

            if (WithinRange(_SourceMeshTransform.TransformPoint(ActiveVerts[Tri1]), Target.position, TargetDistanceThreshold) == true)
            {
                  canAddTriangle = true;
            }

            if (WithinRange(_SourceMeshTransform.TransformPoint(ActiveVerts[Tri2]), Target.position, TargetDistanceThreshold) == true)
            {
                  canAddTriangle = true;
            }
            
            if(canAddTriangle)
            {
             modifiedTriangleList.Add(Tri0);
             modifiedTriangleList.Add(Tri1);
             modifiedTriangleList.Add(Tri2);
            }
           
        }


        Mesh NewMesh = new Mesh();
        NewMesh.Clear();
        NewMesh.SetVertices(ActiveVerts);
        NewMesh.SetTriangles(modifiedTriangleList, 0);
        OutputSkinnedMeshRenderer.sharedMesh = NewMesh;
        _transform.position = SourceSkinnedMeshRenderer.transform.position;
        _transform.rotation = SourceSkinnedMeshRenderer.transform.rotation;
        MeshCollider.sharedMesh = NewMesh;

    }

    bool WithinRange(Vector3 position1, Vector3 position2, float range)
    {
        var dist = range * range;

        float offset = SubtractToVector3(position1, position2).sqrMagnitude;

        if (offset <= dist)
        {
            return true;
        } else
        {
            return false;
        }
    }

    Vector3 SubtractToVector3(Vector3 v1, Vector3 v2)
    {
        Vector3 heading;
        heading.x = v1.x - v2.x;
        heading.y = v1.y - v2.y;
        heading.z = v1.z - v2.z;

        return heading;
    }


}

