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

[assembly: EdmRelationshipAttribute("JustPollsModel", "FK_PossibleAnswers_Polls", "Polls", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(JustPoll.DAL.Poll), "PossibleAnswers", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(JustPoll.DAL.PossibleAnswer), true)]
[assembly: EdmRelationshipAttribute("JustPollsModel", "FK_Votes_PossibleAnswers", "PossibleAnswers", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(JustPoll.DAL.PossibleAnswer), "Votes", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(JustPoll.DAL.Vote), true)]

#endregion

namespace JustPoll.DAL
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class JustPollsEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new JustPollsEntities object using the connection string found in the 'JustPollsEntities' section of the application configuration file.
        /// </summary>
        public JustPollsEntities() : base("name=JustPollsEntities", "JustPollsEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new JustPollsEntities object.
        /// </summary>
        public JustPollsEntities(string connectionString) : base(connectionString, "JustPollsEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new JustPollsEntities object.
        /// </summary>
        public JustPollsEntities(EntityConnection connection) : base(connection, "JustPollsEntities")
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
        public ObjectSet<Poll> Polls
        {
            get
            {
                if ((_Polls == null))
                {
                    _Polls = base.CreateObjectSet<Poll>("Polls");
                }
                return _Polls;
            }
        }
        private ObjectSet<Poll> _Polls;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<PossibleAnswer> PossibleAnswers
        {
            get
            {
                if ((_PossibleAnswers == null))
                {
                    _PossibleAnswers = base.CreateObjectSet<PossibleAnswer>("PossibleAnswers");
                }
                return _PossibleAnswers;
            }
        }
        private ObjectSet<PossibleAnswer> _PossibleAnswers;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Vote> Votes
        {
            get
            {
                if ((_Votes == null))
                {
                    _Votes = base.CreateObjectSet<Vote>("Votes");
                }
                return _Votes;
            }
        }
        private ObjectSet<Vote> _Votes;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Polls EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPolls(Poll poll)
        {
            base.AddObject("Polls", poll);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the PossibleAnswers EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPossibleAnswers(PossibleAnswer possibleAnswer)
        {
            base.AddObject("PossibleAnswers", possibleAnswer);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Votes EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToVotes(Vote vote)
        {
            base.AddObject("Votes", vote);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="JustPollsModel", Name="Poll")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Poll : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Poll object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="title">Initial value of the Title property.</param>
        /// <param name="date">Initial value of the Date property.</param>
        public static Poll CreatePoll(global::System.Int32 id, global::System.String title, global::System.DateTime date)
        {
            Poll poll = new Poll();
            poll.id = id;
            poll.Title = title;
            poll.Date = date;
            return poll;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                OnDateChanging(value);
                ReportPropertyChanging("Date");
                _Date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Date");
                OnDateChanged();
            }
        }
        private global::System.DateTime _Date;
        partial void OnDateChanging(global::System.DateTime value);
        partial void OnDateChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("JustPollsModel", "FK_PossibleAnswers_Polls", "PossibleAnswers")]
        public EntityCollection<PossibleAnswer> PossibleAnswers
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<PossibleAnswer>("JustPollsModel.FK_PossibleAnswers_Polls", "PossibleAnswers");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<PossibleAnswer>("JustPollsModel.FK_PossibleAnswers_Polls", "PossibleAnswers", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="JustPollsModel", Name="PossibleAnswer")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class PossibleAnswer : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new PossibleAnswer object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="pollId">Initial value of the PollId property.</param>
        /// <param name="text">Initial value of the text property.</param>
        /// <param name="votesCount">Initial value of the VotesCount property.</param>
        public static PossibleAnswer CreatePossibleAnswer(global::System.Int32 id, global::System.Int32 pollId, global::System.String text, global::System.Int32 votesCount)
        {
            PossibleAnswer possibleAnswer = new PossibleAnswer();
            possibleAnswer.id = id;
            possibleAnswer.PollId = pollId;
            possibleAnswer.text = text;
            possibleAnswer.VotesCount = votesCount;
            return possibleAnswer;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PollId
        {
            get
            {
                return _PollId;
            }
            set
            {
                OnPollIdChanging(value);
                ReportPropertyChanging("PollId");
                _PollId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PollId");
                OnPollIdChanged();
            }
        }
        private global::System.Int32 _PollId;
        partial void OnPollIdChanging(global::System.Int32 value);
        partial void OnPollIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String text
        {
            get
            {
                return _text;
            }
            set
            {
                OntextChanging(value);
                ReportPropertyChanging("text");
                _text = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("text");
                OntextChanged();
            }
        }
        private global::System.String _text;
        partial void OntextChanging(global::System.String value);
        partial void OntextChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 VotesCount
        {
            get
            {
                return _VotesCount;
            }
            set
            {
                OnVotesCountChanging(value);
                ReportPropertyChanging("VotesCount");
                _VotesCount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VotesCount");
                OnVotesCountChanged();
            }
        }
        private global::System.Int32 _VotesCount;
        partial void OnVotesCountChanging(global::System.Int32 value);
        partial void OnVotesCountChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("JustPollsModel", "FK_PossibleAnswers_Polls", "Polls")]
        public Poll Poll
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Poll>("JustPollsModel.FK_PossibleAnswers_Polls", "Polls").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Poll>("JustPollsModel.FK_PossibleAnswers_Polls", "Polls").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Poll> PollReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Poll>("JustPollsModel.FK_PossibleAnswers_Polls", "Polls");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Poll>("JustPollsModel.FK_PossibleAnswers_Polls", "Polls", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("JustPollsModel", "FK_Votes_PossibleAnswers", "Votes")]
        public EntityCollection<Vote> Votes
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Vote>("JustPollsModel.FK_Votes_PossibleAnswers", "Votes");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Vote>("JustPollsModel.FK_Votes_PossibleAnswers", "Votes", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="JustPollsModel", Name="Vote")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Vote : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Vote object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="answerId">Initial value of the answerId property.</param>
        /// <param name="date">Initial value of the Date property.</param>
        /// <param name="voterIp">Initial value of the voterIp property.</param>
        public static Vote CreateVote(global::System.Int32 id, global::System.Int32 answerId, global::System.DateTime date, global::System.String voterIp)
        {
            Vote vote = new Vote();
            vote.id = id;
            vote.answerId = answerId;
            vote.Date = date;
            vote.voterIp = voterIp;
            return vote;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 answerId
        {
            get
            {
                return _answerId;
            }
            set
            {
                OnanswerIdChanging(value);
                ReportPropertyChanging("answerId");
                _answerId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("answerId");
                OnanswerIdChanged();
            }
        }
        private global::System.Int32 _answerId;
        partial void OnanswerIdChanging(global::System.Int32 value);
        partial void OnanswerIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                OnDateChanging(value);
                ReportPropertyChanging("Date");
                _Date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Date");
                OnDateChanged();
            }
        }
        private global::System.DateTime _Date;
        partial void OnDateChanging(global::System.DateTime value);
        partial void OnDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String voterIp
        {
            get
            {
                return _voterIp;
            }
            set
            {
                OnvoterIpChanging(value);
                ReportPropertyChanging("voterIp");
                _voterIp = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("voterIp");
                OnvoterIpChanged();
            }
        }
        private global::System.String _voterIp;
        partial void OnvoterIpChanging(global::System.String value);
        partial void OnvoterIpChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("JustPollsModel", "FK_Votes_PossibleAnswers", "PossibleAnswers")]
        public PossibleAnswer PossibleAnswer
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PossibleAnswer>("JustPollsModel.FK_Votes_PossibleAnswers", "PossibleAnswers").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PossibleAnswer>("JustPollsModel.FK_Votes_PossibleAnswers", "PossibleAnswers").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<PossibleAnswer> PossibleAnswerReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PossibleAnswer>("JustPollsModel.FK_Votes_PossibleAnswers", "PossibleAnswers");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<PossibleAnswer>("JustPollsModel.FK_Votes_PossibleAnswers", "PossibleAnswers", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
