using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace TimeClock
{
    public class DataAccess
    {

        private OleDbConnection _context;

        public DataAccess(string accesslocation)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + accesslocation + ";Persist Security Info=False;";
            _context = new OleDbConnection(connectionString);
        }      

        public int GetNextAvalibleId()
        {
            int maxId = -1;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_MAX_ID, _context);
                DataSet ds = ExecuteCommand(command);
                maxId =  (int)ds.Tables[0].Rows[0][0] + 1;
                _context.Close();              
            }
            catch(Exception ex)
            {
                throw new Exception("GetNextAvalibleId: " + ex.ToString());
            }
            return maxId;
        }

        public bool AddEmployee(int id, string fname, string lname, DateTime dob, string phoneNumber, Double pay, bool issalary, bool isactive, string password, DateTime hiredDate, string position)
        {
            bool result = false;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_ADDEMPLOYEE_PARTIAL, _context);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@fname", fname);
                command.Parameters.AddWithValue("@lname", lname);
                command.Parameters.AddWithValue("@dob", dob.ToShortDateString());
                command.Parameters.AddWithValue("@phoneNm", phoneNumber);
                command.Parameters.AddWithValue("@pay", pay);
                command.Parameters.AddWithValue("@isSalary", issalary);
                command.Parameters.AddWithValue("@isActive", isactive);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@hiredDt", hiredDate.ToShortDateString());
                command.Parameters.AddWithValue("@pos", position);

                DataSet ds = ExecuteCommand(command);
                _context.Close();
                result = !ds.HasErrors;
            }
            catch (Exception ex)
            {
                throw new Exception("AddEmployee: " + ex.ToString());
            }
            return result;
        }

        public DataSet GetAllEmployees()
        {
            DataSet ds = null;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_GETALLEMPOYEES, _context);
                ds = ExecuteCommand(command);
                _context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllEmployees: " + ex.ToString());
            }
            return ds;
        }

        public bool UpdateEmployee(Employee employee)
        {
            bool result = false;
            DataSet ds = null;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_UPDATEEMPLOYEE, _context);
                command.Parameters.AddWithValue("@fname", employee.FirstName);
                command.Parameters.AddWithValue("@lname", employee.LastName);
                command.Parameters.AddWithValue("@phone", employee.PhoneNumber);
                command.Parameters.AddWithValue("@pay", employee.Pay);
                command.Parameters.AddWithValue("@salary", employee.IsSalary);
                command.Parameters.AddWithValue("@active", employee.IsActive);
                command.Parameters.AddWithValue("@pass", employee.Password);
                command.Parameters.AddWithValue("@pos", employee.Position);
                command.Parameters.AddWithValue("@id", employee.ID);
                ds = ExecuteCommand(command);
                _context.Close();
                result = !ds.HasErrors;
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateEmployeePosition: " + ex.ToString());
            }
            return result;
        }

        public DataSet SearchEmployee(string fName, string lName, DateTime DOB)
        {
            DataSet ds = null; 
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_GETEMPLOYEESEARCH, _context);
                command.Parameters.AddWithValue("@fname", fName);
                command.Parameters.AddWithValue("@lname", lName);
                command.Parameters.AddWithValue("@dob", DOB.ToShortDateString());
                ds = ExecuteCommand(command);
                _context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("SearchEmployee: " + ex.ToString());
            }
            return ds;
        }

        public DataSet SearchEmployee(int id)
        {
            DataSet ds = null;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_GETEMPLOYEEDIRECTFIND, _context);
                command.Parameters.AddWithValue("@id", id);
                ds = ExecuteCommand(command);
                _context.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("SearchEmployee: " + ex.ToString());
            }
            return ds;         
        }

        public DataSet GetClockedInEmployees()
        {
            DataSet ds = null;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_GETCLOCKEDINEMPLOYEES, _context);
                ds = ExecuteCommand(command);
                _context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("GetClockedInEmployees: " + ex.ToString());
            }

            return ds;
        }

        public DataSet GetClockedOutEmployees()
        {
            DataSet ds = null;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_GETCLOCKEDOUTEMPLOYEES, _context);
                ds = ExecuteCommand(command);
                _context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("GetClockedOutEmployees: " + ex.ToString());
            }
            return ds;
        }

        public bool ClockOutEmployee(Guid id, DateTime setClockOutTime)
        {
            bool result = false;
            DataSet ds = null;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_CLOCKOUTEMPLOYEE, _context);
                command.Parameters.AddWithValue("@clockout", GetSqlSafeDateTime(setClockOutTime));
                command.Parameters.AddWithValue("@rid", id);              
                ds = ExecuteCommand(command);
                _context.Close();
                result = !ds.HasErrors;
            }
            catch(Exception ex)
            {
                throw new Exception("ClockOutEmployee: " + ex.ToString());
            }
            return result;
        }

        public bool ClockInEmployee(ClockHistory history)
        {
            bool result = false;
            DataSet ds = null;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_CLOCKINEMPLOYEE, _context);
                command.Parameters.AddWithValue("@id", history.EmployeeId);
                command.Parameters.AddWithValue("@clockin", GetSqlSafeDateTime(history.ClockInTime));
                ds = ExecuteCommand(command);
                _context.Close();
                result = !ds.HasErrors;
            }
            catch(Exception ex)
            {
                throw new Exception("ClockInEmployee: " + ex.ToString());
            }
            return result;
        }

        public DataSet GetAllClockHistory(int id)
        {
            DataSet ds = null;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_GETALLCLOCKHISTORY, _context);
                command.Parameters.AddWithValue("@id", id);
                ds = ExecuteCommand(command);
                _context.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("GetAllClockHistory: " + ex.ToString());
            }
            return ds;
        }

        public DataSet GetClockInRange(int id, DateTime lowerDate, DateTime upperDate)
        {
            DataSet ds = null;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_GETCLOCKINHISTORYRANGE, _context);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@lowerDate", GetSqlSafeDateTime(lowerDate));
                command.Parameters.AddWithValue("@upperDate", GetSqlSafeDateTime(upperDate));
                ds = ExecuteCommand(command);
                _context.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("GetClockInRange: " + ex.ToString());
            }
            return ds;
        }

        public DataSet GetClockedInRow(int id)
        {
            DataSet ds = null;
            try
            {
                _context.Open();
                OleDbCommand command = new OleDbCommand(Constants.SQL_GETCLOCKEDINROW, _context);
                command.Parameters.AddWithValue("@id", id);
                ds = ExecuteCommand(command);
                _context.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("GetClockedInRow: " + ex.ToString());
            }
            return ds;
        }

        private DataSet ExecuteCommand(OleDbCommand command)
        {
            DataSet ds = new DataSet();
            try
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteCommand: " + ex.ToString());
            }
            return ds;
        }

        private string GetSqlSafeDateTime(DateTime d)
        {
            DateTime dt = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
            return dt.ToString("MM/dd/yyyy hh:mm:ss tt");
        }
        

    }
}
