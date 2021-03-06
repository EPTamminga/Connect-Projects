Imports System
Imports System.Data
Imports System.Xml.Serialization

Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Services.Tokens

Namespace Models.Projects

  <Serializable(), XmlRoot("Project")>
  Partial Public Class Project

#Region " IHydratable Implementation "
 Public Overrides Sub Fill(dr As IDataReader)
   MyBase.Fill(dr)
  LicenseType = Convert.ToString(Null.SetNull(dr.Item("LicenseType"), LicenseType))
  ProjectColor = Convert.ToString(Null.SetNull(dr.Item("ProjectColor"), ProjectColor))
  CreatedByUser = Convert.ToString(Null.SetNull(dr.Item("CreatedByUser"), CreatedByUser))
  LastModifiedByUser = Convert.ToString(Null.SetNull(dr.Item("LastModifiedByUser"), LastModifiedByUser))
  NrLiveLinks = Convert.ToInt32(Null.SetNull(dr.Item("NrLiveLinks"), NrLiveLinks))
 End Sub
#End Region

#Region " IPropertyAccess Implementation "
  Public Overrides Function GetProperty(strPropertyName As String, strFormat As String, formatProvider As System.Globalization.CultureInfo, accessingUser As DotNetNuke.Entities.Users.UserInfo, accessLevel As DotNetNuke.Services.Tokens.Scope, ByRef propertyNotFound As Boolean) As String
   Dim outputFormat As String = strFormat
   If strFormat = String.Empty Then
    outputFormat = "D"
   End If
  Select Case strPropertyName.ToLower
   Case "licensetype"
    Return PropertyAccess.FormatString(LicenseType, strFormat)
   Case "projectcolor"
    Return PropertyAccess.FormatString(ProjectColor, strFormat)
   Case "createdbyuser"
    Return PropertyAccess.FormatString(CreatedByUser, strFormat)
   Case "lastmodifiedbyuser"
    Return PropertyAccess.FormatString(LastModifiedByUser, strFormat)
   Case "nrlivelinks"
    Return (NrLiveLinks.ToString(OutputFormat, formatProvider))
   Case Else
     Return MyBase.GetProperty(strPropertyName, strFormat, formatProvider, accessingUser, accessLevel, PropertyNotFound)
  End Select

 End Function
#End Region

 End Class
End Namespace


