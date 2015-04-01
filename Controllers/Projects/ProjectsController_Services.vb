Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Web.Http
Imports Connect.DNN.Modules.Projects.Controllers.ProjectTypes
Imports Connect.DNN.Modules.Projects.Models.Projects

Imports DotNetNuke.Web.Api
Imports Newtonsoft.Json

Namespace Controllers.Projects

 Partial Public Class ProjectsController
  Inherits ModuleApiController

#Region " Service Methods "
  <HttpGet()>
  <DnnModuleAuthorize(AccessLevel:=DotNetNuke.Security.SecurityAccessLevel.View)>
  Public Function Projects() As HttpResponseMessage
   Dim res As IEnumerable(Of Project)
   If Security.Moderator Then
    res = GetProjects(ActiveModule.ModuleID)
   Else
    res = GetProjects(ActiveModule.ModuleID).Where(Function(p) p.Visible Or p.CreatedByUserID = UserInfo.UserID)
   End If
   Return Request.CreateResponse(HttpStatusCode.OK, res)
  End Function

  <HttpGet()>
  <DnnModuleAuthorize(AccessLevel:=DotNetNuke.Security.SecurityAccessLevel.View)>
  Public Function Project(id As Integer) As HttpResponseMessage
   If id = -1 Then
    Return Request.CreateResponse(HttpStatusCode.OK, New Project)
   Else
    Dim res As Project = GetProject(ActiveModule.ModuleID, id)
    If Not res.Visible Then
     If res.CreatedByUserID <> UserInfo.UserID Then
      If Not Security.Moderator Then
       Return Request.CreateResponse(HttpStatusCode.OK, New Project)
      End If
     End If
    End If
    Return Request.CreateResponse(HttpStatusCode.OK, res)
   End If
  End Function

  Public Class ProjectPutDTO
   Public Property project As String
  End Class
  <HttpPost()>
  <DnnModuleAuthorize(PermissionKey:="SUBMITTER")>
  <ValidateAntiForgeryToken()>
  Public Function Put(data As ProjectPutDTO) As HttpResponseMessage
   Dim project As Project = JsonConvert.DeserializeObject(Of Project)(data.project)
   Dim projectToUpdate As New ProjectBase
   Dim projectId As Integer = project.ProjectId
   If project.ProjectId = -1 Then
    projectToUpdate.ReadProjectBase(project)
    projectToUpdate.ModuleId = ActiveModule.ModuleID
    If Security.Moderator Then projectToUpdate.Visible = project.Visible
    projectId = AddProject(projectToUpdate, UserInfo.UserID)
   Else
    projectToUpdate = GetProject(ActiveModule.ModuleID, project.ProjectId).GetProjectBase()
    If projectToUpdate.CreatedByUserID = UserInfo.UserID Or Security.Moderator Then
     projectToUpdate.ReadProjectBase(project)
     If Security.Moderator Then projectToUpdate.Visible = project.Visible
     UpdateProject(projectToUpdate, UserInfo.UserID)
    End If
   End If
   If project.SelectedProjectTypes IsNot Nothing Then
    ProjectTypesController.SetProjectTypes(projectId, project.SelectedProjectTypes)
   End If
   Return Request.CreateResponse(HttpStatusCode.OK, projectId)
  End Function

  <HttpPost()>
  <DnnModuleAuthorize(PermissionKey:="MODERATOR")>
  <ValidateAntiForgeryToken()>
  Public Function Approve(id As Integer, approved As Boolean) As HttpResponseMessage
   Dim projectToUpdate As ProjectBase = GetProject(ActiveModule.ModuleID, id).GetProjectBase()
   projectToUpdate.Visible = approved
   UpdateProject(projectToUpdate, UserInfo.UserID)
   Return Request.CreateResponse(HttpStatusCode.OK, True)
  End Function

  <HttpPost()>
  <DnnModuleAuthorize(PermissionKey:="SUBMITTER")>
  <ValidateAntiForgeryToken()>
  Public Function Delete(id As Integer) As HttpResponseMessage
   Dim projectToDelete As ProjectBase = GetProject(ActiveModule.ModuleID, id).GetProjectBase()
   If projectToDelete.CreatedByUserID = UserInfo.UserID Or Security.Moderator Then
    DeleteProject(projectToDelete)
   End If
   Return Request.CreateResponse(HttpStatusCode.OK, True)
  End Function

  <HttpGet()>
  <DnnModuleAuthorize(AccessLevel:=DotNetNuke.Security.SecurityAccessLevel.View)>
  Public Function Pdf(id As Integer) As HttpResponseMessage
   Dim res As New HttpResponseMessage(HttpStatusCode.OK)
   Dim doc As New Documents.ProjectDocument(ActiveModule.ModuleID, id)
   Dim mem As New IO.MemoryStream
   doc.Save(mem)
   mem.Seek(0, IO.SeekOrigin.Begin)
   res.Content = New StreamContent(mem)
   res.Content.Headers.ContentType = New MediaTypeHeaderValue("application/pdf")
   res.Content.Headers.ContentDisposition = New ContentDispositionHeaderValue("attachment")
   res.Content.Headers.ContentDisposition.FileName = String.Format("Project-{0}.pdf", id)
   Return res
  End Function
#End Region

 End Class
End Namespace
