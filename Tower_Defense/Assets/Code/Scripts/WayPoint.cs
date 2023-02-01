using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    [SerializeField] private Vector3[] points;

    public Vector3[] Points => points;
    public Vector3 CurrentPosition => _currentPosition;

    private Vector3 _currentPosition;
    private bool _gameStated;

    // Start is called before the first frame update
    void Start()
    {
        _gameStated = true;
        _currentPosition = transform.position;
    }

    public Vector3 GetWaypointPositions(int index)
    {
        return CurrentPosition;
    }

    private void OnDrawGizmos()
    {
        if(!_gameStated && transform.hasChanged)
        {
            _currentPosition = transform.position;
        }

        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(points[i] + _currentPosition, 0.5f);

            if(i< points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + _currentPosition, points[i + 1] + _currentPosition);
            }
        }
    }
}

[CustomEditor(typeof(WayPoint))]
public class WaypointEditor : Editor
{
    WayPoint Waypoint => target as WayPoint;

    private void OnSceneGUI()
    {
        Handles.color = Color.cyan;
        for (int i = 0; i < Waypoint.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            // Create Handles
            Vector3 currentWaypointPoint = Waypoint.CurrentPosition + Waypoint.Points[i];
            Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWaypointPoint, Quaternion.identity, 0.7f, new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);

            // Create text
            GUIStyle textStyle = new GUIStyle();
            textStyle.fontStyle = FontStyle.Bold;
            textStyle.fontSize = 16;
            textStyle.normal.textColor = Color.white;
            Vector3 textAlligment = Vector3.down * 0.35f + Vector3.right * 0.35f;
            Handles.Label(Waypoint.CurrentPosition + Waypoint.Points[i] + textAlligment, $"{i + 1}", textStyle);
            EditorGUI.EndChangeCheck();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free Move Handle");
                Waypoint.Points[i] = newWaypointPoint - Waypoint.CurrentPosition;
            }
        }
    }
}
