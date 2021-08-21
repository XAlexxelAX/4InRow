// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/user.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace grpc4InRowService.Protos {

  /// <summary>Holder for reflection information generated from Protos/user.proto</summary>
  public static partial class UserReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/user.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UserReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFQcm90b3MvdXNlci5wcm90byIFCgNSZXEiJAoIVXNlckRhdGESCgoCaWQY",
            "ASABKAUSDAoEdXNlchgCIAEoCSIoCgxMb2dpblJlcXVlc3QSDAoEdXNlchgB",
            "IAEoCRIKCgJwdxgCIAEoCSIjCgpMb2dpblJlcGx5EhUKDWlzU3VjY2Vzc2Z1",
            "bGwYASABKAgiWAoPUmVnaXN0ZXJSZXF1ZXN0EgwKBHVzZXIYASABKAkSCgoC",
            "cHcYAiABKAkSDQoFZW1haWwYAyABKAkSDQoFZm5hbWUYBCABKAkSDQoFbG5h",
            "bWUYBSABKAkiJgoNUmVnaXN0ZXJSZXBseRIVCg1pc1N1Y2Nlc3NmdWxsGAEg",
            "ASgIMn4KBFVzZXISIwoOZ2V0T25saW5lVXNlcnMSBC5SZXEaCS5Vc2VyRGF0",
            "YTABEiMKBUxvZ2luEg0uTG9naW5SZXF1ZXN0GgsuTG9naW5SZXBseRIsCghS",
            "ZWdpc3RlchIQLlJlZ2lzdGVyUmVxdWVzdBoOLlJlZ2lzdGVyUmVwbHlCG6oC",
            "GGdycGM0SW5Sb3dTZXJ2aWNlLlByb3Rvc2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::grpc4InRowService.Protos.Req), global::grpc4InRowService.Protos.Req.Parser, null, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::grpc4InRowService.Protos.UserData), global::grpc4InRowService.Protos.UserData.Parser, new[]{ "Id", "User" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::grpc4InRowService.Protos.LoginRequest), global::grpc4InRowService.Protos.LoginRequest.Parser, new[]{ "User", "Pw" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::grpc4InRowService.Protos.LoginReply), global::grpc4InRowService.Protos.LoginReply.Parser, new[]{ "IsSuccessfull" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::grpc4InRowService.Protos.RegisterRequest), global::grpc4InRowService.Protos.RegisterRequest.Parser, new[]{ "User", "Pw", "Email", "Fname", "Lname" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::grpc4InRowService.Protos.RegisterReply), global::grpc4InRowService.Protos.RegisterReply.Parser, new[]{ "IsSuccessfull" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Req : pb::IMessage<Req> {
    private static readonly pb::MessageParser<Req> _parser = new pb::MessageParser<Req>(() => new Req());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Req> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::grpc4InRowService.Protos.UserReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Req() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Req(Req other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Req Clone() {
      return new Req(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Req);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Req other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Req other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  public sealed partial class UserData : pb::IMessage<UserData> {
    private static readonly pb::MessageParser<UserData> _parser = new pb::MessageParser<UserData>(() => new UserData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<UserData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::grpc4InRowService.Protos.UserReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserData(UserData other) : this() {
      id_ = other.id_;
      user_ = other.user_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UserData Clone() {
      return new UserData(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private int id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "user" field.</summary>
    public const int UserFieldNumber = 2;
    private string user_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string User {
      get { return user_; }
      set {
        user_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as UserData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(UserData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (User != other.User) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0) hash ^= Id.GetHashCode();
      if (User.Length != 0) hash ^= User.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Id);
      }
      if (User.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(User);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
      }
      if (User.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(User);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(UserData other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      if (other.User.Length != 0) {
        User = other.User;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Id = input.ReadInt32();
            break;
          }
          case 18: {
            User = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class LoginRequest : pb::IMessage<LoginRequest> {
    private static readonly pb::MessageParser<LoginRequest> _parser = new pb::MessageParser<LoginRequest>(() => new LoginRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LoginRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::grpc4InRowService.Protos.UserReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginRequest(LoginRequest other) : this() {
      user_ = other.user_;
      pw_ = other.pw_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginRequest Clone() {
      return new LoginRequest(this);
    }

    /// <summary>Field number for the "user" field.</summary>
    public const int UserFieldNumber = 1;
    private string user_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string User {
      get { return user_; }
      set {
        user_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "pw" field.</summary>
    public const int PwFieldNumber = 2;
    private string pw_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Pw {
      get { return pw_; }
      set {
        pw_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LoginRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LoginRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (User != other.User) return false;
      if (Pw != other.Pw) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (User.Length != 0) hash ^= User.GetHashCode();
      if (Pw.Length != 0) hash ^= Pw.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (User.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(User);
      }
      if (Pw.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Pw);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (User.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(User);
      }
      if (Pw.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Pw);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LoginRequest other) {
      if (other == null) {
        return;
      }
      if (other.User.Length != 0) {
        User = other.User;
      }
      if (other.Pw.Length != 0) {
        Pw = other.Pw;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            User = input.ReadString();
            break;
          }
          case 18: {
            Pw = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class LoginReply : pb::IMessage<LoginReply> {
    private static readonly pb::MessageParser<LoginReply> _parser = new pb::MessageParser<LoginReply>(() => new LoginReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LoginReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::grpc4InRowService.Protos.UserReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginReply(LoginReply other) : this() {
      isSuccessfull_ = other.isSuccessfull_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginReply Clone() {
      return new LoginReply(this);
    }

    /// <summary>Field number for the "isSuccessfull" field.</summary>
    public const int IsSuccessfullFieldNumber = 1;
    private bool isSuccessfull_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool IsSuccessfull {
      get { return isSuccessfull_; }
      set {
        isSuccessfull_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LoginReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LoginReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (IsSuccessfull != other.IsSuccessfull) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (IsSuccessfull != false) hash ^= IsSuccessfull.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (IsSuccessfull != false) {
        output.WriteRawTag(8);
        output.WriteBool(IsSuccessfull);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (IsSuccessfull != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LoginReply other) {
      if (other == null) {
        return;
      }
      if (other.IsSuccessfull != false) {
        IsSuccessfull = other.IsSuccessfull;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            IsSuccessfull = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  public sealed partial class RegisterRequest : pb::IMessage<RegisterRequest> {
    private static readonly pb::MessageParser<RegisterRequest> _parser = new pb::MessageParser<RegisterRequest>(() => new RegisterRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RegisterRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::grpc4InRowService.Protos.UserReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterRequest(RegisterRequest other) : this() {
      user_ = other.user_;
      pw_ = other.pw_;
      email_ = other.email_;
      fname_ = other.fname_;
      lname_ = other.lname_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterRequest Clone() {
      return new RegisterRequest(this);
    }

    /// <summary>Field number for the "user" field.</summary>
    public const int UserFieldNumber = 1;
    private string user_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string User {
      get { return user_; }
      set {
        user_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "pw" field.</summary>
    public const int PwFieldNumber = 2;
    private string pw_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Pw {
      get { return pw_; }
      set {
        pw_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "email" field.</summary>
    public const int EmailFieldNumber = 3;
    private string email_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Email {
      get { return email_; }
      set {
        email_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "fname" field.</summary>
    public const int FnameFieldNumber = 4;
    private string fname_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Fname {
      get { return fname_; }
      set {
        fname_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "lname" field.</summary>
    public const int LnameFieldNumber = 5;
    private string lname_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Lname {
      get { return lname_; }
      set {
        lname_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RegisterRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RegisterRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (User != other.User) return false;
      if (Pw != other.Pw) return false;
      if (Email != other.Email) return false;
      if (Fname != other.Fname) return false;
      if (Lname != other.Lname) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (User.Length != 0) hash ^= User.GetHashCode();
      if (Pw.Length != 0) hash ^= Pw.GetHashCode();
      if (Email.Length != 0) hash ^= Email.GetHashCode();
      if (Fname.Length != 0) hash ^= Fname.GetHashCode();
      if (Lname.Length != 0) hash ^= Lname.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (User.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(User);
      }
      if (Pw.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Pw);
      }
      if (Email.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Email);
      }
      if (Fname.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Fname);
      }
      if (Lname.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Lname);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (User.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(User);
      }
      if (Pw.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Pw);
      }
      if (Email.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Email);
      }
      if (Fname.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Fname);
      }
      if (Lname.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Lname);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RegisterRequest other) {
      if (other == null) {
        return;
      }
      if (other.User.Length != 0) {
        User = other.User;
      }
      if (other.Pw.Length != 0) {
        Pw = other.Pw;
      }
      if (other.Email.Length != 0) {
        Email = other.Email;
      }
      if (other.Fname.Length != 0) {
        Fname = other.Fname;
      }
      if (other.Lname.Length != 0) {
        Lname = other.Lname;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            User = input.ReadString();
            break;
          }
          case 18: {
            Pw = input.ReadString();
            break;
          }
          case 26: {
            Email = input.ReadString();
            break;
          }
          case 34: {
            Fname = input.ReadString();
            break;
          }
          case 42: {
            Lname = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class RegisterReply : pb::IMessage<RegisterReply> {
    private static readonly pb::MessageParser<RegisterReply> _parser = new pb::MessageParser<RegisterReply>(() => new RegisterReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RegisterReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::grpc4InRowService.Protos.UserReflection.Descriptor.MessageTypes[5]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterReply(RegisterReply other) : this() {
      isSuccessfull_ = other.isSuccessfull_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RegisterReply Clone() {
      return new RegisterReply(this);
    }

    /// <summary>Field number for the "isSuccessfull" field.</summary>
    public const int IsSuccessfullFieldNumber = 1;
    private bool isSuccessfull_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool IsSuccessfull {
      get { return isSuccessfull_; }
      set {
        isSuccessfull_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RegisterReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RegisterReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (IsSuccessfull != other.IsSuccessfull) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (IsSuccessfull != false) hash ^= IsSuccessfull.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (IsSuccessfull != false) {
        output.WriteRawTag(8);
        output.WriteBool(IsSuccessfull);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (IsSuccessfull != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RegisterReply other) {
      if (other == null) {
        return;
      }
      if (other.IsSuccessfull != false) {
        IsSuccessfull = other.IsSuccessfull;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            IsSuccessfull = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
