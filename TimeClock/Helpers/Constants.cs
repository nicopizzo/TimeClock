
namespace TimeClock
{
    public class Constants
    {      
        public const string ID_COL = "EmployeeId";

        #region EmployeeInfo
        public const string EMPLOYEE_FIRSTNAME_COL = "FirstName";
        public const string EMPLOYEE_LASTNAME_COL = "LastName";
        public const string EMPLOYEE_DOB_COL = "DOB";
        public const string EMPLOYEE_PHONE_COL = "PhoneNumber";
        public const string EMPLOYEE_PAY_COL = "Pay";
        public const string EMPLOYEE_ISSALARY_COL = "IsSalary";
        public const string EMPLOYEE_ISACTIVE_COL = "IsActive";
        public const string EMPLOYEE_PASSWORD_COL = "Password";
        public const string EMPLOYEE_HIREDDATE_COL = "HiredDate";
        public const string EMPLOYEE_POSITION_COL = "Position";
        public const string EMPLOYEE_CLOCKHISTORIES_COL = "ClockHistories";
        #endregion

        #region ClockHistory
        public const string CLOCK_IN_COL = "ClockInTime";
        public const string CLOCK_OUT_COL = "ClockOutTime";
        public const string CLOCK_ROWID_COL = "RowId";
        #endregion

        #region AdminInfo
        public const int ADMIN_USER_COL = 1;
        public const int ADMIN_PASS_COL = 2;
        #endregion

        #region SQL Queries
        public const string SQL_MAX_ID = "select max(EmployeeId) from EmployeeInfo";
        public const string SQL_ADDEMPLOYEE_PARTIAL = "insert into EmployeeInfo ([EmployeeId],[FirstName],[LastName],[DOB],[PhoneNumber],[Pay],[IsSalary],[IsActive],[Password],[HiredDate],[Position]) values (@id, @fname, @lname, @dob, @phoneNm, @pay, @isSalary, @isActive, @password, @hiredDt, @pos)";
        public const string SQL_GETALLEMPOYEES = "select * from EmployeeInfo";
        public const string SQL_GETEMPLOYEESEARCH = "select * from EmployeeInfo where FirstName='@fname' and LastName='@lname' and DOB='@dob'";
        public const string SQL_GETEMPLOYEEDIRECTFIND = "select * from EmployeeInfo where EmployeeId=@id";

        public const string SQL_GETCLOCKEDINEMPLOYEES = "select emp.* from EmployeeInfo emp inner join (select distinct EmployeeId from ClockHistory where ClockOutTime is null) out on emp.EmployeeId = out.EmployeeId";
        public const string SQL_GETCLOCKEDOUTEMPLOYEES = "select * from EmployeeInfo emp where not exists (select * from ClockHistory hist where hist.ClockOutTime is null and hist.EmployeeId = emp.EmployeeId)";

        public const string SQL_UPDATEEMPLOYEE = "update EmployeeInfo set FirstName=@fName, LastName=@lname, PhoneNumber=@phone, Pay=@pay, IsSalary=@salary, IsActive=@active, [Password]=@pass, Position=@pos where EmployeeId=@id";

        public const string SQL_INSERTCLOCKROW = "insert into ClockHistory ([EmployeeId], [ClockInTime], [ClockOutTime]) values (@id, @clockin, @clockout)";
        public const string SQL_CLOCKINEMPLOYEE = "insert into ClockHistory ([EmployeeId], [ClockInTime]) values (@id, @clockin)";
        public const string SQL_CLOCKOUTEMPLOYEE = "update ClockHistory set ClockOutTime=@clockout where RowId=@rid";
        public const string SQL_GETALLCLOCKHISTORY = "select * from ClockHistory where EmployeeId=@id";
        public const string SQL_GETCLOCKEDINROW = "select * from ClockHistory where EmployeeId=@id and ClockOutTime is null";
        public const string SQL_GETCLOCKINHISTORYRANGE = "select * from ClockHistory where EmployeeId=@id and ClockInTime>='@lowerDate' and ClockInTime<='@upperDate'";
        public const string SQL_GETHISTORYBYROWID = "select * from ClockHistory where RowId=@id";
        #endregion

    }

    public class CONFIG_KEYS
    {
        public const string COMPANYID = "CompanyId";
    }
}
