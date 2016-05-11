// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


namespace System.Runtime.Diagnostics
{
    // When adding an EventLogEventId, an entry must also be added to EventLog.mc.
    // The hexadecimal representation of each EventId ('0xabbbcccc') can be broken down into 3 parts:
    //     Hex digit  1   ('a')    : Severity : a=0 for Success, a=4 for Informational, a=8 for Warning, a=c for Error
    //     Hex digits 2-4 ('bbb')  : Facility : bbb=001 for Tracing, bbb=002 for ServiceModel, bbb=003 for TransactionBridge, bbb=004 for SMSvcHost, bbb=005 for Info_Cards, bbb=006 for Security_Audit
    //     Hex digits 5-8 ('cccc') : Code     : Each event within the same facility is assigned a unique "code".
    // The EventId generated from EventLog.mc must match the EventId assigned here.
    // Order is important: The order here must match the order of strings in EventLog.mc so that the 'code' portions of the EventId's match.
    //     The "code" portions of the EventId's are generated by EventLog.mc as follows:
    //         - The first event for a given facility is assigned the code "0x0001".
    //         - Each subsequent event within this facility, regardless of severity, is assigned the value of the previous event incremented by 1.
    //     Thus, if you add an EventLogEventId below, you must ensure that its code is equal to the code of the previous EventLogEventId in its facility incremented by 1.
    // The Severity and Facility assigned in EventLog.mc must match those assigned via the EventId here.
    // If the EventId's do not match, the EventViewer will not be able to display the strings defined in EventLog.mc correctly.  In this case, the following error message will be included in the logged event:
    //     "The description for Event ID XX from source System.ServiceModel 4.0.0.0 cannot be found..."
    // To inspect the value assigned to the enum elements below, build 'System.ServiceModel.Internals', and inspect System.ServiceModel.Internals\System.ServiceModel.Internals.asmmeta
    // To inspect the EventId generated from EventLog.mc, build 'EventLog', and open ServiceModelEvents.dll.mui (convert EventId from decimal to hex).
    // You could also use any other method of viewing ServiceModelEvents.dll.mui which would allow you to inspect the EventId
    internal enum EventLogEventId : uint
    {
        // EventIDs from shared Diagnostics and Reliability code
        // All EventId's beneath 'FailedToSetupTracing', until the next explicitly assigned one, inherit its severity and facility, via the enum's auto-increment
        FailedToSetupTracing = EventSeverity.Error | EventFacility.Tracing | 0x0064,
        FailedToInitializeTraceSource,
        FailFast,
        FailFastException,
        FailedToTraceEvent,
        FailedToTraceEventWithException,
        InvariantAssertionFailed,
        PiiLoggingOn,
        PiiLoggingNotAllowed,

        // ServiceModel EventIDs
        // All EventId's beneath 'WebHostUnhandledException', until the next explicitly assigned one, inherit its severity and facility, via the enum's auto-increment
        WebHostUnhandledException = EventSeverity.Error | EventFacility.ServiceModel | 0x0001,
        WebHostHttpError,
        WebHostFailedToProcessRequest,
        WebHostFailedToListen,
        FailedToLogMessage,
        RemovedBadFilter,
        FailedToCreateMessageLoggingTraceSource,
        MessageLoggingOn,
        MessageLoggingOff,
        FailedToLoadPerformanceCounter,
        FailedToRemovePerformanceCounter,
        WmiGetObjectFailed,
        WmiPutInstanceFailed,
        WmiDeleteInstanceFailed,
        WmiCreateInstanceFailed,
        WmiExecQueryFailed,
        WmiExecMethodFailed,
        WmiRegistrationFailed,
        WmiUnregistrationFailed,
        WmiAdminTypeMismatch,
        WmiPropertyMissing,
        ComPlusServiceHostStartingServiceError,
        ComPlusDllHostInitializerStartingError,
        ComPlusTLBImportError,
        ComPlusInvokingMethodFailed,
        ComPlusInstanceCreationError,
        ComPlusInvokingMethodFailedMismatchedTransactions,
        // Assigning code 0x001c to this EventId because it is the 28th (0x001c) EventId with Facility = ServiceModel.
        WebHostNotLoggingInsufficientMemoryExceptionsOnActivationForNextTimeInterval = EventSeverity.Warning | EventFacility.ServiceModel | 0x001c,

        // TransactionBridge
        // All EventId's beneath 'UnhandledStateMachineExceptionRecordDescription', until the next explicitly assigned one, inherit its severity and facility, via the enum's auto-increment
        UnhandledStateMachineExceptionRecordDescription = EventSeverity.Error | EventFacility.TransactionBridge | 0x0001,
        FatalUnexpectedStateMachineEvent,
        ParticipantRecoveryLogEntryCorrupt,
        CoordinatorRecoveryLogEntryCorrupt,
        CoordinatorRecoveryLogEntryCreationFailure,
        ParticipantRecoveryLogEntryCreationFailure,
        ProtocolInitializationFailure,
        ProtocolStartFailure,
        ProtocolRecoveryBeginningFailure,
        ProtocolRecoveryCompleteFailure,
        TransactionBridgeRecoveryFailure,
        ProtocolStopFailure,
        NonFatalUnexpectedStateMachineEvent,
        PerformanceCounterInitializationFailure,
        ProtocolRecoveryComplete,
        ProtocolStopped,
        ThumbPrintNotFound,
        ThumbPrintNotValidated,
        SslNoPrivateKey,
        SslNoAccessiblePrivateKey,
        MissingNecessaryKeyUsage,
        MissingNecessaryEnhancedKeyUsage,

        // SMSvcHost
        // All EventId's beneath 'StartErrorPublish', until the next explicitly assigned one, inherit its severity and facility, via the enum's auto-increment
        StartErrorPublish = EventSeverity.Error | EventFacility.SMSvcHost | 0x0001,
        BindingError,
        LAFailedToListenForApp,
        UnknownListenerAdapterError,
        WasDisconnected,
        WasConnectionTimedout,
        ServiceStartFailed,
        MessageQueueDuplicatedSocketLeak,
        MessageQueueDuplicatedPipeLeak,
        SharingUnhandledException,

        // SecurityAudit
        ServiceAuthorizationSuccess = EventSeverity.Informational | EventFacility.SecurityAudit | 0x0001,
        ServiceAuthorizationFailure = EventSeverity.Error | EventFacility.SecurityAudit | 0x0002,
        MessageAuthenticationSuccess = EventSeverity.Informational | EventFacility.SecurityAudit | 0x0003,
        MessageAuthenticationFailure = EventSeverity.Error | EventFacility.SecurityAudit | 0x0004,
        SecurityNegotiationSuccess = EventSeverity.Informational | EventFacility.SecurityAudit | 0x0005,
        SecurityNegotiationFailure = EventSeverity.Error | EventFacility.SecurityAudit | 0x0006,
        TransportAuthenticationSuccess = EventSeverity.Informational | EventFacility.SecurityAudit | 0x0007,
        TransportAuthenticationFailure = EventSeverity.Error | EventFacility.SecurityAudit | 0x0008,
        ImpersonationSuccess = EventSeverity.Informational | EventFacility.SecurityAudit | 0x0009,
        ImpersonationFailure = EventSeverity.Error | EventFacility.SecurityAudit | 0x000a
    }

    internal enum EventSeverity : uint
    {
        Success = 0x00000000,
        Informational = 0x40000000,
        Warning = 0x80000000,
        Error = 0xc0000000
    }

    internal enum EventFacility : uint
    {
        Tracing = 0x00010000,
        ServiceModel = 0x00020000,
        TransactionBridge = 0x00030000,
        SMSvcHost = 0x00040000,
        InfoCards = 0x00050000,
        SecurityAudit = 0x00060000
    }
}
