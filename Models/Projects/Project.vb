Imports System.Runtime.Serialization
Imports DotNetNuke.ComponentModel.DataAnnotations

Namespace Models.Projects
 Partial Public Class Project

  <IgnoreColumn()>
  <DataMember()>
  Public Property SelectedProjectTypes As List(Of Integer)

 End Class
End Namespace


