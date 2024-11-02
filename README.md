Unity Custom State Machine


This repository contains two C# scripts, BaseState and StateManager, which form a basic framework for a custom state machine in Unity. These scripts provide a flexible, efficient way to manage various states in your game, especially for complex behaviors like AI, procedural animations, or game logic beyond Unity’s Animator.

Why Use a Custom State Machine?


While Unity’s Animator Controller is ideal for handling animation states, it can be limiting for scenarios where game logic or non-animation behavior needs to be incorporated. With a custom state machine, you have:

Full control over state transitions based on dynamic conditions.
Separate logic from animations, keeping code organized and easy to maintain.
Enhanced performance, with the ability to customize and optimize behaviors.
This approach is particularly useful for AI, procedural animations, or any gameplay mechanics where animations and logic need to be closely integrated.

Scripts Overview


1. BaseState

The BaseState script is an abstract base class that defines the blueprint for each state in the state machine. It enforces a consistent structure across all states by requiring certain methods to be implemented.

Key Components

Constructor: Initializes the state with a unique StateKey.
Properties:
StateKey: An identifier (of type Enum) for each state.
Abstract Methods:
EnterState(): Logic to execute when entering this state.
ExitState(): Logic to execute when exiting this state.
UpdateState(): Ongoing logic for the state, called every frame.
GetNextState(): Determines the next state, allowing for dynamic transitions.
OnTriggerEnter(Collider other), OnTriggerStay(Collider other), OnTriggerExit(Collider other): Custom trigger event logic for interactions.
Example
This class could be inherited by other specific states (like IdleState or AttackState), each defining their unique behaviors by implementing the abstract methods.

2. StateManager
The StateManager script is responsible for managing all the states in the state machine, handling transitions, and updating the current state each frame.

Key Components
Dictionary States: Holds all possible states, mapped by their StateKey.
CurrentState: Tracks the currently active state.
isTransitioningState: A boolean flag that prevents multiple transitions from occurring simultaneously.
Core Methods
Start(): Begins the state machine by calling EnterState() on the initial state.
Update(): Calls UpdateState() on the current state, and checks for state transitions based on GetNextState().
TransitionToState(Estate statekey): Handles logic for exiting the current state and entering a new one.
Trigger Event Methods (OnTriggerEnter, OnTriggerStay, OnTriggerExit): Pass trigger events to the current state.
Example Usage
To use this state machine:

Define an enum of states (e.g., Idle, Walk, Attack).
Create classes that inherit from BaseState for each state, implementing the required methods.
Add these states to the States dictionary in StateManager with their StateKey.
Call TransitionToState() to switch between states as needed.
Installation


To use these scripts in your Unity project:



Download or clone this repository.


Place BaseState.cs and StateManager.cs in your project’s Scripts folder.


Create custom state classes that inherit from BaseState.


Attach the StateManager component to a GameObject in your Unity scene.
