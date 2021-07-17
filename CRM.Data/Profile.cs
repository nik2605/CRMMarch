using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Web;

namespace CRM.Data
{
    public class Profile : DataObject
    {
        private int userId
        {
            get;
            set;
        }

        private string fname
        {
            get;
            set;
        }

        private string lname
        {
            get;
            set;
        }

        public int UserId
        {
            get => userId;
            set => userId = value;
        }

        public string FName
        {
            get =>  fname;
            set => fname = value;
        }

        public string LName
        {
            get => lname;
            set => lname = value;
        }

        void Initilize()
        {
            fname = "";
            lname = "";
        }

        public Profile()
        {
            Initilize();
        }

        public Profile(int id)
        {
            Initilize();
            GetUserProfile(id);
        }

        public void GetUserProfile(int id)
        {
            SqlConnection conn = Trans == null ? new SqlConnection(ConnStr) : Trans.Connection;

            SqlCommand cmd = new SqlCommand("GetUserProfile", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserProfileId", SqlDbType.Int).Value = id;

            SqlParameter _fname = cmd.Parameters.Add("@Fname", SqlDbType.NVarChar, 100);
            _fname.Direction = ParameterDirection.Output;
            SqlParameter _lname = cmd.Parameters.Add("@Lname", SqlDbType.NVarChar, 100);
            _lname.Direction = ParameterDirection.Output;

            try
            {
                if (Trans == null || (Trans.Connection.State & ConnectionState.Open) == 0)
                    conn.Open();

                //conn.Open();
                cmd.ExecuteNonQuery();

                this.fname = Convert.IsDBNull(_fname) ? "" : _fname.Value.ToString();
                this.lname = Convert.IsDBNull(_lname) ? "" : _lname.Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public Profile UpdateUserProfile(Profile profile)
        {
            //todo implem
            return profile;
        }

        public List<Profile> List()
        {
            List<Profile> profiles = new List<Profile>();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Select * From Profile Order by UserId");

            SqlConnection conn = new SqlConnection(ConnStr);
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

            try
            {
                conn.Open();

                SqlDataAdapter sa = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                sa.Fill(ds);

                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    Profile profile = new Profile
                    {
                        fname = dataRow["FName"].ToString(),
                        lname = dataRow["LName"].ToString(),
                        userId = Convert.ToInt32(dataRow["UserId"].ToString())
                    };

                    profiles.Add(profile);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return profiles;
        }
    }
}