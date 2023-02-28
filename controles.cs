using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    public:
        virtual ~Command() { }

        virtual void execute() { } = 0;
}

class JumpCommand : public Command {
    public:
        virtual void execute() { jump(); }
}

class FireCommand : public Command {
    public:
        virtual void execute() { fireGun(); }
}

class ImputHandler {
    public:
        void handleInput();

        //Methods to bind commands...
    
    private:
        Command* buttonX_;
        Command* buttonY_;
        Command* buttonA_;
        Command* buttonB_;
}

void InputHandler::handleInput() {
    if (isPressed(BUTTON_X)) buttonX_ -> execute();
}