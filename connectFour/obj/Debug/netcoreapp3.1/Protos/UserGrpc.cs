// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/user.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace grpc4InRowService.Protos {
  public static partial class User
  {
    static readonly string __ServiceName = "User";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.GeneralReq> __Marshaller_GeneralReq = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.GeneralReq.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.UserData> __Marshaller_UserData = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.UserData.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.UserRequest> __Marshaller_UserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.UserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.GeneralReply> __Marshaller_GeneralReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.GeneralReply.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.GeneralReq, global::grpc4InRowService.Protos.UserData> __Method_getOnlineUsers = new grpc::Method<global::grpc4InRowService.Protos.GeneralReq, global::grpc4InRowService.Protos.UserData>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "getOnlineUsers",
        __Marshaller_GeneralReq,
        __Marshaller_UserData);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.UserRequest, global::grpc4InRowService.Protos.GeneralReply> __Method_Login = new grpc::Method<global::grpc4InRowService.Protos.UserRequest, global::grpc4InRowService.Protos.GeneralReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Login",
        __Marshaller_UserRequest,
        __Marshaller_GeneralReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.UserRequest, global::grpc4InRowService.Protos.GeneralReply> __Method_Register = new grpc::Method<global::grpc4InRowService.Protos.UserRequest, global::grpc4InRowService.Protos.GeneralReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Register",
        __Marshaller_UserRequest,
        __Marshaller_GeneralReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.GeneralReq, global::grpc4InRowService.Protos.GeneralReply> __Method_RemoveFromOnline = new grpc::Method<global::grpc4InRowService.Protos.GeneralReq, global::grpc4InRowService.Protos.GeneralReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RemoveFromOnline",
        __Marshaller_GeneralReq,
        __Marshaller_GeneralReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.GeneralReq, global::grpc4InRowService.Protos.GeneralReply> __Method_AddToOnline = new grpc::Method<global::grpc4InRowService.Protos.GeneralReq, global::grpc4InRowService.Protos.GeneralReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddToOnline",
        __Marshaller_GeneralReq,
        __Marshaller_GeneralReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::grpc4InRowService.Protos.UserReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of User</summary>
    [grpc::BindServiceMethod(typeof(User), "BindService")]
    public abstract partial class UserBase
    {
      /// <summary>
      /// sends GeneralReq with user id, returns a stream of online users from Program.onlineUsers
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="responseStream">Used for sending responses back to the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>A task indicating completion of the handler.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task getOnlineUsers(global::grpc4InRowService.Protos.GeneralReq request, grpc::IServerStreamWriter<global::grpc4InRowService.Protos.UserData> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// sends LoginRequest with username and pw, returns a GeneralReply with user id from db if successfull
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.Protos.GeneralReply> Login(global::grpc4InRowService.Protos.UserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// sends RegisterRequest with username and pw, returns a GeneralReply with user id from db if successfull
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.Protos.GeneralReply> Register(global::grpc4InRowService.Protos.UserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.Protos.GeneralReply> RemoveFromOnline(global::grpc4InRowService.Protos.GeneralReq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.Protos.GeneralReply> AddToOnline(global::grpc4InRowService.Protos.GeneralReq request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for User</summary>
    public partial class UserClient : grpc::ClientBase<UserClient>
    {
      /// <summary>Creates a new client for User</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public UserClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for User that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public UserClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected UserClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected UserClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// sends GeneralReq with user id, returns a stream of online users from Program.onlineUsers
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::grpc4InRowService.Protos.UserData> getOnlineUsers(global::grpc4InRowService.Protos.GeneralReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getOnlineUsers(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// sends GeneralReq with user id, returns a stream of online users from Program.onlineUsers
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncServerStreamingCall<global::grpc4InRowService.Protos.UserData> getOnlineUsers(global::grpc4InRowService.Protos.GeneralReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_getOnlineUsers, null, options, request);
      }
      /// <summary>
      /// sends LoginRequest with username and pw, returns a GeneralReply with user id from db if successfull
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GeneralReply Login(global::grpc4InRowService.Protos.UserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Login(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// sends LoginRequest with username and pw, returns a GeneralReply with user id from db if successfull
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GeneralReply Login(global::grpc4InRowService.Protos.UserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Login, null, options, request);
      }
      /// <summary>
      /// sends LoginRequest with username and pw, returns a GeneralReply with user id from db if successfull
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GeneralReply> LoginAsync(global::grpc4InRowService.Protos.UserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return LoginAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// sends LoginRequest with username and pw, returns a GeneralReply with user id from db if successfull
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GeneralReply> LoginAsync(global::grpc4InRowService.Protos.UserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Login, null, options, request);
      }
      /// <summary>
      /// sends RegisterRequest with username and pw, returns a GeneralReply with user id from db if successfull
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GeneralReply Register(global::grpc4InRowService.Protos.UserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Register(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// sends RegisterRequest with username and pw, returns a GeneralReply with user id from db if successfull
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GeneralReply Register(global::grpc4InRowService.Protos.UserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Register, null, options, request);
      }
      /// <summary>
      /// sends RegisterRequest with username and pw, returns a GeneralReply with user id from db if successfull
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GeneralReply> RegisterAsync(global::grpc4InRowService.Protos.UserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RegisterAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// sends RegisterRequest with username and pw, returns a GeneralReply with user id from db if successfull
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GeneralReply> RegisterAsync(global::grpc4InRowService.Protos.UserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Register, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GeneralReply RemoveFromOnline(global::grpc4InRowService.Protos.GeneralReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RemoveFromOnline(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GeneralReply RemoveFromOnline(global::grpc4InRowService.Protos.GeneralReq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_RemoveFromOnline, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GeneralReply> RemoveFromOnlineAsync(global::grpc4InRowService.Protos.GeneralReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RemoveFromOnlineAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GeneralReply> RemoveFromOnlineAsync(global::grpc4InRowService.Protos.GeneralReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_RemoveFromOnline, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GeneralReply AddToOnline(global::grpc4InRowService.Protos.GeneralReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddToOnline(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GeneralReply AddToOnline(global::grpc4InRowService.Protos.GeneralReq request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddToOnline, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GeneralReply> AddToOnlineAsync(global::grpc4InRowService.Protos.GeneralReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddToOnlineAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GeneralReply> AddToOnlineAsync(global::grpc4InRowService.Protos.GeneralReq request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddToOnline, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override UserClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new UserClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(UserBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_getOnlineUsers, serviceImpl.getOnlineUsers)
          .AddMethod(__Method_Login, serviceImpl.Login)
          .AddMethod(__Method_Register, serviceImpl.Register)
          .AddMethod(__Method_RemoveFromOnline, serviceImpl.RemoveFromOnline)
          .AddMethod(__Method_AddToOnline, serviceImpl.AddToOnline).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UserBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_getOnlineUsers, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::grpc4InRowService.Protos.GeneralReq, global::grpc4InRowService.Protos.UserData>(serviceImpl.getOnlineUsers));
      serviceBinder.AddMethod(__Method_Login, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.Protos.UserRequest, global::grpc4InRowService.Protos.GeneralReply>(serviceImpl.Login));
      serviceBinder.AddMethod(__Method_Register, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.Protos.UserRequest, global::grpc4InRowService.Protos.GeneralReply>(serviceImpl.Register));
      serviceBinder.AddMethod(__Method_RemoveFromOnline, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.Protos.GeneralReq, global::grpc4InRowService.Protos.GeneralReply>(serviceImpl.RemoveFromOnline));
      serviceBinder.AddMethod(__Method_AddToOnline, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.Protos.GeneralReq, global::grpc4InRowService.Protos.GeneralReply>(serviceImpl.AddToOnline));
    }

  }
}
#endregion
