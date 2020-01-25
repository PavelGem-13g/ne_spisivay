#include <Arduino.h>
#include <LiquidCrystal.h>
const int led=2;
const int but=4;

void setup() 
{
pinMode(led,INPUT);
pinMode(but,OUTPUT);
}
int state=0;
void loop()
{
    state=digitalRead(but);
    if(state==HIGH)
    {
      digitalWrite(led,HIGH);
    }
    else
    {
      digitalWrite(led,LOW);
    }
    
}