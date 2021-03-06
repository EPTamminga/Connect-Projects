Imports System
Imports System.Runtime.Serialization
Imports DotNetNuke.ComponentModel.DataAnnotations

Namespace Models.Urls
  <TableName("Connect_Projects_Urls")>
  <PrimaryKey("UrlId", AutoIncrement:=True)>
  <DataContract()>
  Partial Public Class UrlBase

#Region " Private Members "
#End Region
	
#Region " Constructors "
  Public Sub New()
  End Sub

  Public Sub New(urlId As Int32, description As String, isDead As Boolean, lastChange As Date, lastChecked As Date, projectId As Int32, retries As Int32, url As String, urlType As Int32)
   Me.Description = description
   Me.IsDead = isDead
   Me.LastChange = lastChange
   Me.LastChecked = lastChecked
   Me.ProjectId = projectId
   Me.Retries = retries
   Me.Url = url
   Me.UrlId = urlId
   Me.UrlType = urlType
  End Sub
#End Region
	
#Region " Public Properties "
  <DataMember()>
  Public Property Description As String = ""
  <DataMember()>
  Public Property IsDead As Boolean = False
  <DataMember()>
  Public Property LastChange As Date? 
  <DataMember()>
  Public Property LastChecked As Date? 
  <DataMember()>
  Public Property ProjectId As Int32 = -1
  <DataMember()>
  Public Property Retries As Int32? 
  <DataMember()>
  Public Property Url As String = ""
  <DataMember()>
  Public Property UrlId As Int32 = -1
  <DataMember()>
  Public Property UrlType As Int32 = -1
#End Region

#Region " Methods "
  'Public Sub ReadUrlBase(url As UrlBase)
  ' If url.Description IsNot Nothing Then Description = url.Description
  ' IsDead = url.IsDead
  ' If Not url.LastChange = Date.MinValue Then LastChange = url.LastChange
  ' If Not url.LastChecked = Date.MinValue Then LastChecked = url.LastChecked
  ' If url.ProjectId > -1 Then ProjectId = url.ProjectId
  ' If url.Retries > -1 Then Retries = url.Retries
  ' If url.Url IsNot Nothing Then Url = url.Url
  ' If url.UrlId > -1 Then UrlId = url.UrlId
  ' If url.UrlType > -1 Then UrlType = url.UrlType
  'End Sub
#End Region

 End Class
End Namespace


