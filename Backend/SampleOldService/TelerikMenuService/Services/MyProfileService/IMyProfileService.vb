Imports System.ServiceModel
Imports R_Common
Imports MyProfileBack
Imports R_BackEnd
Imports System.ServiceModel.Channels

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IMyProfileService" in both code and config file together.
<ServiceContract()>
Public Interface IMyProfileService

    Inherits R_IServicebase(Of MyProfileDTO)

    <OperationContract()> _
 <FaultContract(GetType(R_ServiceExceptions))> _
    Function GetImage(pcUserId As String) As SliceDTO
End Interface
