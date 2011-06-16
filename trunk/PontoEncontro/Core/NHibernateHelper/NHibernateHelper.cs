using NHibernate.Cfg;
using NHibernate;

namespace Core
{
	public class NHibernateHelper
	{
		private static ISessionFactory sessionFactory;


		private NHibernateHelper()
		{
		}

		public static ISession OpenSession()
		{
			return SessionFactory().OpenSession();
		}
		private static ISessionFactory SessionFactory()
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
