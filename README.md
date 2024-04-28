# Blazicons
Provides support for displaying SVG based icons in Blazor projects.

Check out the [Demo Site](http://blazicons.com).

![Nuget](https://img.shields.io/nuget/v/Blazicons)

[![Build Status](https://dev.azure.com/kyleherzog/Blazicons/_apis/build/status/Blazicons?branchName=main)](https://dev.azure.com/kyleherzog/Blazicons/_build/latest?definitionId=15&branchName=main)

## Overview
Blazicons is a simple library consisting of one Blazor component, the Blazicon.  A Blazicon component displays an SVG icon similar to how a font icon would be displayed.

## Why Blazicons?
Why not just use font libraries to display icons? Blazicons provides a couple of benefits over using font icon libraries. 

The first benefit is resource size. Blazicons is desinged to leverage the SVG versions of the icons from popular icon libraries.  Given Blazor's  assembly trimming, only the icons used, rather than the entire library of icons are delivered to the client.

With Blazicons, an additional benifit is the ability to leverage intellisense.  The various icons available in a given icon library are displayed with Visual Studio's intellisense options.

## Getting Started
To get started using Blazicons, just install the Blazicons NuGet package of the desired icon library.  The following options are currently among those available.

- [Blazicons.Bootstrap](https://github.com/kyleherzog/Blazicons.Bootstrap)
- [Blazicons.Devicon](https://github.com/kyleherzog/Blazicons.Devicon)
- [Blazicons.FluentUI](https://github.com/kyleherzog/Blazicons.FluentUI)
- [Blazicons.FontAwesome](https://github.com/kyleherzog/Blazicons.FontAwesome)
- [Blazicons.GoogleMaterialDesign](https://github.com/kyleherzog/Blazicons.GoogleMaterialDesign)
- [Blazicons.Ionicons](https://github.com/kyleherzog/Blazicons.Ionicons)
- [Blazicons.Lucide](https://github.com/kyleherzog/Blazicons.Lucide)
- [Blazicons.MaterialDesignIcons](https://github.com/kyleherzog/Blazicons.MaterialDesignIcons)

Next add the Blazicons reference to the `_Imports.razor` file in the Blazor project.

```csharp
@using Blazicons
```

Ensure that the project styles.css file is referenced in the head tag section of the index.html/_Host.cshtml file.
```html
<link href="My.App.styles.css" rel="stylesheet" />
```

Finally, add the Blazicon component to your Blazor pages/components.
```html
<Blazicon Svg="MdiIcon.Information"></Blazicon>
```

## Parameters
Each parameter in a Blazor component has a rendering cost. Since it might be desireable to have many Blazicons on a page, maybe even in some sort of repeater control, one of the core principal when creating Blazicons was to limit the number of parameters. 

As a result, a Blazicon only has one parameter, `Svg`. The `Svg` parameter is a special type of `SvgIcon`.  These `SvgIcon` types are defined in the specific icon library Blazicon files.

## Styling
A Blazicon is designed to be displayed with the size and color determined by current font size and color settings.  Therefore, the size and color can easily be changed by adjusting the CSS `font-size` and `color` style attributes of the containing element.

```html
<div style="font-size 200%; color: #f00;">
    <Blazicon Svg="Ionicon.ShapesSharp"></Blazicon>
</div>
```

Styling helper methods also are available on the `SvgIcon` object.
```html
<Blazicon Svg='Ionicon.ShapesSharp.WithColor("#f00").WithSize("200%")'></Blazicon>
```
