# Screens and components

## Screens

When in instruction for you I use the word "screen", I mean 3 files:
NameViewModel.cs, NameView.axaml.cs, and NameView.axaml.
So, for example, when I say "screen malpa", I mean the files MalpaViewModel.cs, MalpaView.axaml.cs, and MalpaView.axaml.
The files are usually grouped in a single folder and are responsible for the UI of one screen.

Before starting any work on a screen, you MUST read the documentation comment at the top of its `.axaml.cs` file to understand its purpose, functionalities, and context.

Inside screen folder there may be folder ScreenComponents where you can put folders of components used only by this screen

### Screens and models

File with model can only be at the feature or core level. You can't put models in the screens folder

Custom components should by default be placed in ScreenComponents. You can place them in FeatureComponents or GlobalComponents only when i will directly tell you to do that.

### Screen Documentation

Every screen MUST contain documentation in a comment at the top of the class inside its `.axaml.cs` file. This comment should contain documentation about the screen, including:

- Purpose of the screen (what it does).
- List of functionalities and features available on this screen.
- Information about key UI elements (e.g., buttons that trigger specific actions like theme switching).
- **Navigation (From):** List of screens that can navigate to this screen via routing.
- **Navigation (To):** List of screens that this screen can navigate to via routing.
- Any other relevant information for developers or AI agents to understand the screen's role.

**IMPORTANT:** Whenever you modify a screen (logic, UI, or functionalities), or when navigation paths change (e.g., another screen adds a button navigating to this screen), you MUST update the corresponding documentation comment in the `.axaml.cs` file to reflect these changes. Documentation must always stay in sync with the implementation.

## Components

Components are reusable or isolated UI blocks that are NOT used directly in ReactiveUI routing (they do NOT implement `IRoutableViewModel`).

Every component MUST contain documentation in a comment at the top of the class inside its `.axaml.cs` file, which serves as the documentation for that specific component.

### Components types

There are two types of components you must distinguish:

1. **Smart Components:** They have their own complex logic, state, or actions. They require a full MVVM triad (e.g., `NameViewModel.cs` inheriting from `ViewModelBase`, `NameView.axaml`, and `NameView.axaml.cs`).
2. **Dumb Components (Stateless):** They only display data and have no complex logic. They do NOT have their own ViewModel file. They consist only of `NameView.axaml` and `NameView.axaml.cs`, using `x:DataType` bound directly to a Model or a property of the parent's ViewModel.

### Component Documentation

Every component MUST contain documentation in a comment at the top of the class inside its `.axaml.cs` file. This comment should contain documentation about the component, including:

- Purpose of the component (what it does and why it was created).
- How to use it (inputs/outputs, properties it binds to).
- Information about key UI elements within the component.
- **Used In:** List of screens or other components that use this component.
- Any other relevant information for developers or AI agents to understand the component's role.

**IMPORTANT:** Whenever you modify a component (logic, UI, or functionalities), or when its usage changes (e.g., it is added to a new screen), you MUST update the corresponding documentation comment in the `.axaml.cs` file to reflect these changes. Documentation must always stay in sync with the implementation.

Custom components should by default be placed in ScreenComponents. You can place them in FeatureComponents or GlobalComponents only when i will directly tell you to do that.

### Communication with parent

When a Screen (Parent) contains a Smart Component (Child), the communication MUST strictly follow ReactiveUI patterns to avoid tight coupling.

1. **NO Direct Reference:** A Child ViewModel MUST NOT know about its Parent. Never inject the Parent ViewModel into the Child ViewModel.
2. **NO MessageBus:** Do NOT use ReactiveUI `MessageBus` for Parent-Child communication. It is reserved ONLY for decoupled global events.

**Allowed Communication Methods:**

1. **Observing State (WhenAnyValue):** If the Child manages state (e.g., `SelectedEmployee`), expose it as a `[Reactive]` property.
2. **Observing Actions (ReactiveCommand):** If the Child performs an action (e.g., clicking a 'Delete' button), the Child MUST expose a `ReactiveCommand`.