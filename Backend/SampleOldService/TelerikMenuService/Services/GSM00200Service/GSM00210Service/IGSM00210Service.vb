Imports System.ServiceModel
Imports R_Common
Imports GSM00200Back
Imports R_BackEnd

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IGSM00210Service" in both code and config file together.
<ServiceContract()>
Public Interface IGSM00210Service

    Inherits R_IServicebase(Of GSM00210DTO)

End Interface
