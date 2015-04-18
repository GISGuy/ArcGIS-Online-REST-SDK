# ArcGIS-Online-REST-SDK
ArcGIS Online REST SDK in C#

This project is an implementation of ArcGIS Online (by ESRI) REST API in C#.
Please noticed that this project is still under development.

## Code Example

```
//Generate user token from ArcGIS Online
AGOL_Error _AGOL_Error = null;
UserToken _userToken = _AGOL_Services.GenerateUserToken(userName, password, out _AGOL_Error);
```

```
//Query user's orgnization's service list
AGOL_Error _AGOL_Error = null;
List<ServiceItem> _serviceItemList = _AGOL_Services.GetOrgServiceList(out _AGOL_Error);
```

```
//Add features to specific feature service
AGOL_Error error = null;
List<Feature> features = new List<Feature>();

Feature feature = new Feature();
feature.geometry = new Geometry();
feature.geometry.x = 23.23;
feature.geometry.y = 31.5;
feature.attributes = new Attributes();
((Attributes)feature.attributes).Junction_MOID = @"Testing";

features.Add(feature);

AddFeaturesResult result = _AGOL_Services.FeatureService_AddFeatures(@"http://services1.arcgis.com/xxxx/arcgis/rest/services/xxxxx/FeatureServer", 0, features, out error);
```

## Screenshot

![alt tag](https://raw.githubusercontent.com/GISGuy/ArcGIS-Online-REST-SDK/master/ArcGIS%20Online%20REST%20SDK/AGOL_Demo/Screenshots/ArcGIS_Online_REST_SDK.png)

Implemented REST API services:

## Installation

Compile and run Demo project.

## Available REST API services

==== User token and information ====

GenerateUserToken

GetUserInfo

GetMyServiceList

GetOrgServiceList

GetServiceInfo

====================================

==== Feature service operations ====

FeatureService_AddFeatures

FeatureService_UpdateFeatures

FeatureService_DeleteFeatures

FeatureService_Layer_Query

====================================

## Under development REST API services

==== Feature Service Administering ====

FeatureService_Definition_Add

FeatureService_Definition_Delete

FeatureService_Definition_Update

FeatureService_Definition_Refresh

FeatureService_Definition_Status

====================================

==== Feature Service Layer Administering ====

FeatureService_Definition_Info

FeatureService_Layer_Definition_Add

FeatureService_Layer_Definition_Delete

FeatureService_Layer_Definition_Update

FeatureService_Layer_Definition_Refresh

====================================

==== Map Service Administering ====

MapService_Edit

MapService_Refresh

MapService_Status

====================================

==== Map Administering ====

WebMap_Info

WebMap_Update

WebMap_Delete

====================================

## API Reference

Will be added later.

## License

ArcGIS Online REST API in C# is available under the MIT license.
