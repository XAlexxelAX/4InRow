// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/game.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace grpc4InRowService.Services {
  public static partial class Game
  {
    static readonly string __ServiceName = "Game";

    static readonly grpc::Marshaller<global::grpc4InRowService.Services.GameRequest> __Marshaller_GameRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::grpc4InRowService.Services.GameRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::grpc4InRowService.Services.GameReply> __Marshaller_GameReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::grpc4InRowService.Services.GameReply.Parser.ParseFrom);

    static readonly grpc::Method<global::grpc4InRowService.Services.GameRequest, global::grpc4InRowService.Services.GameReply> __Method_StartGame = new grpc::Method<global::grpc4InRowService.Services.GameRequest, global::grpc4InRowService.Services.GameReply>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "StartGame",
        __Marshaller_GameRequest,
        __Marshaller_GameReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::grpc4InRowService.Services.GameReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Game</summary>
    [grpc::BindServiceMethod(typeof(Game), "BindService")]
    public abstract partial class GameBase
    {
      public virtual global::System.Threading.Tasks.Task StartGame(global::grpc4InRowService.Services.GameRequest request, grpc::IServerStreamWriter<global::grpc4InRowService.Services.GameReply> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Game</summary>
    public partial class GameClient : grpc::ClientBase<GameClient>
    {
      /// <summary>Creates a new client for Game</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public GameClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Game that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public GameClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected GameClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected GameClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::grpc4InRowService.Services.GameReply> StartGame(global::grpc4InRowService.Services.GameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return StartGame(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::grpc4InRowService.Services.GameReply> StartGame(global::grpc4InRowService.Services.GameRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_StartGame, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override GameClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new GameClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GameBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_StartGame, serviceImpl.StartGame).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GameBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_StartGame, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::grpc4InRowService.Services.GameRequest, global::grpc4InRowService.Services.GameReply>(serviceImpl.StartGame));
    }

  }
}
#endregion
