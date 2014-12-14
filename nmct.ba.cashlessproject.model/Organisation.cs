using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.cashlessproject.model
{
    public class Organisation
    {
        #region fields
        private int _id;
        private string _login;
        private string _password;
        private string _dbName;
        private string _dbLogin;
        private string _dbPassword;
        private string _organisationName;
        private string _address;
        private string _email;
        private string _phone;
        #endregion fields

        #region properties
        public int Id
        {
            get { return _id; }
            set { if (_id != value) { _id = value; } }
        }
        public string Login
        {
            get { return _login; }
            set { if (_login != value) { _login = value; } }
        }
        public string Password
        {
            get { return _password; }
            set { if (_password != value) { _password = value; } }
        }
        public string DbName
        {
            get { return _dbName; }
            set { if (_dbName != value) { _dbName = value; } }
        }
        public string DbLogin
        {
            get { return _dbLogin; }
            set { if (_dbLogin != value) { _dbLogin = value; } }
        }
        public string DbPassword
        {
            get { return _dbPassword; }
            set { if (_dbPassword != value) { _dbPassword = value; } }
        }
        public string OrganisationName
        {
            get { return _organisationName; }
            set { if (_organisationName != value) { _organisationName = value; } }
        }
        public string Address
        {
            get { return _address; }
            set { if (_address != value) { _address = value; } }
        }
        public string Email
        {
            get { return _email; }
            set { if (_email != value) { _email = value; } }
        }
        public string Phone
        {
            get { return _phone; }
            set { if (_phone != value) { _phone = value; } }
        }
        #endregion properties

        #region constructor
        public Organisation()
        {
        }
        #endregion constructor

    }
}
