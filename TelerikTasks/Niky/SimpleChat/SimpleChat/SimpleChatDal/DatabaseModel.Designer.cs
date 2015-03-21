﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("ChatRoomModel", "FK_Messages_ChatRooms", "ChatRooms", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(SimpleChatDal.ChatRoom), "Messages", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(SimpleChatDal.Message), true)]

#endregion

namespace SimpleChatDal
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class ChatRoomEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new ChatRoomEntities object using the connection string found in the 'ChatRoomEntities' section of the application configuration file.
        /// </summary>
        public ChatRoomEntities() : base("name=ChatRoomEntities", "ChatRoomEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ChatRoomEntities object.
        /// </summary>
        public ChatRoomEntities(string connectionString) : base(connectionString, "ChatRoomEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ChatRoomEntities object.
        /// </summary>
        public ChatRoomEntities(EntityConnection connection) : base(connection, "ChatRoomEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ChatRoom> ChatRooms
        {
            get
            {
                if ((_ChatRooms == null))
                {
                    _ChatRooms = base.CreateObjectSet<ChatRoom>("ChatRooms");
                }
                return _ChatRooms;
            }
        }
        private ObjectSet<ChatRoom> _ChatRooms;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Message> Messages
        {
            get
            {
                if ((_Messages == null))
                {
                    _Messages = base.CreateObjectSet<Message>("Messages");
                }
                return _Messages;
            }
        }
        private ObjectSet<Message> _Messages;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the ChatRooms EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToChatRooms(ChatRoom chatRoom)
        {
            base.AddObject("ChatRooms", chatRoom);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Messages EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToMessages(Message message)
        {
            base.AddObject("Messages", message);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ChatRoomModel", Name="ChatRoom")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ChatRoom : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new ChatRoom object.
        /// </summary>
        /// <param name="chatRoomID">Initial value of the ChatRoomID property.</param>
        /// <param name="chatRoomName">Initial value of the ChatRoomName property.</param>
        public static ChatRoom CreateChatRoom(global::System.Int32 chatRoomID, global::System.String chatRoomName)
        {
            ChatRoom chatRoom = new ChatRoom();
            chatRoom.ChatRoomID = chatRoomID;
            chatRoom.ChatRoomName = chatRoomName;
            return chatRoom;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ChatRoomID
        {
            get
            {
                return _ChatRoomID;
            }
            set
            {
                if (_ChatRoomID != value)
                {
                    OnChatRoomIDChanging(value);
                    ReportPropertyChanging("ChatRoomID");
                    _ChatRoomID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ChatRoomID");
                    OnChatRoomIDChanged();
                }
            }
        }
        private global::System.Int32 _ChatRoomID;
        partial void OnChatRoomIDChanging(global::System.Int32 value);
        partial void OnChatRoomIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ChatRoomName
        {
            get
            {
                return _ChatRoomName;
            }
            set
            {
                OnChatRoomNameChanging(value);
                ReportPropertyChanging("ChatRoomName");
                _ChatRoomName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ChatRoomName");
                OnChatRoomNameChanged();
            }
        }
        private global::System.String _ChatRoomName;
        partial void OnChatRoomNameChanging(global::System.String value);
        partial void OnChatRoomNameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ChatRoomModel", "FK_Messages_ChatRooms", "Messages")]
        public EntityCollection<Message> Messages
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Message>("ChatRoomModel.FK_Messages_ChatRooms", "Messages");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Message>("ChatRoomModel.FK_Messages_ChatRooms", "Messages", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ChatRoomModel", Name="Message")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Message : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Message object.
        /// </summary>
        /// <param name="messageID">Initial value of the MessageID property.</param>
        /// <param name="chatRoomID">Initial value of the ChatRoomID property.</param>
        /// <param name="messageText">Initial value of the MessageText property.</param>
        /// <param name="messageDate">Initial value of the MessageDate property.</param>
        /// <param name="author">Initial value of the Author property.</param>
        /// <param name="authorIP">Initial value of the AuthorIP property.</param>
        public static Message CreateMessage(global::System.Int32 messageID, global::System.Int32 chatRoomID, global::System.String messageText, global::System.DateTime messageDate, global::System.String author, global::System.String authorIP)
        {
            Message message = new Message();
            message.MessageID = messageID;
            message.ChatRoomID = chatRoomID;
            message.MessageText = messageText;
            message.MessageDate = messageDate;
            message.Author = author;
            message.AuthorIP = authorIP;
            return message;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 MessageID
        {
            get
            {
                return _MessageID;
            }
            set
            {
                if (_MessageID != value)
                {
                    OnMessageIDChanging(value);
                    ReportPropertyChanging("MessageID");
                    _MessageID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("MessageID");
                    OnMessageIDChanged();
                }
            }
        }
        private global::System.Int32 _MessageID;
        partial void OnMessageIDChanging(global::System.Int32 value);
        partial void OnMessageIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ChatRoomID
        {
            get
            {
                return _ChatRoomID;
            }
            set
            {
                OnChatRoomIDChanging(value);
                ReportPropertyChanging("ChatRoomID");
                _ChatRoomID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ChatRoomID");
                OnChatRoomIDChanged();
            }
        }
        private global::System.Int32 _ChatRoomID;
        partial void OnChatRoomIDChanging(global::System.Int32 value);
        partial void OnChatRoomIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String MessageText
        {
            get
            {
                return _MessageText;
            }
            set
            {
                OnMessageTextChanging(value);
                ReportPropertyChanging("MessageText");
                _MessageText = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("MessageText");
                OnMessageTextChanged();
            }
        }
        private global::System.String _MessageText;
        partial void OnMessageTextChanging(global::System.String value);
        partial void OnMessageTextChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime MessageDate
        {
            get
            {
                return _MessageDate;
            }
            set
            {
                OnMessageDateChanging(value);
                ReportPropertyChanging("MessageDate");
                _MessageDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("MessageDate");
                OnMessageDateChanged();
            }
        }
        private global::System.DateTime _MessageDate;
        partial void OnMessageDateChanging(global::System.DateTime value);
        partial void OnMessageDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Author
        {
            get
            {
                return _Author;
            }
            set
            {
                OnAuthorChanging(value);
                ReportPropertyChanging("Author");
                _Author = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Author");
                OnAuthorChanged();
            }
        }
        private global::System.String _Author;
        partial void OnAuthorChanging(global::System.String value);
        partial void OnAuthorChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String AuthorIP
        {
            get
            {
                return _AuthorIP;
            }
            set
            {
                OnAuthorIPChanging(value);
                ReportPropertyChanging("AuthorIP");
                _AuthorIP = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("AuthorIP");
                OnAuthorIPChanged();
            }
        }
        private global::System.String _AuthorIP;
        partial void OnAuthorIPChanging(global::System.String value);
        partial void OnAuthorIPChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ChatRoomModel", "FK_Messages_ChatRooms", "ChatRooms")]
        public ChatRoom ChatRoom
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ChatRoom>("ChatRoomModel.FK_Messages_ChatRooms", "ChatRooms").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ChatRoom>("ChatRoomModel.FK_Messages_ChatRooms", "ChatRooms").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<ChatRoom> ChatRoomReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ChatRoom>("ChatRoomModel.FK_Messages_ChatRooms", "ChatRooms");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<ChatRoom>("ChatRoomModel.FK_Messages_ChatRooms", "ChatRooms", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
