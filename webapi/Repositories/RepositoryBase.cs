namespace webapi.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly string _connectionString;

        public RepositoryBase(IConfiguration config)
        {
            _connectionString = config.GetConnectionString(Resources.Strings.DbName);
        }
    }
}
