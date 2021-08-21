// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/user.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace grpc4InRowService {
  public static partial class User
  {
    static readonly string __ServiceName = "User";

    static readonly grpc::Marshaller<global::grpc4InRowService.LoginRequest> __Marshaller_LoginRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::grpc4InRowService.LoginRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::grpc4InRowService.LoginReply> __Marshaller_LoginReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::grpc4InRowService.LoginReply.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::grpc4InRowService.RegisterRequest> __Marshaller_RegisterRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::grpc4InRowService.RegisterRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::grpc4InRowService.RegisterReply> __Marshaller_RegisterReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::grpc4InRowService.RegisterReply.Parser.ParseFrom);

    static readonly grpc::Method<global::grpc4InRowService.LoginRequest, global::grpc4InRowService.LoginReply> __Method_Login = new grpc::Method<global::grpc4InRowService.LoginRequest, global::grpc4InRowService.LoginReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Login",
        __Marshaller_LoginRequest,
        __Marshaller_LoginReply);

    static readonly grpc::Method<global::grpc4InRowService.RegisterRequest, global::grpc4InRowService.RegisterReply> __Method_Register = new grpc::Method<global::grpc4InRowService.RegisterRequest, global::grpc4InRowService.RegisterReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Register",
        __Marshaller_RegisterRequest,
        __Marshaller_RegisterReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::grpc4InRowService.UserReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of User</summary>
    [grpc::BindServiceMethod(typeof(User), "BindService")]
    public abstract partial class UserBase
    {
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.LoginReply> Login(global::grpc4InRowService.LoginRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.RegisterReply> Register(global::grpc4InRowService.RegisterRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for User</summary>
    public partial class UserClient : grpc::ClientBase<UserClient>
    {
      /// <summary>Creates a new client for User</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public UserClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for User that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public UserClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected UserClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected UserClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::grpc4InRowService.LoginReply Login(global::grpc4InRowService.LoginRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Login(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::grpc4InRowService.LoginReply Login(global::grpc4InRowService.LoginRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Login, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.LoginReply> LoginAsync(global::grpc4InRowService.LoginRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return LoginAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.LoginReply> LoginAsync(global::grpc4InRowService.LoginRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Login, null, options, request);
      }
      public virtual global::grpc4InRowService.RegisterReply Register(global::grpc4InRowService.RegisterRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Register(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::grpc4InRowService.RegisterReply Register(global::grpc4InRowService.RegisterRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Register, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.RegisterReply> RegisterAsync(global::grpc4InRowService.RegisterRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RegisterAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.RegisterReply> RegisterAsync(global::grpc4InRowService.RegisterRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Register, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override UserClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new UserClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(UserBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Login, serviceImpl.Login)
          .AddMethod(__Method_Register, serviceImpl.Register).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UserBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Login, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.LoginRequest, global::grpc4InRowService.LoginReply>(serviceImpl.Login));
      serviceBinder.AddMethod(__Method_Register, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.RegisterRequest, global::grpc4InRowService.RegisterReply>(serviceImpl.Register));
    }

  }
}
#endregion