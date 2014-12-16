#include <FreeSixIMU.h>
#include <FIMU_ADXL345.h>
#include <FIMU_ITG3200.h>

#include <Wire.h>

float angles[3]; // yaw pitch roll

// Set the FreeSixIMU object
FreeSixIMU sixDOF = FreeSixIMU();

void setup() { 
  Serial.begin(9600);
  Wire.begin();
  
  delay(5);
  sixDOF.init(); //begin the IMU
  delay(5);
}

void loop() { 
  int upperBound = 115;
  int lowerBound = 69;
  sixDOF.getEuler(angles);
  if(angles[2] > upperBound) {
    Serial.println(1);
  }
  if(angles[2] < lowerBound) {  
    Serial.println(-1);
  }
  if(angles[2] < upperBound && angles[2] > lowerBound) {
    Serial.println(0);
  }

  delay(100); 
}

