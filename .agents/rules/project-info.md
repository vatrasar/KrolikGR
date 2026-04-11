---
trigger: always_on
---

#Co to za projekt
Aplikacja o nazwie KrolikGR. aplikacja ma pomóc w układaniu grafiku w restauracji mcdonald. aplikacja ma być pisana w języku c# przy użyciu frameworków:

{

1. AvaloniaUi

2. ReactiveUI

}

Ma ona używać routingu z reactiveUI i architektóry folderów typu feature oriented. 

#Architektura
# Screen
Kiedy będę używał słowa "screen" to mam na myśli 3 pliki
NazwaViewModel.cs, NazwaView.axaml.cs, NazwaView.axaml.
czyli np jak mówie "screen malpa" to mam na myśli pliki MalpaViewModel.cs MalpaView.axaml.cs MalpaView.axaml
pliki są zwykle zgrupowane w jednym folderze i odpowiadają za UI jednego ekranu. 


## Główne foldery

### Features
Tu trzymamy foldery dotyczące konkretnych feautres. Każdy feature ma mieć odddzielny folder. w tym folderze mają być foldery:
* UI tutaj mają być foldery dla screenów danego feature
* models modele danego feature

dodatkowo wszystkie features poza feature o nazwie Shell ma mieć plik NazwaModule.cs (czyli np dla feature o nazwie Malpa ma to być plik MalpaModule.cs). w pliku tym ma mieć miejsce rejestracja routes dotyczących danego feature. same moduły są później rejestrowane w pliku AppBootstraper.cs

### Infrastructure
tu mamy dwa pliki AppBootstrapper i IFeatureModule. AppBootstrapper słuzy do rejestracji modułów. w nim jest też routing state. IFeatureModule to interfejs bazowy dla wszystkich modułów. 

### Shared
najlepiej dawać tam elementy UI które są współdzielone przez wiele features

### Core
Tu można dawać jakieś współdzielone serwisy, modele, i jest tam też viewModelBase.

