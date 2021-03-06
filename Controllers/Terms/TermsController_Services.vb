Imports System.Net
Imports System.Net.Http
Imports System.Web.Http

Imports DotNetNuke.Web.Api

Namespace Controllers.Terms

 Partial Public Class TermsController
  Inherits DnnApiController

#Region " Service Methods "
  <HttpGet()>
  <AllowAnonymous()>
  Public Function Search(query As String) As HttpResponseMessage
   Return Request.CreateResponse(HttpStatusCode.OK, SearchTerms(query))
  End Function
#End Region

 End Class
End Namespace
