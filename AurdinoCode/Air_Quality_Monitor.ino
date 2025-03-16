#include <WiFi.h>
#include <Wire.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>
#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27,16,2);
#define MQ2 33  
#define MQ3 34  
#define MQ4 35  
#define MQ8 32  
int buzzer = 2;
const char *ssid = "Ashok";
const char *password = "Isai@5224";
const char* serverUrl = "http://localhost:5172/api/v1/AirPollution"; 
// set the LCD number of columns and rows
int lcdColumns = 16;
int lcdRows = 2;
String jsonData;
// set LCD address, number of columns and rows
// if you don't know your display address, run an I2C scanner sketch
//LiquidCrystal_I2C lcd(0x27, lcdColumns, lcdRows);  

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  //Serial.setDebugOutput(true);
  lcd.init();                      // initialize the lcd 
  lcd.backlight();
    lcd.print("Welcome...");
    delay(2000);
 // initialize LCD
  lcd.init();
  // turn on LCD backlight                      
  lcd.backlight();
  lcd.setCursor(0, 0);
  lcd.print("Air Quality Mon.");
  delay(2000);
  Serial.println(".........................");
  Serial.println("Welcome to Air Quality Testing Server");
  ConnectWifi();
  pinMode(buzzer,OUTPUT);
  
}

void loop() {

  // set cursor to first column, first row
  lcd.setCursor(0, 0);
  // print message
  lcd.print("Hello, World!");
  delay(1000);
  // clears the display to print new message
  lcd.clear();
  // set cursor to first column, second row
  lcd.setCursor(0,1);
  lcd.print("Hello, World!");
  delay(1000);
  lcd.clear(); 
    // put your main code here, to run repeatedly:
    //Serial.println("Temperature: ");
    Serial.println("------------------------");
    Serial.println("Reading Data From Gas Sensors");
    Serial.println("------------------------");
    
    int gas_mq2 = analogRead(MQ2);
    int gas_mq3 = analogRead(MQ3);
    int gas_mq4 = analogRead(MQ4);
    //int gas_mq7 = analogRead(MQ7);
    int gas_mq8 = analogRead(MQ8);

    if(gas_mq2> 500)
    {
      digitalWrite(buzzer,HIGH);
    }
    else{
       digitalWrite(buzzer,LOW);
    }
    jsonData = "{\"co\":\"1\",\"nO2\": \"2\",\"sO2\": \"3\",\"horizon\": 1}";
    Serial.print("MQ-2 (LPG, Smoke, CO): "); Serial.println(gas_mq2);
    Serial.print("MQ-3 (Alcohol, Ethanol): "); Serial.println(gas_mq3);
    Serial.print("MQ-4 (Methane, CNG): "); Serial.println(gas_mq4);
    //Serial.print("MQ-7 (CO): "); Serial.println(gas_mq7);
    Serial.print("MQ-8 (H2): "); Serial.println(gas_mq8);
    
    Serial.println("------------------------");
    delay(2000);  
}

// Connect Wifi Function
void ConnectWifi()
{   
  lcd.clear();
  lcd.setCursor(0, 0);
  Serial.println("Wifi Connection Begins");
  WiFi.mode(WIFI_STA);
  Serial.println("Wifi Mode Set....");
  delay(500);
  WiFi.begin(ssid, password);
  Serial.println("Wifi Connecting....");
  WiFi.setSleep(false);
  Serial.println("Wifi Sleep Set false....");
  lcd.print("Wifi Connecting.... "); 
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.println("WiFi connected");  
  lcd.print("Wifi connected"); 
}

void sendPostRequest() {
  if (WiFi.status() == WL_CONNECTED) {
    HTTPClient http;

    http.begin(serverUrl);
    http.addHeader("Content-Type", "application/json");

    
    int httpResponseCode = http.POST(jsonData);

    if (httpResponseCode > 0) {
      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);

      String response = http.getString(); // Get the response payload
      Serial.println("Response:");
      Serial.println(response);

      // Parse JSON response
      parseJsonResponse(response);
      
    } else {
      Serial.print("Error on sending POST: ");
      Serial.println(httpResponseCode);
    }

    http.end(); // Close connection
  } else {
    Serial.println("WiFi not connected");
  }
}

void parseJsonResponse(String response) {
  StaticJsonDocument<200> doc; // Adjust size based on response size

  DeserializationError error = deserializeJson(doc, response);

  if (error) {
    Serial.print("JSON parsing failed: ");
    Serial.println(error.c_str());
    return;
  }

  // Example: Extract fields from JSON response
  const char* status = doc["succeeded"]; // Example: {"status":"success","data":{"id":123}}
 
  Serial.print("Status: ");
  Serial.println(status);
}
