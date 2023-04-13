Imports System.ServiceModel
Imports R_Common
Imports GSM00200Back
Imports R_BackEnd
Imports System.ServiceModel.Channels

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IGSM00200StreamingService" in both code and config file together.
<ServiceContract()>
Public Interface IGSM00200StreamingService

    <OperationContract(Action:="GetTableHDList", ReplyAction:="GetTableHDList")> _
    <FaultContract(GetType(R_ServiceExceptions))> _
    Function GetTableHDList() As Message

    <OperationContract(Action:="GetTableDTList", ReplyAction:="GetTableDTList")> _
    <FaultContract(GetType(R_ServiceExceptions))> _
    Function GetTableDTList() As Message
End Interface
