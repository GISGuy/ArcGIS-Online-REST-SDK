using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcGIS_Online_REST_SDK;
using ArcGIS_Online_REST_SDK.Data;

namespace AGOL_Demo
{
    public partial class Main : Form
    {
        private AGOL_Services _AGOL_Services;
        private List<ServiceItem> _serviceItemList;

        public Main()
        {
            InitializeComponent();

            _AGOL_Services = new AGOL_Services();
        }

        private void Log()
        {
            rtx_log.AppendText("=======================================================================" + Environment.NewLine);
        }

        private void Log(String logInfo)
        {
            rtx_log.AppendText(DateTime.Now.ToString() + ": " + logInfo + Environment.NewLine);
        }

        private void Log(Exception ex)
        {
            rtx_log.AppendText(DateTime.Now.ToString() + ": " + ex.ToString() + Environment.NewLine);
        }

        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(Math.Round(unixTimeStamp / 1000d)).ToLocalTime();
            return dtDateTime;
        }

        private void bt_signIn_Click(object sender, EventArgs e)
        {
            Log();
            String userName = tb_userName.Text;
            String password = tb_password.Text;

            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                Log("User name or password cannot be empty!");
                return;
            }

            Log("Sending user name/password to generate token...");
            AGOL_Error _AGOL_Error = null;
            try
            {
                UserToken _userToken = _AGOL_Services.GenerateUserToken(userName, password, out _AGOL_Error);
                if (_AGOL_Error != null)
                {
                    Log("Generate user token failed! Error(" + _AGOL_Error.Code.ToString() + ") :" + _AGOL_Error.Message);
                    return;
                }

                if (_userToken == null)
                {
                    Log("Generate user token failed! Unknown Error!");
                    return;
                }

                Log("New token generated: " + _userToken.Token + " (expires on " + UnixTimeStampToDateTime(_userToken.Expires).ToString() + ")");
                Log();

                Log("Getting user's info...");
                UserInfo _userInfo = _AGOL_Services.GetUserInfo(out _AGOL_Error);
                if (_AGOL_Error != null)
                {
                    Log("Getting user info failed! Error(" + _AGOL_Error.Code.ToString() + ") :" + _AGOL_Error.Message);
                    return;
                }

                if (_userToken == null)
                {
                    Log("Getting user info failed! Unknown Error!");
                    return;
                }

                Log(String.Format("Your user info: Email - {0} Role - {1}", _userInfo.Email, _userInfo.Role));

                bt_listServices.Enabled = true;
                bt_listWebMaps.Enabled = true;
                cb_featureService.Enabled = true;
                cb_mapService.Enabled = true;
                cb_webMap.Enabled = true;
                cb_others.Enabled = true;
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }
        
        private void bt_listServices_Click(object sender, EventArgs e)
        {
            lv_services.Items.Clear();

            Log();

            Log("Listing all services...");

            AGOL_Error _AGOL_Error = null;
            try
            {
                _serviceItemList = _AGOL_Services.GetMyServiceList(out _AGOL_Error);
                if (_AGOL_Error != null)
                {
                    Log("Getting service list failed! Error(" + _AGOL_Error.Code.ToString() + ") :" + _AGOL_Error.Message);
                    return;
                }

                if (_serviceItemList == null)
                {
                    Log("Getting service list failed! Unknown Error!");
                    return;
                }

                Log("Getting service successed. You have " + _serviceItemList.Count + " services!");
                UpdateServiceListView();
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }
        
        private void bt_listOrgServices_Click(object sender, EventArgs e)
        {
            lv_services.Items.Clear();

            Log();

            Log("Listing all services...");

            AGOL_Error _AGOL_Error = null;
            try
            {
                _serviceItemList = _AGOL_Services.GetOrgServiceList(out _AGOL_Error);
                if (_AGOL_Error != null)
                {
                    Log("Getting service list failed! Error(" + _AGOL_Error.Code.ToString() + ") :" + _AGOL_Error.Message);
                    return;
                }

                if (_serviceItemList == null)
                {
                    Log("Getting service list failed! Unknown Error!");
                    return;
                }

                Log("Getting service successed. You have " + _serviceItemList.Count + " services!");
                UpdateServiceListView();
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private void cb_featureService_CheckedChanged(object sender, EventArgs e)
        {
            UpdateServiceListView();
        }

        private void cb_mapService_CheckedChanged(object sender, EventArgs e)
        {
            UpdateServiceListView();
        }

        private void cb_webMap_CheckedChanged(object sender, EventArgs e)
        {
            UpdateServiceListView();
        }

        private void cb_others_CheckedChanged(object sender, EventArgs e)
        {
            UpdateServiceListView();
        }

        private void UpdateServiceListView()
        {
            lv_services.Items.Clear();
            Boolean bFeatureService = cb_featureService.Checked;
            Boolean bMapService = cb_mapService.Checked;
            Boolean bWebMap = cb_webMap.Checked;
            Boolean bOthers = cb_others.Checked;

            foreach (ServiceItem serviceItem in _serviceItemList)
            {
                ListViewItem lvi = new ListViewItem(serviceItem.ID);
                lvi.SubItems.AddRange(new String[] { serviceItem.Owner, serviceItem.Name == null ? "" : serviceItem.Name, serviceItem.Title == null ? "" : serviceItem.Title, serviceItem.Type, serviceItem.Description == null ? "" : serviceItem.Description, serviceItem.Tags == null || serviceItem.Tags.Length == 0 ? "" : String.Join(",", serviceItem.Tags), serviceItem.URL });

                switch (serviceItem.Type)
                {
                    case "Feature Service":
                        if (!bFeatureService)
                        {
                            continue;
                        }
                        lvi.BackColor = Color.FromArgb(0, 192, 0);
                        break;
                    case "Map Service":
                        if (!bMapService)
                        {
                            continue;
                        }
                        lvi.BackColor = Color.FromArgb(128, 128, 255);
                        break;
                    case "Web Map":
                        if (!bWebMap)
                        {
                            continue;
                        }
                        lvi.BackColor = Color.FromArgb(192, 0, 192);
                        break;
                    default:
                        if (!bOthers)
                        {
                            continue;
                        }
                        lvi.BackColor = Color.Gray;
                        break;
                }

                lv_services.Items.Add(lvi);
            }
        }
    }

    public class Attributes
    {
        public int OBJECTID { get; set; }
        public String Junction_MOID { get; set; }
    }
}
