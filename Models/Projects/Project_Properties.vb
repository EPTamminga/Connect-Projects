Imports System
Imports System.Runtime.Serialization
Imports DotNetNuke.ComponentModel.DataAnnotations

Namespace Models.Projects

 <TableName("vw_Connect_Projects_Projects")>
 <PrimaryKey("ProjectId", AutoIncrement:=True)>
 <DataContract()>
 <Scope("ModuleId")>
 Partial Public Class Project
  Inherits ProjectBase

#Region " Private Members "
#End Region

#Region " Constructors "
  Public Sub New()
   MyBase.New()
  End Sub
#End Region

#Region " Public Properties "
  <DataMember()>
  Public Property LicenseType As String = ""
  <DataMember()>
  Public Property ProjectColor As String = ""
  <DataMember()>
  Public Property CreatedByUser As String = ""
  <DataMember()>
  Public Property LastModifiedByUser As String = ""
  <DataMember()>
  Public Property NrLiveLinks As Int32 
#End Region

#Region " Public Methods "
  Public Function GetProjectBase() As ProjectBase
   Dim base As New ProjectBase
   base.Aims = Aims
   base.ModuleId = ModuleId
   base.CreatedByUserID = CreatedByUserID
   base.CreatedOnDate = CreatedOnDate
   base.Dependencies = Dependencies
   base.Description = Description
   base.FirstImage = FirstImage
   base.LastModifiedByUserID = LastModifiedByUserID
   base.LastModifiedOnDate = LastModifiedOnDate
   base.LicenseTypeId = LicenseTypeId
   base.Owners = Owners
   base.People = People
   base.ProjectId = ProjectId
   base.ProjectName = ProjectName
   base.Status = Status
   base.Visible = Visible
   Return base
  End Function
#End Region

 End Class
End Namespace


