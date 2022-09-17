using UnityEngine;

/*
 * Referenced from: https://www.youtube.com/watch?v=DdAfwHYNFOE
 */

[RequireComponent(typeof(LineRenderer))]
public class CircleRenderer : MonoBehaviour {

    [SerializeField] public int lineCount;
    [SerializeField] public float radius;
    
    private LineRenderer _lineRenderer;
    private void Start() {
        _lineRenderer = GetComponent<LineRenderer>();
        DrawCircle(lineCount, radius);
    }
    
    public void DrawCircle(int steps, float radius) {
        _lineRenderer.positionCount = steps;

        for (int i = 0; i < steps; i++) {
            float circumferenceProgress = (float) i / steps;
            float radians = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(radians) * radius;
            float yScaled = Mathf.Sin(radians) * radius;

            var currentPos = new Vector3(xScaled, yScaled);
            _lineRenderer.SetPosition(i, currentPos);
        }
    }
}