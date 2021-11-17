#include <LoRa.h>
#include "boards.h"
//#include "utilities2.h"
#include <TinyGPS++.h>

int counter = 0;

TinyGPSPlus gps;


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
    while (Serial1.available() > 0)
        if (gps.encode(Serial1.read()))
            displayInfo();

    if (millis() > 5000 && gps.charsProcessed() < 10) {
        Serial.println(F("No GPS detected: check wiring."));
        while (true);
    }
  
    Serial.print("Sending packet: ");
    Serial.println(counter);

    delay(5000);
}

void displayInfo()
{
    Serial.print(F("Location: "));
    //Checking if location is valid, duh
    if (gps.location.isValid()) {
        //Beginning LoRa packet
        LoRa.beginPacket();
        //Adding location to LoRa packet
        float lat = gps.location.lat();
        float lng = gps.location.lng();
        
        LoRa.print(String(lat, 9));
        LoRa.print(',');
        LoRa.print(String(lng, 9));

        //Serial Line Debugging
        Serial.print(gps.location.lat(), 6);
        Serial.print(F(","));
        Serial.print(gps.location.lng(), 6);
        //Ending LoRa packet
        LoRa.endPacket();
        //LoRa packet sending magic
        if (u8g2) {
        char buf[256];
        u8g2->clearBuffer();
        u8g2->drawStr(0, 12, "Transmitting: OK!");
        snprintf(buf, sizeof(buf), "Sending: %d", counter);
        u8g2->drawStr(0, 30, buf);
        u8g2->sendBuffer();
    }
    }

    /*Serial.print(F("  Date/Time: "));
    if (gps.date.isValid()) {
        Serial.print(gps.date.month());
        Serial.print(F("/"));
        Serial.print(gps.date.day());
        Serial.print(F("/"));
        Serial.print(gps.date.year());
    } else {
        Serial.print(F("INVALID"));
    }

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
    } else {
        Serial.print(F("INVALID"));
    }*/

    Serial.println();
}
