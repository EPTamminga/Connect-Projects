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
  Public Property TypeDescription As String = ""
  <DataMember()>
  Public Property CreatedByUser As String = ""
  <DataMember()>
  Public Property LastModifiedByUser As String = ""
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
   base.LastModifiedByUserID = LastModifiedByUserID
   base.LastModifiedOnDate = LastModifiedOnDate
   base.Owners = Owners
   base.ProjectId = ProjectId
   base.ProjectName = ProjectName
   base.ProjectType = ProjectType
   base.Status = Status
   base.Url1 = Url1
   base.Url2 = Url2
   base.Visible = Visible
   Return base
  End Function
#End Region

 End Class
End Namespace


