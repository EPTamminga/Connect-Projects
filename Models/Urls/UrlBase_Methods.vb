Imports System
Imports System.Data

Imports DotNetNuke.ComponentModel.DataAnnotations
Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Tokens

Namespace Models.Urls
  Partial Public Class UrlBase
  Implements IHydratable
  Implements IPropertyAccess

#Region " IHydratable Methods "
  Public Overridable Sub Fill(dr As IDataReader) Implements IHydratable.Fill


  Description = Convert.ToString(Null.SetNull(dr.Item("Description"), Description))
  IsDead = Convert.ToBoolean(Null.SetNull(dr.Item("IsDead"), IsDead))
  LastChange = CDate(Null.SetNull(dr.Item("LastChange"), LastChange))
  LastChecked = CDate(Null.SetNull(dr.Item("LastChecked"), LastChecked))
  ProjectId = Convert.ToInt32(Null.SetNull(dr.Item("ProjectId"), ProjectId))
  Retries = Convert.ToInt32(Null.SetNull(dr.Item("Retries"), Retries))
  Url = Convert.ToString(Null.SetNull(dr.Item("Url"), Url))
  UrlId = Convert.ToInt32(Null.SetNull(dr.Item("UrlId"), UrlId))
  UrlType = Convert.ToInt32(Null.SetNull(dr.Item("UrlType"), UrlType))

 End Sub

 <IgnoreColumn()>
  Public Property KeyID() As Integer Implements IHydratable.KeyID
  Get
   Return UrlId
  End Get
  Set(value As Integer)
   UrlId = value
  End Set
 End Property
#End Region

#Region " IPropertyAccess Methods "
  Public Overridable Function GetProperty(strPropertyName As String, strFormat As String, formatProvider As System.Globalization.CultureInfo, accessingUser As DotNetNuke.Entities.Users.UserInfo, accessLevel As DotNetNuke.Services.Tokens.Scope, ByRef propertyNotFound As Boolean) As String Implements IPropertyAccess.GetProperty
   Dim outputFormat As String = strFormat
   If strFormat = String.Empty Then
    outputFormat = "D"
   End If
  Select Case strPropertyName.ToLower
   Case "description"
    If Description Is Nothing Then Return ""
    Return PropertyAccess.FormatString(CStr(Description), strFormat)
   Case "isdead"
    Return IsDead.ToString
   Case "isdeadyesno"
    Return PropertyAccess.Boolean2LocalizedYesNo(IsDead, formatProvider)
   Case "lastchange"
    If LastChange Is Nothing Then Return ""
    Return CType(LastChange, Date).ToString(outputFormat, formatProvider)
   Case "lastchecked"
    If LastChecked Is Nothing Then Return ""
    Return CType(LastChecked, Date).ToString(outputFormat, formatProvider)
   Case "projectid"
    Return ProjectId.ToString(outputFormat, formatProvider)
   Case "retries"
    If Retries Is Nothing Then Return ""
    Return CType(Retries, Int32).ToString(outputFormat, formatProvider)
   Case "url"
    Return PropertyAccess.FormatString(Url, strFormat)
   Case "urlid"
    Return UrlId.ToString(outputFormat, formatProvider)
   Case "urltype"
    Return UrlType.ToString(outputFormat, formatProvider)
   Case Else
    propertyNotFound = True
  End Select

  Return Null.NullString
 End Function

  <IgnoreColumn()>
 Public ReadOnly Property Cacheability() As DotNetNuke.Services.Tokens.CacheLevel Implements DotNetNuke.Services.Tokens.IPropertyAccess.Cacheability
  Get
   Return CacheLevel.fullyCacheable
  End Get
 End Property
#End Region

 End Class
End Namespace
