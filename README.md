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
//Query user's orgnization's service list
AGOL_Error _AGOL_Error = null;
List<ServiceItem> _serviceItemList = _AGOL_Services.GetOrgServiceList(out _AGOL_Error);
```

## Screenshot

![alt tag](https://raw.githubusercontent.com/GISGuy/ArcGIS-Online-REST-SDK/master/ArcGIS%20Online%20REST%20SDK/AGOL_Demo/Screenshots/ArcGIS_Online_REST_SDK.png)

Implemented REST API services:

## Installation

Compile and run Demo project.

## API Reference

Will be added later.

## License

MIT License
