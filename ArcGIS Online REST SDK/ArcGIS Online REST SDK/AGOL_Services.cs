using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ArcGIS_Online_REST_SDK.Data;
using System.Net;
using System.Collections.Specialized;

namespace ArcGIS_Online_REST_SDK
{
    public class AGOL_Services
    {
        private String _userName;
        private String _password;
        private String _sToken;
        private UserToken _userToken;
        private UserInfo _userInfo;
        private JavaScriptSerializer _ser = new JavaScriptSerializer();

        #region User token and information

        /// <summary>
        /// Generating user token from ArcGIS Online
        /// </summary>
        /// <param name="username">User name for generating token</param>
        /// <param name="password">Password for generating token</param>
        /// <param name="error">Check this error if returned user token is null</param>
        /// <param name="expiration">Expiration time in minutes. 60 minutes by default.</param>
        /// <returns></returns>
        public UserToken GenerateUserToken(String username, String password, out AGOL_Error error, int expiration = 60)
        {
            error = null;
            if (String.IsNullOrEmpty(username)) throw new ArgumentNullException("User Name");
            if (String.IsNullOrEmpty(password)) throw new ArgumentNullException("Password");

            using (WebClient webClient = new WebClient())
            {
                NameValueCollection reqparm = new NameValueCollection();

                reqparm.Add("username", username);
                reqparm.Add("password", password);
                reqparm.Add("referer", "localhost");
                reqparm.Add("expiration", expiration.ToString());
                reqparm.Add("f", "json");

                byte[] responsebytes = webClient.UploadValues("https://www.arcgis.com/sharing/rest/generateToken", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                //Check the result is error or not
                AGOL_Error_Wrapper error_Wrapper = (AGOL_Error_Wrapper)_ser.Deserialize(responsebody, typeof(AGOL_Error_Wrapper));
                if (error_Wrapper != null && error_Wrapper.Error != null && error_Wrapper.Error.Code != 0 && !String.IsNullOrEmpty(error_Wrapper.Error.Message))
                {
                    error = error_Wrapper.Error;
                    return null;
                }

                UserToken userToken = (UserToken)_ser.Deserialize(responsebody, typeof(UserToken));
                if (userToken != null)
                {
                    _userToken = userToken;
                }

                return _userToken;
            }
        }

        /// <summary>
        /// Get user's information based on token
        /// </summary>
        /// <param name="error">Check this error if returned user info is null</param>
        /// <returns></returns>
        public UserInfo GetUserInfo(out AGOL_Error error)
        {
            error = null;
            if (_userToken == null) throw new ArgumentNullException("Invalid user token!");

            using (WebClient webClient = new WebClient())
            {
                NameValueCollection reqparm = new NameValueCollection();

                reqparm.Add("token", _userToken.Token);
                reqparm.Add("f", "json");

                byte[] responsebytes = webClient.UploadValues("https://www.arcgis.com/sharing/rest/accounts/self", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                //Check the result is error or not
                AGOL_Error_Wrapper error_Wrapper = (AGOL_Error_Wrapper)_ser.Deserialize(responsebody, typeof(AGOL_Error_Wrapper));
                if (error_Wrapper != null && error_Wrapper.Error != null && error_Wrapper.Error.Code != 0 && !String.IsNullOrEmpty(error_Wrapper.Error.Message))
                {
                    error = error_Wrapper.Error;
                    return null;
                }

                UserInfo_Wrapper userInfo_Wrapper = (UserInfo_Wrapper)_ser.Deserialize(responsebody, typeof(UserInfo_Wrapper));
                if (userInfo_Wrapper != null)
                {
                    _userInfo = userInfo_Wrapper.User;
                }

                return _userInfo;
            }
        }

        /// <summary>
        /// Get user's service list
        /// </summary>
        /// <param name="error">Check this error if returned service list is null</param>
        /// <returns></returns>
        public List<ServiceItem> GetMyServiceList(out AGOL_Error error)
        {
            error = null;
            if (_userToken == null || _userInfo == null) throw new ArgumentNullException("Invalid user token!");

            using (WebClient webClient = new WebClient())
            {
                Boolean end = false;
                int index = 0;
                List<ServiceItem> serviceItemList = new List<ServiceItem>();

                while (!end)
                {
                    NameValueCollection reqparm = new NameValueCollection();

                    reqparm.Add("token", _userToken.Token);
                    reqparm.Add("num", "100");
                    reqparm.Add("start", index.ToString());
                    reqparm.Add("f", "json");

                    byte[] responsebytes = webClient.UploadValues("https://www.arcgis.com/sharing/rest/content/users/" + _userInfo.UserName, "POST", reqparm);
                    string responsebody = Encoding.UTF8.GetString(responsebytes);

                    //Check the result is error or not
                    AGOL_Error_Wrapper error_Wrapper = (AGOL_Error_Wrapper)_ser.Deserialize(responsebody, typeof(AGOL_Error_Wrapper));
                    if (error_Wrapper != null && error_Wrapper.Error != null && error_Wrapper.Error.Code != 0 && !String.IsNullOrEmpty(error_Wrapper.Error.Message))
                    {
                        error = error_Wrapper.Error;
                        end = true;
                        break;
                    }

                    Services_Wrapper services_Wrapper = (Services_Wrapper)_ser.Deserialize(responsebody, typeof(Services_Wrapper));

                    if (services_Wrapper == null)
                    {
                        end = true;
                    }
                    else if (services_Wrapper.Total != 100)
                    {
                        serviceItemList.AddRange(services_Wrapper.Items);
                        end = true;
                    }
                    else
                    {
                        serviceItemList.AddRange(services_Wrapper.Items);
                        index += 100;
                    }
                }

                return serviceItemList;
            }
        }

        /// <summary>
        /// Get user's orgnization's service list
        /// </summary>
        /// <param name="error">Check this error if returned service list is null</param>
        /// <returns></returns>
        public List<ServiceItem> GetOrgServiceList(out AGOL_Error error)
        {
            error = null;
            if (_userToken == null || _userInfo == null) throw new ArgumentNullException("Invalid user token!");

            using (WebClient webClient = new WebClient())
            {
                Boolean end = false;
                int index = 0;
                List<ServiceItem> serviceItemList = new List<ServiceItem>();

                while (!end)
                {
                    NameValueCollection reqparm = new NameValueCollection();

                    reqparm.Add("token", _userToken.Token);
                    reqparm.Add("num", "100");
                    reqparm.Add("start", index.ToString());
                    reqparm.Add("sortField", "numViews");
                    reqparm.Add("sortOrder", "desc");
                    reqparm.Add("q", "orgid:" + _userInfo.OrgID);
                    reqparm.Add("f", "json");

                    byte[] responsebytes = webClient.UploadValues("https://www.arcgis.com/sharing/rest/search", "POST", reqparm);
                    string responsebody = Encoding.UTF8.GetString(responsebytes);

                    //Check the result is error or not
                    AGOL_Error_Wrapper error_Wrapper = (AGOL_Error_Wrapper)_ser.Deserialize(responsebody, typeof(AGOL_Error_Wrapper));
                    if (error_Wrapper != null && error_Wrapper.Error != null && error_Wrapper.Error.Code != 0 && !String.IsNullOrEmpty(error_Wrapper.Error.Message))
                    {
                        error = error_Wrapper.Error;
                        end = true;
                        break;
                    }

                    OrgServices_Wrapper services_Wrapper = (OrgServices_Wrapper)_ser.Deserialize(responsebody, typeof(OrgServices_Wrapper));

                    if (services_Wrapper == null)
                    {
                        end = true;
                    }
                    else if (services_Wrapper.Total != 100)
                    {
                        serviceItemList.AddRange(services_Wrapper.Results);
                        end = true;
                    }
                    else
                    {
                        serviceItemList.AddRange(services_Wrapper.Results);
                        index += 100;
                    }
                }

                return serviceItemList;
            }
        }
        
        /// <summary>
        /// Get service info based on service URL
        /// </summary>
        /// <param name="serviceURL">Service URL. For instance: http://services1.arcgis.com/XXXXX/ArcGIS/rest/services/XXXXX/FeatureServer or http://tiles.arcgis.com/tiles/XXXXX/arcgis/rest/services/XXXXX/MapServer</param>
        /// <param name="error">Check this error if returned service info is null</param>
        /// <returns></returns>
        public ServiceInfo GetServiceInfo(String serviceURL, out AGOL_Error error)
        {
            error = null;
            if (_userToken == null || _userInfo == null) throw new ArgumentNullException("Invalid user token!");

            using (WebClient webClient = new WebClient())
            {
                NameValueCollection reqparm = new NameValueCollection();

                reqparm.Add("token", _userToken.Token);
                reqparm.Add("f", "json");

                byte[] responsebytes = webClient.UploadValues(serviceURL, "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                //Check the result is error or not
                AGOL_Error_Wrapper error_Wrapper = (AGOL_Error_Wrapper)_ser.Deserialize(responsebody, typeof(AGOL_Error_Wrapper));
                if (error_Wrapper != null && error_Wrapper.Error != null && error_Wrapper.Error.Code != 0 && !String.IsNullOrEmpty(error_Wrapper.Error.Message))
                {
                    error = error_Wrapper.Error;
                    return null;
                }

                return (ServiceInfo)_ser.Deserialize(responsebody, typeof(ServiceInfo));
            }
        }

        #endregion

        #region Feature service operations

        public AddFeaturesResult FeatureService_AddFeatures(String serviceURL, int layerID, List<Feature> features, out AGOL_Error error)
        {
            error = null;
            if (_userToken == null || _userInfo == null) throw new ArgumentNullException("Invalid user token!");

            using (WebClient webClient = new WebClient())
            {
                NameValueCollection reqparm = new NameValueCollection();

                reqparm.Add("token", _userToken.Token);
                reqparm.Add("f", "json");
                reqparm.Add("features", _ser.Serialize(features));

                byte[] responsebytes = webClient.UploadValues(serviceURL + "/" + layerID.ToString() + "/addFeatures", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                //Check the result is error or not
                AGOL_Error_Wrapper error_Wrapper = (AGOL_Error_Wrapper)_ser.Deserialize(responsebody, typeof(AGOL_Error_Wrapper));
                if (error_Wrapper != null && error_Wrapper.Error != null && error_Wrapper.Error.Code != 0 && !String.IsNullOrEmpty(error_Wrapper.Error.Message))
                {
                    error = error_Wrapper.Error;
                    return null;
                }

                return (AddFeaturesResult)_ser.Deserialize(responsebody, typeof(AddFeaturesResult));
            }
        }

        public UpdateFeaturesResult FeatureService_UpdateFeatures(String serviceURL, int layerID, List<Feature> features, out AGOL_Error error)
        {
            error = null;
            if (_userToken == null || _userInfo == null) throw new ArgumentNullException("Invalid user token!");

            using (WebClient webClient = new WebClient())
            {
                NameValueCollection reqparm = new NameValueCollection();

                reqparm.Add("token", _userToken.Token);
                reqparm.Add("f", "json");
                reqparm.Add("features", _ser.Serialize(features));

                byte[] responsebytes = webClient.UploadValues(serviceURL + "/" + layerID.ToString() + "/updateFeatures", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                //Check the result is error or not
                AGOL_Error_Wrapper error_Wrapper = (AGOL_Error_Wrapper)_ser.Deserialize(responsebody, typeof(AGOL_Error_Wrapper));
                if (error_Wrapper != null && error_Wrapper.Error != null && error_Wrapper.Error.Code != 0 && !String.IsNullOrEmpty(error_Wrapper.Error.Message))
                {
                    error = error_Wrapper.Error;
                    return null;
                }

                return (UpdateFeaturesResult)_ser.Deserialize(responsebody, typeof(UpdateFeaturesResult));
            }
        }

        public DeleteFeaturesResult FeatureService_DeleteFeatures(String serviceURL, int layerID, List<int> OBJECTIDs, String whereClause, out AGOL_Error error)
        {
            error = null;
            if (_userToken == null || _userInfo == null) throw new ArgumentNullException("Invalid user token!");

            using (WebClient webClient = new WebClient())
            {
                NameValueCollection reqparm = new NameValueCollection();

                reqparm.Add("token", _userToken.Token);
                reqparm.Add("f", "json");
                if (OBJECTIDs != null && OBJECTIDs.Count > 0)
                {
                    reqparm.Add("objectIds", String.Join(",", OBJECTIDs));
                }
                if (!String.IsNullOrEmpty(whereClause))
                {
                    reqparm.Add("where", whereClause);
                }

                byte[] responsebytes = webClient.UploadValues(serviceURL + "/" + layerID.ToString() + "/deleteFeatures", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                //Check the result is error or not
                AGOL_Error_Wrapper error_Wrapper = (AGOL_Error_Wrapper)_ser.Deserialize(responsebody, typeof(AGOL_Error_Wrapper));
                if (error_Wrapper != null && error_Wrapper.Error != null && error_Wrapper.Error.Code != 0 && !String.IsNullOrEmpty(error_Wrapper.Error.Message))
                {
                    error = error_Wrapper.Error;
                    return null;
                }

                return (DeleteFeaturesResult)_ser.Deserialize(responsebody, typeof(DeleteFeaturesResult));
            }
        }

        public QueryResult FeatureService_Layer_Query(String serviceURL, int layerID, String whereClause, out AGOL_Error error, Boolean returnGeometry = true, Boolean returnIdsOnly = false, Boolean returnCountOnly = false)
        {
            error = null;
            if (_userToken == null || _userInfo == null) throw new ArgumentNullException("Invalid user token!");
            if (String.IsNullOrEmpty(whereClause)) throw new ArgumentNullException("Where clause");

            using (WebClient webClient = new WebClient())
            {
                NameValueCollection reqparm = new NameValueCollection();

                reqparm.Add("token", _userToken.Token);
                reqparm.Add("f", "json");
                reqparm.Add("where", whereClause);
                reqparm.Add("returnGeometry", returnGeometry.ToString());
                reqparm.Add("returnIdsOnly", returnIdsOnly.ToString());
                reqparm.Add("returnCountOnly", returnCountOnly.ToString());

                byte[] responsebytes = webClient.UploadValues(serviceURL + "/" + layerID.ToString() + "/query", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                //Check the result is error or not
                AGOL_Error_Wrapper error_Wrapper = (AGOL_Error_Wrapper)_ser.Deserialize(responsebody, typeof(AGOL_Error_Wrapper));
                if (error_Wrapper != null && error_Wrapper.Error != null && error_Wrapper.Error.Code != 0 && !String.IsNullOrEmpty(error_Wrapper.Error.Message))
                {
                    error = error_Wrapper.Error;
                    return null;
                }

                return (QueryResult)_ser.Deserialize(responsebody, typeof(QueryResult));
            }
        }

        #endregion

        #region Feature Service Administering

        public void FeatureService_Definition_Add()
        {

        }

        public void FeatureService_Definition_Delete()
        {
        }

        public void FeatureService_Definition_Update()
        {
        }

        public void FeatureService_Definition_Refresh()
        {
        }

        public void FeatureService_Definition_Status()
        {
        }

        #endregion

        #region Feature Service Layer Administering

        public void FeatureService_Definition_Info()
        {
        }

        public void FeatureService_Layer_Definition_Add()
        {
        }

        public void FeatureService_Layer_Definition_Delete()
        {
        }

        public void FeatureService_Layer_Definition_Update()
        {
        }

        public void FeatureService_Layer_Definition_Refresh()
        {
        }

        #endregion

        #region Map Service Administering

        public void MapService_Edit()
        {
        }

        public void MapService_Refresh()
        {
        }

        public void MapService_Status()
        {
        }

        #endregion

        #region Web Map Administering

        public void WebMap_Info()
        {
        }

        public void WebMap_Update()
        {
        }

        public void WebMap_Delete()
        {
        }

        #endregion
    }
}
