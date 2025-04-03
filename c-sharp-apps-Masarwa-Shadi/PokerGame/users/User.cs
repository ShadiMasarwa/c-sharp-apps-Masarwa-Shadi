using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Masarwa_Shadi.PokerGame.poker_hands;

namespace c_sharp_apps_Masarwa_Shadi.PokerGame.users
{
    public class User
    {
        private string username;
        private User_Role role;
        private Hand hand = new Hand();

        //private List<User_Role> roles;
        //public List<User_Role> Roles { get => roles; set => roles = value; }

        public string Username { get => username; set => username = value; }
        public User_Role Role { get => role; set => role = value; }
        public Hand Hand { get => hand; set => hand = value; }

        public User(string username, User_Role role)
        {
            this.username = username;
            this.role = role;
        }
    }
}
