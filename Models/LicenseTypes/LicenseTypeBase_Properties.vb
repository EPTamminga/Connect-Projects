Imports System
Imports System.Runtime.Serialization
Imports DotNetNuke.ComponentModel.DataAnnotations

Namespace Models.LicenseTypes
  <TableName("Connect_Projects_LicenseTypes")>
  <PrimaryKey("LicenseTypeId", AutoIncrement:=True)>
  <DataContract()>
  Partial Public Class LicenseTypeBase

#Region " Private Members "
#End Region
	
#Region " Constructors "
  Public Sub New()
  End Sub

  Public Sub New(licenseTypeId As Int32, projectColor As String, typeDescription As String)
   Me.LicenseTypeId = licenseTypeId
   Me.ProjectColor = projectColor
   Me.TypeDescription = typeDescription
  End Sub
#End Region
	
#Region " Public Properties "
  <DataMember()>
  Public Property LicenseTypeId As Int32 = -1
  <DataMember()>
  Public Property ProjectColor As String = ""
  <DataMember()>
  Public Property TypeDescription As String = ""
#End Region

#Region " Methods "
  Public Sub ReadLicenseTypeBase(licensetype As LicenseTypeBase)
   If licensetype.LicenseTypeId > -1 Then LicenseTypeId = licensetype.LicenseTypeId
   If licensetype.ProjectColor IsNot Nothing Then ProjectColor = licensetype.ProjectColor
   If licensetype.TypeDescription IsNot Nothing Then TypeDescription = licensetype.TypeDescription
  End Sub
#End Region

 End Class
End Namespace


