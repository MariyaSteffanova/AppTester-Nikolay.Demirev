using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMessageBoard.DAL
{
    public static class SimpleMessageBoard
    {
        public static int Vote(int messageId, string ip, bool IsUpVote)
        {
            SimpleMessageBoardEntities database = new SimpleMessageBoardEntities();

            Vote newVote = new Vote();
            newVote.IsUpVote = IsUpVote;
            newVote.MessageId = messageId;
            newVote.VoterIp = ip;

            database.Votes.AddObject(newVote);

            Message message = (from p in database.Messages where p.MessageId == messageId select p).FirstOrDefault();

            if (IsUpVote)
            {
                message.Rating++;
            }
            else
            {
                message.Rating--;
            }

            database.SaveChanges();

            return message.Rating;
        }

        public static int GetMessageRating(int messageId)
        {
            SimpleMessageBoardEntities database = new SimpleMessageBoardEntities();

            Message message = (from p in database.Messages where p.MessageId == messageId select p).FirstOrDefault();

            return message.Rating;
        }

        public static List<Message> GetMessages(int page, int messagesPerPage)
        {
            SimpleMessageBoardEntities database = new SimpleMessageBoardEntities();

            var messages = (from p in database.Messages orderby p.Date select p).Skip((page - 1) * messagesPerPage).Take(messagesPerPage).ToList();

            return messages;
        }

        public static void PostMessage(string author, string message)
        {
            Message newMessage = new Message();

            newMessage.Author = author;
            newMessage.MessageContent = message;
            newMessage.Date = DateTime.Now.Date.ToShortDateString();

            SimpleMessageBoardEntities database = new SimpleMessageBoardEntities();
            database.Messages.AddObject(newMessage);
            database.SaveChanges();
        }

        public static int GetMessagesCount()
        {
            SimpleMessageBoardEntities database = new SimpleMessageBoardEntities();

            return (from p in database.Messages select p).Count();
        }
    }
}
