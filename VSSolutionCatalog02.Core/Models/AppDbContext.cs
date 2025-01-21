//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System.Data.Common;
using Microsoft.EntityFrameworkCore; // DbContext, DbContextOptionsBuilder
using Microsoft.EntityFrameworkCore.Metadata;

//using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;

namespace VSSolutionCatalog02.Core.Models;

public class AppDbContext : DbContext {

    // this manages the connection to the database
    //private readonly string dbProvider = dbProvider;
    //const string dbProvider = "SQL Server";
    //private readonly string dbDir = dbDir;
    //private const string SqlServerConnectString = "Data Source=.;Initial Catalog=Snippets;Integrated Security=true;MultipleActiveResultSets=true;";

    #region Singleton
    private static readonly AppDbContext shared = new();

    public static AppDbContext Shared => shared;
    #endregion singleton

    #region App Entities
    public DbSet<Solution> Solutions {
        get; set;
    }

    #endregion



    public static (bool success, string message) TestConnection() {
        var connectString = ConnectionString();
        NpgsqlConnection conn = new(connectString);
        try {
            conn.Open();
        } catch (Exception ex) {
            return (false, $"Error opening connection: {ex.Message}");
        } finally {
            conn.Close();
        }
        return (true, "Successfully opened and closed connection to LocalHost:5432/VSSolCat using username VSSolCatUser");
    }

    private static string ConnectionString() {
        NpgsqlConnectionStringBuilder bldr = new() {
            Host = "localhost",
            Port = 5432,
            Database = "vssolcat",     //note: case-sensitive
            Username = "vssolcatuser", //note: case-sensitive
            Password = "password",     //note: case-sensitive
            //Options =  "Include Error Detail",
            IncludeErrorDetail = true,
            SearchPath = "vssolcatschema,public"
            //IdentifierCase = IdentifierCase.Insensitive
        };

        return bldr.ConnectionString;
    }

    public AppDbContext() {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(ConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        MigrateTablenamesToPostgres(modelBuilder);
        // .... more code ...
    }

    private void MigrateTablenamesToPostgres(ModelBuilder builder) {
        foreach (var entity in builder.Model.GetEntityTypes()) {
            // Replace table names
            entity.SetTableName(entity.GetTableName().ToLower());

            // Replace column names
            foreach (var property in entity.GetProperties()) {
                var columnName = property.GetColumnName(StoreObjectIdentifier.Table(property.DeclaringEntityType.GetTableName(), null));
                property.SetColumnName(columnName.ToLower());
            }

            foreach (var key in entity.GetKeys()) {
                key.SetName(key.GetName().ToLower());
            }

            foreach (var key in entity.GetForeignKeys()) {
                key.SetConstraintName(key.GetConstraintName().ToLower());
            }

            foreach (var index in entity.GetIndexes()) {
                index.SetDatabaseName(index.GetDatabaseName().ToLower());
            }
        }
    }

    public (bool success, string message) PopulateData0() {
        var connectString = ConnectionString();
        using var conn = new NpgsqlConnection(connectString);
        try {
            conn.Open();
            //count solutions
            var cmd = conn.CreateCommand();
            cmd.CommandText = "select count(*) from vssolcatschema.solutions";
            var rslt = cmd.ExecuteScalar();
            var oldCount = (int)(long)rslt;
            //do some inserts
            var inscmd = conn.CreateCommand();
            var rowsAdded = 0;
            inscmd.CommandText = "insert into vssolcatschema.solutions(Name, Path, Description, Language) values (:nm,:pt,:la,:de)";
            inscmd.Parameters.AddWithValue(":nm", "Soln1");
            inscmd.Parameters.AddWithValue(":pt", @"F:\dev\");
            inscmd.Parameters.AddWithValue(":la", "COBOL");
            inscmd.Parameters.AddWithValue(":de", "Some project or other.");
            rowsAdded += inscmd.ExecuteNonQuery();
            inscmd.Parameters[":nm"].Value = "VSSolutionCategory2";
            inscmd.Parameters[":pt"].Value = @"F:\Dev\WinUI\VSSolutionCategory2\";
            inscmd.Parameters[":la"].Value = "C#";
            inscmd.Parameters[":de"].Value = "This project";
            rowsAdded += inscmd.ExecuteNonQuery();
            inscmd.Parameters[":nm"].Value = "Soln2";
            inscmd.Parameters[":pt"].Value = @"F:\";
            inscmd.Parameters[":la"].Value = "French";
            inscmd.Parameters[":de"].Value = "What it means";
            rowsAdded += inscmd.ExecuteNonQuery();
            //count solutions
            rslt = cmd.ExecuteScalar();
            var newCount = (int)(long)rslt;

            return (true, $"Successfully appended to Solutions table.  Rowcount: {oldCount} => {newCount}.");
        } catch (Exception ex) {
            return (false, $"Error inserting rows into solutions table: {ex.Message}");
        } finally {
            conn.Close();
        }
    }

    public (bool success, string message) PopulateData() {
        var connectString = ConnectionString();
        using var conn = new NpgsqlConnection(connectString);
        try {
            conn.Open();
            //count solutions
            var cmd = conn.CreateCommand();
            cmd.CommandText = "select count(*) from vssolcatschema.solutions";
            var rslt = cmd.ExecuteScalar();
            var oldCount = (int)(long)rslt;
            //do some inserts
            var inscmd = conn.CreateCommand();
            var rowsAdded = 0;
            inscmd.CommandText = "insert into vssolcatschema.solutions(Name, Path, Description, Language) values (:nm,:pt,:la,:de)";
            inscmd.Parameters.AddWithValue(":nm", "");
            inscmd.Parameters.AddWithValue(":pt", "");
            inscmd.Parameters.AddWithValue(":la", "");
            inscmd.Parameters.AddWithValue(":de", "");

            var path = "F:\\DevOld";
            var dir = new DirectoryInfo(path);
            var dirMatches = dir.EnumerateDirectories("*", SearchOption.AllDirectories);
            foreach (var dirMatch in dirMatches) {
                var fileMatches = dirMatch.EnumerateFiles("*.sln");
                foreach (var fileMatch in fileMatches) {
                    inscmd.Parameters[":nm"].Value = fileMatch.Name;
                    inscmd.Parameters[":pt"].Value = fileMatch.FullName;
                    inscmd.Parameters[":la"].Value = "";
                    inscmd.Parameters[":de"].Value = "";
                    rowsAdded += inscmd.ExecuteNonQuery();
                }
            }

            //count solutions
            rslt = cmd.ExecuteScalar();
            var newCount = (int)(long)rslt;

            return (true, $"Successfully appended to Solutions table.  Rowcount: {oldCount} => {newCount}.");
        } catch (Exception ex) {
            return (false, $"Error inserting rows into solutions table: {ex.Message}");
        } finally {
            conn.Close();
        }
    }

    public (bool success, string message) DeleteData() {
        var connectString = ConnectionString();
        using var conn = new NpgsqlConnection(connectString);
        try {
            conn.Open();
            //count solutions
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "select count(*) from vssolcatschema.solutions";
            var rslt = cmd.ExecuteScalar();
            var oldCount = (int)(long)rslt;
            //do some inserts
            using var delcmd = conn.CreateCommand();
            var rowsAffected = 0;
            delcmd.CommandText = "delete from vssolcatschema.solutions";
            rowsAffected += delcmd.ExecuteNonQuery();
            //count solutions
            rslt = cmd.ExecuteScalar();
            var newCount = (int)(long)rslt;
            return (true, $"Successfully deleted rows from Solutions table.  Rowcount: {oldCount} => {newCount}.");
        } catch (Exception ex) {
            return (false, $"Error deleting rows from Solutions table: {ex.Message}");
        } finally {
            conn.Close();
        }
    }

    public string FetchData() {
        var connectString = ConnectionString();
        using var conn = new NpgsqlConnection(connectString);
        try {
            conn.Open();
            //count solutions
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM vssolcatschema.solutions LIMIT 10";
            var rslt = cmd.ExecuteReader();
            var s = "";
            while (rslt.Read()) {
                for (var i = 0; i < rslt.FieldCount; i++) {
                    var val = rslt.GetValue(i);
                    s += val.ToString() + ((i == rslt.FieldCount - 1) ? "" : "|");
                }
                s += "\n";
            }
            return s;
        } catch (Exception ex) {
            return $"Error selecting rows from Solutions table: {ex.Message}";
        } finally {
            conn.Close();
        }
    }
}


/*
 * 
 * Initial model creation from cmd prompt or nuget console: 
 * 
 * https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
 * 
 * (build project)
 * PM>
 * f:
 * cd dev\winui\VSSolutionCatalog02.Core
 * dotnet ef migrations add InitialCreate
 * dotnet ef database drop
 * dotnet ef database update
 *
 */
