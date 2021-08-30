// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/game.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace grpc4InRowService.Protos {
  public static partial class Games
  {
    static readonly string __ServiceName = "Games";

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
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.Check> __Marshaller_Check = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.Check.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.CheckReply> __Marshaller_CheckReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.CheckReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.GameRequest> __Marshaller_GameRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.GameRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.GameReply> __Marshaller_GameReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.GameReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.MoveRequest> __Marshaller_MoveRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.MoveRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.Reply> __Marshaller_Reply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.Reply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.MoveCheck> __Marshaller_MoveCheck = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.MoveCheck.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::grpc4InRowService.Protos.Score> __Marshaller_Score = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::grpc4InRowService.Protos.Score.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.Check, global::grpc4InRowService.Protos.CheckReply> __Method_CheckForGame = new grpc::Method<global::grpc4InRowService.Protos.Check, global::grpc4InRowService.Protos.CheckReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CheckForGame",
        __Marshaller_Check,
        __Marshaller_CheckReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.GameRequest, global::grpc4InRowService.Protos.GameReply> __Method_OfferGame = new grpc::Method<global::grpc4InRowService.Protos.GameRequest, global::grpc4InRowService.Protos.GameReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "OfferGame",
        __Marshaller_GameRequest,
        __Marshaller_GameReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.GameRequest, global::grpc4InRowService.Protos.GameReply> __Method_RemoveRequest = new grpc::Method<global::grpc4InRowService.Protos.GameRequest, global::grpc4InRowService.Protos.GameReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RemoveRequest",
        __Marshaller_GameRequest,
        __Marshaller_GameReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.MoveRequest, global::grpc4InRowService.Protos.Reply> __Method_CreateGame = new grpc::Method<global::grpc4InRowService.Protos.MoveRequest, global::grpc4InRowService.Protos.Reply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateGame",
        __Marshaller_MoveRequest,
        __Marshaller_Reply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.MoveRequest, global::grpc4InRowService.Protos.Reply> __Method_MakeMove = new grpc::Method<global::grpc4InRowService.Protos.MoveRequest, global::grpc4InRowService.Protos.Reply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "MakeMove",
        __Marshaller_MoveRequest,
        __Marshaller_Reply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.MoveCheck, global::grpc4InRowService.Protos.Reply> __Method_CheckMove = new grpc::Method<global::grpc4InRowService.Protos.MoveCheck, global::grpc4InRowService.Protos.Reply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CheckMove",
        __Marshaller_MoveCheck,
        __Marshaller_Reply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::grpc4InRowService.Protos.Score, global::grpc4InRowService.Protos.Reply> __Method_UpdateScore = new grpc::Method<global::grpc4InRowService.Protos.Score, global::grpc4InRowService.Protos.Reply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateScore",
        __Marshaller_Score,
        __Marshaller_Reply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::grpc4InRowService.Protos.GameReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Games</summary>
    [grpc::BindServiceMethod(typeof(Games), "BindService")]
    public abstract partial class GamesBase
    {
      /// <summary>
      /// invokes server with check that contains user id, returns reply if there's a waiting game request
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.Protos.CheckReply> CheckForGame(global::grpc4InRowService.Protos.Check request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// sends to server game request
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.Protos.GameReply> OfferGame(global::grpc4InRowService.Protos.GameRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.Protos.GameReply> RemoveRequest(global::grpc4InRowService.Protos.GameRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// creates a new game to be played
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.Protos.Reply> CreateGame(global::grpc4InRowService.Protos.MoveRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// send a move in an ongoing game
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.Protos.Reply> MakeMove(global::grpc4InRowService.Protos.MoveRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// checks if a move was made by the opponent
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.Protos.Reply> CheckMove(global::grpc4InRowService.Protos.MoveCheck request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::grpc4InRowService.Protos.Reply> UpdateScore(global::grpc4InRowService.Protos.Score request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Games</summary>
    public partial class GamesClient : grpc::ClientBase<GamesClient>
    {
      /// <summary>Creates a new client for Games</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public GamesClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Games that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public GamesClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected GamesClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected GamesClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// invokes server with check that contains user id, returns reply if there's a waiting game request
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.CheckReply CheckForGame(global::grpc4InRowService.Protos.Check request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CheckForGame(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// invokes server with check that contains user id, returns reply if there's a waiting game request
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.CheckReply CheckForGame(global::grpc4InRowService.Protos.Check request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CheckForGame, null, options, request);
      }
      /// <summary>
      /// invokes server with check that contains user id, returns reply if there's a waiting game request
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.CheckReply> CheckForGameAsync(global::grpc4InRowService.Protos.Check request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CheckForGameAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// invokes server with check that contains user id, returns reply if there's a waiting game request
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.CheckReply> CheckForGameAsync(global::grpc4InRowService.Protos.Check request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CheckForGame, null, options, request);
      }
      /// <summary>
      /// sends to server game request
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GameReply OfferGame(global::grpc4InRowService.Protos.GameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return OfferGame(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// sends to server game request
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GameReply OfferGame(global::grpc4InRowService.Protos.GameRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_OfferGame, null, options, request);
      }
      /// <summary>
      /// sends to server game request
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GameReply> OfferGameAsync(global::grpc4InRowService.Protos.GameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return OfferGameAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// sends to server game request
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GameReply> OfferGameAsync(global::grpc4InRowService.Protos.GameRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_OfferGame, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GameReply RemoveRequest(global::grpc4InRowService.Protos.GameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RemoveRequest(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.GameReply RemoveRequest(global::grpc4InRowService.Protos.GameRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_RemoveRequest, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GameReply> RemoveRequestAsync(global::grpc4InRowService.Protos.GameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RemoveRequestAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.GameReply> RemoveRequestAsync(global::grpc4InRowService.Protos.GameRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_RemoveRequest, null, options, request);
      }
      /// <summary>
      /// creates a new game to be played
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.Reply CreateGame(global::grpc4InRowService.Protos.MoveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateGame(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// creates a new game to be played
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.Reply CreateGame(global::grpc4InRowService.Protos.MoveRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateGame, null, options, request);
      }
      /// <summary>
      /// creates a new game to be played
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.Reply> CreateGameAsync(global::grpc4InRowService.Protos.MoveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateGameAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// creates a new game to be played
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.Reply> CreateGameAsync(global::grpc4InRowService.Protos.MoveRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateGame, null, options, request);
      }
      /// <summary>
      /// send a move in an ongoing game
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.Reply MakeMove(global::grpc4InRowService.Protos.MoveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return MakeMove(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// send a move in an ongoing game
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.Reply MakeMove(global::grpc4InRowService.Protos.MoveRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_MakeMove, null, options, request);
      }
      /// <summary>
      /// send a move in an ongoing game
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.Reply> MakeMoveAsync(global::grpc4InRowService.Protos.MoveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return MakeMoveAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// send a move in an ongoing game
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.Reply> MakeMoveAsync(global::grpc4InRowService.Protos.MoveRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_MakeMove, null, options, request);
      }
      /// <summary>
      /// checks if a move was made by the opponent
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.Reply CheckMove(global::grpc4InRowService.Protos.MoveCheck request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CheckMove(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// checks if a move was made by the opponent
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.Reply CheckMove(global::grpc4InRowService.Protos.MoveCheck request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CheckMove, null, options, request);
      }
      /// <summary>
      /// checks if a move was made by the opponent
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.Reply> CheckMoveAsync(global::grpc4InRowService.Protos.MoveCheck request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CheckMoveAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// checks if a move was made by the opponent
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.Reply> CheckMoveAsync(global::grpc4InRowService.Protos.MoveCheck request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CheckMove, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.Reply UpdateScore(global::grpc4InRowService.Protos.Score request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateScore(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::grpc4InRowService.Protos.Reply UpdateScore(global::grpc4InRowService.Protos.Score request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateScore, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.Reply> UpdateScoreAsync(global::grpc4InRowService.Protos.Score request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateScoreAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::grpc4InRowService.Protos.Reply> UpdateScoreAsync(global::grpc4InRowService.Protos.Score request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateScore, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override GamesClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new GamesClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(GamesBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CheckForGame, serviceImpl.CheckForGame)
          .AddMethod(__Method_OfferGame, serviceImpl.OfferGame)
          .AddMethod(__Method_RemoveRequest, serviceImpl.RemoveRequest)
          .AddMethod(__Method_CreateGame, serviceImpl.CreateGame)
          .AddMethod(__Method_MakeMove, serviceImpl.MakeMove)
          .AddMethod(__Method_CheckMove, serviceImpl.CheckMove)
          .AddMethod(__Method_UpdateScore, serviceImpl.UpdateScore).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GamesBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CheckForGame, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.Protos.Check, global::grpc4InRowService.Protos.CheckReply>(serviceImpl.CheckForGame));
      serviceBinder.AddMethod(__Method_OfferGame, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.Protos.GameRequest, global::grpc4InRowService.Protos.GameReply>(serviceImpl.OfferGame));
      serviceBinder.AddMethod(__Method_RemoveRequest, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.Protos.GameRequest, global::grpc4InRowService.Protos.GameReply>(serviceImpl.RemoveRequest));
      serviceBinder.AddMethod(__Method_CreateGame, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.Protos.MoveRequest, global::grpc4InRowService.Protos.Reply>(serviceImpl.CreateGame));
      serviceBinder.AddMethod(__Method_MakeMove, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.Protos.MoveRequest, global::grpc4InRowService.Protos.Reply>(serviceImpl.MakeMove));
      serviceBinder.AddMethod(__Method_CheckMove, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.Protos.MoveCheck, global::grpc4InRowService.Protos.Reply>(serviceImpl.CheckMove));
      serviceBinder.AddMethod(__Method_UpdateScore, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::grpc4InRowService.Protos.Score, global::grpc4InRowService.Protos.Reply>(serviceImpl.UpdateScore));
    }

  }
}
#endregion
