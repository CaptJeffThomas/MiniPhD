//This controls our credit roll //

using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class Credits : MonoBehaviour 
{
    public GUISkin creditSkin;
    public float creditSpeed;
    private TextReader tr;
    private string path;
    List<string> credits = new List<string>();
    List<Rect> positionRect = new List<Rect>();
 
    // Use this for initialization
    void Start () 
    {        
        // Set the path for the credits.txt file
        path = "Assets/Credits.txt";
 
        // Create reader & open file
        tr = new StreamReader(path);
 
        string temp;
        int count = 0;
        while((temp = tr.ReadLine()) != null)
        {
            // Read a line of text
            credits.Add(temp);
            positionRect.Add(new Rect(200, 790 + (30 * count), 300, 100));
            Debug.Log(temp);
            count++;
        }
 
        // Close the stream
        tr.Close();
    }
 
    // Update is called once per frame
    void OnGUI() 
    {
        GUI.skin = creditSkin;
        for (int i = 0; i < credits.Count; i++)
        {
            GUI.Label(positionRect[i], credits[i], "item");
            Rect tempRect = positionRect[i];
            tempRect.y = tempRect.y - creditSpeed;
            positionRect[i] = tempRect;
        }
    }
}