---
trigger: always_on
---

#Theme

Project use FluentTheme. 

# Icons

You have installed Material.Icons.Avalonia and Avalonia.Fluent.Icons so you can use them for icons

# Folders and files

* Files with styles related to feature should be placed in UI/Styles folder of feature. Styles used across several features should be placed in Shared/Styles folder.
* You can add new global style only if i directly tell to do so. 
* There should be separated files for styles for different types of controls (for example styles for Buttons and TextBlocks should be in separated files). Colors also should be placed in separated style file.
* to use file with styles in your view you need to import it for example
  <StyleInclude Source="avares://KrolikGR/Src/Shared/Styles/ButtonsStyles.axaml" />
* Files with styles should have name with suffix "Styles" for example ButtonsStyles.axaml
* Colors should be kept in <ResourceDictionary>
* To include resources:
   <ResourceDictionary.MergedDictionaries> <ResourceInclude Source="avares://KrolikGR/Src/Shared/Styles/ColorResources.axaml" />
   </ResourceDictionary.MergedDictionaries>

# ControlTheme

* Control themes should be placed in same folders as styles
* files with ControlThemes should have suffix "ControlTheme" for example MalpaControlTheme.axaml
