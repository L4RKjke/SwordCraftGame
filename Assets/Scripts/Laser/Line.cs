using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    public LineRenderer LineRenderer => _lineRenderer;

    virtual  public void DrawLine(Vector3 startLine, Vector3 endLine) {}
}
