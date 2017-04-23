using UnityEngine;
using System.Collections;
using Vectrosity;


public class Graph : MonoBehaviour {
    //the buffer contains 100 points
    private CircularBuffer<Vector3> buffer = new CircularBuffer<Vector3>(100);

    private VectorLine line;
    private Vector3 point;

    private float x = -5f;
    private float increment = .1f;

    float dotSize = 2.0f;
    int numberOfDots = 50;

    void Start() {
        //initial points
        for (int i = 0; i < buffer.Count; i++) {
            x += increment;

            point = new Vector3(x, Mathf.Sin(x));
            buffer.Add(point);
        }

        // VectorLine.SetLine (Color.green, new Vector2(0, 0), new Vector2(Screen.width-1, Screen.height-1));

        // line = new VectorLine("MyLine", buffer.ToArray(), Color.red, null, 2.0f, LineType.Continuous);
        // line.Draw3DAuto();
    }


    void FixedUpdate() {
        x += increment;

        //add the points to the buffer (old points get dequeued)
        point = new Vector3(x, Mathf.Sin(x) * Random.Range(1, 1.2f));
        buffer.Add(point);

        //move the line object
        // Vector3 pos = line.vectorObject.transform.position;
        // pos.x -= increment;
        // line.vectorObject.transform.position = pos;

        // update the current points
        // line.points3 = buffer.ToArray();
    }
}
