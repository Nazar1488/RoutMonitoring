using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Test.Models
{
    public class MonitoringRepository
    {
        private readonly string _connectionString;

        public MonitoringRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Monitoring> GetAll()
        {
            List<Monitoring> monitorings;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                monitorings = db.Query<Monitoring>("SELECT * FROM Monitorings").ToList();
            }

            return monitorings;
        }

        public Monitoring Get(int id)
        {
            Monitoring monitoring;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                monitoring = db.Query<Monitoring>("SELECT * FROM Monitorings WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return monitoring;
        }

        public Monitoring Create(Monitoring monitoring)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Monitorings (Type, UserId, IsSuccessed, IsInProccess, Rout, [From], [To], Date, Time, SeatType) VALUES(@Type, @UserId, @IsSuccessed, @IsInProccess, @Rout, @From, @To, @Date, @Time, @SeatType); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? monitoringId = db.Query<int>(sqlQuery, monitoring).FirstOrDefault();
                monitoring.Id = monitoringId.Value;
            }

            return monitoring;
        }

        public void Update(Monitoring monitoring)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Monitorings SET Type = @Type, UserId = @UserId, IsSuccessed = @IsSuccessed, IsInProccess = @IsInProccess, Rout = @Rout, [From] = @From, [To] = @To, Date = @Date, Time = @Time, SeatType = @SeatType WHERE Id = @Id";
                db.Execute(sqlQuery, monitoring);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Monitorings WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}