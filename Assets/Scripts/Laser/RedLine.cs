using UnityEngine;

public class RedLine : Line
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;

    private readonly int _maxPoints = 2;
    private readonly float _height = 0.081f;
    private readonly int _xPosition = 0;

    public override void DrawLine(Vector3 startLine, Vector3 endLine)
    {
        LineRenderer.positionCount = _maxPoints;

        DrowRedLine(_start.position.z, 0);
        DrowRedLine(_end.position.z, 1);
    }

    private void DrowRedLine(float positionZ, int PosId)
    {
        LineRenderer.SetPosition(PosId, new Vector3(_xPosition, _height, positionZ));
    }
}