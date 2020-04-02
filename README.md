# ThinkGeo Cloud Vector Maps Sample for Wpf

### Description

This sample demonstrates how you can draw the ThinkGeo Cloud Vector Tiles in your map applications, with any style you want from [StyleJSON (Mapping Definition Grammar)](https://wiki.thinkgeo.com/wiki/thinkgeo_stylejson).  It supports 3 built-in default map styles as well as custom ones.  

- Light
- Dark
- TransparentBackground
- Custom

ThinkGeo Cloud Vector Maps works perfectly on both low and high resolution (4k) monitors. It would work in all of the ThinkGeo Map controls such as Desktop, Web and Mobile. Check out https://maps.thinkgeo.com/ and get an idea what it looks on Web.

Even this sample is built on .NET Framework 4.6.1, the component supports the latest .NET Core 3.1 without any issues. You can easily create a .NET Core WPF map application using the same code. 

![Screenshot](https://github.com/ThinkGeo/ThinkGeoCloudVectorMapsSample-ForWpf12/blob/master/Screenshot.gif)

### Requirements
This sample makes use of the following NuGet Packages

[ThinkGeo.UI.Wpf 13.0.0-beta068](https://www.nuget.org/packages/ThinkGeo.UI.Wpf/13.0.0-beta068)

### About the Code
```csharp
 this.wpfMap.MapUnit = GeographyUnit.Meter;
 
 // Create background world map with vector tile requested from ThinkGeo Cloud Service. 
 ThinkGeoCloudVectorMapsOverlay thinkGeoCloudVectorMapsOverlay = new ThinkGeoCloudVectorMapsOverlay(thinkGeoCloudId, thinkGeoCloudSecret, thinkGeoCloudVectorMapsMapType);
 mapView.Overlays.Add(thinkGeoCloudVectorMapsOverlay);

```
### Getting Help

[Map Suite Desktop for Wpf Wiki Resources](https://wiki.thinkgeo.com/wiki/map_suite_desktop_for_wpf)

[Map Suite Desktop for Wpf Product Description](https://thinkgeo.com/gis-ui-controls#wpf-platforms)

[ThinkGeo Community Site](http://community.thinkgeo.com/)

[ThinkGeo Web Site](http://www.thinkgeo.com)

### About ThinkGeo
ThinkGeo is a GIS (Geographic Information Systems) company founded in 2004 and located in Frisco, TX. Our clients are in more than 40 industries including agriculture, energy, transportation, government, engineering, software development, and defense.
