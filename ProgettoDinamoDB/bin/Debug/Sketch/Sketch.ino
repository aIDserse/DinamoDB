// Libs
#include "DHT.h"
#include "ArduinoJson.h"
// Digital PIN connected to DHT
#define DHTPIN 2
// Sensor type: DHT 11
#define DHTTYPE DHT11
// Sensor type: Water level
#define SensorPower 12
#define relevation A0

DHT dht(DHTPIN, DHTTYPE);
// WaterLev to memorize the water level
int WaterLev = 0;

void setup() {
  // We set the digital input 12 as OUTPUT
  pinMode(SensorPower, OUTPUT);
  // We set as LOW the sensor's +Vcc
  digitalWrite(SensorPower, LOW);
  Serial.begin(9600);
  dht.begin();  
}

void loop() {
  delay(2000);
  float h = dht.readHumidity();
  float t = dht.readTemperature();
  const int capacity = JSON_OBJECT_SIZE(4);
  DynamicJsonDocument doc(1024);
  int LIGHT = luminosity();
  int H2O = waterlevel();
  int HUM = dht.readHumidity();
  int TP = dht.readTemperature();
  doc["ID"] = 0;
  doc["Time"] = "0";
  doc["CordX"] = 0;
  doc["CordY"] = 0;
  doc["WaterLevel"] = H2O;
  doc["Humidity"] = HUM;
  doc["Deg"] = TP;
  doc["Lumin"] = LIGHT;
  serializeJson(doc, Serial);
  Serial.println("\n");
}
int luminosity(){
  int l = analogRead(A1);
  return l;
}
int waterlevel() {
  digitalWrite(SensorPower, HIGH);  // Turns on the sensor
  WaterLev = analogRead(relevation);// Reads the value and saves it in the relevation value
  digitalWrite(SensorPower, LOW);   // Turns off the sensor
  return WaterLev;
}
