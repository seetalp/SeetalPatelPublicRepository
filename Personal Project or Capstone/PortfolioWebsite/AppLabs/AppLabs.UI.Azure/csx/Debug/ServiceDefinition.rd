<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="AppLabs.UI.Azure" generation="1" functional="0" release="0" Id="67e72429-d218-4ec5-821c-40c00d1973b4" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="AppLabs.UI.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="AppLabs.UI:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/AppLabs.UI.Azure/AppLabs.UI.AzureGroup/LB:AppLabs.UI:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="AppLabs.UI:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/AppLabs.UI.Azure/AppLabs.UI.AzureGroup/MapAppLabs.UI:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="AppLabs.UIInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/AppLabs.UI.Azure/AppLabs.UI.AzureGroup/MapAppLabs.UIInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:AppLabs.UI:Endpoint1">
          <toPorts>
            <inPortMoniker name="/AppLabs.UI.Azure/AppLabs.UI.AzureGroup/AppLabs.UI/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapAppLabs.UI:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/AppLabs.UI.Azure/AppLabs.UI.AzureGroup/AppLabs.UI/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapAppLabs.UIInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/AppLabs.UI.Azure/AppLabs.UI.AzureGroup/AppLabs.UIInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="AppLabs.UI" generation="1" functional="0" release="0" software="C:\Users\apprentice\Documents\Visual Studio 2013\Projects\AppLabs\AppLabs.UI.Azure\csx\Debug\roles\AppLabs.UI" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;AppLabs.UI&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;AppLabs.UI&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/AppLabs.UI.Azure/AppLabs.UI.AzureGroup/AppLabs.UIInstances" />
            <sCSPolicyUpdateDomainMoniker name="/AppLabs.UI.Azure/AppLabs.UI.AzureGroup/AppLabs.UIUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/AppLabs.UI.Azure/AppLabs.UI.AzureGroup/AppLabs.UIFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="AppLabs.UIUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="AppLabs.UIFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="AppLabs.UIInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="3a987e3a-9272-4d2d-a903-269d004ce47f" ref="Microsoft.RedDog.Contract\ServiceContract\AppLabs.UI.AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="43fa20c7-7e9d-4f72-80ec-5b341c2a59d9" ref="Microsoft.RedDog.Contract\Interface\AppLabs.UI:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/AppLabs.UI.Azure/AppLabs.UI.AzureGroup/AppLabs.UI:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>