using UnityEngine;
using System.Collections;
using System.IO.Ports;


public class PlayerSerialController : MonoBehaviour {
    public Vector2 moving = new Vector2();
    public float speed = 4000f;

    SerialPort stream;

    int joystick_val;

    // IEnumerator ReadSerial() {
        // stream.BaseStream.WriteByte(0);
        // joystick_val = stream.ReadByte();
    //     yield return null;
    // }

    void Start () {
        stream = new SerialPort("/dev/tty.usbmodem1422");
        stream.Open();
        // stream.DiscardOutBuffer();
        // stream.DiscardInBuffer();
        // StartCoroutine("ReadSerial");
        // stream.ReadTimeout = 100;
    }

    // Update is called once per frame
    void Update () {
        stream.BaseStream.WriteByte(0);
        joystick_val = stream.ReadByte();

        if (joystick_val > 200) {
            moving.x = 20;
        } else if (joystick_val < 40) {
            moving.x = -20;
        } else {
            moving.x = moving.y = 0;
        }
    }
}
