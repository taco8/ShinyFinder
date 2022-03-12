#include <SwitchControlLibrary.h>

enum {
  RIGHT = 0,
  LEFT,
  UP,
  DOWN,
  A,
  B,
  X,
  Y,
  R,
  L,
  ZR,
  ZL,
  RSTICK,
  LSTICK,
  RCLICK,
  LCLICK,
  HOME,
  CAPTURE,
  PLUS,
  MINUS
};

enum {
  PRESS = 0,
  RELEASE
};

void setup() {
  //connect to switch
//  for (int i = 0; i < 3; ++i) {
//    SwitchControlLibrary().PressButtonZL();
//    SwitchControlLibrary().PressButtonZR();
//    delay(500);
//    SwitchControlLibrary().ReleaseButtonZL();
//    SwitchControlLibrary().ReleaseButtonZR();
//    delay(500);
//  }
  
  
   for(int i=0;i<5;i++){
      SwitchControlLibrary().PressButtonB();
      delay(100);
      SwitchControlLibrary().ReleaseButtonB();
      delay(500);
   }
   
  
  Serial1.begin(115200);
 // Serial.begin(115200);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (Serial1.available() > 0) {
    int button_type = Serial1.read();
    int button_command;
    int stick_x, stick_y;
    while (Serial1.available() <= 0) {}
    if (button_type == RSTICK or button_type == LSTICK) {
      stick_x = Serial1.read();
      while (Serial1.available() <= 0) {}
      stick_y = Serial1.read();
    } else {
      button_command = Serial1.read();
    }
    

    switch (button_type) {
      case RIGHT:
        if (button_command == PRESS) {
          SwitchControlLibrary().MoveHat(2);
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().MoveHat(8);
        }
        break;
      case LEFT:
        if (button_command == PRESS) {
          SwitchControlLibrary().MoveHat(6);
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().MoveHat(8);
        }
        break;
      case UP:
        if (button_command == PRESS) {
          SwitchControlLibrary().MoveHat(0);
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().MoveHat(8);
        }
        break;
      case DOWN:
        if (button_command == PRESS) {
          SwitchControlLibrary().MoveHat(4);
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().MoveHat(8);
        }
        break;
      case A:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonA();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonA();
        }
        break;
      case B:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonB();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonB();
        }
        break;
      case X:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonX();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonX();
        }
        break;
      case Y:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonY();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonY();
        }
        break;
      case R:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonR();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonR();
        }
        break;
      case L:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonL();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonL();
        }
        break;
      case ZR:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonZR();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonZR();
        }
        break;
      case ZL:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonZL();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonZL();
        }
        break;  
      case RSTICK:
        SwitchControlLibrary().MoveRightStick(stick_x, stick_y);
        break;
      case LSTICK:
        SwitchControlLibrary().MoveLeftStick(stick_x, stick_y);
        break;
      case RCLICK:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonRClick();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonRClick();
        }
        break;        
      case LCLICK:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonLClick();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonLClick();
        }
        break;
      case HOME:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonHome();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonHome();
        }
        break;
      case CAPTURE:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonCapture();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonCapture();
        }
        break;
      case PLUS:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonPlus();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonPlus();
        }
        break;
      case MINUS:
        if (button_command == PRESS) {
          SwitchControlLibrary().PressButtonMinus();
        } else if (button_command == RELEASE) {
          SwitchControlLibrary().ReleaseButtonMinus();
        }
        break;                
    }
  }
}
