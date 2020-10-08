using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomGameObjectWindow : EditorWindow
{

    //Public Variables
    public string sourceName;
    public GameObject sourceGameObject;
    public List<MeshRenderer> sourceMeshRendererList;
    public List<Material> sourceMaterialList;

    //Private Variables 
    private string tempName = "Please Name Me";
    private GameObject tempGameObject;
    private List<MeshRenderer> tempMeshRendererList;
    private Shader tempShader;
    private List<Material> tempMaterialList;

    private ushort index = 0;

    //Contructor 
    public void OnEnable()
    {
        sourceMeshRendererList = new List<MeshRenderer>();
        sourceMaterialList = new List<Material>();
       // tempGameObject = new GameObject();
        tempMeshRendererList = new List<MeshRenderer>();
        tempShader = Shader.Find("Standard");
        tempMaterialList = new List<Material>();
    }
    //Public Methods
    [MenuItem("CustomWindows/CustomGameObjectWindow")]
    public static void Init()
    {
        //var window = GetWindowWithRect<CustomGameObjectMenu>(new Rect(0, 0, 300, 200));
        var window = (CustomGameObjectWindow)EditorWindow.GetWindow(typeof(CustomGameObjectWindow));

        window.Show();
    }
    // Update is called once per frame
    public void OnGUI()
    {
        EditorGUILayout.BeginVertical();

        GetName();
        GetGameObject();
        GetMeshInfo();

        EditorGUILayout.EndVertical();
        OnButtonClick();
    }

    private void GetName()
    {
        sourceName = (string)EditorGUILayout.TextField("New GameObject Name", tempName);
        if (tempName != sourceName)
        {
            tempName = sourceName;
        }
    }

    private void GetGameObject()
    {
        sourceGameObject = (GameObject)EditorGUILayout.ObjectField("Source Prefab", tempGameObject, typeof(GameObject), false);
        if (tempGameObject != sourceGameObject)
        {
            tempMeshRendererList.Clear();
            tempMaterialList.Clear();
            tempGameObject = sourceGameObject;
            if (sourceGameObject.GetComponentsInChildren<MeshRenderer>() != null)
            {
                //refactor this
                foreach (var meshRenderer in sourceGameObject.GetComponentsInChildren<MeshRenderer>())
                {
                    tempMeshRendererList.Add(meshRenderer);
                    tempMaterialList.Add(meshRenderer.sharedMaterial);
                }
            }
            else if (sourceGameObject.GetComponent<MeshRenderer>() != null)
            {
                tempMeshRendererList.Add(sourceGameObject.GetComponent<MeshRenderer>());
                tempMaterialList.Add(sourceGameObject.GetComponent<Material>());
            }
            else
            {
                Debug.Log("No Mesh Renderer Found");
            }
        }
        else
        {
            tempGameObject = sourceGameObject;
        }
    }
    private void GetMeshInfo()
    {
        if (tempMeshRendererList.Count != 0)
        {
            index = 0;
            sourceMeshRendererList.Clear();
            foreach (var tempMeshRenderer in tempMeshRendererList)
            {
                sourceMeshRendererList.Add((MeshRenderer)EditorGUILayout.ObjectField($"Source MeshRenderer {index}", tempMeshRenderer, typeof(MeshRenderer), false));
                if (tempMeshRenderer != sourceMeshRendererList[index])
                {
                    tempMeshRendererList[index] = sourceMeshRendererList[index];
                    tempMaterialList[index] = sourceMeshRendererList[index].sharedMaterial;
                }
                index++;
            }
            //index = 0;
            sourceMaterialList.Clear();
            for (int i = 0; i < tempMaterialList.Count; i++)
            {
                sourceMaterialList.Add((Material)EditorGUILayout.ObjectField($"Source Material {i}", tempMaterialList[i], typeof(Material), false));
                if (tempMaterialList[i] != sourceMaterialList[i])
                {
                    tempMaterialList[i] = sourceMaterialList[i];
                }
                index++;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void OnButtonClick()
    {
        if (GUILayout.Button("Create Custom Game Object"))
        {
            index = 0;
            if (tempGameObject != null)
            {
                var newGameObject = GameObject.Instantiate<GameObject>(tempGameObject);

                if (newGameObject != null)
                {
                    if (tempName != null)
                    {
                        newGameObject.name = tempName;
                    }
                    if (tempMeshRendererList != null)
                    {
                        if (tempMaterialList == null && tempMeshRendererList[index].sharedMaterial != null)
                        {
                            if (newGameObject.GetComponentsInChildren<MeshRenderer>() != null)
                            {
                                foreach (var tempMeshRenderer in tempMeshRendererList)
                                {
                                    newGameObject.GetComponent<MeshRenderer>().sharedMaterial = tempMeshRenderer.sharedMaterial;
                                }
                            }
                            else if (newGameObject.GetComponent<MeshRenderer>() != null)
                            {
                                newGameObject.GetComponent<MeshRenderer>().sharedMaterial = tempMeshRendererList[index].sharedMaterial;
                            }
                            else
                            {
                                Debug.Log("Failed to set default materials");
                            }
                        }
                        else
                        {
                            if (newGameObject.GetComponentsInChildren<MeshRenderer>() != null)
                            {
                                foreach (var newGameObjectMaterial in newGameObject.GetComponentsInChildren<MeshRenderer>())
                                {
                                    newGameObjectMaterial.sharedMaterial = tempMaterialList[index];
                                    index++;
                                }
                            }
                            else if (newGameObject.GetComponent<MeshRenderer>() != null)
                            {
                                newGameObject.GetComponent<MeshRenderer>().sharedMaterial = tempMaterialList[index];
                            }
                            else
                            {
                                Debug.Log("Failed to set user defined materials");
                            }
                        }
                    }
                }
            }
            else
            {
                Debug.Log("tempgameObject is Null");
            }
            ClearEverything();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void ClearEverything()
    {
        sourceMeshRendererList = new List<MeshRenderer>();
        sourceMaterialList = new List<Material>();
        tempGameObject = new GameObject();
        tempMeshRendererList = new List<MeshRenderer>();
        tempMaterialList = new List<Material>();
        index = 0;
        DestroyImmediate(GameObject.Find("New Game Object"),true);
    }
}
