Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Connect.DNN.Modules.Projects.Models.Projects

Imports DotNetNuke.Web.Api

Namespace Controllers.Projects

 Partial Public Class ProjectsController
  Inherits DnnApiController

#Region " Service Methods "
  <HttpGet()>
  <DnnModuleAuthorize(AccessLevel:=DotNetNuke.Security.SecurityAccessLevel.View)>
  Public Function Projects() As HttpResponseMessage
   Return Request.CreateResponse(HttpStatusCode.OK, GetProjects(ActiveModule.ModuleID))
  End Function

  <HttpGet()>
  <DnnModuleAuthorize(AccessLevel:=DotNetNuke.Security.SecurityAccessLevel.View)>
  Public Function Project(id As Integer) As HttpResponseMessage
   If id = -1 Then
    Return Request.CreateResponse(HttpStatusCode.OK, New Project)
   Else
    Return Request.CreateResponse(HttpStatusCode.OK, GetProject(ActiveModule.ModuleID, id))
   End If
  End Function

  <HttpPost()>
  <DnnModuleAuthorize(AccessLevel:=DotNetNuke.Security.SecurityAccessLevel.View)>
  Public Function Put(project As ProjectBase) As HttpResponseMessage
   If project.ProjectId = -1 Then
    Dim projectToUpdate As New ProjectBase
    projectToUpdate.ReadProjectBase(project)
    projectToUpdate.ModuleId = ActiveModule.ModuleID
    AddProject(projectToUpdate, UserInfo.UserID)
   Else
    Dim projectToUpdate As ProjectBase = GetProject(ActiveModule.ModuleID, project.ProjectId).GetProjectBase()
    projectToUpdate.ReadProjectBase(project)
    UpdateProject(projectToUpdate, UserInfo.UserID)
   End If
   Return Request.CreateResponse(HttpStatusCode.OK, True)
  End Function
#End Region

 End Class
End Namespace
