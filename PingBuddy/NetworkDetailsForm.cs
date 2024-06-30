using System;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Management;
using System.Linq;

namespace PingBuddy
{
    public partial class NetworkDetailsForm : Form
    {
        public NetworkDetailsForm()
        {
            InitializeComponent();
            GatherAndDisplayNetworkInfo();
        }

        private void GatherAndDisplayNetworkInfo()
        {
            detailsTreeView.BeginUpdate();

            // Network Interfaces
            TreeNode interfacesNode = detailsTreeView.Nodes.Add("Network Interfaces");
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                TreeNode nicNode = interfacesNode.Nodes.Add(nic.Name);
                nicNode.Nodes.Add($"Description: {nic.Description}");
                nicNode.Nodes.Add($"Type: {nic.NetworkInterfaceType}");
                nicNode.Nodes.Add($"Status: {nic.OperationalStatus}");
                nicNode.Nodes.Add($"Speed: {nic.Speed} bps");
                nicNode.Nodes.Add($"MAC Address: {nic.GetPhysicalAddress()}");

                IPInterfaceProperties properties = nic.GetIPProperties();
                TreeNode ipNode = nicNode.Nodes.Add("IP Information");
                foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
                {
                    ipNode.Nodes.Add($"IP Address: {ip.Address}");
                    ipNode.Nodes.Add($"Subnet Mask: {ip.IPv4Mask}");
                }

                ipNode.Nodes.Add($"DNS Servers: {string.Join(", ", properties.DnsAddresses)}");
                ipNode.Nodes.Add($"Gateway: {string.Join(", ", properties.GatewayAddresses)}");
            }

            // TCP Connections
            TreeNode tcpNode = detailsTreeView.Nodes.Add("TCP Connections");
            IPGlobalProperties globalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnections = globalProperties.GetActiveTcpConnections();
            foreach (TcpConnectionInformation tcp in tcpConnections.Take(50)) // Limit to 50 connections
            {
                TreeNode connNode = tcpNode.Nodes.Add($"{tcp.LocalEndPoint} <-> {tcp.RemoteEndPoint}");
                connNode.Nodes.Add($"State: {tcp.State}");
            }

            // Network Adapter Configuration
            TreeNode adapterNode = detailsTreeView.Nodes.Add("Network Adapter Configuration");
            using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        TreeNode configNode = adapterNode.Nodes.Add(mo["Description"].ToString());
                        if (mo["IPAddress"] != null)
                            configNode.Nodes.Add($"IP Address: {string.Join(", ", (string[])mo["IPAddress"])}");
                        if (mo["IPSubnet"] != null)
                            configNode.Nodes.Add($"Subnet Mask: {string.Join(", ", (string[])mo["IPSubnet"])}");
                        if (mo["DefaultIPGateway"] != null)
                            configNode.Nodes.Add($"Default Gateway: {string.Join(", ", (string[])mo["DefaultIPGateway"])}");
                        if (mo["DNSServerSearchOrder"] != null)
                            configNode.Nodes.Add($"DNS Servers: {string.Join(", ", (string[])mo["DNSServerSearchOrder"])}");
                        if (mo["DHCPEnabled"] != null)
                            configNode.Nodes.Add($"DHCP Enabled: {mo["DHCPEnabled"]}");
                        if (mo["DHCPServer"] != null)
                            configNode.Nodes.Add($"DHCP Server: {mo["DHCPServer"]}");
                    }
                }
            }

            detailsTreeView.EndUpdate();
            detailsTreeView.ExpandAll();
        }
    }
}