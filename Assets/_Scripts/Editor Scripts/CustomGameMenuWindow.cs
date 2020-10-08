using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;

public class CustomGameMenuWindow : EditorWindow
{
    //public variable
    public string sourceMenuName;
    //public string sourceMenuTitle;
    //public Sprite sourceBackgroundImage;
    //public byte sourceAmountOfMenuButtons;
    //public List<string> sourceMenuButtons;
    //public List<Sprite> sourceButtonSprites;

    //private variables
    private string tempMenuName = "Please Name The Menu";
    //private string tempMenuTitle = "Please Give the Menu a Title";
    //public static Sprite tempBackgroundImage;
    //private byte tempAmountOfMenuButtons = new byte();
    //public List<string> tempMenuButtons = new List<string>();
    //public static Sprite tempMenuButtonSprite;
    //public List<Sprite> tempButtonSprites= new List<Sprite>();

    //contructor 
    public static void OnEnabled()
    {
        //tempBackgroundImage = AssetDatabase.LoadAssetAtPath<Sprite>("unity_bulitin_extra/Background");
        //tempMenuButtonSprite = Resources.Load("UISprite") as Sprite;
    }
    //public methods
    [MenuItem("CustomWindows/CustomGameMenuWindow")]
    public static void Init()
    {
        var window = (CustomGameMenuWindow)EditorWindow.GetWindow(typeof(CustomGameMenuWindow));

        window.Show();
        //OnEnabled();
    }

    // Update is called once per frame
    public void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        GetMenuName();
        //GetMenuTitle();
        //GetBackgroundImage();
        //GetAmountOfMenuButtons();
        //PopulateMenuButtons();
        //GetButtonSprite();
        EditorGUILayout.EndVertical();
        //OnButtonClick();
    }


    private void GetMenuName()
    {
        sourceMenuName = (string)EditorGUILayout.TextField("New Menu Name", tempMenuName);
        if (tempMenuName != sourceMenuName)
        {
            tempMenuName = sourceMenuName;
        }
    }
    //private void GetMenuTitle()
    //{
    //    sourceMenuTitle = (string)EditorGUILayout.TextField("New Menu Name", tempMenuTitle);
    //    if (tempMenuTitle != sourceMenuTitle)
    //    {
    //        tempMenuTitle = sourceMenuTitle;
    //    }
    //}

    //private void GetBackgroundImage()
    //{
    //    sourceBackgroundImage = (Sprite)EditorGUILayout.ObjectField("Background Sprite", tempBackgroundImage,typeof(Sprite),false);
    //    if (tempBackgroundImage != sourceBackgroundImage)
    //    {
    //        tempBackgroundImage = sourceBackgroundImage;
    //    }
    //}

    //private void GetAmountOfMenuButtons()
    //{
    //    sourceAmountOfMenuButtons = (byte)EditorGUILayout.IntField("New GameObject Name", tempAmountOfMenuButtons);
    //    if (tempAmountOfMenuButtons != sourceAmountOfMenuButtons)
    //    {
    //        tempAmountOfMenuButtons = sourceAmountOfMenuButtons;
    //        if (tempMenuButtons != null)
    //        {
    //            tempMenuButtons.Clear();
    //        }
    //        for (int i = 0; i < tempAmountOfMenuButtons; i++)
    //        {
    //            tempMenuButtons.Add(string.Format("Button " + i));
    //        }
    //        sourceMenuButtons = tempMenuButtons;
    //        if (tempButtonSprites != null)
    //        {
    //            tempMenuButtons.Clear();
    //        }
    //        for (int i = 0; i < tempAmountOfMenuButtons; i++)
    //        {
    //            tempButtonSprites.Add(tempMenuButtonSprite);
    //        }
    //        sourceButtonSprites = tempButtonSprites;
    //    }
    //}
    //private void PopulateMenuButtons()
    //{
    //    if (tempAmountOfMenuButtons > 0)
    //    {

    //        for (int i = 0; i<tempAmountOfMenuButtons; i++)
    //        {
    //            Debug.Log(i);

    //            sourceMenuButtons[i] = (string)EditorGUILayout.TextField($"New Menu Button {i} Name", tempMenuButtons[i]);
    //            if (tempMenuButtons[i] != sourceMenuButtons[i])
    //            {
    //                tempMenuButtons[i] = sourceMenuButtons[i];
    //            }
    //        }  
    //    }
    //}


    //private void GetButtonSprite()
    //{
    //    if (tempButtonSprites.Count > 0)
    //    {
    //        for (int i = 0; i < tempButtonSprites.Count; i++)
    //        {
    //            sourceButtonSprites[i] = (Sprite)EditorGUILayout.ObjectField($"Button {i} Sprite", tempButtonSprites[i], typeof(Sprite), false);
    //            if (tempButtonSprites[i] != sourceButtonSprites[i])
    //            {
    //                tempButtonSprites[i] = sourceButtonSprites[i];
    //            }
    //        }
    //    }
    //}
    //private void OnButtonClick()
    //{
    //    if (GUILayout.Button("Create Custom Menu"))
    //    {
    //        var newMenuParentCanvas = new GameObject();
    //        newMenuParentCanvas.name = tempMenuName;
    //        newMenuParentCanvas.AddComponent<Canvas>();
    //        newMenuParentCanvas.AddComponent<CanvasScaler>();
    //        newMenuParentCanvas.AddComponent<GraphicRaycaster>();
    //        var newMenuBackgroundImage = new GameObject();
    //        newMenuBackgroundImage.name = "NewMenuBackgroundImage";
    //        newMenuBackgroundImage.transform.parent = newMenuParentCanvas.transform;

    //        newMenuBackgroundImage.AddComponent<Image>().sprite = tempBackgroundImage;
    //        if(tempAmountOfMenuButtons>0)
    //        {
    //            for (int i = 0; i < tempAmountOfMenuButtons; i++)
    //            {
    //                var newButton = new GameObject();
    //                newButton.name = tempMenuButtons[i];
    //                newButton.transform.parent = newMenuParentCanvas.transform;
    //                if (tempButtonSprites[i] != null)
    //                {
    //                    newButton.AddComponent<Image>().sprite = tempButtonSprites[i];
    //                }
    //                else
    //                {
    //                    newButton.AddComponent<Image>();
    //                }
    //                newButton.AddComponent<Button>();
    //            }
    //        }
    //        ClearEverything();
    //    }

    //}


    ////private variables
    //private void ClearEverything()
    //{
    //    sourceMenuName = string.Empty;
    //    sourceMenuTitle = string.Empty;
    //    sourceAmountOfMenuButtons = new byte();
    //    tempMenuName = string.Empty;
    //    tempMenuTitle = string.Empty;
    //    tempAmountOfMenuButtons = new byte();
        
    //    //DestroyImmediate(GameObject.Find("New Game Object"), true);
    //}
}
