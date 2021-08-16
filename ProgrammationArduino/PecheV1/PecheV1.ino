#include <SoftwareSerial.h>
#include <SerialCommand.h>
#include <Wire.h>
#include <Adafruit_MotorShield.h>

//Pins on Arduino Mega
#define pinPing 7
#define pinError 6
#define pinEcho 5
SerialCommand sCmd;
 
// Create the motor shield object with the default I2C address
Adafruit_MotorShield AFMS = Adafruit_MotorShield(0x61); 
// Or, create it with a different I2C address (say for stacking)
// Adafruit_MotorShield AFMS = Adafruit_MotorShield(0x61); 

// Connect a stepper motor with 200 steps per revolution (1.8 degree)
// to motor port #2 (M3 and M4)
Adafruit_StepperMotor *myMotor = AFMS.getStepper(200, 2);

void pingHandler();
void backwardHandler();
void forwardHandler();


//https://answers.microsoft.com/en-us/windows/forum/windows_vista-networking/how-to-identify-com-port/bec6c2a1-1c4d-4d40-a496-421afd0aaa20 
void setup() 
{
    Serial.begin(9600);
    while (!Serial);
 
    sCmd.addCommand("PING", pingHandler);
    sCmd.addCommand("BACKWARD", backwardHandler);
    sCmd.addCommand("FORWARD", forwardHandler);
    sCmd.addCommand("STOP", stopHandler);




    pinMode(pinError, OUTPUT);
    pinMode(pinPing, OUTPUT);
    AFMS.begin();  // create with the default frequency 1.6KHz
    //AFMS.begin(1000);  // OR with a different frequency, say 1KHz
  
    myMotor->setSpeed(50);  // 50 rpm   //Value here is directly the rpm
}

void loop()
{
    if (Serial.available() > 0)
        sCmd.readSerial();  //Read strings from serial port and invoke right handler
}

void pingHandler()
{
    //Serial.println("PONG");
    digitalWrite(pinPing, HIGH);
    //delay(500);
    digitalWrite(pinPing, LOW);
}


void forwardHandler()
{
    //Serial.println("FORWARD");
    //myMotor->step(50, BACKWARD, DOUBLE);
    myMotor->step(50, FORWARD, DOUBLE);
}
void backwardHandler()
{
    //Serial.println("BACKWARD");
    myMotor->step(50, BACKWARD, SINGLE);
}
void stopHandler()
{
    //Serial.println("STOP");
    myMotor->release();
}

void errorHandler (const char *command)
{
    Serial.println("WRONG PONG");
    digitalWrite(pinError, HIGH);
    delay(1000);
    digitalWrite(pinError, LOW);
}

void echoHandler () {
  char *arg;
  arg = sCmd.next();
  if (arg != NULL)
    Serial.println(arg);
  else
    Serial.println("nothing to echo");
}