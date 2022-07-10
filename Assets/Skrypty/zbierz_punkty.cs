using System.Collections;
using System.IO;
using System;
using UnityEngine;

public class zbierz_punkty : MonoBehaviour
{
    public PolygonCollider2D collider;
    private Vector2[] punkty;
    void Start()
    {
        punkty = new Vector2[collider.GetTotalPointCount()];
        punkty=collider.points;
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
        {
            foreach (Vector2 element in punkty)
                outputFile.WriteLine(element);
        }
    }
}
