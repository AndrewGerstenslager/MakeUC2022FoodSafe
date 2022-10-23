#include <Arduino.h>
#include <U8g2lib.h>

#ifdef U8X8_HAVE_HW_SPI
#include <SPI.h>
#endif
#ifdef U8X8_HAVE_HW_I2C
#include <Wire.h>
#endif

U8G2_SSD1306_128X64_NONAME_F_SW_I2C u8g2(U8G2_R0, /* clock=*/ SCL, /* data=*/ SDA, /* reset=*/ U8X8_PIN_NONE);   // All Boards without Reset of the Display
int State = 0;
int temp = 0;


void setup(){
  Serial.begin(9600);
  Serial.setTimeout(10);
  pinMode(13, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(7, OUTPUT);
  u8g2.begin();
}

void loop(){
  u8g2.clearBuffer();
  u8g2.setFont(u8g2_font_ncenB08_tr);
  temp = Serial.parseInt();
  if (State != temp && temp != 0){
    State = temp;
    Serial.println(State);
  }
  if (State == 3){
    digitalWrite(13, LOW);
    digitalWrite(11, LOW);
    digitalWrite(9, HIGH);
    digitalWrite(7, LOW);
    u8g2.drawStr(0,10,"Caution");	// write something to the internal memory
    u8g2.sendBuffer();					// transfer internal memory to the display 
    delay(100);
    digitalWrite(9, LOW);
    delay(100);
    
  }
  if (State == 2){
    digitalWrite(13, LOW);
    digitalWrite(11, HIGH);
    digitalWrite(9, LOW);
    digitalWrite(7, LOW);
    u8g2.drawStr(0,10,"Unsafe");	// write something to the internal memory
    u8g2.sendBuffer();					// transfer internal memory to the display
    delay(100);
    digitalWrite(11, LOW);
    delay(100);
  }
  if (State == 1){

      digitalWrite(13, HIGH);
      digitalWrite(11, LOW);
      digitalWrite(9, LOW);
      digitalWrite(7, LOW);
      u8g2.drawStr(0,10,"Calculating");	// write something to the internal memory
      u8g2.sendBuffer();					// transfer internal memory to the display
      delay(100);
      digitalWrite(13, LOW);
      delay(100);
  }
  if (State == 4){
    digitalWrite(13, LOW);
      digitalWrite(11, LOW);
      digitalWrite(9, LOW);
      digitalWrite(7, HIGH);
      u8g2.drawStr(0,10,"Safe");	// write something to the internal memory
    u8g2.sendBuffer();					// transfer internal memory to the display
      delay(100);
      digitalWrite(7, LOW);
      delay(100);
  }
  if (State == 5 ){
    digitalWrite(13, LOW);
      digitalWrite(11, LOW);
      digitalWrite(9, LOW);
      digitalWrite(7, LOW);
      u8g2.drawStr(0,10,"");	// write something to the internal memory
    u8g2.sendBuffer();	
  }

}