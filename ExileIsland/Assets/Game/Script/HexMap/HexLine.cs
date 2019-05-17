using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class HexLine : MonoBehaviour
{
    
    public Color color = Color.red;
    public int lengthOfLineRenderer = 12;
    public LineRenderer lineRenderer;
    public Vector3 offset = new Vector3(0, 1, 0);
    public float width = 0.2f;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = width;
        lineRenderer.positionCount = lengthOfLineRenderer;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(color, 0.0f), new GradientColorKey(color, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
    }

    void Start()
    {
        
    }

    void Update()
    {
        /*var points = new Vector3[lengthOfLineRenderer];
        var t = Time.time;
        for (int i = 0; i < lengthOfLineRenderer; i++)
        {
            points[i] = new Vector3(i * 0.5f, Mathf.Sin(i + t), 0.0f);
        }
        lineRenderer.SetPositions(points);*/
    }

    public void Outline(HexCell cell)
    {
        Vector3 center = cell.transform.localPosition;
        var points = new Vector3[lengthOfLineRenderer];
        int i = 0;
        for (HexDirection d = HexDirection.NE; d <= HexDirection.NW; d++)
        {
            points[i++] = center + HexMetrics.GetFirstCorner(d) + offset;
            points[i++] = center + HexMetrics.GetSecondCorner(d) + offset;
        }
        lineRenderer.SetPositions(points);
    }
}
