Imports System.ServiceModel
Imports R_Common
Imports GSI00100Back
Imports R_BackEnd
Imports System.ServiceModel.Channels

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IGSH00100StreamingService" in both code and config file together.
<ServiceContract()>
Public Interface IGSI00100StreamingService

    <OperationContract(Action:="GetCmbGroup", ReplyAction:="GetCmbGroup")> _
    <FaultContract(GetType(R_ServiceExceptions))> _
    Function GetCmbGroup() As Message

    <OperationContract(Action:="GetCmbByField", ReplyAction:="GetCmbByField")> _
    <FaultContract(GetType(R_ServiceExceptions))> _
    Function GetCmbByField() As Message

    <OperationContract(Action:="GetCmbUser", ReplyAction:="GetCmbUser")> _
    <FaultContract(GetType(R_ServiceExceptions))> _
    Function GetCmbUser() As Message

    <OperationContract(Action:="GetCmbProgram", ReplyAction:="GetCmbProgram")> _
    <FaultContract(GetType(R_ServiceExceptions))> _
    Function GetCmbProgram() As Message

    <OperationContract(Action:="GetAuditHistory", ReplyAction:="GetAuditHistory")> _
    <FaultContract(GetType(R_ServiceExceptions))> _
    Function GetAuditHistory() As Message

    <OperationContract(Action:="GetAuditHistoryByPK", ReplyAction:="GetAuditHistoryByPK")> _
    <FaultContract(GetType(R_ServiceExceptions))> _
    Function GetAuditHistoryByPK() As Message

    <OperationContract()> _
    <FaultContract(GetType(R_ServiceExceptions))> _
    Sub Dummy(ByVal poPar As List(Of CmbDTO), _
              ByVal poPar2 As List(Of ParameterDTO))

End Interface
