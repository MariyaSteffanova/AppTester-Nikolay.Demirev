using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleChatDal
{
    public static class SimpleChatDal
    {
        public static List<ChatRoom> GetAllChatRooms()
        {
            ChatRoomEntities database = new ChatRoomEntities();
            return (from p in database.ChatRooms.Include("Messages") select p).ToList();
        }

        public static List<ChatRoom> GetChatRooms(List<int> openedChatRooms)
        {
            ChatRoomEntities database = new ChatRoomEntities();

            List<ChatRoom> chatRooms = new List<ChatRoom>();

            foreach (var chatRoomId in openedChatRooms)
            {
                var chatRoom = (from p in database.ChatRooms.Include("Messages") where p.ChatRoomID == chatRoomId select p).FirstOrDefault();
                if (chatRoom != null)
                {
                    chatRooms.Add(chatRoom);
                }
            }
            return chatRooms;
        }

        public static void PostMessage(string author, string authorIp, int chatRoomId, string message)
        {
            ChatRoomEntities database = new ChatRoomEntities();

            Message newMessage = new Message();
            newMessage.Author = author;
            newMessage.ChatRoomID = chatRoomId;
            newMessage.MessageDate = DateTime.Now;
            newMessage.MessageText = message;
            newMessage.AuthorIP = authorIp;

            database.Messages.AddObject(newMessage);
            database.SaveChanges();
        }
    }
}
