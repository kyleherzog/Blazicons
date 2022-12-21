# Blazicons
Provides support for displaying SVG based icons in Blazor projects.

Check out the [Demo Site](http://blazicons.com).

## Overview
Blazicons is a simple library consisting of one Blazor component, the Blazicon.  A Blazicon component displays an SVG icon similar to how a font icon would be displayed.

## Why Blazicons?
Why not just use font libraries to display icons? Blazicons provides a couple of benefits over using font icon libraries. 

The first benefit is resource size. Blazicons is desinged to leverage the SVG versions of the icons from popular icon libraries.  Given Blazor's  assembly trimming, only the icons used, rather than the entire library of icons are delivered to the client.

With Blazicons, an additional benifit is the ability to leverage intellisense.  The various icons available in a given icon library are displayed with Visual Studio's intellisense options.

## Getting Started
To get started using Blazicons, just install the Blazicons NuGet package of the decired icon library.  The following options are currently among those available.

- Blazicons.Bootstrap
- Blazicons.FluentUI
- Blazicons.FontAwesome
- Blazicons.GoogleMaterialDesign
- Blazicons.Ionicons
- Blazicons.MaterialDesignIcons

Next add the Blazicons reference to the `_Imports.razor` file in the Blazor project.

```csharp
@using Blazicons
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
<Blazicon Svg='Ionicon.ShapesSharp.WithColor("#f00).WithSize("200%")'></Blazicon>
```
