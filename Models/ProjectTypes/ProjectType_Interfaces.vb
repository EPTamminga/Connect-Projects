Imports System
Imports System.Data
Imports System.Xml.Serialization

Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Services.Tokens

Namespace Models.ProjectTypes

  <Serializable(), XmlRoot("ProjectType")>
  Partial Public Class ProjectType

#Region " IHydratable Implementation "
 Public Overrides Sub Fill(dr As IDataReader)
   MyBase.Fill(dr)
  ProjectName = Convert.ToString(Null.SetNull(dr.Item("ProjectName"), ProjectName))
  Visible = Convert.ToBoolean(Null.SetNull(dr.Item("Visible"), Visible))
  TypeDescription = Convert.ToString(Null.SetNull(dr.Item("TypeDescription"), TypeDescription))
  TypeIcon = Convert.ToString(Null.SetNull(dr.Item("TypeIcon"), TypeIcon))
 End Sub
#End Region

#Region " IPropertyAccess Implementation "
  Public Overrides Function GetProperty(strPropertyName As String, strFormat As String, formatProvider As System.Globalization.CultureInfo, accessingUser As DotNetNuke.Entities.Users.UserInfo, accessLevel As DotNetNuke.Services.Tokens.Scope, ByRef propertyNotFound As Boolean) As String
   Dim outputFormat As String = strFormat
   If strFormat = String.Empty Then
    outputFormat = "D"
   End If
  Select Case strPropertyName.ToLower
   Case "projectname"
    Return PropertyAccess.FormatString(ProjectName, strFormat)
   Case "visible"
    Return Visible.ToString
   Case "visibleyesno"
    Return PropertyAccess.Boolean2LocalizedYesNo(Visible, formatProvider)
   Case "typedescription"
    Return PropertyAccess.FormatString(TypeDescription, strFormat)
   Case "typeicon"
    Return PropertyAccess.FormatString(TypeIcon, strFormat)
   Case Else
     Return MyBase.GetProperty(strPropertyName, strFormat, formatProvider, accessingUser, accessLevel, PropertyNotFound)
  End Select

 End Function
#End Region

 End Class
End Namespace


