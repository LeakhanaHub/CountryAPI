using System.Data;
using CountryAPI.Model;

namespace CountryAPI.Repository;

public class BaseRepository
{
    private readonly DapperContext _dbContext;

    public BaseRepository(DapperContext dataBaseContext)
    {
        _dbContext = dataBaseContext;
    }
    public IDbConnection CreateConnection()
    {
        return _dbContext.CreateConnection();
        
    }

}