using UnityEngine;
using System.Collections;
using System.IO.Ports;


public class PlayerSerialControllerEvent : MonoBehaviour {
    public Vector2 moving = new Vector2();
    public float speed = 4000f;

    SerialPort stream;

    int joystick_val;

    void Start () {
        SerialPort mySerialPort = new SerialPort("/dev/tty.usbmodem1422");
        mySerialPort.BaudRate = 9600;
        mySerialPort.Parity = Parity.None;
        // mySerialPort.StopBits = StopBits.One;
        mySerialPort.DataBits = 8;
        mySerialPort.Handshake = Handshake.None;


        mySerialPort.Open();
        mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        print("OPEN");
    }

    // Update is called once per frame
    void Update () {
        // print(joystick_val);
        // if (joystick_val > 0xF000) {
        //     moving.x = -20;
        // } else if (joystick_val < 0x1000) {
        //     moving.x = 20;
        // } else {
        //     moving.x = moving.y = 0;
        // }
    }

    private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        print("Data Received:");
        // print(indata);
    }
}
