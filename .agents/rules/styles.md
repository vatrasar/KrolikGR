---
trigger: always_on
---

# Theme and colors

The application use the **FluentTheme** design system with custom palettes defined in the project.
*   **Prohibition of Hardcoded Colors:** DO NOT use hex codes (e.g., `#FFFFFF`) or named colors (e.g., `Red`, `Blue`) directly in XAML or code. Use theme resources instead.
*   **Dynamic Resources:** Always use `{DynamicResource}` for brushes and colors to ensure compatibility with Light/Dark mode switching.
*   **Custom Colors:** If a unique color is absolutely necessary (e.g., for specific status indicators), it must be added to Shared/GlobalStyles/Colors.axaml


# Icons

You have installed Material.Icons.Avalonia and Avalonia.Fluent.Icons so you can use them for icons

# Folders and files

* Files with styles related to feature should be placed in UI/FeatureStyles folder of feature. 
* Styles used across several features should be placed in Shared/GlobalStyles folder.
* Styles used only in one screen should be placed in style ScreenStyles inside of screen folder
* You can add new global and feature styles only if i directly tell to do so. For default you should place all new styles in ScreenStyles of screen which will use this styles
* There should be separated files for styles for different types of controls (for example styles for Buttons and TextBlocks should be in separated files). Colors also should be placed in separated style file.
* to use file with styles in your view you need to import it for example
  <StyleInclude Source="avares://KrolikGR/Src/Shared/GlobalStyles/ButtonsStyles.axaml" />
* Files with styles should have name with suffix "Styles" for example ButtonsStyles.axaml
* Colors should be kept in <ResourceDictionary>
* To include resources:
   <ResourceDictionary.MergedDictionaries> <ResourceInclude Source="avares://KrolikGR/Src/Shared/Styles/ColorResources.axaml" />
   </ResourceDictionary.MergedDictionaries>

# Styles separation from views

* NEVER use inline `<UserControl.Styles>` or `<Window.Styles>` directly inside View files (like UserControl or Window).
* ALL styles MUST be extracted to dedicated `.axaml` files in the appropriate `Styles` directory (FeatureStyles, GlobalStyles or ScreenStyles).
* In the View file, you are ONLY allowed to import styles using `<StyleInclude Source="..." />`.
* DO NOT ignore this rule even for small, one-off styles. 

# ControlTheme

* Control themes should be placed in same folders as styles
* files with ControlThemes should have suffix "ControlTheme" for example MalpaControlTheme.axaml