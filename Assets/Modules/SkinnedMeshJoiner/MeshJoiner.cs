using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public class MeshJoiner : MonoBehaviour
{
    public GameObject meshSource;
    public SkinnedMeshRenderer otherSkinnedRenderer;
    public float weight = 3.0f;

#if UNITY_EDITOR
    int getBoneIndex(SkinnedMeshRenderer skinnedRenderer, GameObject obj)
    {
        
        //Debug.Log("Object: " + obj.name);
            
        Transform parent = obj.transform.parent;
        do
        {
            //Debug.Log("Parent: " + parent.gameObject.name);
            int index = 0;
            foreach (var bone in skinnedRenderer.bones)
            {
                //Debug.Log("Bone: " + bone.gameObject.name);
                if (parent.GetInstanceID() == bone.GetInstanceID())
                    return index;
                index++;
            }
            parent = parent.parent;
        } while (parent != null);
            
        return 0;
    }

    BoneWeight[] generateWeights(Mesh mesh, int boneIndex, float weight)
    {
        var weights = new BoneWeight[mesh.vertexCount];
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i].boneIndex0 = boneIndex;
            weights[i].weight0 = weight;
            weights[i].boneIndex1 = boneIndex;
            weights[i].weight1 = weight;
            weights[i].boneIndex2 = boneIndex;
            weights[i].weight2 = weight;
            weights[i].boneIndex3 = boneIndex;
            weights[i].weight3 = weight;
        }
        return weights;
    }

    void printWeights(Mesh mesh)
    {
        string str = "";
        foreach (var weight in mesh.boneWeights)
        {
            str += " " + weight.boneIndex0 + ":" + weight.weight0 + " ";
        }
        Debug.Log(str);
    }

    void printMatrices(Matrix4x4[] matrices)
    {
        string str = "";
        foreach (var matrix in matrices)
        {
            str += " " + matrix.ToString();
        }
        Debug.Log(str);
    }

    [ContextMenu("Join")]
    void join()
    {
        if (!meshSource)
            return;
        MeshFilter[] meshFilters = meshSource.GetComponentsInChildren<MeshFilter>();
        var combineList = new List<CombineInstance>();

        var skinnedRenderer = meshSource.GetComponentInChildren<SkinnedMeshRenderer>();

        printMatrices(skinnedRenderer.sharedMesh.bindposes);

        {
            var combination = new CombineInstance();
            combination.mesh = skinnedRenderer.sharedMesh;
            combination.transform = Matrix4x4.identity;
            combineList.Add(combination);
        }

        for (int i = 0; i < meshFilters.Length; ++i)
        {
            var meshFilter = meshFilters[i];
            var obj = meshFilter.gameObject;
            Debug.Log("Object: " + obj.name);
            if (meshFilter.sharedMesh == null)
                continue;
            var currentMesh = Instantiate(meshFilters[i].sharedMesh);

            var combination = new CombineInstance();

            combination.mesh = currentMesh;
            int boneIndex = getBoneIndex(skinnedRenderer, obj);
            Debug.Log("Bone index: " + boneIndex);
            currentMesh.boneWeights = generateWeights(currentMesh, boneIndex, weight);

            var curTransform = meshFilters[i].transform;
            combination.transform = skinnedRenderer.transform.worldToLocalMatrix * curTransform.localToWorldMatrix;


            combineList.Add(combination);
        }

        var mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.CombineMeshes(combineList.ToArray());

        mesh.bindposes = skinnedRenderer.sharedMesh.bindposes;

        printMatrices(mesh.bindposes);

        Debug.Log(mesh.bindposes);

        int vertexIndex = 0;
        var weights = new List<BoneWeight> ();
        foreach (var combined in combineList)
        {
            foreach (var weight in combined.mesh.boneWeights)
            {
                weights.Add(weight);
                vertexIndex++;
            }
        }
        mesh.boneWeights = weights.ToArray();

        otherSkinnedRenderer.sharedMesh = mesh;

        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Test.obj"))
        //{
        //    sw.Write(MeshToString(mesh, skinnedRenderer.materials, "Test"));
        //}


        AssetDatabase.CreateAsset(mesh, "Assets/" + meshSource.name + ".mesh");
        AssetDatabase.Refresh();
    }

    public static string MeshToString(Mesh mesh, Material[] mats, string name)
    {
        Mesh m = mesh;

        var sb = new System.Text.StringBuilder();

        sb.Append("g ").Append(name).Append("\n");
        foreach (Vector3 v in m.vertices)
        {
            sb.Append(string.Format("v {0} {1} {2}\n", v.x, v.y, v.z));
        }
        sb.Append("\n");
        foreach (Vector3 v in m.normals)
        {
            sb.Append(string.Format("vn {0} {1} {2}\n", v.x, v.y, v.z));
        }
        sb.Append("\n");
        foreach (Vector3 v in m.uv)
        {
            sb.Append(string.Format("vt {0} {1}\n", v.x, v.y));
        }
        for (int material = 0; material < m.subMeshCount; material++)
        {
            sb.Append("\n");
            sb.Append("usemtl ").Append(mats[material].name).Append("\n");
            sb.Append("usemap ").Append(mats[material].name).Append("\n");

            int[] triangles = m.GetTriangles(material);
            for (int i = 0; i < triangles.Length; i += 3)
            {
                sb.Append(string.Format("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}\n",
                    triangles[i] + 1, triangles[i + 1] + 1, triangles[i + 2] + 1));
            }
        }
        return sb.ToString();
    }


    private void Update()
    {

    }
#endif
}
