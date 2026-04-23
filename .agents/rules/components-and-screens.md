---
trigger: always_on
---

# Screens

When in instruction for you I use the word "screen", I mean 4 files:
NameViewModel.cs, NameView.axaml.cs, NameView.axaml and Screen.md.
So, for example, when I say "screen malpa", I mean the files MalpaViewModel.cs, MalpaView.axaml.cs, MalpaView.axaml and Screen.md.
The files are usually grouped in a single folder and are responsible for the UI of one screen. 

Before starting any work on a screen, you SHOULD read its `Screen.md` file to understand its purpose, functionalities, and context.

Inside screen folder there may be folder ScreenComponents where you can put folders of components used only by this screen

## Screens and models

File with  model can only be at the feature or core level. You can't put models in the screens folder

Custom components should by default be placed in ScreenComponents. You can place them in FeatureComponents or GlobalComponents only when i will directly tell you to do that. 

## Screen.md

Every screen folder MUST contain a Screen.md file. This file should contain documentation about the screen, including:

- Purpose of the screen (what it does).
- List of functionalities and features available on this screen.
- Information about key UI elements (e.g., buttons that trigger specific actions like theme switching).
- **Navigation (From):** List of screens that can navigate to this screen via routing.
- **Navigation (To):** List of screens that this screen can navigate to via routing.
- Any other relevant information for developers or AI agents to understand the screen's role.

**IMPORTANT:** Whenever you modify a screen (logic, UI, or functionalities), or when navigation paths change (e.g., another screen adds a button navigating to this screen), you MUST update the corresponding `Screen.md` file(s) to reflect these changes. Documentation must always stay in sync with the implementation.

# Components

Components are reusable or isolated UI blocks that are NOT used directly in ReactiveUI routing (they do NOT implement `IRoutableViewModel`). 

Every component folder MUST contain a Component.md file, which serves as the documentation for that specific component.

Before starting any work on a component, you SHOULD read its `Component.md` file to understand its purpose, usage, and context.

There are two types of components you must distinguish:

1. **Smart Components:** They have their own complex logic, state, or actions. They require a full MVVM triad (e.g., `NameViewModel.cs` inheriting from `ViewModelBase`, `NameView.axaml`, and `NameView.axaml.cs`).
2. **Dumb Components (Stateless):** They only display data and have no complex logic. They do NOT have their own ViewModel file. They consist only of `NameView.axaml` and `NameView.axaml.cs`, using `x:DataType` bound directly to a Model or a property of the parent's ViewModel.

## Component.md

Every component folder MUST contain a Component.md file. This file should contain documentation about the component, including:

- Purpose of the component (what it does and why it was created).
- How to use it (inputs/outputs, properties it binds to).
- Information about key UI elements within the component.
- **Used In:** List of screens or other components that use this component.
- Any other relevant information for developers or AI agents to understand the component's role.

**IMPORTANT:** Whenever you modify a component (logic, UI, or functionalities), or when its usage changes (e.g., it is added to a new screen), you MUST update the corresponding `Component.md` file to reflect these changes. Documentation must always stay in sync with the implementation.