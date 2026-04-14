---
trigger: always_on
---

# What is this project
An application named KrolikGR. The application is meant to help with scheduling in a McDonald's restaurant. The application is to be written in C# using the following frameworks:

{

1. AvaloniaUi

2. ReactiveUI

}

It is meant to use routing from ReactiveUI and a feature-oriented folder architecture.

# Glossary of terms

## Screen
When in instruction for you I use the word "screen", I mean 3 files:
NameViewModel.cs, NameView.axaml.cs, NameView.axaml.
So, for example, when I say "screen malpa", I mean the files MalpaViewModel.cs, MalpaView.axaml.cs, and MalpaView.axaml.
The files are usually grouped in a single folder and are responsible for the UI of one screen.

# Folders architecture


## Src
In this folder, you can find folders in which you will work most often


### Features
Here we keep folders related to specific features. Each feature must have a separate folder. Inside this folder, there should be the following folders:
* UI - here should be folders for the screens of the given feature
* Domain - and in that folder you can add folders for services, models ,usecases and ect if needed

you can also add additional folders (like for example "services" for services related to feature) if needed 

Additionally, all features (except the feature named Shell) must have a file named NameModule.cs (e.g., for a feature named Malpa, it should be the file MalpaModule.cs). This file should contain the registration of routes for the given feature. The modules themselves are later registered in the AppBootstrapper.cs file.

### Infrastructure
Here we have two files: AppBootstrapper and IFeatureModule. AppBootstrapper is used for registering modules. It also contains the routing state. IFeatureModule is the base interface for all modules.

### Shared
It is best to put UI elements here that are shared across multiple features.

### Core
Here you can put some services, models shared by several features, and it also contains the ViewModelBase.

## rxui:RoutedViewHost

rxui:RoutedViewHost (that is, the place where views will change) is located in the shell feature, in the Host screen. The job of MainWindow is just to display the Host screen.

## Assets
Here you can store things like icons images and ect

## Tests
here you should place all tests. inside there are folders:

### CoreTests
here you put tests related to things from Src/Core

### FeaturesTests
and here in subfolders you put tests realted to each feature (for example tests of services from Malpa feature you should place in folder Tests/FeaturesTests/MalpaTests/ServicesTests

# Routing

The routing paths for a given feature should be registered in the NameModule.cs file of the given module.

Example:
For the "Malpa" feature for which the "pies" screen exists, we have the file MalpaModule.cs.

This file should generally look like this:

```cs

// skipping imports
namespace KrolikGR.Features.Malpa;

  

public class MalpaModule : IFeatureModule
{

	public void Register(IMutableDependencyResolver services)
	
	{
	
	     services.Register(() => new PiesView(), typeof(IViewFor<PiesViewModel>));
	
	  
	
	}

}
```

Each module should be registered in the AppBootstrapper method.

Example:

```cs
		var modules = new List<IFeatureModule>
		
			{
			
			new MalpaModule()
			
			};

  

		foreach (var module in modules)
		
		{
		
			module.Register(Locator.CurrentMutable);
		
		}
```

## Navigation between views

If we want to navigate to the pies view from some viewModel, we do this:

```cs
Router.Navigate.Execute(new ShellViewModel(Router));

```

where Router is an object of type RoutingState. Every viewModel should have a property containing the router, and it should be passed between viewModels during navigation in the constructor.