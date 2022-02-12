#include <LoRa.h>
#include "boards.h"
#include <TinyGPS++.h>
#include <ArduinoJson.h>

//packet counter
int counter = 0;

TinyGPSPlus gps;

//char[] jsonData = '{' + '"' + "lat" + '"' + ": " + '"' + lat + '"' + ","

void setup()
{
  initBoard();
  // When the power is turned on, a delay is required.
  delay(1500);

  Serial.println("LoRa Sender");
  LoRa.setPins(RADIO_CS_PIN, RADIO_RST_PIN, RADIO_DI0_PIN);
  if (!LoRa.begin(LoRa_frequency)) {
    Serial.println("Starting LoRa failed!");
    while (1);
  }

  Serial.println(TinyGPSPlus::libraryVersion());
}

void loop()
{
  // This sketch displays information every time a new sentence is correctly encoded.
  while (Serial1.available() > 0){
    if (gps.encode(Serial1.read())){
      displayInfo();
      break;
    }
  }

  if (millis() > 5000 && gps.charsProcessed() < 10) {
    Serial.println(F("No GPS detected: check wiring."));
    while (true);
  }

  Serial.println("Sending packet: ");
  //Serial.println(counter);
  counter++;

  delay(5000);
}

void displayInfo()
{
  //starting JSON packet
  DynamicJsonDocument doc(512);

  //Beginning LoRa packet
  LoRa.beginPacket();

  Serial.print(F("Trying to get location... "));
  //Checking if location is valid, duh
  if (gps.location.isValid()) {
    //Getting location
    float lat = gps.location.lat();
    float lng = gps.location.lng();
    int sats = gps.satellites.value();
    double speed = gps.speed.mps();

    //Adding GPS location data to JSON Packet
    doc["Lat"] = lat;
    doc["Lng"] = lng;
    doc["Sats"] = sats;
    doc["Speed"] = speed;
    //Serial Line Debugging
    Serial.print(lat, 6);
    Serial.print(F(","));
    Serial.print(lng, 6);
    Serial.print(F(" Sats: "));
    Serial.print(sats);
    /*Serial.print(F("  Date/Time: "));
      if (gps.date.isValid()) {
        Serial.print(gps.date.month());
        Serial.print(F("/"));
        Serial.print(gps.date.day());
        Serial.print(F("/"));
        Serial.print(gps.date.year());
      } else {
        Serial.print(F("INVALID"));
      }*/

    Serial.print(F(" "));
    if (gps.time.isValid()) {
      if (gps.time.hour() < 10) Serial.print(F("0"));
      Serial.print(gps.time.hour());
      Serial.print(F(":"));
      if (gps.time.minute() < 10) Serial.print(F("0"));
      Serial.print(gps.time.minute());
      Serial.print(F(":"));
      if (gps.time.second() < 10) Serial.print(F("0"));
      Serial.print(gps.time.second());
      Serial.print(F("."));
      if (gps.time.centisecond() < 10) Serial.print(F("0"));
      Serial.print(gps.time.centisecond());

      //time
      String Time = String(gps.time.value());
      doc["Time"] = Time;

    } else {
      Serial.print(F("INVALID"));
    }
    //serialize the JSON to a packet and putting it in the LoRa packet
    char serializedJSON[512];
    Serial.println("Serializing json...");
    serializeJson(doc, serializedJSON);
    Serial.println("Serialized json, now sending...");
    LoRa.print(serializedJSON);
    Serial.println(serializedJSON);
    Serial.println("sent!");
    
    //Ending LoRa packet
    LoRa.endPacket();
    //LoRa packet sending magic
    Serial.println("Doing the magic");
    if (u8g2) {
      char buf[256];
      u8g2->clearBuffer();
      u8g2->drawStr(0, 12, "Transmitting: OK!");
      snprintf(buf, sizeof(buf), "Sending: %d", counter);
      u8g2->drawStr(0, 30, buf);
      u8g2->sendBuffer();

      Serial.println();
    }
  }
}
