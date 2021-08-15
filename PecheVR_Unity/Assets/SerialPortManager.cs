using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialPortManager : MonoBehaviour
{

    SerialPort stream;
    bool SerialComm = false;//Used to comm with Arduino or not

    // Start is called before the first frame update
    void Start()
    {
        if (SerialComm)
        {
            stream = new SerialPort("COM4", 9600);  //!!!!!!!!!!!!!!!!!! Need to search and find the good COM port to use the Arduino!!!!!!!!!!!!!!!!!!!!!!
            stream.ReadTimeout = 50;
            stream.Open();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }



}
