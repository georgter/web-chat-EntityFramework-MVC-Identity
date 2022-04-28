using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.BLL.DTO;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;

namespace WebChat.BLL.Services
{
    public class SerchServises
    {
        public List<UserDTO> GetAllDTOUser()
        {
            var userDTOList = new List<UserDTO>();
            var serch = new Serch();
            var users = new List<ClientProfile>();

            users = serch.GetAllUsers();


            foreach (var user in users)
            {
                UserDTO userDTO = new UserDTO() { Id = user.Id, Login = user.Name };
                userDTOList.Add(userDTO);
            }

            return userDTOList;
        }
        /// <summary>
        /// Поиск UserId
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetIdUser(string name)
        {
            var serch = new Serch();
            return serch.GetUserId(name);
        }

        public string GetNameUser(string id)
        {
            var serch = new Serch();
            return serch.GetUserName(id);
        }
    }
}
