using NHibernate.Cfg;
using NHibernate;

namespace PontoEncontro.Domain
{
	public class SessionFactoryHelper
	{
		private static ISessionFactory sessionFactory;


        private SessionFactoryHelper()
		{
		}

        public static ISessionFactory GetSessionFactory()
		{
			if (sessionFactory != null)
			{
				return sessionFactory;
			}
			var config = new Configuration().Configure();
			sessionFactory = config.BuildSessionFactory();

			return sessionFactory;
		}
	}
}
