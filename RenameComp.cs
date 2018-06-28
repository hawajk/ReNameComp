using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class RenameComp : MonoBehaviour {

    public string szPath;
    public string szNameReplaceOld;
    public string szNameReplaceNew;
    
	// Use this for initialization
	void Start () {
        ReName();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReName()
    {
        string selectPath = Application.dataPath + szPath;
       
        //var path_BGImage = Application.dataPath + "/../../BGImage/";
        if (!Directory.Exists(selectPath))
        {
            Debug.LogError(selectPath + "path is not exist!!");
            return;
        }
        var directionBGImage = new DirectoryInfo(selectPath);

        //获取文件信息
        FileInfo[] files = directionBGImage.GetFiles("*", SearchOption.AllDirectories);
        
        for (int i = 0; i < files.Length; i++)
        {
            string name = files[i].Name.Replace(szNameReplaceOld, szNameReplaceNew);
            files[i].MoveTo(selectPath + name);
            Debug.Log("rename to " + name);
        }


        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
}
